enum LogLevel : int
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
 }

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        if (string.IsNullOrWhiteSpace(logLine))
            return LogLevel.Unknown;

        int start = logLine.IndexOf('[') + 1;
        int end = logLine.IndexOf(']');
        if (start < 1 || end <= start)
            return LogLevel.Unknown;

        string code = logLine.Substring(start, end - start);

        return code switch
        {
            "TRC" => LogLevel.Trace,
            "DBG" => LogLevel.Debug,
            "INF" => LogLevel.Info,
            "WRN" => LogLevel.Warning,
            "ERR" => LogLevel.Error,
            "FTL" => LogLevel.Fatal,
            _ => LogLevel.Unknown
        };
    }


    public static string OutputForShortLog(LogLevel level, string message)
    {
        return $"{(int)level}:{message}";
    }
}
