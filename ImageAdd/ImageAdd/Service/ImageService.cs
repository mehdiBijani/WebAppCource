using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ImageAdd.Models;

namespace ImageAdd.Service
{
   public class ImageService
{
    private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    public List<ImageViewModel> GetAllImages()
    {
        var result = new List<ImageViewModel>();

        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = new SqlCommand("sp_GetImages", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new ImageViewModel
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"].ToString(),
                        FilePath = "/img/images/" + reader["Id"] + ".jpg"
                    });
                }
            }
        }

        return result;
    }

    public int AddImage(string title)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = new SqlCommand("sp_AddImage", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", title);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputIdParam);

            conn.Open();
            cmd.ExecuteNonQuery();

            return (int)outputIdParam.Value;
        }
    }

    public void UpdateImage(int id, string title)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = new SqlCommand("sp_UpdateImage", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Title", title);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}

}