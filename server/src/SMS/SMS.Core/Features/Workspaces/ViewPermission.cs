namespace SMS.Core.Features.Workspaces;

public class ViewPermission
{
    public ViewAction AllowRead { get; set; }
    public ViewAction AllowUpdate { get; set; }
    public ViewAction AllowDelete { get; set; }
    public ViewAction AllowCreate { get; set; }
}