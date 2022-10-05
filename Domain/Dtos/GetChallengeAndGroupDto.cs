namespace Domain.Dtos;

public class GetChallengeAndGroupDto
{
    public int Id { get; set; }
    public string Title { get; set; } 
    public string Description  { get; set; }
    public List<GEtGroupDto> Groups { get; set; }
}
