using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Test1ConnectedAdo
{
    public class DataAccess
    {
        SqlConnection con1;
        SqlCommand com;
        SqlConnection getConnection()
        {
            con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring1"].ToString());
            return con1;
        }
        public void InsertAddress(Address address)
        {
            using (con1 = getConnection())
            {
                {
                    using (com = new SqlCommand("sp_insertAddress", con1))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@First_name", address.First_name);
                        com.Parameters.AddWithValue("@Last_name", address.Last_name);
                        com.Parameters.AddWithValue("@Email", address.Email);
                        com.Parameters.AddWithValue("@Phonenumber", address.Phonenumber);
                        com.Parameters.AddWithValue("@age", address.age);
                        con1.Open();
                        com.ExecuteNonQuery();
                        con1.Close();
                    }
                }
            }
        }


        public void EditAddress(int Address_id, Address address)
        {
            con1 = getConnection();
            com = new SqlCommand("sp_updateAddress", con1);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@First_name", address.First_name);
            com.Parameters.AddWithValue("@Address_id", Address_id);
            con1.Open(); com.ExecuteNonQuery();
            con1.Close();
        }
        public void DeleteAddress(int Address_id)
        {
            using (con1 = getConnection())
            {
                using (com = new SqlCommand("sp_deleteAddress", con1))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Address_id", Address_id);
                    con1.Open(); com.ExecuteNonQuery();
                    con1.Close();
                }
            }
        }
        public Address SearchAdress(string Address_id)
        {
            Address address = null;
            using (con1 = getConnection())
            {
                using (com = new SqlCommand("sp_searchAddress", con1))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Address_id", Address_id);
                    con1.Open();
                    SqlDataReader read = com.ExecuteReader();
                    if (read.HasRows)
                    {
                        read.Read();
                        address = new Address();
                        address.Last_name = read["Last_name"].ToString();
                        address.Email = read["Email"].ToString();
                        address.Phonenumber = read["Email"].ToString();
                        address.age = (int)read["age"];
                    }
                    read.Close();
                    con1.Close();
                }
            }
            return address;
        }
    }
}