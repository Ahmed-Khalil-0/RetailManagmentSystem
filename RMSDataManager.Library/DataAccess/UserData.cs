using RMSDataManager.Library.Internal.DataAccess;
using RMSDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSDataManager.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            return sql.LoadData<UserModel, string>("dbo.spUserLookUp", id, "DefaultConnection");
        }
    }
}
