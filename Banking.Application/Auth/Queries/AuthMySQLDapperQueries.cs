using Banking.Application.Auth.Contracts;
using Banking.Application.Auth.ViewModels;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace Banking.Application.Auth.Queries
{
    public class AuthMySQLDapperQueries : IAuthQueries
    {
        public LoginViewModel GetLoginInfo(long userId)
        {
            string sql = @"
                    SELECT
                        u.user_id AS userId,
                        u.user_name AS userName,
                        u.email_address AS emailAddress,
                        u.first_name AS userFirstName,
                        u.last_name AS userLastName,
                        c.customer_id  AS customerId,
                        c.first_name AS customerFirstName,
                        c.last_name AS customerLastName,
                        r.role_id AS roleId,
                        r.role_name AS roleName,
                        p.permission_id AS permissionId,
                        p.permission_name AS permissionName
                    FROM 
                        user u     
                        INNER JOIN role r ON r.role_id = u.role_id   
                        INNER JOIN role_permission rp ON r.role_id = rp.role_id
                        INNER JOIN permission p ON p.permission_id = rp.permission_id
                        INNER JOIN customer c ON c.user_id = u.user_id
                    WHERE
                        u.user_id = @UserId                       
                        and r.role_id = 2
                    ORDER BY 
                        c.customer_id, r.role_id, p.permission_id;";
            string connectionString = Environment.GetEnvironmentVariable("MYSQL_BANKING_CORE");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    List<LoginQueryViewModel> result = connection
                        .Query<LoginQueryViewModel>(sql, new
                        {
                            UserId = userId
                        })
                        .ToList();
                    return MapLoginInfo(result);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    throw ex;
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
        public LoginViewModel GetLoginInfoAdm(long userId)
        {
            string sql = @"
                    SELECT
                        u.user_id AS userId,
                        u.user_name AS userName,
                        u.email_address AS emailAddress,
                        u.first_name AS userFirstName,
                        u.last_name AS userLastName,
                        c.agent_id  AS customerId,
                        c.first_name AS customerFirstName,
                        c.last_name AS customerLastName,
                        r.role_id AS roleId,
                        r.role_name AS roleName,
                        p.permission_id AS permissionId,
                        p.permission_name AS permissionName
                    FROM 
                        user u     
                        INNER JOIN role r ON r.role_id = u.role_id   
                        INNER JOIN role_permission rp ON r.role_id = rp.role_id
                        INNER JOIN permission p ON p.permission_id = rp.permission_id
                        INNER JOIN agent c ON c.user_id = u.user_id
                    WHERE
                        u.user_id = @UserId
                        and r.role_id = 1
                    ORDER BY 
                        c.agent_id, r.role_id, p.permission_id;";
            string connectionString = Environment.GetEnvironmentVariable("MYSQL_BANKING_CORE");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    List<LoginQueryViewModel> result = connection
                        .Query<LoginQueryViewModel>(sql, new
                        {
                            UserId = userId
                        })
                        .ToList();
                    return MapLoginInfo(result);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    throw ex;
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

        private LoginViewModel MapLoginInfo(List<LoginQueryViewModel> result)
        {
            if (result.Count <= 0)
            {
                return new LoginViewModel();
            }

            var loginViewModel = new LoginViewModel
            {
                UserId = (long) result[0].userId,
                FirstName = result[0].userFirstName,
                LastName = result[0].userLastName,
                Name = result[0].userName,
                EmailAddress = result[0].emailAddress
            };            

            List<CustomerLoginDto> customers = result.DistinctBy(item => item.customerId).ToList()
                .Select(
                    c => new CustomerLoginDto
                    {
                        Id = c.customerId,
                        Name = c.customerFirstName + ' ' + c.customerLastName
                    }
                ).ToList();

            List<RoleLoginDto> roles = result.DistinctBy(item => item.roleId).ToList()
                .Select(
                    r => new RoleLoginDto
                    {
                        Id = r.roleId,
                        Name = r.roleName
                    }
                ).ToList();

            List<PermissionLoginDto> permissions = result.DistinctBy(item => item.permissionId).ToList()
                .Select(
                    p => new PermissionLoginDto
                    {
                        Id = p.permissionId,
                        Name = p.permissionName
                    }
                ).ToList();

            loginViewModel.Customers = customers;
            loginViewModel.Roles = roles;
            loginViewModel.Permissions = permissions;

            return loginViewModel;
        }
    }
}
