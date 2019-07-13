using Banking.Application.Movements.Contracts;
using Banking.Application.Movements.ViewModels;
using Dapper;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;

namespace Banking.Application.Movements.Queries
{
    public class MovementMySQLDapperQueries : IMovementQueries
    {
        public List<MovementDto> GetListPaginated(int Account_id,int page = 0, int pageSize = 5)
        {
            string sql = @"                    
                        SELECT  
	                        m.created_at_utc as fecha_ope,
	                        m.balance as monto,
	                        mt.movement_type as tipo_movimiento
                        FROM 
	                        movement m
	                        inner join movement_type mt on mt.movement_type_id = m.movement_type_id
                        where
	                        account_id = @Account
                        ORDER BY 
	                        m.created_at_utc DESC
                        limit @Page , @PageSize;";
            string connectionString = Environment.GetEnvironmentVariable("MYSQL_BANKING_CORE");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    List<MovementDto> customers = connection
                        .Query<MovementDto>(sql, new
                        {
                            Account = Account_id,
                            Page = page,
                            PageSize = pageSize
                        })
                        .ToList();
                    return customers;
                } catch(Exception ex) {
                    ex.ToString();
                    return new List<MovementDto>();
                }
                finally
                {
                    if (connection.State != System.Data.ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
