using Banking.Domain.Movements.Constants;
using Banking.Domain.Accounts.Entities;
using Common;
using System.Collections.Generic;
using System.Linq;

namespace Banking.Domain.Movements.Entities
{
    public class Movement : Entity
    {
        public virtual int Movement_type_id { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual Account Account_id { get; set; }
        public virtual Account Account_destino_id { get; set; }

        public Movement()
        {
            
        }

        

    }
}
