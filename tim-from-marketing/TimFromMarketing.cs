static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        var idPrefix = id.HasValue ? $"[{id}]" + " - " : string.Empty;
        var departmentSuffix = string.IsNullOrWhiteSpace(department) 
            ? "OWNER" 
            : department.ToUpperInvariant();

        return $"{idPrefix}{name} - {departmentSuffix}";
    }
}
