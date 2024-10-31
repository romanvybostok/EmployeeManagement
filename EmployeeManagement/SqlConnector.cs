using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    internal class SqlConnector
    {
        private const string db = "EmployeeManagement";

        public void CreateUser(UserModel model)
        {
            DateTime today = DateTime.Today;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Username", model.Username);
                p.Add("@Password", model.Password);
                p.Add("@RegistrationDate", today);
                p.Add("@id", 0, DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spUsers_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");
            }
        }

        public List<UserModel> GetUser_All()
        {
            List<UserModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<UserModel>("dbo.spUsers_GetAll").ToList();
            }

            return output;
        }

        public int GetUser_CountOfSameUsername(UserModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Username", model.Username);

                int output = connection.ExecuteScalar<int>("spUsers_GetCountOfSameUsername", p, commandType: CommandType.StoredProcedure);

                return output;
            }
        }

        public int GetUser_CountByLogin(UserModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Username", model.Username);
                p.Add("@Password", model.Password);

                int output = connection.ExecuteScalar<int>("spUsers_GetUserByValidLogin", p, commandType: CommandType.StoredProcedure);

                return output;
            }
        }

        public void CreateEmployee(EmployeeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();

                p.Add("@FirstName", model.FirstName);
                p.Add("@LastName", model.LastName);
                p.Add("@Gender", model.Gender);
                p.Add("@PhoneNumber", model.PhoneNumber);
                p.Add("@EmailAddress", model.EmailAddress);
                p.Add("@Position", model.Position);
                p.Add("Salary", model.Salary);
                p.Add("Status", model.Status);
                p.Add("@id", 0, DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spEmployees_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");
            }
        }

        public List<EmployeeModel> GetEmployee_All()
        {
            List<EmployeeModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<EmployeeModel>("dbo.spEmployees_GetAll").ToList();
            }

            return output;
        }

        public void UpdateEmployee(EmployeeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();

                p.Add("@Id", model.Id);
                p.Add("@FirstName", model.FirstName);
                p.Add("@LastName", model.LastName);
                p.Add("@Gender", model.Gender);
                p.Add("@PhoneNumber", model.PhoneNumber);
                p.Add("@EmailAddress", model.EmailAddress);
                p.Add("@Position", model.Position);
                p.Add("Salary", model.Salary);
                p.Add("Status", model.Status);

                connection.Execute("dbo.spEmployees_Update", p, commandType: CommandType.StoredProcedure);
            }
        }
        public void DeleteEmployee(EmployeeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@id", model.Id);

                connection.Execute("dbo.spEmployees_DeleteById", p, commandType: CommandType.StoredProcedure);
            }
        }

        public int GetEmployee_ActiveCount()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                int output = connection.ExecuteScalar<int>("spEmployees_GetCountOfActive", commandType: CommandType.StoredProcedure);

                return output; 
            }
        }

        public int GetEmployee_InactiveCount()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                int output = connection.ExecuteScalar<int>("spEmployees_GetCountOfInactive", commandType: CommandType.StoredProcedure);

                return output;
            }
        }
    }
}
