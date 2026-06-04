using Microsoft.EntityFrameworkCore;
using RESTWebApiDatabaseFirst2.Data;
using RESTWebApiDatabaseFirst2.DTOs;
using RESTWebApiDatabaseFirst2.Exceptions;
using RESTWebApiDatabaseFirst2.Models;

namespace RESTWebApiDatabaseFirst2.Services;

public class DBService : IDBService
{
    private readonly DatabaseFirstContext _context;

    public DBService(DatabaseFirstContext context)
    {
        _context = context;

    }

    public async Task<IEnumerable<PatientsDTo>> GetPatients(string? search)
    {
        var query = _context.Patients.AsQueryable();
        
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p =>
                EF.Functions.Like(p.FirstName, $"%{search}%") ||
                EF.Functions.Like(p.LastName, $"%{search}%"));
        }

        
        
        return await  query.Select(p => new PatientsDTo
        {
            
            Pesel = p.Pesel,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Age = p.Age,

            Sex = p.Sex ? "Male" : "Female",
            
            Admissions = p.Admissions.Select(a => new AdmissionDTO
            {
                Id = a.Id,
                AdmissionDate = a.AdmissionDate,
                DischargeDate = a.DischargeDate,
                Ward = new WardDto
                {
                    Id = a.Ward.Id,
                    Name = a.Ward.Name,
                    Description = a.Ward.Description
                }
            }).ToList(),
            
            BedAssignments = p.BedAssignments.Select(
            b => new BedAssignmentDTO
            {
            Id = b.Id,
            From = b.From,
            To = b.To,

            Bed = new BedDTO()
            {
                Id = b.Bed.Id,

                BedType = new BedTypeDTO()
                {
                    Id = b.Bed.BedType.Id,
                    Name = b.Bed.BedType.Name,
                    Description = b.Bed.BedType.Description
                },

                Room = new RoomDTO()
                {
                    Id = b.Bed.Room.Id,
                    HasTv = b.Bed.Room.HasTv,

                    Ward = new WardDto()
                    {
                        Id = b.Bed.Room.Ward.Id,
                        Name = b.Bed.Room.Ward.Name,
                        Description = b.Bed.Room.Ward.Description
                    }
                }
            }
        }).ToList()
        })
        .ToListAsync();
    }

    public async Task<IEnumerable<BedAssignmentsPostDTO>> BedAssignments(string pesel, BedAssignmentsPostDTO dto)
    {
        var patient = await _context.Patients.AnyAsync(p => p.Pesel == pesel);
        if (!patient)
        {
            throw new NotFoundException();
        }
        var wardId = await _context.Wards
            .Where(w => w.Name == dto.Ward)
            .Select(w => w.Id)
            .FirstOrDefaultAsync();
        return null;
    }







}