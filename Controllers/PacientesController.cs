using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcPacientes.Data;
using MvcPacientes.Models;

namespace MvcPacientes.Controllers
{
    public class PacientesController : Controller
    {
        private readonly MvcPacientesContext _context;

        public PacientesController(MvcPacientesContext context)
        {
            _context = context;
        }

        // GET: Pacientes
        /*public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Paciente == null)
            {
                return Problem("Entity set 'MvcPacientesContext.Paciente'  is null.");
            }

            var pacientes = from p in _context.Paciente
                         select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                pacientes = pacientes.Where(s => s.Name!.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(await pacientes.ToListAsync());
        }*/

        // GET: Pacientes
        public async Task<IActionResult> Index(string pacienteGender, string searchString)
        {
            if (_context.Paciente == null)
            {
                return Problem("Entity set 'MvcPacientesContext.Paciente'  is null.");
            }

            // LINQ to get list of gender.
            IQueryable<string> genderQuery = from p in _context.Paciente
                                             orderby p.Gender
                                             select p.Gender;

            var pacientes = from p in _context.Paciente select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                pacientes = pacientes.Where(s => s.Name!.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!string.IsNullOrEmpty(pacienteGender))
            {
                pacientes = pacientes.Where(x => x.Gender == pacienteGender);
            }

            // So that it is not null
            var pacienteGenderVM = new PacienteGenderViewModel
            {
                Gender = new SelectList(await genderQuery.Distinct().ToListAsync()),
                Pacientes = await pacientes.ToListAsync()  //List of Model
            };

            return View(pacienteGenderVM);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Gender,Phone,Email,Birthdate,Observaciones,Rating")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,Gender,Phone,Email,Birthdate,Observaciones,Rating")] Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente != null)
            {
                _context.Paciente.Remove(paciente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return _context.Paciente.Any(e => e.Id == id);
        }
    }
}
