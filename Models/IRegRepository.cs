using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeesManagement.Models
{
    public interface IRegRepository
    {
        Reg GetReg(string RegId);
        IEnumerable<Reg> GetAllReg();
        Reg Add(Reg reg);
        Reg Update(Reg reg);
        Reg Delete(string RegId);

    }
}
