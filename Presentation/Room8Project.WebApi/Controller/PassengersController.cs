namespace Room8Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private readonly Room8ProjectContext _context;

        public PassengersController(Room8ProjectContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IEnumerable<Passengers> GetTaxiDrivers()
        {
            return _context.Passengers.ToList();
        }

        
        [HttpGet("{id}")]
        public Passengers GetPassengers(string id)
        {
            var passengers = _context.Passengers.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            return passengers;
        }

        
        [HttpPost]
        public Passengers PostPassengers(Passengers passengers)
        {
            _context.Passengers.Add(passengers);
            _context.SaveChanges();

            return passengers;
        }


        [HttpPut("{id}")]
        public void PutPassengers(string id, Passengers passengers)
        {
            var originalOne = _context.Passengers.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            _context.Entry(passengers).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            originalOne.Id = passengers.Id;
            originalOne.Name = passengers.Name;
            originalOne.Surname = passengers.Surname;
            originalOne.LicencePlate = passengers.LicencePlate;

            _context.SaveChanges();

        }

        [HttpDelete("{id}")]
        public TaxiDriver DeletePassengers(string id)
        {
            var passengers = _context.Passengers.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();


            _context.Passengers.Remove(passengers);
            _context.SaveChanges();

            return passengers;
        }

    }

}