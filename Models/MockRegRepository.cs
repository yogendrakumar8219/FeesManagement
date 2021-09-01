using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeesManagement.Models
{
    public class MockRegRepository:IRegRepository
    {
        private List<Reg> _regList;
        public MockRegRepository()
        {
            _regList = new List<Reg>()
            {
                new Reg(){SNo=1,RegId="19G121121",RollNo="101",StudentName="Pakhi",Gender=Genders.Female,FatherName="Yogendra Kumar",Categery="O.B.C",Address="House No.-227 South Bhopa Road, New Manadi Mzn",MobileNumber="9897505503",Email="yogendrakumar8219@gmail.com",PhotoPath=""},
                new Reg(){SNo=2,RegId="18G121121",RollNo="102",StudentName="Manu",Gender=Genders.Male,FatherName="Sanjay Kumar",Categery="O.B.C",Address="House No.-227 South Bhopa Road, New Manadi Mzn",MobileNumber="9897653676",Email="sanjaykumar@gmail.com",PhotoPath=""}
            };
        }

        public Reg Add(Reg reg)
        {
            reg.SNo = _regList.Max(e => e.SNo) + 1;
            _regList.Add(reg);
            return reg;
        }

        public IEnumerable<Reg> GetAllReg()
        {
            return _regList;
        }

        public Reg GetReg(string RegId)
        {
            return this._regList.FirstOrDefault(e => e.RegId ==RegId);
        }

        public Reg Update(Reg regChanges)
        {
            Reg reg = _regList.FirstOrDefault(e => e.RegId == regChanges.RegId);
            if (reg != null)
            {
                reg.RollNo = regChanges.RollNo;
                reg.StudentName = regChanges.StudentName;
                reg.Gender = regChanges.Gender;
                reg.FatherName = regChanges.FatherName;
                reg.Categery = regChanges.Categery;
                reg.Address = regChanges.Address;
                reg.MobileNumber = regChanges.MobileNumber;
                reg.Email = reg.Email;
            }
            return reg;
        }

        public Reg Delete(string RegId)
        {
            Reg reg = _regList.FirstOrDefault(e => e.RegId ==RegId);
            if (reg != null)
            {
                _regList.Remove(reg);
            }
            return reg;
        }

    }
}
