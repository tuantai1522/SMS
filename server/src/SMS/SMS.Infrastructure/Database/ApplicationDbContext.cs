using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql;
using SMS.Core.Common;
using SMS.Core.Features.Channels;
using SMS.Core.Features.Countries;
using SMS.Core.Features.Posts;
using SMS.Core.Features.Projects;
using SMS.Core.Features.RefreshTokens;
using SMS.Core.Features.Teams;
using SMS.Core.Features.Users;
using SMS.Core.Features.Workspaces;
using SMS.UseCases.Abstractions.Data;
using SMS.Core.Features.Tasks;
using SMS.UseCases.Exceptions;
using TaskDomain = SMS.Core.Features.Tasks.Task;
using TaskStatus = SMS.Core.Features.Tasks.TaskStatus;

using Task = System.Threading.Tasks.Task;

namespace SMS.Infrastructure.Database;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator) : DbContext(options), IUnitOfWork, IApplicationDbContext
{
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<Channel> Channels => Set<Channel>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    
    
    public DbSet<Workspace> Workspaces => Set<Workspace>();
    public DbSet<WorkspaceMember> WorkspaceMembers => Set<WorkspaceMember>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<TaskDomain> Tasks => Set<TaskDomain>();
    public DbSet<TaskStatus> TaskStatuses => Set<TaskStatus>();
    public DbSet<TaskPriority> TaskPriorities => Set<TaskPriority>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permission> Permissions => Set<Permission>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Default);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            int result = await base.SaveChangesAsync(cancellationToken);

            await PublishDomainEvents(cancellationToken);

            return result;
        }
        // Throw exception in case there is violation conflict in database
        catch (DbUpdateException e) when (e.InnerException is PostgresException { SqlState: PostgresErrorCodes.UniqueViolation })
        {
            throw new DuplicateKeyException("Duplicate key error", e);
        }
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default) 
        => await Database.CommitTransactionAsync(cancellationToken);

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        await Database.RollbackTransactionAsync(cancellationToken);
    }

    /// <summary>
    /// Publishes and then clears all the domain events that exist within the current transaction.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    private async Task PublishDomainEvents(CancellationToken cancellationToken)
    {
        List<EntityEntry<AggregateRoot>> aggregateRoots = ChangeTracker
            .Entries<AggregateRoot>()
            .Where(entityEntry => entityEntry.Entity.DomainEvents.Any())
            .ToList();

        List<IDomainEvent> domainEvents = aggregateRoots.SelectMany(entityEntry => entityEntry.Entity.DomainEvents).ToList();

        aggregateRoots.ForEach(entityEntry => entityEntry.Entity.ClearDomainEvents());

        IEnumerable<Task> tasks = domainEvents.Select(domainEvent => mediator.Publish(domainEvent, cancellationToken));

        await Task.WhenAll(tasks);
    }
}