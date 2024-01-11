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
    public class PolynomialCalculusTests
    {
        [TestMethod()]
        public void SetPolynomialTest()
        {
            PolynomialCalculus poly1 = new PolynomialCalculus();
            Assert.IsTrue(poly1.IsValidPolynomial("1 0 -2.1 -1 5 12"));
        }

        [TestMethod()]
        public void IsValidPolynomialTest()
        {
            PolynomialCalculus poly2 = new PolynomialCalculus();
            Assert.IsTrue(poly2.IsValidPolynomial("1 0 -2.1 -1 5 12"));
        }

        [TestMethod()]
        public void GetPolynomialTest()
        {
            PolynomialCalculus poly3 = new PolynomialCalculus("1 0 -2.1 -1 5 12");
            Assert.AreEqual("x^5 - 2.1x^3 - x^2 + 5x + 12", poly3.GetPolynomial());
        }

        [TestMethod()]
        public void EvaluatePolynomialTest()
        {
            PolynomialCalculus poly4 = new PolynomialCalculus("1 0 -2.1 -1 5 12");
            Assert.AreEqual(905.6, poly4.EvaluatePolynomial(4));
        }

        [TestMethod()]
        public void EvaluatePolynomialDerivativeTest()
        {
            PolynomialCalculus poly6 = new PolynomialCalculus("1 0 -2.1 -1 5 12");
            Assert.AreEqual(347.3, poly6.EvaluatePolynomialDerivative(3));
        }

        [TestMethod()]
        public void EvaluatePolynomialIntegralTest()
        {
            PolynomialCalculus poly7 = new PolynomialCalculus("1 0 -2.1 -1 5 12");
            Assert.AreEqual(2343.0666666666666, poly7.EvaluatePolynomialIntegral(1, 5));
        }

        // ADDITIONAL TEST CASES
        [TestMethod()]
        public void GetPolynomialTest2()
        {
            PolynomialCalculus poly12 = new PolynomialCalculus("0 0 -.55 13 0");
            Assert.AreEqual("-0.55x^2 + 13x", poly12.GetPolynomial());
        }

        [TestMethod()]
        public void GetPolynomialTest3()
        {
            PolynomialCalculus poly13 = new PolynomialCalculus("-123.456");
            Assert.AreEqual("-123.456", poly13.GetPolynomial());
        }

        [TestMethod()]
        public void GetPolynomialTest4()
        {
            PolynomialCalculus poly14 = new PolynomialCalculus("0");
            Assert.AreEqual("", poly14.GetPolynomial());
        }

        [TestMethod()]
        public void GetPolynomialTest5()
        {
            PolynomialCalculus poly15 = new PolynomialCalculus("-1 -1 -1 -1");
            Assert.AreEqual("-x^3 - x^2 - x - 1", poly15.GetPolynomial());
        }

        [TestMethod()]
        public void EvaluatePolynomialTest2()
        {
            PolynomialCalculus poly22 = new PolynomialCalculus("7 0 1 13 0");
            Assert.AreEqual(0, poly22.EvaluatePolynomial(0));
        }

        [TestMethod()]
        public void EvaluatePolynomialTest3()
        {
            PolynomialCalculus poly23 = new PolynomialCalculus("7 0 1 13 0");
            Assert.AreEqual(13120015, poly23.EvaluatePolynomial(-37));
        }

        [TestMethod()]
        public void EvaluatePolynomialDerivativeTest2()
        {
            PolynomialCalculus poly32 = new PolynomialCalculus("-1 2 0 0 0 0");
            Assert.AreEqual(-621, poly32.EvaluatePolynomialDerivative(-3));
        }

        [TestMethod()]
        public void EvaluatePolynomialDerivativeTest3()
        {
            PolynomialCalculus poly33 = new PolynomialCalculus("0");
            Assert.AreEqual(0, poly33.EvaluatePolynomialDerivative(100));
        }

        [TestMethod()]

        public void EvaluatePolynomialDerivativeTest4()
        {
            PolynomialCalculus poly34 = new PolynomialCalculus("0");
            Assert.AreEqual(0, poly34.EvaluatePolynomialDerivative(-100));
        }

        [TestMethod()]
        public void EvaluatePolynomialIntegralTest2()
        {
            PolynomialCalculus poly42 = new PolynomialCalculus("0 0 -.55 13 0");
            Assert.AreEqual(192.16666666666666, poly42.EvaluatePolynomialIntegral(-3, 7));
        }

        [TestMethod()]

        public void EvaluatePolynomialIntegralTest3()
        {
            PolynomialCalculus poly43 = new PolynomialCalculus("1 0 0 0");
            Assert.AreEqual(1620, poly43.EvaluatePolynomialIntegral(3, 9));
        }

        [TestMethod()]
        public void EvaluatePolynomialIntegralTest4()
        {
            PolynomialCalculus poly44 = new PolynomialCalculus("0");
            Assert.AreEqual(0, poly44.EvaluatePolynomialIntegral(-3, 7));
        }

        [TestMethod]
        public void IsValidPolynomialTest2()
        {
            PolynomialCalculus pc5 = new PolynomialCalculus();
            Assert.IsFalse(pc5.IsValidPolynomial(""));
        }

        [TestMethod]
        public void IsValidPolynomialTest3()
        {
            PolynomialCalculus pc5 = new PolynomialCalculus();
            Assert.IsFalse(pc5.IsValidPolynomial("abc"));
        }

        [TestMethod]
        public void IsValidPolynomialTest4()
        {
            PolynomialCalculus pc5 = new PolynomialCalculus();
            Assert.IsFalse(pc5.IsValidPolynomial("0 . 1 8 8 0 9 "));
        }

        [TestMethod]
        public void IsValidPolynomialTest5()
        {
            PolynomialCalculus pc5 = new PolynomialCalculus();
            Assert.IsFalse(pc5.IsValidPolynomial("6/9 4"));
        }

        [TestMethod]
        public void IsValidPolynomialTest6()
        {
            PolynomialCalculus pc5 = new PolynomialCalculus();
            Assert.IsFalse(pc5.IsValidPolynomial("1 4"));
        }

        [TestMethod]
        public void IsValidPolynomialTest7()
        {
            PolynomialCalculus pc5 = new PolynomialCalculus();
            Assert.IsTrue(pc5.IsValidPolynomial("-2 -3.547 0 0"));
        }

        [TestMethod]
        public void GetAllRootsTest166()
        {
            PolynomialCalculus pc4 = new PolynomialCalculus("1 6 6");
            List<double> actual = pc4.GetAllRoots(0.000001);

            double result1 = Math.Round(-3 - Math.Sqrt(3), 4);
            double result2 = Math.Round(-3 + Math.Sqrt(3), 4);

            Assert.AreEqual(result1, actual[0]);
            Assert.AreEqual(result2, actual[1]);
        }

        [TestMethod]
        public void GetAllRootsTest5()
        {
            PolynomialCalculus pc4 = new PolynomialCalculus("1 6 6 8 9");
            List<double> actual = pc4.GetAllRoots(0.000001);

            double result1 = -5.057;
            double result2 = -1.18;
            foreach (var item in actual)
            {
                Assert.IsTrue(isNear(item, result1) || isNear(item, result2));
            }
        }

        [TestMethod]
        public void GetAllRootsTest4()
        {
            PolynomialCalculus pc4 = new PolynomialCalculus("1 0 6 -51 -9");
            List<double> actual = pc4.GetAllRoots(0.000001);

            double result1 = -0.173;
            double result2 = 3.248;
            foreach (var item in actual)
            {
                Assert.IsTrue(isNear(item, result1) || isNear(item, result2));
            }
        }

        [TestMethod]
        public void GetAllRootsTestThrowException()
        {
            PolynomialCalculus pc4 = new PolynomialCalculus("");
            try
            {
                List<double> actual = pc4.GetAllRoots(0.000001);
                Assert.Fail();
            }
            catch (InvalidOperationException e)
            {
                // expected
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void GetPolynomialException()
        {
            PolynomialCalculus poly15 = new PolynomialCalculus("");
            try
            {
                poly15.GetPolynomial();
                Assert.Fail();
            }
            catch (InvalidOperationException e)
            {
                // expected
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void EvaluatePolynomialException()
        {
            PolynomialCalculus poly25 = new PolynomialCalculus("");
            try
            {
                poly25.EvaluatePolynomial(5);
                Assert.Fail();
            }
            catch (InvalidOperationException e)
            {
                // expected
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void EvaluatePolynomialDerivativeException()
        {
            PolynomialCalculus poly35 = new PolynomialCalculus("");
            try
            {
                poly35.EvaluatePolynomialDerivative(5);
                Assert.Fail();
            }
            catch (InvalidOperationException e)
            {
                // expected
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void EvaluatePolynomialIntegralException()
        {
            PolynomialCalculus poly45 = new PolynomialCalculus("");
            try
            {
                poly45.EvaluatePolynomialIntegral(1,5);
                Assert.Fail();
            }
            catch (InvalidOperationException e)
            {
                // expected
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        private bool isNear(double x, double y) // helper method
        {
            return Math.Abs(x - y) <= 0.001;
        }
    }
}
