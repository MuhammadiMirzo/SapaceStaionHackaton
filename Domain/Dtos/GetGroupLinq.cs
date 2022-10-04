namespace Domain.Dtos;

public class GetGroupLinq
{
     public int Id { get; set; } 
    public string GroupNick { get; set; }
    public bool NeededMember { get; set; }
    public string TeamSlogan { get; set; }

    public string ChallengeTitle { get; set; }
    public DateTimeOffset CreatedAt { get; set; }   
}
