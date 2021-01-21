using Common.MsSql;
using Entity.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.System
{
    public class B_sys_Menu
    {
        public static List<sys_Menu> GetList()
        {
            return SqlSugarHelper<sys_Menu>.GetList();
        }

        public static bool Insert(sys_Menu obj)
        {
            return SqlSugarHelper<sys_Menu>.Insertable(obj) > 0 ? true : false;
        }

        public static bool Update(sys_Menu obj)
        {
            return SqlSugarHelper<sys_Menu>.Update(obj) > 0 ? true : false;
        }

        public static bool Delete(sys_Menu obj)
        {
            return SqlSugarHelper<sys_Menu>.Delete(obj) > 0 ? true : false;
        }

        public static bool Delete(int primaryKeyValue)
        {
            return SqlSugarHelper<sys_Menu>.Delete(primaryKeyValue) > 0 ? true : false;
        }
    }
}
