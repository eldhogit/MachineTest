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
    public class DalProduct
    {
        string ErrorClass = "DalCategory";

        public bool Insert(out string ErrorMessage, Product product)
        {
            ErrorMessage = string.Empty;
            bool IsSuccess = true;

            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConstants.ConnectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand("InsertProduct_sp", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Name", product.Name);
                    sqlCommand.Parameters.AddWithValue("@Price", product.Price);
                    sqlCommand.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                    sqlCommand.Parameters.AddWithValue("@IsActive", product.IsActive);

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

        public bool UpdateById(out string ErrorMessage, Product product)
        {
            ErrorMessage = string.Empty;
            bool IsSuccess = true;

            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConstants.ConnectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand("UpdateProductById_sp", con);

                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", product.Id);
                    sqlCommand.Parameters.AddWithValue("@Name", product.Name);
                    sqlCommand.Parameters.AddWithValue("@Price", product.Price);
                    sqlCommand.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                    sqlCommand.Parameters.AddWithValue("@IsActive", product.IsActive);

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

                    SqlCommand sqlCommand = new SqlCommand("DeleteProductById_sp", con);
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

        public bool GetById(out string ErrorMessage, out Product product, long Id)
        {
            ErrorMessage = string.Empty;
            bool IsSuccess = true;

            product = new Product();

            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConstants.ConnectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand("GetProductById_sp", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    sqlCommand.Parameters.AddWithValue("@Id", Id);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();

                        dataTable.Columns.Add("Id");
                        dataTable.Columns.Add("Name");
                        dataTable.Columns.Add("Price");
                        dataTable.Columns.Add("CategoryId");
                        dataTable.Columns.Add("IsActive");
                      

                        while (sqlDataReader.Read())
                        {
                            DataRow dataRow = dataTable.NewRow();

                            dataRow["Id"] = sqlDataReader["Id"];
                            dataRow["Name"] = sqlDataReader["Name"];
                            dataRow["Price"] = sqlDataReader["Price"];
                            dataRow["CategoryId"] = sqlDataReader["CategoryId"];
                            dataRow["IsActive"] = sqlDataReader["IsActive"];

                            dataTable.Rows.Add(dataRow);


                            if (dataTable.Rows.Count == 1)
                            {
                                foreach (DataRow item in dataTable.Rows)
                                {
                                    product.Id = Convert.ToInt64(item["Id"]);
                                    product.Name = Convert.ToString(item["Name"]);
                                    product.Price = Convert.ToInt32(item["Price"]);
                                    product.CategoryId = Convert.ToInt64(item["CategoryId"]);
                                    product.IsActive = Convert.ToBoolean(item["IsActive"]);

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

        public bool GetAll(out string ErrorMessage, out List<Product> products)
        {
            ErrorMessage = string.Empty;
            bool IsSuccess = true;

            products = new List<Product>();

            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConstants.ConnectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand("GetAllProduct_sp", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();

                        dataTable.Columns.Add("Id");
                        dataTable.Columns.Add("Name");
                        dataTable.Columns.Add("Price");
                        dataTable.Columns.Add("CategoryId");
                        dataTable.Columns.Add("CategoryName");
                        dataTable.Columns.Add("IsActive");

                        while (sqlDataReader.Read())
                        {
                            DataRow dataRow = dataTable.NewRow();

                            dataRow["Id"] = sqlDataReader["Id"];
                            dataRow["Name"] = sqlDataReader["Product Name"];
                            dataRow["Price"] = sqlDataReader["Price"];
                            dataRow["CategoryId"] = sqlDataReader["Category Id"];
                            dataRow["CategoryName"] = sqlDataReader["Category Name"];
                            dataRow["IsActive"] = sqlDataReader["IsActive"];

                            dataTable.Rows.Add(dataRow);
                        }

                        if (dataTable != null)
                        {
                            foreach (DataRow item in dataTable.Rows)
                            {
                                products.Add(new Product()
                                {
                                    Id = Convert.ToInt64(item["Id"]),
                                    Name = Convert.ToString(item["Name"]),
                                    Price = Convert.ToInt32(item["Price"]),
                                    CategoryId = Convert.ToInt64(item["CategoryId"]),
                                    CategoryName = Convert.ToString(item["CategoryName"]),
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
