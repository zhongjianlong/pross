using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.System
{
    [SugarTable("sys_Users")]
    public class sys_Users
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int uid { get; set; }

        public string name { get; set; }

        public int age { get; set; }

        public string account { get; set; }

        public string password { get; set; }

    }
}
