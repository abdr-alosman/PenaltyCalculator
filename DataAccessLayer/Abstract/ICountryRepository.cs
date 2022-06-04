using EntityLayer.Concrete;


namespace DataAccessLayer.Abstract
{
    public interface ICountryRepository: IGenericRepository<Country>
    {
        List<Country> GetCountryNaWithHolidyDays();
        Country GetCountryByIdNaWithHolies(int id);
    }
}
