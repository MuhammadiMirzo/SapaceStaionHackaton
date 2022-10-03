using Domain.Wrapper;

public interface IGroupService
{
    Task<Response<AddGroupDto>> AddGroup(AddGroupDto model);
    Task<Response<string>> DeleteGroup(int id);
    bool Equals(object? obj);
    Task<Response<Group>> GetGroupById(int id);
    Task<Response<List<GEtGroupDto>>> GetGroups();
    int GetHashCode();
    Task<Response<AddGroupDto>> UpdateGroup(AddGroupDto Group);
}
