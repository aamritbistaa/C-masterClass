using EmployeeMS.AppDbContext;
using EmployeeMS.Dto.Request;
using EmployeeMS.Dto.Response;
using EmployeeMS.Helpers;
using EmployeeMS.Mapper;
using EmployeeMS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeMS.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllAttendance")]
        public async Task<List<AttendanceResponse>?> GetAllAttendance()
        {
            var atten = await _context.Attendances.ToListAsync();

            var datas = atten.Where(x => x.IsDeleted == false).ToList();

            var response = (from item in datas
                            select Mappers.AttendanceToAttendanceResponseMapper(item)
                            ).ToList();
            return response;
        }
        [HttpGet("GetSpecificNoOfAttendance")]
        public async Task<List<AttendanceResponse>?> GetSpecificNoOfAttendance(int NoOfItem = 3, int PageNo = 1)
        {
            var atten = _context.Attendances.ToList();

            var datas = atten.Skip((PageNo - 1) * NoOfItem).Take(NoOfItem).ToList();

            var response = (from item in datas
                            select Mappers.AttendanceToAttendanceResponseMapper(item)
                            ).ToList();
            return response;

        }

        [HttpGet("GetAllAttendanceByEmployeeId")]
        public async Task<List<AttendanceResponse>?> GetAllAtendanceByEmployeeId(int id)
        {
            var atten = await _context.Attendances.ToListAsync();

            var datas = atten.Where(x => x.Id == id).ToList();
            var response =
                (from item in datas
                 select Mappers.AttendanceToAttendanceResponseMapper(item)
                ).ToList();
            return response;
        }
        [HttpGet("GetAllAttendanceByDate")]
        public async Task<List<AttendanceResponse>?> GetAllAttendanceByDate(DateOnly date)
        {
            var atten = await _context.Attendances.ToListAsync();

            var attendanceList = (from item in atten
                                  where item.Date == date
                                  select Mappers.AttendanceToAttendanceResponseMapper(item)
                                  ).ToList();
            return attendanceList;
        }
        [HttpPost("CreateAttendance")]
        public async Task<AttendanceResponse?> CreateAttendance(CreateAttendanceRequest request)
        {
            //parsing Date and Time
            DateOnly ParsedDate = DateOnly.Parse(request.Date);
            TimeOnly ParsedInTime = TimeOnly.Parse(request.InTime);

            // Check if in time and out time is more than current time
            var currentDate = DateTimeHelpers.ReturnTodayDate;
            var currentTime = DateTimeHelpers.ReturnCurrentTime;
            if (ParsedDate >= currentDate)
            {
                if (ParsedInTime > currentTime)
                {
                    // In time cant be in future
                    return null;
                }
                if (request.OutTime != null)
                {
                    var ParsedOutTime = TimeOnly.Parse(request.OutTime);
                    if (ParsedOutTime > currentTime)
                    {
                        return null;
                    }
                    if (ParsedOutTime < ParsedInTime)
                    {
                        return null;
                    }
                }
            }
            //Employee exist or not
            var item = _context.Employees.Find(request.EmployeeId);
            if (item == null)
            {
                return null;
            }

            var atten = _context.Attendances;
            var attendance = new Attendance
            {
                Date = ParsedDate,
                InTime = ParsedInTime,
                EmployeeId = request.EmployeeId,
            };

            if (request.OutTime != null)
            {
                attendance.OutTime = TimeOnly.Parse(request.OutTime);
            }

            atten.Add(attendance);

            await _context.SaveChangesAsync();

            var response = Mappers.AttendanceToAttendanceResponseMapper(attendance);
            return response;
        }

        [HttpPost("UpdateAttendanceBasedOnEmployeeIdAndDate")]
        public async Task<AttendanceResponse> UpdateAttendanceBasedOnEmployeeIdAndDate(UpdateAttendanceRequest request)
        {
            //parsing Date and Time
            DateOnly ParsedDate = DateOnly.Parse(request.Date);
            TimeOnly ParsedInTime = TimeOnly.Parse(request.InTime);

            // Check if in time and out time is more than current time
            var currentDate = DateTimeHelpers.ReturnTodayDate;
            var currentTime = DateTimeHelpers.ReturnCurrentTime;
            if (ParsedDate >= currentDate)
            {
                if (ParsedInTime > currentTime)
                {
                    // In time cant be in future
                    return null;
                }
                if (request.OutTime != null)
                {
                    var ParsedOutTime = TimeOnly.Parse(request.OutTime);
                    if (ParsedOutTime > currentTime)
                    {
                        return null;
                    }
                    if (ParsedOutTime < ParsedInTime)
                    {
                        return null;
                    }
                }
            }

            var atten = _context.Attendances;
            var item = await atten.FirstOrDefaultAsync(x => x.EmployeeId == request.EmployeeId && x.Date == DateOnly.Parse(request.Date));
            if (item == null) return null;
            item.InTime = ParsedInTime;
            if (request.OutTime != null)
            {
                item.OutTime = TimeOnly.Parse(request.OutTime);
            }
            atten.Update(item);
            await _context.SaveChangesAsync();

            var response = Mappers.AttendanceToAttendanceResponseMapper(item);
            return response;
        }


        [HttpPost("RegisterInTimeByEmployee")]
        public async Task<AttendanceResponse?> RegisterInTimeByEmployee(int id)
        {
            var atten = _context.Attendances;

            var item = atten.FirstOrDefault(x => x.Date == DateTimeHelpers.ReturnTodayDate && x.EmployeeId == id);
            if (item != null)
            {
                var res = new AttendanceResponse()
                {
                    Id = item.Id,
                    EmployeeId = item.EmployeeId,
                    Date = item.Date,
                    InTime = item.InTime,
                    IsDeleted = item.IsDeleted,
                    OutTime = item?.OutTime,
                };
                return res;
            }
            var attendance = new Attendance
            {
                EmployeeId = id,
                InTime = DateTimeHelpers.ReturnCurrentTime,
                Date = DateTimeHelpers.ReturnTodayDate
            };

            atten.Add(attendance);
            await _context.SaveChangesAsync();

            var response = Mappers.AttendanceToAttendanceResponseMapper(attendance);
            return response;
        }

        [HttpPost("RegisterOutTimeByEmployee")]
        public async Task<AttendanceResponse?> RegisterOutTimeByEmployee(int id)
        {
            var atten = _context.Attendances;

            var data = await _context.Attendances.Where(x => x.Date == DateTimeHelpers.ReturnTodayDate && x.EmployeeId == id).FirstOrDefaultAsync();
            if (data == null)
            {
                return null;
            }

            data.OutTime = DateTimeHelpers.ReturnCurrentTime;
            atten.Update(data);
            await _context.SaveChangesAsync();
            var response = Mappers.AttendanceToAttendanceResponseMapper(data);
            return response;
        }

        [HttpDelete("TempDeleteAttendanceById")]
        public async Task<AttendanceResponse> TempDeleteAttendanceById(int id)
        {
            var atten = _context.Attendances;

            var data = await atten.FindAsync(id);
            if (data == null)
            {
                return null;
            }
            data.IsDeleted = true;
            atten.Update(data);
            await _context.SaveChangesAsync();
            var response = Mappers.AttendanceToAttendanceResponseMapper(data);
            return response;

        }

        [HttpDelete("PermaDeleteAttendanceById")]
        public async Task<AttendanceResponse> PermaDeleteAttendanceById(int id)
        {
            var atten = _context.Attendances;

            var data = await atten.FindAsync(id);

            if (data == null)
            {
                return null;
            }
            _context.Remove(data);
            await _context.SaveChangesAsync();
            var response = Mappers.AttendanceToAttendanceResponseMapper(data);
            return response;

        }


    }
}
