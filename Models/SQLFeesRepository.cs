using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeesManagement.Models;
using FeesManagement.ViewModels;

namespace FeesManagement.Models
{
    public class SQLFeesRepository:IFeesRepository
    {
        private readonly AppDbContext context;
        public SQLFeesRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Fees Add(Fees fees)
        {
            context.Feess.Add(fees);
            context.SaveChanges();
            return fees;
        }
        public Fees Delete(int FeesId)
        {
            Fees fees = context.Feess.Find(FeesId);
            if (fees != null)
            {
                context.Feess.Remove(fees);
                context.SaveChanges();
            }
            return fees;
        }

        public IEnumerable<ViewModel> GetAllFees()
        {
            List<Reg> regs = context.Regs.ToList();
            List<Course> courses = context.Courses.ToList();
            List<Fees> fees = context.Feess.ToList();

            var q = from r in regs
                    join c in courses on r.RegId equals c.RegId
                    join f in fees on c.CourseId equals f.CourseId
                    orderby f.RegId
                    select new ViewModel
                    {
                        reg = r,
                        course = c,
                        fees = f
                    };
            return q;
        }

        public Fees GetFees(int FeesId)
        {
            return context.Feess.Find(FeesId);
        }
        public Fees Update(Fees feesChanges)
        {
            var fees = context.Feess.Attach(feesChanges);
            fees.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return feesChanges;
        }
    }
}



