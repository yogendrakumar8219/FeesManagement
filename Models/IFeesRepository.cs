using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeesManagement.Models
{
    public interface IFeesRepository
    {
        Fees GetFees(int FeesId);
        IEnumerable<ViewModel> GetAllFees();
        Fees Add(Fees fees);
        Fees Update(Fees fees);
        Fees Delete(int FeesId);
    }
}
