using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class ChallengeService : IChallengeService
{
    private readonly DataContext _context;

    public ChallengeService(DataContext context)
    {
        _context = context;
    }

    
    public async Task<Response<List<GetChallengeAndGroupDto>>> GetChallengeAndGroupLinqu()
    {
        var groups = await (from ch in _context.Challenges
                            select new GetChallengeAndGroupDto
                            {
                                Description = ch.Description,
                                Id = ch.Id,
                                Title = ch.Title,
                                Groups = (
                                    from g in _context.Groups
                                    where g.ChallangeId == ch.Id
                                    select new GEtGroupDto()
                                    {
                                        ChallengeId = g.ChallangeId,
                                        GroupNick = g.GroupNick,
                                        NeededMember = g.NeededMember,
                                        TeamSlogan = g.TeamSlogan,
                                        Id = g.Id
                                    }).ToList(),
                                
                            }).ToListAsync();
        
        return new Response<List<GetChallengeAndGroupDto>>(groups);
                            
                            
    }
    public async Task<Response<List<GEtChallengeDto>>> GetChallenges()
    {
        var Challenges = await _context.Challenges.Select(l => new GEtChallengeDto()
        {
            Description = l.Description,
            Id = l.Id,
            Title = l.Title
        }).ToListAsync();
        return new Response<List<GEtChallengeDto>>(Challenges);
    }


    public async Task<Response<AddChallengeDto>> AddChallenge(AddChallengeDto model)
    {
        try
        {
            var Challenge = new Challenge()
            {
                Description = model.Description,
                Title = model.Title
            };
            await _context.Challenges.AddAsync(Challenge);
            await _context.SaveChangesAsync();
            model.Id = Challenge.Id;
            return new Response<AddChallengeDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddChallengeDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<Challenge>> GetChallengeById(int id)
    {
        var find = await _context.Challenges.FindAsync(id);
        return new Response<Challenge>(find);
    }


    public async Task<Response<AddChallengeDto>> UpdateChallenge(AddChallengeDto Challenge)
    {
        try
        {
            var find = await _context.Challenges.FindAsync(Challenge.Id);
            if (find == null) return new Response<AddChallengeDto>(System.Net.HttpStatusCode.NotFound, "");


            find.Description = Challenge.Description;
            find.Title = Challenge.Title;
            await _context.SaveChangesAsync();
            return new Response<AddChallengeDto>(Challenge);
        }
        catch (System.Exception ex)
        {
            return new Response<AddChallengeDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }


    public async Task<Response<string>> DeleteChallenge(int id)
    {
        try
        {
            var find = await _context.Challenges.FindAsync(id);
            if (find == null) return new Response<string>(System.Net.HttpStatusCode.NotFound, "");

            _context.Challenges.Remove(find);
            await _context.SaveChangesAsync();
            return new Response<string>("removed successfully");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}

