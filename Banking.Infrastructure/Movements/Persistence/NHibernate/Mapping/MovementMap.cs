using Banking.Domain.Movements.Entities;
using FluentNHibernate.Mapping;

namespace Banking.Infrastructure.Movements.Persistence.NHibernate.Mapping
{
    public class MovementMap : ClassMap<Movement>
    {
        public MovementMap()
        {
            Id(x => x.Id).Column("account_id");
            Map(x => x.Balance).Column("balance");
            Map(x => x.Movement_type_id).Column("movement_type_id");
            Map(x => x.CreatedAt).Column("created_at_utc");
           References(x => x.Account_id, "account_id");
            References(x => x.Account_destino_id, "account_destino_id");
        }
    }
}
