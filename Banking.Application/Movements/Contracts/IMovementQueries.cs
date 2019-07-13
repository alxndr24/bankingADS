using Banking.Application.Movements.ViewModels;
using System.Collections.Generic;

namespace Banking.Application.Movements.Contracts
{
    public interface IMovementQueries
    {
        List<MovementDto> GetListPaginated(int Account_id,int page = 0, int pageSize = 5);
    }
}
