using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MsSql
{
    public class SqlSugarHelper<T> where T : class, new()
    {
        private static SqlSugarClient Db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = ConfigHelper.GetConfigString("MySysDataDB"),
            DbType = SqlSugar.DbType.SqlServer,//设置数据库类型
            IsAutoCloseConnection = true,//自动释放数据务，如果存在事务，在事务结束后释放
            InitKeyType = InitKeyType.Attribute //从实体特性中读取主键自增列信息
        });//用来处理事务多表查询和复杂的操作



        //查询

        public static List<T> GetList()
        {
            var list = Db.Queryable<T>().ToList();
            return list;
        }

        public static T GetObj(int pkid)  //根据主键，获取对象
        {
            return Db.Queryable<T>().InSingle(pkid);
        }

        public static List<T> GetList(string sqlstr, int pageIndex, int pageSize, out int totle)  //分页获取
        {
            List<T> list = Db.SqlQueryable<T>(sqlstr).ToPageList(pageIndex, pageSize);  
            totle = Db.SqlQueryable<T>(sqlstr).ToList().Count; 
            return list;
        }
         

        // 添加
        public static int Insertable(T insertObj)
        {
            return Db.Insertable(insertObj).ExecuteCommand();
        }

        //批量操作，事务处理
        public static int Insertable(List<T> listObj)
        {
            Db.BeginTran();
            int res = 0;
            try
            {
                res = Db.Insertable(listObj).ExecuteCommand();
                Db.CommitTran();
            }
            catch (Exception)
            {
                Db.RollbackTran();
            }
            return res;
        }

        public static int InsertableReturnIdentity(T insertObj)
        {
            return Db.Insertable(insertObj).ExecuteReturnIdentity();
        }


        //动态控制列，不进行操作 ( IgnoreColumn类中 EntityName实体类名, PropertyName 属性名 )

        public static int InsertableReturnIdentity(T insertObj, List<IgnoreColumn> columns)
        {
            if (columns.Count > 0)
            {
                columns.ForEach((e) =>
                {
                    Db.IgnoreInsertColumns.Add(e);
                });
            }
            return Db.Insertable(insertObj).ExecuteReturnIdentity();
        }

        //修改

        public static int Update(T obj)
        {
            return Db.Updateable<T>(obj).ExecuteCommand();
        }

        public static int Update(T obj, List<IgnoreColumn> columns)
        {
            if (columns.Count > 0)
            {
                columns.ForEach((e) =>
                {
                    Db.IgnoreColumns.Add(e);
                });
            }
            return Db.Updateable<T>(obj).ExecuteCommand();
        }

        public static int Update(List<T> obj)
        {
            Db.BeginTran();
            int res = 0;
            try
            {
                res = Db.Updateable<T>(obj).ExecuteCommand();
                Db.CommitTran();
            }
            catch (Exception)
            {
                Db.RollbackTran();
            }
            return res;
        }



        //删除

        public static int Delete(T obj)
        {
            return Db.Deleteable<T>(obj).ExecuteCommand();
        }

        public static int Delete(List<T> obj)
        {
            Db.BeginTran();
            int res = 0;
            try
            {
                res = Db.Deleteable<T>(obj).ExecuteCommand();
                Db.CommitTran();
            }
            catch (Exception)
            {
                Db.RollbackTran();
            }
            return res;
        }

        public static int Delete(int[] primaryKeyValues)
        {
            Db.BeginTran();
            int res = 0;
            try
            {
                res = Db.Deleteable<T>().In(primaryKeyValues).ExecuteCommand();
                Db.CommitTran();
            }
            catch (Exception)
            {
                Db.RollbackTran();
            }
            return res;
        }

        public static int Delete(int primaryKeyValue)
        {
            return Db.Deleteable<T>().In(primaryKeyValue).ExecuteCommand();
        }
    }
}
