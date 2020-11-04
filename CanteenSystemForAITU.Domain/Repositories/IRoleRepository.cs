using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IRoleRepository
    {
        Role GetByName(string name);
    }
}
