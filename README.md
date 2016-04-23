Simple_Log
==========

Description
-----------
Simple log is a project to log data to MS SQL DB or Text File or Console or any combinations of the previous media.

Samples
-------

###Console
<pre>
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

Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(message));
s1.Stop();

Console.WriteLine("Completed executing {0} in {1} milliseconds", methodName, s1.ElapsedMilliseconds);
</pre>

