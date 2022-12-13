using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace AIR_RESERVATION_SYSTEM_API.Logging
{
    public class Admin_Logger : ActionFilterAttribute
    {
        readonly string logfileName;
        DateTime startTime;
        DateTime endTime;
        TimeSpan totalTime;

        public Admin_Logger(IWebHostEnvironment enviroment)
        {
            logfileName = enviroment.ContentRootPath + @"/LogFile/AdminLogger.txt";

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ControllerBase controllerBase = (ControllerBase)context.Controller;
            ControllerContext controllerContext = controllerBase.ControllerContext;
            string controllerName = controllerContext.ActionDescriptor.ActionName;
            string actionMethod = controllerContext.ActionDescriptor.ActionName;
            using (StreamWriter writer = File.AppendText(logfileName))
            {
                startTime = DateTime.Now;
                writer.Write($"StartTime::{startTime}\t| ControllerName::{controllerName}\t| ActionName::{actionMethod}");
                writer.Close();
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            endTime = DateTime.Now;
            totalTime = endTime - startTime;
            using (StreamWriter writer = File.AppendText(logfileName))
            {
                writer.WriteLine($"\t |EndTime::{endTime}\t| TotalTime in Seconds::{totalTime.TotalSeconds}");
                writer.Close();

            }
        }
    }
}
