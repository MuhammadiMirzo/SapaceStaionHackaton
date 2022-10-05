using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class GroupService : IGroupService
{
    private readonly DataContext _context;

    public GroupService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<Response<List<GetGroupAndParticipant>>> GetGroupAndParticipantLinqu()
    {
        var groups = await (from gr in _context.Groups
                            select new GetGroupAndParticipant
                            {
                                GroupNick = gr.GroupNick,
                                TeamSlogan = gr.TeamSlogan,
                                NeededMember = gr.NeededMember,
                                CreatedAt = gr.CreatedAt,
                                ChallengeId = gr.ChallangeId,
                                Id = gr.Id,
                                Participants = (
                                    from pr in _context.Participants
                                    where pr.GroupId == gr.Id
                                    select new GEtParticipantDto()
                                    {
                                        CreatedAt = pr.CreatedAt,
                                        Email = pr.Email,
                                        FullName = pr.FullName,
                                        GroupId = pr.GroupId,
                                        Id = pr.Id,
                                        LocationId = pr.LocationId,
                                        Phone = pr.Phone
                                    }).ToList(),
                                
                            }).ToListAsync();
        
        return new Response<List<GetGroupAndParticipant>>(groups);
                            
                            
    }
    public async Task<Response<List<GetGroupLinq>>> GetGroupLinqu()
    {
        var groups = await (from gr in _context.Groups
                            join ch in _context.Challenges
                            on gr.ChallangeId equals ch.Id
                            orderby gr.CreatedAt descending
                            select new GetGroupLinq
                            {
                                GroupNick = gr.GroupNick,
                                 CreatedAt = gr.CreatedAt,
                                 Id = gr.Id,
                                 NeededMember = gr.NeededMember,
                                 TeamSlogan = gr.TeamSlogan,
                                ChallengeTitle = ch.Title
                            }).ToListAsync();
        
        return new Response<List<GetGroupLinq>>(groups);
                            
                            
    }
    
    public async Task<Response<List<GEtGroupDto>>> GetGroups()
    {
        var Groups = await _context.Groups.Select(l => new GEtGroupDto()
        {
            Id = l.Id,
             GroupNick = l.GroupNick,
            TeamSlogan = l.TeamSlogan,
            NeededMember = l.NeededMember,
            CreatedAt = l.CreatedAt
        }).ToListAsync();
        return new Response<List<GEtGroupDto>>(Groups);
    }


    public async Task<Response<AddGroupDto>> AddGroup(AddGroupDto model)
    {
        try
        {
            var Group = new Group()
            {
                Id = model.Id,
                GroupNick = model.GroupNick,
                ChallangeId = model.ChallangeId,
                TeamSlogan = model.TeamSlogan,
                NeededMember = model.NeededMember,
                CreatedAt = model.CreatedAt
            };
            await _context.Groups.AddAsync(Group);
            await _context.SaveChangesAsync();
            model.Id = Group.Id;
            return new Response<AddGroupDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddGroupDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<Group>> GetGroupById(int id)
    {
        var find = await _context.Groups.FindAsync(id);
        return new Response<Group>(find);
    }


    public async Task<Response<AddGroupDto>> UpdateGroup(AddGroupDto Group)
    {
        try
        {
            var find = await _context.Groups.FindAsync(Group.Id);
            if (find == null) return new Response<AddGroupDto>(System.Net.HttpStatusCode.NotFound, "");


            find.GroupNick = Group.GroupNick;
            find.ChallangeId = Group.ChallangeId;
            find.CreatedAt = Group.CreatedAt;
            find.NeededMember = Group.NeededMember;
            find.TeamSlogan = Group.TeamSlogan;
            await _context.SaveChangesAsync();
            return new Response<AddGroupDto>(Group);
        }
        catch (System.Exception ex)
        {
            return new Response<AddGroupDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }


    public async Task<Response<string>> DeleteGroup(int id)
    {
        try
        {
            var find = await _context.Groups.FindAsync(id);
            if (find == null) return new Response<string>(System.Net.HttpStatusCode.NotFound, "");

            _context.Groups.Remove(find);
            await _context.SaveChangesAsync();
            return new Response<string>("removed successfully");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    
}