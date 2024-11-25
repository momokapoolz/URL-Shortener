using laptop_service.Models;
using laptop_service.Repositories.Interfaces;
using laptop_service.Data;

namespace laptop_service.Repositories
{
    public class LaptopRepository : ILaptopRepository
    {
        private laptop_serviceContext _context;

        public LaptopRepository(laptop_serviceContext context)
        {
            _context = context;
        }

        public List<Laptop> DisplayAllLaptops()
        {
            return _context.Laptop.OrderBy(laptop_service => laptop_service.Model).ToList();
        }
    }
}
