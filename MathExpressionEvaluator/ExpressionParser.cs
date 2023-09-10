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
                    if (i == input.Length - 1 && leftSideInitialized)
                    {
                        expr.RightSideOperand = double.Parse(token);
                        break;
                    }
                }
                else if (MathSympols.Contains(currentChar))
                {
                    if (!leftSideInitialized)
                    {
                        expr.LeftSideOperand = double.Parse(token);
                        leftSideInitialized = true;
                    }
                    expr.Operation = ParseMathOperation(currentChar.ToString());
                    token = "";
                }
                else if (currentChar == '-' && i > 0)
                {
                    if (expr.Operation == MathOperation.None)
                    {
                        expr.Operation = MathOperation.Subtraction;
                        expr.LeftSideOperand = double.Parse(token);
                        leftSideInitialized = true;
                        token = "";
                    }
                    else
                        token += currentChar;
                }
                else if (char.IsLetter(currentChar))
                {
                    leftSideInitialized= true;
                    token += currentChar;
                }
                else if (currentChar == ' ')
                {
                    if (!leftSideInitialized)
                    {
                        expr.LeftSideOperand = double.Parse(token);
                        leftSideInitialized = true;
                        token = "";
                    }
                    else if (expr.Operation == MathOperation.None)
                    {
                        expr.Operation = ParseMathOperation(token);
                        token = "";
                    }
                }
                else
                    token += currentChar;
            }
            return expr;
        }

        private static MathOperation ParseMathOperation(string token)
        {
            var operation = token.ToLower() switch
            {
                "+" => MathOperation.Addition,
                "*" => MathOperation.Muliplication,
                "/" => MathOperation.Division,

                "%" => MathOperation.Modulus,
                "mod" => MathOperation.Modulus,

                "^" => MathOperation.Power,
                "pow" => MathOperation.Power,

                "sin" => MathOperation.Sin,
                "cos" => MathOperation.Cos,
                "tan" => MathOperation.Tan,
                _ => MathOperation.None
            };
            return operation;

            //switch (operation.ToLower())
            //{
            //    case "+":
            //        return MathOperation.Addition;
            //    case "*":
            //        return MathOperation.Muliplication;
            //    case "/":
            //        return MathOperation.Division;
            //    case "%":
            //    case "mod":
            //        return MathOperation.Modulus;
            //    case "^":
            //    case "pow":
            //        return MathOperation.Power;
            //    case "sin":
            //        return MathOperation.Sin;
            //    case "cos":
            //        return MathOperation.Cos;
            //    case "tan":
            //        return MathOperation.Tan;
            //    default:
            //        return MathOperation.None;
            //}
        }
    }
}
