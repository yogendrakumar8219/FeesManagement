using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeesManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reg>().HasData(
                new Reg
                {
                    SNo=1,
                    RegId="19G121121",
                    RollNo="101",
                    StudentName="Pakhi",
                    Gender=Genders.Female,
                    FatherName="Yogendra Kumar",
                    Categery="O.B.C",
                    Address="House No.-227 South Bhopa Road, New Manadi Mzn",
                    MobileNumber="9897505503",
                    Email="yogendrakumar8219@gmail.com",
                    PhotoPath=""
                },
                new Reg
                {
                    SNo=2,
                    RegId="18G121121",
                    RollNo="102",
                    StudentName="Manu",
                    Gender=Genders.Male,
                    FatherName="Sanjay Kumar",
                    Categery="O.B.C",
                    Address="House No.-227 South Bhopa Road, New Manadi Mzn",
                    MobileNumber="9897653676",
                    Email="sanjaykumar@gmail.com",
                    PhotoPath=""
                }
                );
        }

    }
}
