using Microsoft.VisualStudio.TestTools.UnitTesting;
using MP1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP1.Tests
{
    [TestClass()]
    public class ArithmeticTests
    {
        [TestMethod()]
        public void OutputExpressionTest()
        {
            string result = Arithmetic.OutputExpression("2     +    3");

            Assert.AreEqual("2 + 3", result);
        }

        [TestMethod()]
        public void OutputExpressionTest1()
        {
            string result = Arithmetic.OutputExpression("2*-3");

            Assert.AreEqual("2 * -3", result);
        }

        [TestMethod()]
        public void OutputExpressionTest2()
        {
            string result = Arithmetic.OutputExpression("2-3");

            Assert.AreEqual("2 - 3", result);
        }

        [TestMethod()]
        public void OutputExpressionTest3()
        {
            string result = Arithmetic.OutputExpression("2+-3");

            Assert.AreEqual("2 - 3", result);
        }

        [TestMethod()]
        public void OutputExpressionTest4()
        {
            string result = Arithmetic.OutputExpression("2^3 + -4");

            Assert.AreEqual("2 ^ 3 - 4", result);
        }

        [TestMethod()]
        public void OutputExpressionTest5()
        {
            string result = Arithmetic.OutputExpression("4 +   .23");

            Assert.AreEqual("4 + 0.23", result);
        }

        [TestMethod()]
        public void isValidExpressionTest()
        {
            bool result = Arithmetic.isValidExpression("2+/3");

            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void isValidExpressionTest1()
        {
            bool result = Arithmetic.isValidExpression("(2+3)");

            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void isValidExpressionTest2()
        {
            bool result = Arithmetic.isValidExpression("(2+3+)");

            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void RPNTest()
        {
            Queue<string> resultQueue = new Queue<string>(Arithmetic.RPN("2 + 3 * 4"));



            StringBuilder sb = new StringBuilder();
            foreach (string item in resultQueue)
            {
                sb.Append(item);
                sb.Append(" ");
            }

            string resultString = sb.ToString();


            Assert.AreEqual("2 3 4 * + ", resultString);
        }

        [TestMethod()]
        public void RPNTest1()
        {
            Queue<string> resultQueue = new Queue<string>(Arithmetic.RPN("1 + (2 + 3)"));



            StringBuilder sb = new StringBuilder();
            foreach (string item in resultQueue)
            {
                if (item != " ")
                {
                    sb.Append(item);
                    sb.Append(" ");
                }

            }


            string resultString = sb.ToString();


            Assert.AreEqual("1 2 3 + + ", resultString);
        }

        [TestMethod()]
        public void OutputExpressionTest6()
        {
            string result = Arithmetic.OutputExpression("1+(2+3)");

            Assert.AreEqual("1 + (2 + 3)", result);
        }

        [TestMethod()]
        public void RPNTest2()
        {
            Queue<string> resultQueue = new Queue<string>(Arithmetic.RPN("2 * - 3"));



            StringBuilder sb = new StringBuilder();
            foreach (string item in resultQueue)
            {
                sb.Append(item);
                sb.Append(" ");
            }

            string resultString = sb.ToString();


            Assert.AreEqual("2 -3 * ", resultString);
        }

        [TestMethod()]
        public void RPNTest3()
        {
            Queue<string> resultQueue = new Queue<string>(Arithmetic.RPN("2 * ( 2^-3 ) - 2"));



            StringBuilder sb = new StringBuilder();
            foreach (string item in resultQueue)
            {
                sb.Append(item);
                sb.Append(" ");
            }

            string resultString = sb.ToString();


            Assert.AreEqual("2 2 -3 ^ * 2 - ", resultString);
        }

        [TestMethod()]
        public void RPNTest4()
        {
            Queue<string> resultQueue = new Queue<string>(Arithmetic.RPN("( 2 + 0.23 ^ 4 ) / 3"));



            StringBuilder sb = new StringBuilder();
            foreach (string item in resultQueue)
            {
                sb.Append(item);
                sb.Append(" ");
            }

            string resultString = sb.ToString();


            Assert.AreEqual("2 0.23 4 ^ + 3 / ", resultString);
        }

        [TestMethod()]
        public void EvaluateRPNTest()
        {
            double result = Arithmetic.EvaluateRPN(Arithmetic.RPN("2+3"));

            Assert.AreEqual(5, result);
        }

        [TestMethod()]
        public void EvaluateRPNTest1()
        {
            double result = Arithmetic.EvaluateRPN(Arithmetic.RPN("(4 + 3) / 3"));

            Assert.AreEqual((double)7 / 3, result);
        }

        [TestMethod()]
        public void EvaluateRPNTest2()
        {
            double result = Arithmetic.EvaluateRPN(Arithmetic.RPN("4^-2"));

            Assert.AreEqual(0.0625, result);
        }
        [TestMethod()]
        public void EvaluateRPNTest3()
        {
            double result = Arithmetic.EvaluateRPN(Arithmetic.RPN("(4+3) ^ 2"));

            Assert.AreEqual(49, result);
        }

        [TestMethod()]
        public void EvaluateRPNTest4()
        {
            double result = Arithmetic.EvaluateRPN(Arithmetic.RPN("( 2 + -0.23 ^ 4 ) / 3"));

            Assert.AreEqual(0.67, Math.Round(result, 2));
        }

        [TestMethod()]
        public void EvaluateExpressionTest()
        {
            double result = Arithmetic.EvaluateExpression(")1+3(");
            Assert.AreEqual(double.NaN, result);
        }

        [TestMethod()]
        public void EvaluateRPNTest5()
        {
            double result = Arithmetic.EvaluateRPN(Arithmetic.RPN("1*2^(4-1)"));

            Assert.AreEqual(8, result);
        }

        [TestMethod()]
        public void RPNTest5()
        {

            Queue<string> resultQueue = new Queue<string>(Arithmetic.RPN("8 * 3 ^ 5 - 2"));



            StringBuilder sb = new StringBuilder();
            foreach (string item in resultQueue)
            {
                sb.Append(item);
                sb.Append(" ");
            }

            string resultString = sb.ToString();


            Assert.AreEqual("8 3 5 ^ * 2 - ", resultString);
        }
    }
}