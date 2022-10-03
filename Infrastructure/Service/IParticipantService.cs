using Domain.Wrapper;

public interface IParticipantService
{
    Task<Response<AddParticipantDto>> AddParticipant(AddParticipantDto model);
    Task<Response<string>> DeleteParticipant(int id);
    Task<Response<Participant>> GetParticipantById(int id);
    Task<Response<List<GEtParticipantDto>>> GetParticipants();
    Task<Response<AddParticipantDto>> UpdateParticipant(AddParticipantDto Participant);
}
