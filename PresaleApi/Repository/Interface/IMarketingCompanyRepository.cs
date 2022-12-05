using PresaleApi.DataBaseEntity;

namespace PresaleApi.Repository
{
    public interface IMarketingCompanyRepository
    {
        ApplicationResponse Upsert(NearBy model);
        object Upsert(MarketingCompany marketingCompany);
    }
}
