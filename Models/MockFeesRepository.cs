using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeesManagement.Models
{
    public class MockFeesRepository : IFeesRepository
    {
        private List<Course> _courseList;
        private List<Reg> _regList;
        private List<Fees> _feesList;
        public MockFeesRepository()
        {
            _courseList = new List<Course>()
            {
                new Course(){CourseId=1,StudentClass="BCA",Year="I",Session="2021-22",TotalFees=18925,RegId="19G121121"},
                new Course(){CourseId=2,StudentClass="BBA",Year="I",Session="2021-22",TotalFees=18925,RegId="18G121121"}
            };
            _regList = new List<Reg>()
            {
                new Reg(){SNo=1,RegId="19G121121",RollNo="101",StudentName="Pakhi",Gender=Genders.Female,FatherName="Yogendra Kumar",Categery="O.B.C",Address="House No.-227 South Bhopa Road, New Manadi Mzn",MobileNumber="9897505503",Email="yogendrakumar8219@gmail.com",PhotoPath=""},
                new Reg(){SNo=2,RegId="18G121121",RollNo="102",StudentName="Manu",Gender=Genders.Male,FatherName="Sanjay Kumar",Categery="O.B.C",Address="House No.-227 South Bhopa Road, New Manadi Mzn",MobileNumber="9897653676",Email="sanjaykumar@gmail.com",PhotoPath=""}
            };
            _feesList = new List<Fees>()
            {
                new Fees(){FeesId=1,Tran_date=Convert.ToDateTime("29-08-2021"),CourseId=1,RegId="19G121121",FeesDeposit=25000},
                new Fees(){FeesId=2,Tran_date=Convert.ToDateTime("29-08-2021"),CourseId=1,RegId="18G121121",FeesDeposit=18925}

            };
        }

        public Fees Add(Fees fees)
        {
            fees.FeesId = _feesList.Max(e => e.FeesId) + 1;
            _feesList.Add(fees);
            return fees;
        }
        public IEnumerable<ViewModel> GetAllFees()
        {
            List<Reg> regs = _regList;
            List<Course> courses = _courseList;
            List<Fees> fees = _feesList;

            var q = from r in regs
                    join c in courses on r.RegId equals c.RegId
                    join f in fees on r.RegId equals f.RegId
                    orderby f.RegId
                    select new ViewModel
                    {
                        reg = r,
                        course = c,
                        fees=f
                    };
            return q;
        }
        public Fees GetFees(int FeesId)
        {
            return this._feesList.FirstOrDefault(e => e.FeesId == FeesId);
        }

        public Fees Update(Fees feesChanges)
        {
            Fees fees = _feesList.FirstOrDefault(e => e.FeesId == feesChanges.FeesId);
            if (fees != null)
            {
                fees.Tran_date = feesChanges.Tran_date;
                fees.RegId = feesChanges.RegId;
                fees.CourseId = feesChanges.CourseId;
                fees.FeesDeposit = feesChanges.FeesDeposit;
            }
            return fees;
        }

        public Fees Delete(int FeesId)
        {
            Fees fees = _feesList.FirstOrDefault(e => e.FeesId == FeesId);
            if (fees != null)
            {
                _feesList.Remove(fees);
            }
            return fees;
        }

    }
}
