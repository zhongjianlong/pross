using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.System
{
    [SugarTable("sys_Menu")]
    public class sys_Menu
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }

        public string text { get; set; }

        public string iconCls { get; set; }

        public string url { get; set; }

        public string targetType { get; set; }

        public int fid { get; set; }

    }
}
