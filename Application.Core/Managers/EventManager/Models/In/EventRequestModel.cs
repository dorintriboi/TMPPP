namespace Application.Core.Managers.EventManager.Models.In;

public class EventRequestModel
{
    public DateTime Date { get; set; }
    public string SpectacleId { get; set; }
    public string InstitutionId { get; set; }
    public string Location { get; set; }
}