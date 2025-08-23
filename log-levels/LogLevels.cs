static class LogLine
{
    public static string Message(string logLine)
    {
        return logLine.Substring(logLine.IndexOf(":") + 1).Trim();
    }

    public static string LogLevel(string logLine)
    {
        int start = logLine.IndexOf("[") + 1;
        int end = logLine.IndexOf("]");
        
        return logLine.Substring(start, end - start).ToLower();
    }

    public static string Reformat(string logLine)
    {
        string message = Message(logLine);
        string level = LogLevel(logLine);

        return $"{message} ({level})";
    }
}
