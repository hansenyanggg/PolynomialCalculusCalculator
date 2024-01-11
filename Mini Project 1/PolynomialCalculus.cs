//MP1  
//This file contains the PolynomialCalculus class.

//You should implement the requesed methods.


using System;
using System.Collections.Generic;
using System.Text;

namespace MP1
{
    public class PolynomialCalculus
    {
        List<double> coefficientList = new List<double>(); //the only field of this class

        // The following two constructors are used for unit testing.
        public PolynomialCalculus() //Needed for unit testing and for Main(). Do not remove or modify.
        {
            // Default constructor has an empty body
        }
        public PolynomialCalculus(string testInput) //Needed for unit testing. Do not remove or modify.
        {
            string[] coefficients = testInput.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in coefficients)
            {
                coefficientList.Add(Convert.ToDouble(item));
            }
        }

        /// <summary>
        /// Prompts the user for the coefficients of a polynomial, and sets the 
        /// the coefficientList field of the object.
        /// The isValidPolynomial method is used to check for the validity
        /// of the polynomial entered by the user, otherwise the field must 
        /// not change.
        /// The acceptable format of the coefficients received from the user is 
        /// a series of numbers (one for each coefficient) separated by spaces.
        /// All coefficients values must be entered even those that are zero.
        /// </summary>
        /// <returns>True if the polynomial is succeffully set, false otherwise.</returns>
        public bool SetPolynomial()
        {
            Console.WriteLine("\nEnter the coeficients for the polynomial, separated by a space (descending order).");
            Console.WriteLine("Example: Enter 1.13 0 -3 1 0 for the polynomial 1.13x^4 - 3x^2 + x");
            string coefficientEntry = Console.ReadLine().Trim();

            //to implement

            if (IsValidPolynomial(coefficientEntry))
            {
                List<string> polynomiallist = new List<String>(coefficientEntry.Split(" "));

                for (int i = 0; i < polynomiallist.Count(); i++) //remove all elements of list which only contains " "
                {
                    if (polynomiallist[i] == "")
                    {
                        polynomiallist.RemoveAt(i);
                    }
                }

                foreach (string item in polynomiallist)
                {
                    coefficientList.Add(Convert.ToDouble(item));
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the passed polynomial string is valid.
        /// The acceptable format of the coefficient string is a series of 
        /// numbers (one for each coefficient) separated by spaces. 
        /// Any number of extra spaces is allowed.
        /// </summary>
        /// <example>
        /// Examples of valid strings: 
        ///       "1 2 3", or " 2   3.5 0  ", or "-2 -3.547 0 0", or "0 .1 -1"
        /// Examples of invalid strings: 
        ///       "3 . 5", or "2x^2+1", or "a b c", or "3 - 5", or "1/2 2", or ""
        /// </example>
        /// <param name="polynomial">
        /// A string containing the coefficient of a polynomial. The first value is the
        /// highest order, and all coefficients exist (even 0's).
        /// </param>
        /// <returns>True if a valid polynomial, false otherwise.</returns>
        public bool IsValidPolynomial(string polynomial)
        {
            if (polynomial == "") //so there is no empty string
            {
                return false;
            }

            List<string> polynomiallist = new List<string>(polynomial.Split(" "));

            for (int i = 0; i < polynomiallist.Count; i++)
            {
                if (polynomiallist[i] == "")
                {
                    polynomiallist.RemoveAt(i);
                }
            }

            if (polynomiallist.Count < 3) //the list contains more than 3 variables
            {
                return false;
            }

            for (int i = 0; i < polynomiallist.Count; i++)
            {

                double value;
                bool isdouble = double.TryParse(polynomiallist[i], out value);

                if (isdouble == false)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns a string representing this polynomial.
        /// </summary>
        /// <returns>
        /// A string containing the polynomial in the format:
        /// a_nx^n +- a_n_1x^n_1 +- ... +- a1x +- a0
        /// Formatting rules:
        /// The +- operator will be + if the associated coefficient is positive, and - if negative.
        /// There is a space on either side of the binary operator.
        /// Do not display the associated term of a coefficient if it is 0.
        /// Do not display a coefficient if it is 1, except for a0.
        /// Do not display the power of x, if it is 1.
        /// If all coefficients are 0, then it returns "0".
        /// <example>
        /// For a user input "1 1 1", the method returns "x^2 + x + 1"
        /// For a user input "-1 -1 -1", the method returns "-x^2 - x - 1"
        /// For a user input "3 2 1", the method returns "3x^2 + 2x + 1"
        /// For a user input "0", the method returns "0"
        /// For a user input "-123.456", the method returns "-123.456"
        /// For a user input "-1.3 0 -5", the method returns "-1.3x^2 - 5"
        /// For a user input "0 0 -.55 13 0", the method returns "-0.55x^2 + 13x"
        /// For a user input "1 0 -2.1 -1 5 12", the method returns "x^5 - 2.1x^3 - x^2 + 5x + 12"
        /// </example>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the coefficientList field is empty. 
        /// Exception message used: "No polynomial is set."
        /// </exception>
        public string GetPolynomial()
        {
            int power = coefficientList.Count - 1;
            int counter = 0; // index of the printed polynomial (disregard 0)
            StringBuilder sb = new StringBuilder();

            if (coefficientList.Count == 0) // exception
            {
                throw new InvalidOperationException("No polynomial is set");
            }

            for (int i = 0; i < coefficientList.Count; i++)
            {
                if (coefficientList[i] == 0) // excluding 0
                {
                }

                else if (coefficientList[i] < 0) // for negative number
                {
                    if (counter == 0)
                    {
                        sb.Append($"-");
                    }
                    else
                    {
                        sb.Append($" - ");
                    }
                    // value
                    if (Math.Abs(coefficientList[i]) != 1 || i == coefficientList.Count - 1) // not showing coefficient 1 when there is variable
                    {
                        sb.Append(Math.Abs(coefficientList[i]));
                    }
                    sb.Append(Power(power));
                    counter++;
                }

                else // for positive number
                {
                    if (counter > 0)
                    {
                        sb.Append($" + ");
                    }
                    if (coefficientList[i] != 1 || i == coefficientList.Count - 1) // not showing coefficient 1 when there is variable
                    {
                        sb.Append(Math.Abs(coefficientList[i]));
                    }
                    sb.Append(Power(power));
                    counter++;
                }
                power--;
            }
            static string Power(int pow) // returning variable x with its power
            {
                string result;
                if (pow > 1)
                {
                    result = ($"x^{pow}");
                }
                else if (pow == 1)
                {
                    result = ("x");
                }
                else
                {
                    result = ("");
                }
                return result;
            }
            return sb.ToString();
        }

        /// <summary>
        /// Evaluates this polynomial at the x passed to the method.
        /// </summary>
        /// <param name="x">The x at which we are evaluating the polynomial.</param>
        /// <returns>The result of the polynomial evaluation.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the coefficientList field is empty. 
        /// Exception message used: "No polynomial is set."
        /// </exception>
        public double EvaluatePolynomial(double x)
        {
            double result = 0;
            double power = coefficientList.Count - 1;

            if(coefficientList.Count == 0) // exception
            {
                throw new InvalidOperationException("No polynomial is set");
            }
            for (int i = 0; i < coefficientList.Count; i++) // calculation
            {
                result += coefficientList[i] * Math.Pow(x, power);
                power--;
            }
            return result;
        }

        /// <summary>
        /// Finds a root of this polynomial using the provided guess.
        /// </summary>
        /// <param name="guess">The initial value for the Newton method.</param>
        /// <param name="epsilon">The desired accuracy: stops when |f(result)| is
        /// less than or equal epsilon.</param>
        /// <param name="iterationMax">A max cap on the number of iterations in the
        /// Newton-Raphson method. This is to also guarantee no infinite loops.
        /// If this iterationMax is reached, a double.NaN is returned.</param>
        /// <returns>
        /// The root found using the Netwon-Raphson method. 
        /// A double.NaN is returned if a root cannot be found.
        /// The return value is rounded to have 4 digits after the decimal point.
        /// </returns>
        public double NewtonRaphson(double guess, double epsilon, int iterationMax)
        {
            int count;
            double x = guess;

            for (count = 0; Math.Abs(EvaluatePolynomial(x)) > epsilon && count < iterationMax; count++)
            {
                x -= EvaluatePolynomial(x) / EvaluatePolynomialDerivative(x);
            }

            if (count == iterationMax)
            {
                return double.NaN;
            }

            return Math.Round(x, 4); //4 decimal places
        }

        /// <summary>
        /// Calculates and returns all unique real roots of this polynomial 
        /// that can be found using the NewtonRaphson method. 
        /// The method uses all initial guesses between -50 and 50 (inclusive) with 
        /// steps of 0.5 to find all unique roots it can find. 
        /// A root is considered unique, if there is no root already found 
        /// that is within an accuracy level of 0.001 (since we rounded the roots).
        /// Uses 10 as the max number of iterations used by Newton-Raphson method.
        /// </summary>
        /// <param name="epsilon">The desired accuracy used for NewtonRaphson.</param>
        /// <returns>A list containing all the unique roots that the method finds.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the coefficientList field is empty. 
        /// Exception message used: "No polynomial is set."
        /// </exception>
        public List<double> GetAllRoots(double epsilon)
        {
            if (coefficientList.Count == 0)  // exception
            {
                throw new InvalidOperationException("No polynomial is set"); //throw exception if cofficient list is empty
            }

            HashSet<double> set1 = new HashSet<double>();

            for (double i = -50; i <= 50; i = i + 0.5)
            {
                double x = NewtonRaphson(i, epsilon, 10); // x equals to approx for guess i, max iteration 10

                if (!double.IsNaN(x))
                {
                    bool isUnique = true; //check if x is unique based on spec
                    foreach (var item in set1)
                    {
                        double difference = Math.Abs(item - x);
                        if (difference <= 0.00101)
                        {
                            isUnique = false;
                            break;
                        }
                    }
                    if (isUnique)
                    {
                        set1.Add(x);
                    }
                }

            }

            List<double> roots = new List<double>();

            foreach (double x in set1)
            {
                roots.Add(x);
            }

            return roots;
        }

        /// <summary>
        /// Evaluates the 1st derivative of this polynomial at x (passed to the method).
        /// The method uses the exact numerical technique, since it is easy to obtain the 
        /// derivative of a polynomial.
        /// </summary>
        /// <param name="x">The x at which we are evaluating the polynomial derivative.</param>
        /// <returns>The result of the polynomial derivative evaluation.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the coefficientList field is empty.
        /// Exception message used: "No polynomial is set."
        /// </exception>
        public double EvaluatePolynomialDerivative(double x)
        {
            double derivative = 0;
            double power = coefficientList.Count - 1;

            if(coefficientList.Count == 0) // exception
            {
                throw new InvalidOperationException("No polynomial is set");
            }
            for (int i = 0; i < coefficientList.Count - 1; i++) // calculation
            {
                derivative += power * coefficientList[i] * Math.Pow(x, --power);
            }
            return derivative;
        }

        /// <summary>
        /// Evaluates the definite integral of this polynomial from a to b.
        /// The method uses the exact numerical technique, since it is easy to obtain the 
        /// indefinite integral of a polynomial.
        /// </summary>
        /// <param name="a">The lower limit of the integral.</param>
        /// <param name="b">The upper limit of the integral.</param>
        /// <returns>The result of the integral evaluation.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the coefficientList field is empty.
        /// Exception message used: "No polynomial is set."
        /// </exception>
        public double EvaluatePolynomialIntegral(double a, double b)
        {
            if(coefficientList.Count == 0) // exception
            {
                throw new InvalidOperationException("No polynomial is set");
            }
            double integral = 0;
            for (int i = 0; i < coefficientList.Count; i++) // calculation
            {
                double power = coefficientList.Count - 1 - i;
                integral += (coefficientList[i] / ++power) * Math.Pow(b, power) - (coefficientList[i] / power) * Math.Pow(a, power);
            }
            return integral;
        }
    }
}