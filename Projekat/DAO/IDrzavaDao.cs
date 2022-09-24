using Projekat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.DAO
{
    public interface IDrzavaDao
    {
        IEnumerable<Drzava> FindAll();
    }
}
