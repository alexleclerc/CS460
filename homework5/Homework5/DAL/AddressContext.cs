using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homework5.Models;
using System.Data.Entity;

namespace Homework5.DAL
{
    public class AddressContext : DbContext
    {
        public AddressContext() : base("name=AddressContext")
        {

        }
        public virtual DbSet<Address> Addresses { get; set; }
    }
}