using ProjectForAITUCanteen.DataTransfer.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForAITUCanteen.Domain.Models.Auth
{
    public class Student
    {
        public Student()
        {

        }

        public Student(StudentDto dto)
        {

            Id = Guid.NewGuid();
            Name = dto.Name;
            Surname = dto.Surname;
            Birthday = dto.Birthday;
            GroupId = dto.GroupId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime Birthday { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public string Role { get; set; }
    }
}
