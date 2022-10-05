using Domain.Dtos;
using Domain.Wrapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;

    public GroupController(IGroupService GroupService)
    {
        _groupService = GroupService;
    }
    [HttpGet("GetGroupAndParticipant")]
    public async Task<Response<List<GetGroupAndParticipant>>> GetGroupAndParticipantLinqu()
    {
        var Groups = await _groupService.GetGroupAndParticipantLinqu();
        return Groups;
    }
    [HttpGet("GetGroupLinqu")]
    public async Task<Response<List<GetGroupLinq>>> GetGroupLinqu()
    {
        var Groups = await _groupService.GetGroupLinqu();
        return Groups;
    }

    [HttpGet("GetGroup")]
    public async Task<Response<List<GEtGroupDto>>> GetGroup()
    {
        var Groups = await _groupService.GetGroups();
        return Groups;
    }
    
    [HttpGet("GetGroupById")]
    public async Task<Response<Group>> GetGroupById(int id)
    {
        var Group = await _groupService.GetGroupById(id);
        return Group;
    }
    
    [HttpPost("AddGroup")]
    public async Task<Response<AddGroupDto>> AddGroup(AddGroupDto Group)
    {
        var newGroup = await _groupService.AddGroup(Group);
        return newGroup;
    }
    
    [HttpPut("UpdateGroup")]
    public async Task<Response<AddGroupDto>> UpdateGroup(AddGroupDto Group)
    {
        var updatedGroup = await _groupService.UpdateGroup(Group);
        return updatedGroup;
    }
    
    [HttpDelete("DeleteGroup")]
    public async Task<Response<string>> DeleteGroup(int id)
    {
        var Group = await _groupService.DeleteGroup(id);
        return Group;
    }

}