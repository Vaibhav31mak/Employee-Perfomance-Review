using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EPR.Data;
using EPR.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EPR.Controllers
{
    [Authorize]
    public class ApplicantsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ApplicantsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Applicants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Applicants.ToListAsync());
        }
        public string GenerateUniqueEmpNo()
        {
            string empNo;
            Random random = new Random();
            do
            {
                empNo = "EMP" + random.Next(10000, 99999).ToString(); // Generates EMP12345 format
            } while (_context.Employees.Any(e => e.EmpNo == empNo)); // Ensures uniqueness

            return empNo;
        }
        public async Task<IActionResult> Select(int? id)
        {
            if (id == null) return NotFound();

            var applicant = await _context.Applicants.FindAsync(id);
            if (applicant == null) return NotFound();

            var user = await _userManager.FindByEmailAsync(applicant.EmailAddress);
            if (user == null) return NotFound();

            // Convert the applicant to an employee
            var employee = new Employee
            {
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                PhoneNumber = applicant.PhoneNumber,
                EmailAddress = applicant.EmailAddress,
                Country = applicant.Country,
                DateOfBirth = applicant.DateOfBirth,
                Address = applicant.Address,
                Designation = applicant.Designation
            };
            employee.EmpNo = GenerateUniqueEmpNo();

            await _context.Employees.AddAsync(employee);
            _context.Applicants.Remove(applicant);

            // Remove "Applicant" role and assign "Employee" role
            await _userManager.RemoveFromRoleAsync(user, "Applicant");
            await _userManager.AddToRoleAsync(user, "Employee");

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }



        // GET: Applicants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicants
                .FirstOrDefaultAsync(m => m.id == id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }


        // GET: Applicants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FirstName,MiddleName,LastName,PhoneNumber,EmailAddress,Country,DateOfBirth,Address,Resume,Designation")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicant);
        }

        // GET: Applicants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicants.FindAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FirstName,MiddleName,LastName,PhoneNumber,EmailAddress,Country,DateOfBirth,Address,Resume,Designation")] Applicant applicant)
        {
            if (id != applicant.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicantExists(applicant.id))
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
            return View(applicant);
        }

        // GET: Applicants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicants
                .FirstOrDefaultAsync(m => m.id == id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicant = await _context.Applicants.FindAsync(id);
            if (applicant != null)
            {
                _context.Applicants.Remove(applicant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicantExists(int id)
        {
            return _context.Applicants.Any(e => e.id == id);
        }
    }
}
