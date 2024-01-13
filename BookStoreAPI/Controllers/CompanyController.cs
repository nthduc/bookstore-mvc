using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        // GET all companies
        public IActionResult GetCompanies()
        {
            var companies = _unitOfWork.Company.GetAll();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        // Get a company by Id
        public IActionResult GetCompany(int id)
        {
            var company = _unitOfWork.Company.Get(c => c.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]
        // Create a new company
        public IActionResult CreateCompany(Company company)
        {
            _unitOfWork.Company.Add(company);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        // Update a company
        public IActionResult UpdateCompany(int id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }
            _unitOfWork.Company.Update(company);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        // Delete a company
        public IActionResult DeleteCompany(int id)
        {
            var company = _unitOfWork.Company.Get(c => c.Id == id);

            if (company == null)
            {
                return NotFound();
            }
            _unitOfWork.Company.Remove(company);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
