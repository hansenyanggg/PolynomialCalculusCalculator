//MP1 
//This file contains the Arithmethic class.

//You should implement the requesed methods.

using MP1;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace MP1
{

    public class Arithmetic
    {
        /// <summary>
        /// Use this method as is.
        /// It is called by Main and is used to get an expression from console.
        /// The method calls the EvaluateExpression and OutputExpression methods. 
        /// </summary>
        /// <returns>
        /// A string formed from the formatted expression and the evaluation 
        /// result, or the error message "Invalid expression".
        /// </returns>
        public static string BasicArithmetic()
        {
            Console.WriteLine();
            Console.WriteLine("Basic arithmetic opertions with + - * / ^");
            Console.WriteLine("Enter an expression:");
            string expression = Console.ReadLine().Trim();

            double result = EvaluateExpression(expression);
            if (double.IsNaN(result))
                return "Invalid expression";
            return $"{OutputExpression(expression)} = {result}";
        }

        /// <summary>
        /// Return the numerical evaluation of the arithmetic expression passed to it.
        /// 
        /// Prcedence of the operators (from highest to lowest):
        ///    parenthesis
        ///    power
        ///    multiplication and division (equal precedence)
        ///    addition and subtraction (equal precedence)
        /// An inner parentheses has higher precedence.
        /// * and / have the same precedence.
        /// + and - have the same precedence.
        /// 
        /// All rithmetic operators are left-associative.
        /// 
        /// - can be used as the negative sign as well as subtraction.
        /// There must not be any space between the negative sign and the number.
        /// + is only used for addition (i.e. is not allowed to be used as a positive sign)
        /// </summary>
        /// <param name="expression">
        /// The user input string (with Trim() already applied)
        /// </param>
        /// <returns>
        /// Returns the result of a successful evaluation of the expression,
        /// or double.NaN if the expression is not valid.
        /// </returns>
        /// <example>
        /// If the user expression is "2.1 + 3" or "2.1+ 3" or "2.1 +3", 
        /// then the method returns 5.1
        /// If the user expression is "(8 + -3) * (2 ^ 5)" or "(8 + -3) * 2 ^ 5", 
        /// then the method returns 160 
        /// If the user expression is "2 + ((3 * 2) * 5)" it returns 32 
        /// A 0 before decimal point is not mandatory, so .52 is equivalent to 0.52
        /// Any extra spaces are fine, so if the user enters "  2   ^ 3 ", then 
        /// the method returns 8
        /// If the user input is any incorrect or unbalanced expression, for example,
        /// "4 5" or "4 +" or "+4" or " (4 + 5" or "4 + 5 * 4)", then the method 
        /// returns double.NaN
        /// </example>
        public static double EvaluateExpression(string expression)
        {
            if (!isValidExpression(expression))
                return double.NaN;


            Queue<string> RPNQ = new Queue<string>(RPN(expression));

            return EvaluateRPN(RPNQ);

        }

        /// <summary>
        /// Returns a modestly cleaned up version of the input expression 
        /// </summary>
        /// <param name="expression">
        /// The user input string (with Trim() already applied)
        /// </param>
        /// <returns>
        /// Returns a string that is rather similar to the expression the user entered, with: 
        /// All extra spaces are removed, but it is ensured that a space is on the either sides of any binary arithmetic operator.
        /// For any negative number being subtracted from another number, it is changed to the addition with its absolute value.
        /// for any negative number being added to another number, it is changed to the subtraction of its absolute value.
        /// </returns>
        /// <example>
        /// If the expression is "2.1 + 3" or "2.1+3" or "2.1+ 3" or "2.1 +3" or "2.1 +    3" 
        ///       then the method returns "2.1 + 3".
        /// If the expression is "2.1 - 3" or "2.1-3" or "2.1- 3" or "2.1 -3" or "2.1 -    3" 
        ///       then the method returns "2.1 - 3".
        /// If the expression is "2.1 + -3" or "2.1+-3" or "2.1 - 3"  
        ///       then the method returns "2.1 - 3".
        /// If the expression is "2.1 - -3" or "2.1--3" or "2.1 + 3"  
        ///       then the method returns "2.1 + 3".
        /// If the expression is "2.1 *   -3" or "2.1*-3"  
        ///       then the method returns "2.1 * -3".
        /// If the expression is "( 2 +  3 )   * 2 ^ 5"
        ///       it returns "(2 + 3) * 2 ^ 5" 
        /// If the expression is "2 + ( ( 3 * 2) *  5)" it returns "2 + ((3 * 2) * 5)" 
        /// Any extra spaces are fine, so if the original user input is "  2   ^ 3 " then 
        ///     the method returns "2 ^ 3".
        /// </example>

        public static string OutputExpression(string expression)
        {
            string expressionSb = Clean(expression);


            StringBuilder expression2Sb = new StringBuilder();

            for (int i = 0; i < expressionSb.Length; i++)
            {
                if (expressionSb[i] == '/' || expressionSb[i] == '*' || expressionSb[i] == '^' || expressionSb[i] == '+')
                {
                    expression2Sb.Append(' ');
                    expression2Sb.Append(expressionSb[i]);
                    expression2Sb.Append(' ');
                }
                else if (expressionSb[i] == '.')
                {
                    if (i == 0 || expressionSb[i - 1] != '0')
                    {
                        expression2Sb.Append('0');
                        expression2Sb.Append('.');
                    }
                    else
                    {
                        expression2Sb.Append('.');
                    }
                }

                else if (expressionSb[i] == '-')
                {
                    if (expressionSb[i - 1] == '*' || expressionSb[i - 1] == '/' || expressionSb[i - 1] == '^')
                        expression2Sb.Append('-');
                    else
                    {
                        expression2Sb.Append(' ');
                        expression2Sb.Append('-');
                        expression2Sb.Append(' ');
                    }


                }
                else expression2Sb.Append(expressionSb[i]);

            }
            return expression2Sb.ToString();

        }

        //You may add helper methods below here. Follow the specs and document well.


        /// <summary>
        /// Removes spaces
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>expression with no spaces</returns>
        public static string noSpaces(string expression)
        {
            StringBuilder expressionSb = new StringBuilder();
            for (int i = 0; i < expression.Length; i++)
            {


                if (expression[i] != ' ')
                    expressionSb.Append(expression[i]);

            }
            return expressionSb.ToString();
        }
        /// <summary>
        /// Convters +- to - and -- to + 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>cleaned expression</returns>
        public static string Clean(string expression)
        {


            expression = noSpaces(expression);
            bool plusMinus = false;
            bool minusMinus = false;
            StringBuilder expression2Sb = new StringBuilder();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '+')
                {
                    if (expression[i + 1] == '-')
                    {
                        expression2Sb.Append('-');
                        plusMinus = true;

                    }
                    else
                    {
                        expression2Sb.Append('+');
                    }


                }
                else if (expression[i] == '-')
                {
                    if (expression[i + 1] == '-')
                    {
                        expression2Sb.Append('+');
                        minusMinus = true;
                    }
                    else if (plusMinus == false && minusMinus == false)
                    {
                        expression2Sb.Append('-');

                    }
                    else
                    {
                        plusMinus = false;
                        minusMinus = false;
                    }
                }
                else
                    expression2Sb.Append(expression[i]);

            }
            return expression2Sb.ToString();
        }

        /// <summary>
        /// Determines if expression is valid expression.
        /// Exception is order of parenthesis. 
        /// This is validated in OutputExpression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>true if valid, false otherwise</returns>
        public static bool isValidExpression(string expression)
        {
            string expression2 = Clean(expression);
            //Ensures even number of parentheses
            int sum = 0;
            foreach (char c in expression2)
            {
                if (c == '(')
                    sum++;
                else if (c == ')')
                    sum--;
            }
            if (sum != 0) return false;

            //Ensures all parts of expression are numbers or operations
            foreach (char c in expression2)
            {
                if (!Char.IsDigit(c) && c != '*' && c != '/' && c != '-' && c != '+' && c != '^' && c != '.' && c != '(' && c != ')')
                    return false;
            }
            //Ensures operations aren't inputed back to back (eg. 2++3 is not valid)
            for (int i = 0; i < expression2.Length - 1; i++)
                if (!Char.IsDigit(expression2[i]) && expression[i] != ')')
                {
                    if (!Char.IsDigit(expression2[i + 1]))
                        return false;
                }
            //Ensures first and last
            if (!Char.IsDigit(expression2[0]) && expression2[0] != '(')
                return false;

            if (!Char.IsDigit(expression2[expression2.Length - 1]) && expression2[expression2.Length - 1] != ')')
                return false;

            return true;

        }

        /// <summary>
        /// Cleans expression to use in RPN.
        /// Seperates all operands and numbers so they can be split in RPN
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Expression where all operands and numbers are seperated by a single space</returns>
        public static string CleanRPN(string expression)
        {
            //expression = noSapces(expression);
            string expressionSb = Clean(expression);
            StringBuilder expression2Sb = new StringBuilder();

            for (int i = 0; i < expressionSb.Length; i++)
            {
                if (expressionSb[i] == '/' || expressionSb[i] == '*' || expressionSb[i] == '^' || expressionSb[i] == '+')
                {
                    expression2Sb.Append(' ');
                    expression2Sb.Append(expressionSb[i]);
                    expression2Sb.Append(' ');
                }
                else if (expressionSb[i] == '.')
                {
                    if (i == 0 || expressionSb[i - 1] != '0')
                    {
                        expression2Sb.Append('0');
                        expression2Sb.Append('.');
                    }
                    else
                    {
                        expression2Sb.Append('.');
                    }
                }

                else if (expressionSb[i] == '(')
                {
                    expression2Sb.Append(expressionSb[i]);
                    expression2Sb.Append(' ');
                }
                else if (expressionSb[i] == ')')
                {
                    expression2Sb.Append(' ');
                    expression2Sb.Append(expressionSb[i]);
                }

                else if (expressionSb[i] == '-')
                {
                    if (!Char.IsDigit(expressionSb[i - 1]) && expressionSb[i - 1] != ')')
                    {
                        expression2Sb.Append(expressionSb[i]);

                    }
                    else
                    {
                        expression2Sb.Append(' ');
                        expression2Sb.Append(expressionSb[i]);
                        expression2Sb.Append(' ');
                    }
                }
                else
                {
                    expression2Sb.Append(expressionSb[i]);

                }

            }
            return expression2Sb.ToString();
        }
        /// <summary>
        /// Converts user input into RPN Queue
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Queue that can be used to evalute RPN. Empty Queue if expression is not valid</returns>
        /// 
        public static Queue<string> RPN(string expression)
        {
            string expression2 = CleanRPN(expression);

            string[] expressionArr = expression2.Split(' ');



            Stack<string> stack = new Stack<string>();
            Queue<string> output = new Queue<string>();

            bool parenthesis = true;
            bool stop = false;

            foreach (string c in expressionArr)
            {

                if (stop == true)
                    break;
                if (c.All(char.IsDigit))
                {
                    output.Enqueue(c);
                }
                else
                {
                    if (stack.Count == 0 && c != "(")
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        switch (c)
                        {
                            case "^":

                                //if (stack.Peek() == "*" || stack.Peek() == "/")
                                //{
                                //    output.Enqueue(c);
                                //    output.Enqueue(stack.Pop());

                                //    Console.WriteLine("Test");
                                //}
                                stack.Push(c);
                                break;
                            case "(":
                                stack.Push(c);
                                parenthesis = false;
                                break;

                            case ")":
                                if (parenthesis == true)
                                {
                                    stop = true;
                                    break;
                                }


                                while (stack.Peek() != "(")
                                {
                                    output.Enqueue(stack.Pop());

                                }
                                stack.Pop();
                                parenthesis = true;
                                break;
                            case "*":
                                if (stack.Peek() == "*" || stack.Peek() == "/")
                                {
                                    output.Enqueue(stack.Pop());
                                    stack.Push(c);
                                }

                                //else if (stack.Peek() == "^")
                                //{
                                //    output.Enqueue(stack.Pop());
                                //    output.Enqueue(c);
                                //}
                                else
                                    stack.Push(c);
                                break;
                            case "/":
                                if (stack.Peek() == "*" || stack.Peek() == "/")
                                {
                                    output.Enqueue(stack.Pop());
                                    stack.Push(c);
                                }
                                else
                                    stack.Push(c);
                                break;
                            case "+":
                                if (output.Count < 2 || stack.Peek() == "(")
                                {
                                    stack.Push(c);
                                }
                                else
                                {
                                    while (stack.Count > 0 && (stack.Peek() != "+" || stack.Peek() != "-"))
                                    {
                                        output.Enqueue(stack.Pop());
                                    }


                                    stack.Push(c);
                                }
                                break;
                            case "-":
                                if (output.Count < 2 || stack.Peek() == "(")
                                {
                                    stack.Push(c);
                                }
                                else
                                {
                                    while (stack.Count > 0 && (stack.Peek() != "+" || stack.Peek() != "-"))
                                    {
                                        output.Enqueue(stack.Pop());
                                    }


                                    stack.Push(c);
                                }
                                break;
                            default:
                                output.Enqueue(c);
                                break;

                        }
                    }


                }
            }
            if (stop == true)
            {
                Queue<string> error = new Queue<string>();
                return error;
            }

            if (stack.Count > 0)
            {
                for (int i = 0; i <= stack.Count; i++)
                {
                    output.Enqueue(stack.Pop());
                }

            }
            return output;
        }

        /// <summary>
        /// Evaluates RPN Queue
        /// </summary>
        /// <param name="output"></param>
        /// <returns>Result of inputed expression. double.NaN if input was not valid</returns>
        public static double EvaluateRPN(Queue<string> output)
        {
            if (output.Count == 0)
                return double.NaN;

            Stack<double> stack = new Stack<double>();
            foreach (string str in output)
            {
                if (double.TryParse(str, out double num) == true)
                {
                    stack.Push(num);
                }

                else
                {
                    Evaluate(stack.Pop(), stack.Pop(), str, out double result);
                    stack.Push(result);

                }
            }
            return stack.Pop();

            double Evaluate(double num1, double num2, in string op, out double result)
            {

                switch (op)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num2 - num1;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        result = num2 / num1;
                        break;
                    case "^":
                        result = Math.Pow(num2, num1);
                        break;
                    default:
                        result = 0;
                        break;
                }


                return result;


            }

        }
    }



}