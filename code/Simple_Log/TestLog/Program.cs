﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLog
{
    class Program
    {
        static void Main(string[] args)
        {
            DoTest1ConsoleLog();
            DoTest2DBLog();
            DoTest3TextFileLog();

            Console.WriteLine("Press anykey to exit ...");
            Console.Read();
        }

        private static void DoTest1ConsoleLog()
        {
            var s1 = System.Diagnostics.Stopwatch.StartNew();
            s1.Start();
            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            Console.WriteLine("Start executing {0} ...", methodName);

            dynamic settings = new System.Dynamic.ExpandoObject();

            settings.CanAddError = true;
            settings.CanAddWarning = true;
            settings.CanAddInfo = true;

            SimpleLog.Manager logManager = new SimpleLog.Manager(SimpleLog.Constants.LOG_CONSOLE, settings);

            SimpleLog.Message message = new SimpleLog.Message() {
                CreatedOn = DateTime.UtcNow,
                Data = "Sample data to log",
                Group = "Group A",
                IdentifierName = "User_ID",
                IdentifierValue = "User-1",
                MessageType = "error",
                Operation = "Edit User",
                Owner = "AppUser"
            };

            logManager.Add(message);

            Console.WriteLine(JsonConvert.SerializeObject(message));
            s1.Stop();

            Console.WriteLine("Completed executing {0} in {1} milliseconds", methodName, s1.ElapsedMilliseconds);
        }

        private static void DoTest2DBLog()
        {
            var s1 = System.Diagnostics.Stopwatch.StartNew();
            s1.Start();
            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            Console.WriteLine("Start executing {0} ...", methodName);

            dynamic settings = new System.Dynamic.ExpandoObject();

            settings.CanAddError = true;
            settings.CanAddWarning = true;
            settings.CanAddInfo = true;

            SimpleLog.Manager logManager = new SimpleLog.Manager(SimpleLog.Constants.LOG_DB, settings);

            SimpleLog.Message message = new SimpleLog.Message()
            {
                CreatedOn = DateTime.UtcNow,
                Data = "Sample data to log",
                Group = "Group A",
                IdentifierName = "User_ID",
                IdentifierValue = "User-1",
                MessageType = "error",
                Operation = "Edit User",
                Owner = "AppUser"
            };

            logManager.Add(message);

            Console.WriteLine(JsonConvert.SerializeObject(message));
            s1.Stop();

            Console.WriteLine("Completed executing {0} in {1} milliseconds", methodName, s1.ElapsedMilliseconds);
        }

        private static void DoTest3TextFileLog()
        {
            var s1 = System.Diagnostics.Stopwatch.StartNew();
            s1.Start();
            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            Console.WriteLine("Start executing {0} ...", methodName);

            dynamic settings = new System.Dynamic.ExpandoObject();
            
            settings.CanAddError = true;
            settings.CanAddWarning = true;
            settings.CanAddInfo = true;

            settings.FileName = SimpleLog.Helper.GenerateFileName("log");

            SimpleLog.Manager logManager = new SimpleLog.Manager(SimpleLog.Constants.LOG_TEXT_FILE, settings);

            for (int i = 1; i <= 10; i++)
            {
                SimpleLog.Message message = new SimpleLog.Message()
                {
                    ID = i,
                    CreatedOn = DateTime.UtcNow,
                    Data = "Sample data to log " + i.ToString(),
                    Group = "Group A",
                    IdentifierName = "User_ID",
                    IdentifierValue = "User-" + i.ToString(),
                    MessageType = "error",
                    Operation = "Edit User",
                    Owner = "AppUser"
                };

                logManager.Add(message);
            }

            s1.Stop();

            Console.WriteLine("Completed executing {0} in {1} milliseconds", methodName, s1.ElapsedMilliseconds);
        }
    }
}
