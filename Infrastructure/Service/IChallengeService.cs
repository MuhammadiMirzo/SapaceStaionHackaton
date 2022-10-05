using Domain.Wrapper;
using Domain.Dtos;
public interface IChallengeService
{
    Task<Response<AddChallengeDto>> AddChallenge(AddChallengeDto model);
    Task<Response<string>> DeleteChallenge(int id);
    Task<Response<Challenge>> GetChallengeById(int id);
    Task<Response<List<GEtChallengeDto>>> GetChallenges();
    Task<Response<AddChallengeDto>> UpdateChallenge(AddChallengeDto Challenge);
    Task<Response<List<GetChallengeAndGroupDto>>> GetChallengeAndGroupLinqu();
}

