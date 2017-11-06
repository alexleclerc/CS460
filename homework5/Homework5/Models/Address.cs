using System;
using System.Data.Entity;

namespace Homework5.Models
{
    public class Address
    {
        public int ID { get; set; }
        public DateTime dob { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Addr { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string County { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
    }
}