using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeesManagement.Models
{
    public class SQLRegRepository : IRegRepository
    {
        private readonly AppDbContext context;
        public SQLRegRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Reg Add(Reg reg)
        {
            context.Regs.Add(reg);
            context.SaveChanges();
            return reg;
        }
        public Reg Delete(string RegId)
        {
            Reg reg = context.Regs.Find(RegId);
            if (reg != null)
            {
                context.Regs.Remove(reg);
                context.SaveChanges();
            }
            return reg;
        }
        public IEnumerable<Reg> GetAllReg()
        {
            return context.Regs;
        }
        public Reg GetReg(string RegId)
        {
            return context.Regs.Find(RegId);
        }
        public Reg Update(Reg regChanges)
        {
            var reg = context.Regs.Attach(regChanges);
            //reg.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return regChanges;
        }

    }
}
