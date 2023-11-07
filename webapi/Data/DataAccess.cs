using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace webapi.DataAccess
{
    public class DataAccess
    {
        private readonly string _connectionString = "";

        public IEnumerable<Employee> GetEmployees()
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                var stringScript = File.ReadAllText("sql_queries/employee.sql");

                using (var command = new OracleCommand(stringScript, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        var employees = new List<Employee>();

                        while (reader.Read())
                        {
                            var employee = new Employee
                            {
                                Id = reader.GetString(reader.GetOrdinal("EMPLOYEE_ID")),
                                Name = reader.GetString(reader.GetOrdinal("EMPLOYEE_NAME"))
                            };

                            employees.Add(employee);
                        }

                        return employees;
                    }
                }
            }
        }

        public IEnumerable<BarVas> GetBarVas()
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                var stringScript = File.ReadAllText("sql_queries/BarVas.sql");

                using (var command = new OracleCommand(stringScript, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        var barVasList = new List<BarVas>();

                        while (reader.Read())
                        {
                            var barVas = new BarVas
                            {
                                Hour = reader.GetString(reader.GetOrdinal("Hour")),
                                QTY = reader.GetInt32(reader.GetOrdinal("QTY"))
                            };

                            barVasList.Add(barVas);
                        }

                        return barVasList;
                    }
                }
            }
        }

        public IEnumerable<BarShopPick> GetBarShopPick()
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                var stringScript = File.ReadAllText("sql_queries/BarShopPick.sql");

                using (var command = new OracleCommand(stringScript, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        var barShopPickList = new List<BarShopPick>();

                        while (reader.Read())
                        {
                            var barShopPick = new BarShopPick
                            {
                                HOUR_QUARTER = reader.GetString(reader.GetOrdinal("HOUR_QUARTER")),
                                QTY = reader.GetInt32(reader.GetOrdinal("QTY"))
                            };

                            barShopPickList.Add(barShopPick);
                        }

                        return barShopPickList;
                    }
                }
            }
        }


        public IEnumerable<VasImport> VasImport()
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                var stringScript = File.ReadAllText("sql_queries/VasImport.sql");

                using (var command = new OracleCommand(stringScript, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        var vasImportList= new List<VasImport>();

                        while (reader.Read())
                        {
                            var vasImport = new VasImport
                            {
                                OrderType = reader.GetString(reader.GetOrdinal("ORDERTYPE")),
                                QTY = reader.GetInt32(reader.GetOrdinal("QTY"))
                            };

                            vasImportList.Add(vasImport);
                        }

                        return vasImportList;
                    }
                }
            }
        }
    }
}
