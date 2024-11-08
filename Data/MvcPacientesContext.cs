using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcPacientes.Models;

namespace MvcPacientes.Data
{
    public class MvcPacientesContext : DbContext
    {
        public MvcPacientesContext (DbContextOptions<MvcPacientesContext> options)
            : base(options)
        {
        }

        public DbSet<MvcPacientes.Models.Paciente> Paciente { get; set; } = default!;
    }
}
