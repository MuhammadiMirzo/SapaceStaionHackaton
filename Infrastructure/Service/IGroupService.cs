using Domain.Dtos;
using Domain.Wrapper;

public interface IGroupService
{
    
     Task<Response<List<GetGroupAndParticipant>>> GetGroupAndParticipantLinqu();
    Task<Response<AddGroupDto>> AddGroup(AddGroupDto model);
    Task<Response<string>> DeleteGroup(int id);
    bool Equals(object? obj);
    Task<Response<Group>> GetGroupById(int id);
    Task<Response<List<GetGroupLinq>>> GetGroupLinqu();
    Task<Response<List<GEtGroupDto>>> GetGroups();
    int GetHashCode();
    Task<Response<AddGroupDto>> UpdateGroup(AddGroupDto Group);
}
