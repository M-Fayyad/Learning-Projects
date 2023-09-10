namespace MathExpressionEvaluator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Pleace enter math expression: ");
                var input = Console.ReadLine();
                var expr = ExpressionParser.Parse(input);
                Console.WriteLine($"Left side {expr.LeftSideOperand}, operatoin {expr.Operation}, Right side {expr.RightSideOperand}");
                Console.WriteLine($"{input} = {EvaluateExpression(expr)}");
            }
        }

        private static object EvaluateExpression(MathExpression expr)
        {
            var result = expr.Operation switch
            {
                MathOperation.Addition => expr.LeftSideOperand + expr.RightSideOperand,
                MathOperation.Subtraction => expr.LeftSideOperand - expr.RightSideOperand,
                MathOperation.Muliplication => expr.LeftSideOperand * expr.RightSideOperand,
                MathOperation.Division => expr.LeftSideOperand / expr.RightSideOperand,
                MathOperation.Modulus => expr.LeftSideOperand % expr.RightSideOperand,
                MathOperation.Power => Math.Pow(expr.LeftSideOperand, expr.RightSideOperand),
                MathOperation.Sin => Math.Sin(expr.RightSideOperand),
                MathOperation.Cos => Math.Cos(expr.RightSideOperand),
                MathOperation.Tan => Math.Tan(expr.RightSideOperand)
            };
            return result;
        }
    }
}