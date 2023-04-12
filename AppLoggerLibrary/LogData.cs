using System;

namespace AppLoggerLibrary
{
    public class LogData
    {
        private DateTime _createdAt;
        private string categoryName;
        private string message;
        private string stackTrace;
        private TimeSpan timeTaken;

        public LogData(string categoryName, string message, string stackTrace, TimeSpan timeTaken)
        {
            _createdAt = DateTime.Now;
            this.categoryName = categoryName;
            this.message = message;
            this.stackTrace = stackTrace;
            this.timeTaken = timeTaken;
        }

        public override string ToString()
        {
            string log = _createdAt.ToString("dddd, dd/MM/yyyy hh:mm:ss") + $"\nTime Elapsed : {timeTaken}\n{categoryName} > {message}\n{stackTrace}\n\n";
            return log;
        }
    }
}
