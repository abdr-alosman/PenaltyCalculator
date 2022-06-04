using EntityLayer.Concrete;


namespace BusinessLayer.Abstract
{
    public interface ICountryService
    {
        void Insert(Country t);
        void Update(Country t);
        void Delete(Country t);
        List<Country> GetListAll();
        Country GetByID(int id);
        List<Country> GetCountryNaWithHolidyDays();
        Country GetCountryByIdNaWithHolies(int id);
    }
}
