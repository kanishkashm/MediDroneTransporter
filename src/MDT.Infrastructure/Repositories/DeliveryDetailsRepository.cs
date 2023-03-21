using MDT.Core.Entities;
using MDT.Core.Interfaces;
using MDT.Infrastructure.Persistence;

namespace MDT.Infrastructure.Repositories
{
    public class DeliveryDetailsRepository : RepositoryBase<DeliveryDetails>, IDeliveryDetailsRepository
    {
        public DeliveryDetailsRepository(MdtContext dbContext) : base(dbContext)
        {
        }
    }
}
