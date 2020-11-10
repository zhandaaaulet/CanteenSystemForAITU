using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ProjectForAITUCanteen.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        private readonly CanteenContext _db;
        

        public EntityRepository(CanteenContext db)
        {
            _db = db;
           
        }

        public async Task<T> AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> AddStudent(Student s)
        {
            _db.StudentList.Add(s);
            return (await _db.SaveChangesAsync()) > 0;
        }

        public async Task DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.StudentList.Include(x => x.Group).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }








        /* public async Task<IEnumerable<UserEntity>> GetUsers()
         {
             User user = new User();
             UserEntity userEntity = _mapper.Map<UserEntity>(user);
             return await _db.Users.Include(x => x.Login).ToListAsync();
         }*/
        /*   public async Task<bool> AddStudent(User user)
           {
               UserEntity userEntity = _mapper.Map<UserEntity>(user);
               _db.Users.Add(userEntity);
               return (await _db.SaveChangesAsync()) > 0;
           }*/

        /*public void Create(User user)
        {
            UserEntity userEntity = _mapper.Map<UserEntity>(user);

            _db.Users.Add(userEntity);
            _db.SaveChanges();
        }*/
    }
}
