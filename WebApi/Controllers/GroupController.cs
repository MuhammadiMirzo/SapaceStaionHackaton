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

    [HttpGet]
    public async Task<Response<List<GEtGroupDto>>> Get()
    {
        var Groups = await _groupService.GetGroups();
        return Groups;
    }
    
    [HttpGet("{id}")]
    public async Task<Response<Group>> Get(int id)
    {
        var Group = await _groupService.GetGroupById(id);
        return Group;
    }
    
    [HttpPost]
    public async Task<Response<AddGroupDto>> Post(AddGroupDto Group)
    {
        var newGroup = await _groupService.AddGroup(Group);
        return newGroup;
    }
    
    [HttpPut]
    public async Task<Response<AddGroupDto>> Put(AddGroupDto Group)
    {
        var updatedGroup = await _groupService.UpdateGroup(Group);
        return updatedGroup;
    }
    
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        var Group = await _groupService.DeleteGroup(id);
        return Group;
    }

}