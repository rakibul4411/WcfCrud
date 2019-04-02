using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WcfCrud
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base("rakibConnection") { }

        public DbSet<Person> Person { get; set; }
    }
}