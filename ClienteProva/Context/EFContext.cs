using ClienteProva.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClienteProva.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("CLIENTEPROVA") { }
        public DbSet<Cliente> clientes { get; set; }
    }
}