using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressionEvaluator
{
    public static class ExpressionParser
    {
        private const string MathSympols = "+*/%^";
        public static MathExpression Parse(string input)
        {
            input = input.Trim();
            var expr = new MathExpression();

            string token = "";

            bool leftSideInitialized = false;

            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];

                if (char.IsDigit(currentChar))
                {
                    token += currentChar;
                }
                else if (MathSympols.Contains(currentChar))
                {
                    expr.LeftSideOperand = double.Parse(token);
                    expr.Operation = ParseMathOperation(currentChar.ToString());
                    token = "";
                }
                else if (currentChar == '-')
                {

                }
                else if (char.IsLetter(currentChar))
                {
                    token += currentChar;
                }
                else if (currentChar == ' ')
                {
                    if (!leftSideInitialized)
                    {
                        expr.LeftSideOperand = double.Parse(token);
                    }
                    else if (expr.Operation == MathOperation.None)
                    {
                        expr.Operation = ParseMathOperation(token);
                    }
                    token= "";
                }
            }
            return expr;
        }

        private static MathOperation ParseMathOperation(string operation)
        {
            switch (operation.ToLower())
            {
                case "+":
                    return MathOperation.Addition;
                case "*":
                    return MathOperation.Muliplication;
                case "/":
                    return MathOperation.Division;
                case "%":
                case "mod":
                    return MathOperation.Modulus;
                case "^":
                case "pow":
                    return MathOperation.Power;
                case "sin":
                    return MathOperation.Sin;
                case "cos":
                    return MathOperation.Cos;
                case "tan":
                    return MathOperation.Tan;
                default:
                    return MathOperation.None;

            }
        }
    }
}
