namespace SMS.Core.Features.Workspaces;

public enum PermissionConstant
{
    Dashboard, // IsMenu = true
    
    Tasks, // IsMenu = true
    CreateTask,
    EditTask,
    DeleteTask,
    
    Members, // IsMenu = true
    AddMember,
    ChangeMemberRole,
    RemoveMember,
    
    Settings, // IsMenu = true
    DeleteWorkspace,
    EditWorkspace,
    
    CreateProject,
    EditProject,
    DeleteProject,
}