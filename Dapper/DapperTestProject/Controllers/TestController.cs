using System.Threading.Tasks;
using DapperTestProject.Data;
using DapperTestProject.Entity;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using DapperTestProject.Dtos;
using DapperTestProject.View;

namespace DapperTestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public TestController(ApplicationDbContext context, ISqlConnectionFactory sqlConnectionFactory)
        {
            _context = context;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            const string query = """SELECT * FROM "Users" """;
            var users = await connection.QueryAsync<EUsers>(query);
            return Ok(users);
        }

        [HttpGet("view/active")]
        public async Task<IActionResult> GetActiveUsers()
        {

            /*
                CREATE OR REPLACE VIEW "UserView" AS
                SELECT 
                    "Id",
                    "UserName",
                    "Email",
                    CASE 
                        WHEN "UpdatedDate" IS NULL 
                            OR "UpdatedDate" = '-infinity' THEN "CreatedDate"
                        ELSE "UpdatedDate"
                    END AS "Date",
                    "Status"
                FROM "Users"
                where "IsDeleted" = false;

                select * from "UserView";

                DROP VIEW IF EXISTS "UserSummaryView";
            */
            using var connection = _sqlConnectionFactory.CreateConnection();
            const string query = """SELECT * FROM "UserView" """;
            await connection.ExecuteAsync(query);
            var users = await connection.QueryAsync<UserView>(query);
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            const string query = """SELECT "Id", "UserName", "Email", "Status" FROM "Users" WHERE "Id" = @Id""";
            var users = await connection.QueryFirstAsync<EUsers>(query, new { Id = id });
            if (users == null)
            {
                return NoContent();
            }
            var response = new UserResponseDto
            {
                Email = users.Email,
                Status = users.Status.ToString(),
                UserName = users.UserName
            };
            return Ok(response);
        }

        [HttpGet("sp/{id}")]
        public async Task<IActionResult> GetByIdFromSp(int id)
        {
            /*
                CREATE OR REPLACE FUNCTION "GetUsersById"(id INT)
                RETURNS TABLE("Id" INT, "Username" TEXT, "Email" TEXT)
                AS $$
                BEGIN
                    RETURN QUERY
                    SELECT u."Id", u."UserName", u."Email"
                    FROM "Users" u
                    WHERE u."Id" = id;
                END;
                $$ LANGUAGE plpgsql;

                SELECT * FROM "GetUsersById"(5);
            */
            using var connection = _sqlConnectionFactory.CreateConnection();
            const string query = """SELECT * FROM "GetUsersById"(@Id)""";

            var users = await connection.QueryFirstAsync<EUsers>(query, new { Id = id });
            if (users == null)
            {
                return NoContent();
            }
            var response = new UserResponseDto
            {
                Email = users.Email,
                Status = users.Status.ToString(),
                UserName = users.UserName
            };
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRequestDto model)
        {
            _context.Users.Add(new EUsers
            {
                CreatedDate = DateTime.UtcNow,
                Email = model.Email,
                Status = model.Status,
                UserName = model.UserName
            });
            await _context.SaveChangesAsync();
            return Ok("Added successfully");
        }
    }
}
