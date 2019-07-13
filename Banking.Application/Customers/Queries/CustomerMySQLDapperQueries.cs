using Banking.Application.Customers.Contracts;
using Banking.Application.Customers.ViewModels;
using Dapper;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;

namespace Banking.Application.Customers.Queries
{
    public class CustomerMySQLDapperQueries : ICustomerQueries
    {
        public List<CustomerDto> GetListPaginated(int page = 0, int pageSize = 5)
        {
            string sql = @"
                    SELECT 
                        c.customer_id AS id,
                        c.first_name AS firstName,
                        c.last_name AS lastName,
                        c.identity_document AS identityDocument,
                        c.active
                    FROM 
                        customer c
                        JOIN (SELECT c2.customer_id FROM customer c2 ORDER BY c2.last_name ASC, c2.first_name ASC LIMIT @Page, @PageSize)
                            AS c3 ON c.customer_id = c3.customer_id
                    ORDER BY 
                        c.last_name ASC, c.first_name ASC;";
            string connectionString = Environment.GetEnvironmentVariable("MYSQL_BANKING_CORE");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    List<CustomerDto> customers = connection
                        .Query<CustomerDto>(sql, new
                        {
                            Page = page,
                            PageSize = pageSize
                        })
                        .ToList();
                    return customers;
                } catch(Exception ex) {
                    ex.ToString();
                    return new List<CustomerDto>();
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
