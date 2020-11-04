using ProjectForAITUCanteen.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForAITUCanteen.Domain.Repositories
{
    public interface IAuthRepository
    {
        Student Register(Student student, string password);
        Student Login(string username, string password);
        bool UserExists(string username);
    }
}
