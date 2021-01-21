using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Filter
{
    public class HandlerErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            //context.ExceptionHandled = true;

            //WriteLog(context);
            //var url = context.HttpContext.Request.Path;
            //var msg = url + context.Exception.Message;
            //new LogApp().WriteDbLog(msg);
        }

        //private void WriteLog(ExceptionContext context)
        //{
        //    if (context == null)
        //        return;
        //    var log = LogFactory.GetLogger(context.Controller.ToString());
        //    log.Error(context.Exception);
        //}
    }
}