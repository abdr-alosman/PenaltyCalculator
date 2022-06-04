using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfCountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public Country GetCountryByIdNaWithHolies(int id)
        {
            using (var c = new Context())
            {
                return c.Countries.Include(x => x.CountryWeekendDays).ThenInclude(x => x.WeekDay).Include(x => x.NationalReligiousDays).SingleOrDefault(x=>x.Id==id);
            }
        }

        public List<Country> GetCountryNaWithHolidyDays()
        {
            using (var c = new Context())
            {
                return c.Countries.Include(x => x.CountryWeekendDays).ThenInclude(x => x.WeekDay).Include(x => x.NationalReligiousDays).ToList();
            }
        }
    }
}
