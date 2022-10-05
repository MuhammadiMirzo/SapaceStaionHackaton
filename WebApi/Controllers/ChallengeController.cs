using Domain.Dtos;
using Domain.Wrapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ChallengeController : ControllerBase
{
    private readonly IChallengeService _challengeService;

    public ChallengeController(IChallengeService ChallengeService)
    {
        _challengeService = ChallengeService;
    }

    [HttpGet("GetChallengeAndGroupDto")]
    public async Task<Response<List<GetChallengeAndGroupDto>>> GetChallengeAndGroupDto()
    {
        var challenges = await _challengeService.GetChallengeAndGroupLinqu();
        return challenges;
    }
    [HttpGet("GetChallenge")]
    public async Task<Response<List<GEtChallengeDto>>> Get()
    {
        var Challenges = await _challengeService.GetChallenges();
        return Challenges;
    }
    
    [HttpGet("GetByChallenge")]
    public async Task<Response<Challenge>> GetChallengeById(int id)
    {
        var Challenge = await _challengeService.GetChallengeById(id);
        return Challenge;
    }
    
    [HttpPost("AddChallen")]
    public async Task<Response<AddChallengeDto>> AddChallenge(AddChallengeDto Challenge)
    {
        var newChallenge = await _challengeService.AddChallenge(Challenge);
        return newChallenge;
    }
    
    [HttpPut("UpdateChallenge")]
    public async Task<Response<AddChallengeDto>> UpdateChallengePut(AddChallengeDto Challenge)
    {
        var updatedChallenge = await _challengeService.UpdateChallenge(Challenge);
        return updatedChallenge;
    }
    
    [HttpDelete("DeleteChallenge")]
    public async Task<Response<string>> DeleteChallenge(int id)
    {
        var Challenge = await _challengeService.DeleteChallenge(id);
        return Challenge;
    }

}