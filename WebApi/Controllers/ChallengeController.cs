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

    [HttpGet]
    public async Task<Response<List<GEtChallengeDto>>> Get()
    {
        var Challenges = await _challengeService.GetChallenges();
        return Challenges;
    }
    
    [HttpGet("{id}")]
    public async Task<Response<Challenge>> Get(int id)
    {
        var Challenge = await _challengeService.GetChallengeById(id);
        return Challenge;
    }
    
    [HttpPost]
    public async Task<Response<AddChallengeDto>> Post(AddChallengeDto Challenge)
    {
        var newChallenge = await _challengeService.AddChallenge(Challenge);
        return newChallenge;
    }
    
    [HttpPut]
    public async Task<Response<AddChallengeDto>> Put(AddChallengeDto Challenge)
    {
        var updatedChallenge = await _challengeService.UpdateChallenge(Challenge);
        return updatedChallenge;
    }
    
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        var Challenge = await _challengeService.DeleteChallenge(id);
        return Challenge;
    }

}