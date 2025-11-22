using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Tasks;
using SMS.Core.Features.Tasks;
using SMS.UseCases.Abstractions.Authentication;
using SMS.UseCases.Abstractions.Data;
using SMS.UseCases.Exceptions;
using SMS.UseCases.Queries.Projects;
using Task = SMS.Core.Features.Tasks.Task;
using TaskStatus = SMS.Core.Features.Tasks.TaskStatus;

namespace SMS.UseCases.Features.Tasks.CreateTask;

internal sealed class CreateTaskCommandHandler(
    IUserProvider userProvider,
    IUnitOfWork unitOfWork,
    IGetProjectByIdAndLockService getProjectByIdAndLockService,
    IRepository<TaskStatus> taskStatusRepository,
    IRepository<TaskPriority> taskPriorityRepository,
    IRepository<Task> taskRepository): IRequestHandler<CreateTaskCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateTaskCommand command, CancellationToken cancellationToken)
    {
        var verifyExistedStatus = await taskStatusRepository.VerifyExistedEntityByIdAsync(command.StatusId, cancellationToken);

        if (!verifyExistedStatus)
        {
            return Result.Failure<Guid>(TaskErrors.CanNotFindStatusById);
        }
        
        var verifyExistedPriority = await taskPriorityRepository.VerifyExistedEntityByIdAsync(command.PriorityId, cancellationToken);

        if (!verifyExistedPriority)
        {
            return Result.Failure<Guid>(TaskErrors.CanNotFindPriorityById);
        }
        
        const int maxRetries = 3;
        for (int attempt = 1; attempt <= maxRetries; attempt++)
        {
            await unitOfWork.BeginTransactionAsync(cancellationToken);

            var project = await getProjectByIdAndLockService.Handle(command.ProjectId, cancellationToken);

            if (project == null)
            {
                return Result.Failure<Guid>(TaskErrors.CanNotFindProject);
            }

            var userId = userProvider.UserId;

            // Update total task of project
            project.UpdateTotalTasks();

            var task = Task.CreateTask(command.Name, project.TotalTasks.ToString(), command.Description, command.ProjectId, command.StatusId,
                command.PriorityId, command.AssignedTo, userId, command.StartDate, command.DueDate);

            await taskRepository.AddAsync(task, cancellationToken);

            // Try to save
            try
            {
                await unitOfWork.SaveChangesAsync(cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);

                return Result.Success(task.Id);
            }
            catch (DuplicateKeyException)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                
                if (attempt == maxRetries)
                {
                    // Return error if function goes beyond a number of time retrying
                    return Result.Failure<Guid>(TaskErrors.CanNotCreateTask);
                }
            }

        }
        
        return Result.Failure<Guid>(TaskErrors.CanNotCreateTask);
    }
}
