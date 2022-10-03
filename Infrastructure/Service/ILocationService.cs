using Domain.Dtos;
using Domain.Wrapper;

public interface ILocationService
{
    Task<Response<AddLocationDto>> AddLocation(AddLocationDto model);
    Task<Response<string>> DeleteLocation(int id);
    Task<Response<Location>> GetLocationById(int id);
    Task<Response<List<GEtLocationDto>>> GetLocations();
    Task<Response<AddLocationDto>> UpdateLocation(AddLocationDto location);
}
