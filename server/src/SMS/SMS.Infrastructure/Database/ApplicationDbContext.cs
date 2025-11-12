using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        // Dispatch Domain Events collection. 
        // Choices:
        // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
        // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
        // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
        // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 

        // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
        // performed through the DbContext will be committed
        int result = await base.SaveChangesAsync(cancellationToken);

        await PublishDomainEvents(cancellationToken);
        
        return result;
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