using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForAITUCanteen.DataTransfer.DTO.Auth
{
    public class StudentDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public Guid GroupId { get; set; }
    }
}
