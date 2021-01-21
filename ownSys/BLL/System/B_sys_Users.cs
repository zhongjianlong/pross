using Common.MsSql;
using Entity.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.System
{
    public class B_sys_Users
    {
        public static List<sys_Users> GetList()
        {
            return SqlSugarHelper<sys_Users>.GetList();
        }

        public static List<sys_Users> GetList(sys_Users obj, int pageIndex, int pageSize, out int totle)
        {
            string sqlstr = "select * from sys_Users  ";
            string strWhere = "where 1=1 ";
            if (!string.IsNullOrEmpty(obj.name))
            {
                strWhere = "and name like '%" + obj.name.Trim() + "%' ";
            }
            sqlstr+= strWhere;
            return SqlSugarHelper<sys_Users>.GetList(sqlstr, pageIndex, pageSize, out totle);
        }

        public static bool Insert(sys_Users obj)
        {
            return SqlSugarHelper<sys_Users>.Insertable(obj) > 0 ? true : false;
        }

        public static bool Update(sys_Users obj)
        {
            return SqlSugarHelper<sys_Users>.Update(obj) > 0 ? true : false;
        }

        public static bool Delete(sys_Users obj)
        {
            return SqlSugarHelper<sys_Users>.Delete(obj) > 0 ? true : false;
        }

        public static bool Delete(int primaryKeyValue)
        {
            return SqlSugarHelper<sys_Users>.Delete(primaryKeyValue) > 0 ? true : false;
        }
    }
}
