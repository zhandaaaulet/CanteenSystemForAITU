using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForAITUCanteen.Domain.Models.Auth
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
