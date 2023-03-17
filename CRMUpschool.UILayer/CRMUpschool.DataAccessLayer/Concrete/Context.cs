// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRMUpschool.EntityLayer.Concrete;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRMUpschool.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//kullanıcı adı yada şifre girmeden baglantı yapmamızı sağlar
        {
            optionsBuilder.UseSqlServer("Server=.;Database=DbCRM;Integrated Security=true");// usesqlserver bağlantı yapmmaızı sağlar
        }
        public DbSet<Customer> Customers { get; set; }//Tablolarımız //Çogullar amacı c# sınıf model ile sql deki tablo çakışmasın
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public DbSet<EmployeeTaskDetails> EmployeeTaskDetails { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
