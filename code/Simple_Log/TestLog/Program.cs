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
            DoTest1();

            Console.WriteLine("Press anykey to exit ...");
            Console.Read();
        }

        private static void DoTest1()
        {
            var s1 = System.Diagnostics.Stopwatch.StartNew();
            s1.Start();
            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            Console.WriteLine("Start executing {0} ...", methodName);

            SimpleLog.Manager logManager = new SimpleLog.Manager(SimpleLog.Constants.LOG_CONSOLE);

            SimpleLog.Message message = new SimpleLog.Message() {
                CreatedOn = DateTime.UtcNow,
                Data = "Sample data to log",
                Group = "Group A",
                IdentifierName = "User_ID",
                IdentifierValue = "User-1",
                Operation = "Edit User",
                Owner = "AppUser"
            };

            logManager.Add(message);

            Console.WriteLine(JsonConvert.SerializeObject(message));
            s1.Stop();

            Console.WriteLine("Completed executing {0} in {1} milliseconds", methodName, s1.ElapsedMilliseconds);
        }
    }
}
