using System.ComponentModel.DataAnnotations;

public class GEtParticipantDto
{
     public int Id { get; set; }

    public string? FullName { get; set; }
  
    public string? Email { get; set; }

    public string? Phone { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int GroupId { get; set; }
    public int LocationId { get; set; } 
}