using Dapper;
using GreenSchool.Core.Repositories;
using GreenSchool.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSchool.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConfiguration _config;
        private const string CONNECTION_STRING_CONFIGURATION = "GreenSchoolConnectionString";
        public StudentRepository(IConfiguration config)
        {
            _config = config;
        }

        public Task DeleteById(long studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetById(long studentId)
        {
            using (var connection = GetConnection())
            {
                string sQuery = "SELECT * FROM Students WHERE StudentID = @StudentID";
                connection.Open();

                var result = await connection.QueryAsync<Student>(sQuery, new { StudentID = studentId });
                return result.FirstOrDefault();
            }
        }

        public Task Update(long studentId, string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public Task<long> Add(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        private IDbConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString(CONNECTION_STRING_CONFIGURATION));
        }
}
}
