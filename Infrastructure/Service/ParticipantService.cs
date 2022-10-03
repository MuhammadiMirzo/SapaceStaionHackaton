using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class ParticipantService : IParticipantService
{
    private readonly DataContext _context;

    public ParticipantService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GEtParticipantDto>>> GetParticipants()
    {
        var Participants = await _context.Participants.Select(l => new GEtParticipantDto()
        {
            Id = l.Id,
            FullName = l.FullName,
            CreatedAt = l.CreatedAt,
            Email = l.Email,
            GroupId = l.GroupId,
            LocationId = l.LocationId,
            Phone = l.Phone

        }).ToListAsync();
        return new Response<List<GEtParticipantDto>>(Participants);
    }


    public async Task<Response<AddParticipantDto>> AddParticipant(AddParticipantDto model)
    {
        try
        {
            var Participant = new Participant()
            {
            Id = model.Id,
            FullName = model.FullName,
            CreatedAt = model.CreatedAt,
            Email = model.Email,
            GroupId = model.GroupId,
            LocationId = model.LocationId,
            Phone = model.Phone

            };
            await _context.Participants.AddAsync(Participant);
            await _context.SaveChangesAsync();
            model.Id = Participant.Id;
            return new Response<AddParticipantDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddParticipantDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<Participant>> GetParticipantById(int id)
    {
        var find = await _context.Participants.FindAsync(id);
        return new Response<Participant>(find);
    }


    public async Task<Response<AddParticipantDto>> UpdateParticipant(AddParticipantDto Participant)
    {
        try
        {
            var find = await _context.Participants.FindAsync(Participant.Id);
            if (find == null) return new Response<AddParticipantDto>(System.Net.HttpStatusCode.NotFound, "");


            find.CreatedAt = Participant.CreatedAt;
            find.Email = Participant.Email;
            find.FullName = Participant.Email;
            find.GroupId = Participant.GroupId;
            find.LocationId = Participant.LocationId;
            find.Phone = Participant.Phone;
            await _context.SaveChangesAsync();
            return new Response<AddParticipantDto>(Participant);
        }
        catch (System.Exception ex)
        {
            return new Response<AddParticipantDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }


    public async Task<Response<string>> DeleteParticipant(int id)
    {
        try
        {
            var find = await _context.Participants.FindAsync(id);
            if (find == null) return new Response<string>(System.Net.HttpStatusCode.NotFound, "");

            _context.Participants.Remove(find);
            await _context.SaveChangesAsync();
            return new Response<string>("removed successfully");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}