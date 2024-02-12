using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace InterviewTask.DAL
{
    public class DALBase
    {
        protected SqlDatabase SqlDatabase;
        private readonly IConfiguration _configuartion;

        //public DALBase(IConfiguration configuration)
        //{
        //    _configuartion = configuration;
        //}
        public DALBase()
        {
            var builder = WebApplication.CreateBuilder();
            this.SqlDatabase = new SqlDatabase(builder.Configuration.GetConnectionString("DbConnectionString"));
            //this.SqlDatabase = new SqlDatabase(_configuartion.GetConnectionString("DbConnectionString"));
        }
    }
}
