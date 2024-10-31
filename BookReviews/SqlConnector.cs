using BookReviews.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviews
{
    internal class SqlConnector
    {
        private const string db = "BookReviews";

        public void CreateBook (BookModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@BookName", model.BookName);
                p.Add("@AuthorName", model.AuthorName);
                p.Add("@PublishYear", model.PublishYear);
                p.Add("@Rating", model.Rating);
                p.Add("@UserDescription", model.UserDescription);
                p.Add("@UserThoughts", model.UserThoughts);
                p.Add("@id", 0, DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spBooks_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");
            }
        }
        public List<BookModel> GetBook_All()
        {
            List<BookModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            { 
                output = connection.Query<BookModel>("dbo.spBooks_GetAll").ToList();
            }

            return output;
        }

        public void UpdateBook (BookModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@id", model.Id);
                p.Add("@BookName", model.BookName);
                p.Add("@AuthorName", model.AuthorName);
                p.Add("@PublishYear", model.PublishYear);
                p.Add("@Rating", model.Rating);
                p.Add("@UserDescription", model.UserDescription);
                p.Add("@UserThoughts", model.UserThoughts);

                connection.Execute("dbo.spBooks_Update", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteBook (BookModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@id", model.Id);

                connection.Execute("dbo.spBooks_DeleteBookById", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
