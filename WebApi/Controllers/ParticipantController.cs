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

     [HttpGet("GetParticipantsLinqu")]
    public async Task<Response<List<GetParticipantsLinq>>> GetParticipantsLinq()
    {
        var Participants = await _participantService.GetParticipantLinqu();
        return Participants;
    }
    [HttpGet(("GetParticipants"))]
    public async Task<Response<List<GEtParticipantDto>>> GetParticipants()
    {
        var Participants = await _participantService.GetParticipants();
        return Participants;
    }
    
    [HttpGet("GetParticipantsById")]
    public async Task<Response<Participant>> GetParticipantsById(int id)
    {
        var Participant = await _participantService.GetParticipantById(id);
        return Participant;
    }
    
    [HttpPost(".AddParticipant")]
    public async Task<Response<AddParticipantDto>> AddParticipant(AddParticipantDto Participant)
    {
        var newParticipant = await _participantService.AddParticipant(Participant);
        return newParticipant;
    }
    
    [HttpPut("UpdateParticipant")]
    public async Task<Response<AddParticipantDto>> UpdateParticipant(AddParticipantDto Participant)
    {
        var updatedParticipant = await _participantService.UpdateParticipant(Participant);
        return updatedParticipant;
    }
    
    [HttpDelete("DeleteParticipant")]
    public async Task<Response<string>> DeleteParticipant(int id)
    {
        var Participant = await _participantService.DeleteParticipant(id);
        return Participant;
    }

}