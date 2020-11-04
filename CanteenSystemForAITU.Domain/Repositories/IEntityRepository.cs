using Domain.Models;
using ProjectForAITUCanteen.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IEntityRepository<T> where T : class
    {
        /*   void Create(User user);*/
        
        Task<bool> AddStudent(Student s);
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<Student>> GetStudents();
       
    }
}
