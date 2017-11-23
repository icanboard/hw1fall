namespace Homework7.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RequestContext : DbContext
    {
        public RequestContext()
            : base("name=request") // Name of the model
        {
        }

        public virtual DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
