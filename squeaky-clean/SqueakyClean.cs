using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        if (identifier.Length == 0)
        {
            return string.Empty;
        }

        var result = new StringBuilder();
        bool toUpperNext = false;

        foreach (char c in identifier)
        {
            if (c == ' ')
            {
                result.Append('_');
                continue;
            }

            if (char.IsControl(c))
            {
                result.Append("CTRL");
                continue;
            }

            if (c == '-')
            {
                toUpperNext = true;
                continue;
            }

            char current = c;

            if (toUpperNext)
            {
                current = char.ToUpper(current);
                toUpperNext = false;
            }

            if (!char.IsLetter(current))
            {
                continue;
            }

            if (current >= 'α' && current <= 'ω')
            {
                continue;
            }

            result.Append(current);
        }

        return result.ToString();
    }
}
