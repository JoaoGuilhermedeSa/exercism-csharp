public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        if (null == operation)
        {
            throw new ArgumentNullException("Invalid operation", "operation");
        }
        if (string.IsNullOrEmpty(operation))
        {
            throw new ArgumentException("Invalid operation", "operation");
        }
        if (operand2 == 0 && operation == "/")
        {
            return "Division by zero is not allowed.";
        }

        int result = operation switch
        {
            "+" => operand1 + operand2,
            "*" => operand1 * operand2,
            "/" => operand1 / operand2,
            _   => throw new ArgumentOutOfRangeException("Unexpected operation")
        };

        return $"{operand1} {operation} {operand2} = {result}";
    }
}
