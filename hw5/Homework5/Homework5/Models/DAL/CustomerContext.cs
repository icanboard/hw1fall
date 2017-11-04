using Homework5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Homework5.DAL
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("name=MyDBContext")
        { }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}