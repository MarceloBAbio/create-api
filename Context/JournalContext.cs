using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using create_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace create_api.Context
{
    public class JournalContext : DbContext
    {
        public JournalContext(DbContextOptions<JournalContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}