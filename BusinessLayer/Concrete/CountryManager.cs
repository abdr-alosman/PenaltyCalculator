using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;


namespace BusinessLayer.Concrete
{
    public class CountryManager : ICountryService
    {
        private ICountryRepository _countryRepository;
        public CountryManager(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;

        }
        public void Delete(Country t)
        {
            // iş kuralları uygula burda
            _countryRepository.Delete(t);
        }

        public Country GetByID(int id)
        {
            return _countryRepository.GetByID(id);
        }

        public Country GetCountryByIdNaWithHolies(int id)
        {
            return _countryRepository.GetCountryByIdNaWithHolies(id);
        }

        public List<Country> GetCountryNaWithHolidyDays()
        {
            return _countryRepository.GetCountryNaWithHolidyDays();
        }

        public List<Country> GetListAll()
        {
            return _countryRepository.GetListAll();
        }

        public void Insert(Country t)
        {
            _countryRepository.Insert(t);
        }

        public void Update(Country t)
        {
            _countryRepository.Update(t);
        }
    }
}
