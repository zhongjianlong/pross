using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ResponseModel<T> where T : class
    {
        public int code { set; get; }
        public string msg { set; get; }
        public List<T> data { set; get; }

    }
}