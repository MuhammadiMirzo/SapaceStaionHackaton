namespace Domain.Dtos;

public class GetGroupAndParticipant
{
     public int Id { get; set; } 
    public string GroupNick { get; set; }
    public bool NeededMember { get; set; }
    public string TeamSlogan { get; set; }
    public DateTimeOffset CreatedAt { get; set; } 
    public int ChallengeId { get; set; }  
    public List<GEtParticipantDto> Participants { get; set; }
}
