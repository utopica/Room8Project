using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Room8Project.Domain.Entities;
using Room8Project.Persistence.Contexts;

namespace Room8Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiDriversController : ControllerBase
    {
        private readonly Room8ProjectContext _context;

        public TaxiDriversController(Room8ProjectContext context)
        {
            _context = context;
        }

        // GET: api/TaxiDrivers
        [HttpGet]
        public IEnumerable<TaxiDriver> GetTaxiDrivers()
        {
            return _context.TaxiDrivers.ToList();
        }

        // GET: api/TaxiDrivers/5
        [HttpGet("{id}")]
        public TaxiDriver GetTaxiDriver(string id)
        {
            var taxiDriver = _context.TaxiDrivers.Where( x => x.Id == Guid.Parse(id)).FirstOrDefault();

            return taxiDriver;
        }

        // POST: api/TaxiDrivers
        [HttpPost]
        public TaxiDriver PostTaxiDriver(TaxiDriver taxiDriver)
        {
            _context.TaxiDrivers.Add(taxiDriver);
            _context.SaveChanges();

            return taxiDriver;
        }

        // PUT: api/TaxiDrivers/5
        [HttpPut("{id}")]
        public void PutTaxiDriver(string id, TaxiDriver taxiDriver)
        {
            var originalOne = _context.TaxiDrivers.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            _context.Entry(taxiDriver).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            originalOne.Id = taxiDriver.Id;
            originalOne.Name = taxiDriver.Name;
            originalOne.Surname = taxiDriver.Surname;
            originalOne.LicencePlate = taxiDriver.LicencePlate;

            _context.SaveChanges();
            
        }

        // DELETE: api/TaxiDrivers/5
        [HttpDelete("{id}")]
        public TaxiDriver DeleteTaxiDriver(string id)
        {
            var taxiDriver = _context.TaxiDrivers.Where( x => x.Id == Guid.Parse(id)).FirstOrDefault();
            

            _context.TaxiDrivers.Remove(taxiDriver);
            _context.SaveChanges();

            return taxiDriver;
        }

    }

}
