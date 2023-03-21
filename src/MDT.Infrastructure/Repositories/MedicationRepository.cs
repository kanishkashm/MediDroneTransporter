using MDT.Core.Entities;
using MDT.Core.Interfaces;
using MDT.Infrastructure.Persistence;

namespace MDT.Infrastructure.Repositories
{
    public class MedicationRepository : RepositoryBase<Medication>, IMedicationRepository
    {
        public MedicationRepository(MdtContext dbContext) : base(dbContext)
        {
        }
    }
}
