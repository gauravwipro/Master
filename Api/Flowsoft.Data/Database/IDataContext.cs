using Flowsoft.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flowsoft.Data
{
    public interface IDataContext
    {
        DbSet<AdmissionTypes> AdmissionTypes { get; set; }
        DbSet<Departments> Departments { get; set; }
        DbSet<Doctors> Doctors { get; set; }
        DbSet<Genders> Genders { get; set; }
        DbSet<PatientAdmission> PatientAdmission { get; set; }
        DbSet<Patients> Patients { get; set; }
        DbSet<ProductCategories> ProductCategories { get; set; }
        DbSet<Products> Products { get; set; }
        DbSet<States> States { get; set; }
        DbSet<Users> Users { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<Opds> Opds { get; set; }
        void SaveChanges();
    }
}
