Simple_Log
==========

Description
-----------
Simple log is a project to log data to MS SQL DB or Text File or Console or any combinations of the previous media.

Samples
-------

###Add Log to Console
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

###Add Log to DB
<pre>
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
</pre>

###Add Log to Text File
<pre>
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
</pre>
