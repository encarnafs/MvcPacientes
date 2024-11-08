using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcPacientes.Data;
using MvcPacientes.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MvcPacientes.SeedData
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcPacientesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcPacientesContext>>()))
            {
                // Look for any movies.
                if (context.Paciente.Any())
                {
                    return;   // DB has been seeded
                }
                context.Paciente.AddRange(
                    new Paciente
                    {
                        Name = "Phillips",
                        LastName = "Pharell Fox",
                        Gender = "Man",
                        Phone = "999 99 99 99",
                        Email = "PhillilpsPharellFox@gmail.com",
                        Birthdate = DateTime.Parse("1989-2-12"),
                        Observaciones = "Sick at heart",
                        Rating = "+60"
                    },
                    new Paciente
                    {
                        Name = "Angela",
                        LastName = "Petters Brown",
                        Gender = "Woman",
                        Phone = "888 88 88 88",
                        Email = "PettersBrownAngela@gmail.com",
                        Birthdate = DateTime.Parse("1989-3-16"),
                        Observaciones = "Asthmatic",
                        Rating = "18-30"
                    },
                    new Paciente
                    {
                        Name = "Greycie",
                        LastName = "Robinson Like",
                        Gender = "Woman",
                        Phone = "333 33 33 33",
                        Email = "RobinsonLikeGreycie@gmail.com",
                        Birthdate = DateTime.Parse("1989-9-7"),
                        Observaciones = "Fibromyalgia",
                        Rating = "30-40"
                    },
                    new Paciente
                    {
                        Name = "Eduard",
                        LastName = "Moore Willis",
                        Gender = "Man",
                        Phone = "777 77 77 77",
                        Email = "MooreWillisEduard@gmail.com",
                        Birthdate = DateTime.Parse("1989-6-25"),
                        Observaciones = "Fibromyalgia",
                        Rating = "40-50"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}