using Nimap.DAL.Common;
using Nimap.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimap.DAL
{
    public class DalCategory
    {
        string ErrorClass = "DalCategory";
        public bool Insert(out string ErrorMessage, Category category)
        {
            ErrorMessage = string.Empty;
            bool IsSuccess = true;

            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConstants.ConnectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand("InsertCategory_sp", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Name", category.Name);
                    sqlCommand.Parameters.AddWithValue("@IsActive", category.IsActive);

                    con.Open();

                    int RowsAffected = sqlCommand.ExecuteNonQuery();
                }

                return IsSuccess;
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                var errMsg = ex.Message;

                ErrorMessage = ErrorClass + " | " + errMsg;

                return IsSuccess;
            }
        }

        public bool UpdateById(out string ErrorMessage, Category category)
        {
            ErrorMessage = string.Empty;
            bool IsSuccess = true;

            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConstants.ConnectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand("UpdateCategoryById_sp", con);

                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", category.Id);
                    sqlCommand.Parameters.AddWithValue("@Name", category.Name);
                    sqlCommand.Parameters.AddWithValue("@IsActive", category.IsActive);

                    con.Open();

                    int RowsAffected = sqlCommand.ExecuteNonQuery();

                    return IsSuccess;
                }
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                var errMsg = ex.Message;
                ErrorMessage = ErrorClass + " | " + ex.ToString();

                return IsSuccess;
            }

        }

        public bool DeleteById(out string ErrorMessage, long Id)
        {
            ErrorMessage = string.Empty;
            bool IsSuccess = true;

            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConstants.ConnectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand("DeleteByIdCategory_sp", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", Id);

                    con.Open();

                    int RowsAffected = sqlCommand.ExecuteNonQuery();

                    return IsSuccess;
                }

            }
            catch (Exception ex)
            {
                IsSuccess = false;
                var errMsg = ex.Message;
                ErrorMessage = ErrorClass + " | " + ex.ToString();

                return IsSuccess;
            }
        }

        public bool GetById(out string ErrorMessage, out Category category, long Id)
        {
            ErrorMessage = string.Empty;
            bool IsSuccess = true;

            category = new Category();

            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConstants.ConnectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand("GetCategoryById_sp", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    sqlCommand.Parameters.AddWithValue("@Id", Id);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();

                        dataTable.Columns.Add("Id");
                        dataTable.Columns.Add("Name");
                        dataTable.Columns.Add("IsActive");

                        while (sqlDataReader.Read())
                        {
                            DataRow dataRow = dataTable.NewRow();

                            dataRow["Id"] = sqlDataReader["Id"];
                            dataRow["Name"] = sqlDataReader["Name"];
                            dataRow["IsActive"] = sqlDataReader["IsActive"];

                            dataTable.Rows.Add(dataRow);


                            if (dataTable.Rows.Count == 1)
                            {
                                foreach (DataRow item in dataTable.Rows)
                                {
                                    category.Id = Convert.ToInt64(item["Id"]);
                                    category.Name = Convert.ToString(item["Name"]);
                                    category.IsActive = Convert.ToBoolean(item["IsActive"]);

                                }
                            }

                        }

                    }
                }
                return IsSuccess;
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                var errMsg = ex.Message;
                ErrorMessage = ErrorClass + " | " + ex.ToString();

                return IsSuccess;
            }
        }
        public bool GetAll(out string ErrorMessage,out List<Category> Categories)
        {
            ErrorMessage = string.Empty;
            bool IsSuccess = true;

            Categories = new List<Category>();

            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConstants.ConnectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand("GetAllCategory_sp", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();

                        dataTable.Columns.Add("Id");
                        dataTable.Columns.Add("Name");
                        dataTable.Columns.Add("IsActive");

                        while (sqlDataReader.Read())
                        {
                            DataRow dataRow = dataTable.NewRow();

                            dataRow["Id"] = sqlDataReader["Id"];
                            dataRow["Name"] = sqlDataReader["Name"];
                            dataRow["IsActive"] = sqlDataReader["IsActive"];

                            dataTable.Rows.Add(dataRow);
                        }

                        if (dataTable != null)
                        {
                            foreach (DataRow item in dataTable.Rows)
                            {
                                Categories.Add(new Category()
                                {
                                    Id = Convert.ToInt64(item["Id"]),
                                    Name = Convert.ToString(item["Name"]),
                                    IsActive = Convert.ToBoolean(item["IsActive"]),
                                });
                            }
                        }

                    }

                }

                return IsSuccess;
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                var errMsg = ex.Message;
                ErrorMessage = ErrorClass + " | " + ex.ToString();               

                return IsSuccess;
            }
        }
        public bool GetAllByIsActive(out string ErrorMessage, out List<Category> Categories)
        {
            ErrorMessage = string.Empty;
            bool IsSuccess = true;

            Categories = new List<Category>();

            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConstants.ConnectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand("GetAllCategoryByIsActiveStatus_sp", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();

                        dataTable.Columns.Add("Id");
                        dataTable.Columns.Add("Name");
                        dataTable.Columns.Add("IsActive");

                        while (sqlDataReader.Read())
                        {
                            DataRow dataRow = dataTable.NewRow();

                            dataRow["Id"] = sqlDataReader["Id"];
                            dataRow["Name"] = sqlDataReader["Name"];
                            dataRow["IsActive"] = sqlDataReader["IsActive"];

                            dataTable.Rows.Add(dataRow);
                        }

                        if (dataTable != null)
                        {
                            foreach (DataRow item in dataTable.Rows)
                            {
                                Categories.Add(new Category()
                                {
                                    Id = Convert.ToInt64(item["Id"]),
                                    Name = Convert.ToString(item["Name"]),
                                    IsActive = Convert.ToBoolean(item["IsActive"]),
                                });
                            }
                        }

                    }

                }

                return IsSuccess;
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                var errMsg = ex.Message;
                ErrorMessage = ErrorClass + " | " + ex.ToString();

                return IsSuccess;
            }
        }

    }
}

