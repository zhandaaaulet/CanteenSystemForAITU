using Infrastructure.Data;
using ProjectForAITUCanteen.Domain.Models.Auth;
using ProjectForAITUCanteen.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectForAITUCanteen.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly CanteenContext _context;

        public AuthRepository(CanteenContext context)
        {
            _context = context;
        }
        public Student Login(string username, string password)
        {
            var student = _context.StudentList.FirstOrDefault(x => x.Username == username);
            if (student == null || !VerifyPasswordHash(password, student.PasswordHash, student.PasswordSalt))
                return null;

            return student;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        public Student Register(Student student, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            student.PasswordHash = passwordHash;
            student.PasswordSalt = passwordSalt;

            _context.StudentList.Add(student);
            _context.SaveChanges();

            return student;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public bool UserExists(string username)
        {
            return _context.StudentList.Any(x => x.Username == username);
        }
    }
}
