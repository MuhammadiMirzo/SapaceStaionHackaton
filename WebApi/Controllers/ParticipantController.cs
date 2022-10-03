using Domain.Dtos;
using Domain.Wrapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ParticipantController : ControllerBase
{
    private readonly IParticipantService _participantService;

    public ParticipantController(IParticipantService participantService)
    {
        _participantService = participantService;
    }

    [HttpGet]
    public async Task<Response<List<GEtParticipantDto>>> Get()
    {
        var Participants = await _participantService.GetParticipants();
        return Participants;
    }
    
    [HttpGet("{id}")]
    public async Task<Response<Participant>> Get(int id)
    {
        var Participant = await _participantService.GetParticipantById(id);
        return Participant;
    }
    
    [HttpPost]
    public async Task<Response<AddParticipantDto>> Post(AddParticipantDto Participant)
    {
        var newParticipant = await _participantService.AddParticipant(Participant);
        return newParticipant;
    }
    
    [HttpPut]
    public async Task<Response<AddParticipantDto>> Put(AddParticipantDto Participant)
    {
        var updatedParticipant = await _participantService.UpdateParticipant(Participant);
        return updatedParticipant;
    }
    
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        var Participant = await _participantService.DeleteParticipant(id);
        return Participant;
    }

}