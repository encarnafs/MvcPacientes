using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcPacientes.Models
{
    public class PacienteGenderViewModel
    {
        public List<Paciente>? Pacientes {  get; set; }
        public SelectList? Gender { get; set; }
        public string? PacienteGender { get; set; }
        public string? SearchString {  get; set; }

    }
}