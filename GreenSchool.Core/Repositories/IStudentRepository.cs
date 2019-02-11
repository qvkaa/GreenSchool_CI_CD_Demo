using GreenSchool.Models;
using System;
using System.Threading.Tasks;

namespace GreenSchool.Core.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> GetById(long studentId);

        Task Update(long studentId, string firstName, string lastName);

        Task DeleteById(long studentId);

        Task<long> Add(string firstName, string lastName);
    }
}
