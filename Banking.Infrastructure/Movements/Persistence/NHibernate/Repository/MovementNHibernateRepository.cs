using Banking.Domain.Movements.Contracts;
using Banking.Domain.Movements.Entities;
using Banking.Infrastructure.NHibernate;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;

namespace Banking.Infrastructure.Movements.Persistence.NHibernate.Repository
{
    public class MovementNHibernateRepository : NHibernateRepository<Movement>, IMovementRepository
    {
        public MovementNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }
        

    }
}
