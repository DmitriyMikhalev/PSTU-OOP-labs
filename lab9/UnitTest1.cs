using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab9;
using System;

namespace lab9
{
    [TestClass]
    public class TestMoneyClass
    {
        [TestMethod]
        public void TestConstructorNonParameters()
        {
            uint expected = 0;
            Money testObject = new Money();

            Assert.AreEqual(expected, testObject.Rubles);
            Assert.AreEqual(expected, testObject.Kopecks);
        }
        [TestMethod]
        public void TestConstructorKopecks()
        {
            uint expectedKopecks = 13;
            uint expectedRubles = 1;
            Money testObject = new Money(kopecks: 113);

            Assert.AreEqual(expectedKopecks, testObject.Kopecks);
            Assert.AreEqual(expectedRubles, testObject.Rubles);
        }
        [TestMethod]
        public void TestConstructorAllParameters()
        {
            uint expectedRubles = 13;
            uint expectedKopecks = 89;
            Money testObject = new Money(rubles: 13, kopecks: 89);

            Assert.AreEqual(expectedRubles, testObject.Rubles);
            Assert.AreEqual(expectedKopecks, testObject.Kopecks);
        }

        [TestMethod]
        public void TestCount()
        {
            uint prevCount = Money.Count;
            Money t1 = new Money();
            Money t2 = new Money(13);
            Money t3 = new Money(13, 13);

            Assert.AreEqual(prevCount + 3, Money.Count);
        }

        [TestMethod]
        public void TestProprtyKopecksIncorrect()
        {
            uint expectedKopecks = 99;
            Money testObj = new Money();
            testObj.Kopecks = 123;

            Assert.AreEqual(expectedKopecks, testObj.Kopecks);
        }
        [TestMethod]
        public void TestProprtyKopecks()
        {
            uint expectedKopecks = 19;
            Money testObj = new Money();
            testObj.Kopecks = 19;

            Assert.AreEqual(expectedKopecks, testObj.Kopecks);
        }
        [TestMethod]
        public void TestProprtyRubles()
        {
            uint expectedRubles = 1305;
            Money testObj = new Money();
            testObj.Rubles = 1305;

            Assert.AreEqual(expectedRubles, testObj.Rubles);
        }

        [TestMethod]
        public void TestCopyObject()
        {
            Money toCopy = new Money(13, 17);
            Money testObject = new Money(toCopy);

            Assert.AreNotSame(testObject, toCopy);
            Assert.AreEqual(toCopy.Kopecks, testObject.Kopecks);
            Assert.AreEqual(toCopy.Rubles, testObject.Rubles);
        }

        [TestMethod]
        public void TestOperatorAddKopecks()
        {
            uint expectedKopecks = 10;
            Money testObject = new Money(13, 97);
            testObject = testObject + 13;

            Assert.IsInstanceOfType(testObject, typeof(Money));
            Assert.AreEqual(expectedKopecks, testObject.Kopecks);

        }
        [TestMethod]
        public void TestStaticMethodAddKopecks()
        {
            uint expectedKopecks = 10;
            Money testObject = new Money(13, 97);
            testObject = Money.AddCopecks(testObject, 13);

            Assert.IsInstanceOfType(testObject, typeof(Money));
            Assert.AreEqual(expectedKopecks, testObject.Kopecks);

        }
        [TestMethod]
        public void TestMethodAddKopecks()
        {
            uint expectedKopecks = 10;
            Money testObject = new Money(13, 97);
            testObject = testObject.AddCopecks(13);

            Assert.IsInstanceOfType(testObject, typeof(Money));
            Assert.AreEqual(expectedKopecks, testObject.Kopecks);

        }
        [TestMethod]
        public void TestOperatorSumObjects()
        {
            uint expectedRubles = 15;
            uint expectedKopecks = 0;
            Money testObject1 = new Money(13, 97);
            Money testObject2 = new Money(1, 3);
            Money result = testObject1 + testObject2;

            Assert.IsInstanceOfType(result, typeof(Money));
            Assert.AreEqual(expectedRubles, result.Rubles);
            Assert.AreEqual(expectedKopecks, result.Kopecks);
        }

        [TestMethod]
        public void TestOperatorDiffObjects()
        {
            uint expectedRubles = 13;
            uint expectedKopecks = 97;
            Money testObject1 = new Money(15, 0);
            Money testObject2 = new Money(1, 3);
            Money result = testObject1 - testObject2;

            Assert.IsInstanceOfType(result, typeof(Money));
            Assert.AreEqual(expectedRubles, result.Rubles);
            Assert.AreEqual(expectedKopecks, result.Kopecks);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid values for the difference.")]
        public void TestOperatorDiffObjectsException()
        {
            Money testObject1 = new Money(15, 0);
            Money testObject2 = new Money(1, 3);
            Money result = testObject2 - testObject1;
        }
        [TestMethod]
        public void TestOperatorIncrement()
        {
            uint expectedRubles = 1;
            uint expectedKopecks = 0;
            Money testObject = new Money(99);
            testObject = ++testObject;

            Assert.IsInstanceOfType(testObject, typeof(Money));
            Assert.AreEqual(expectedRubles, testObject.Rubles);
            Assert.AreEqual(expectedKopecks, testObject.Kopecks);
        }
        [TestMethod]
        public void TestOperatorDecrement()
        {
            uint expectedRubles = 0;
            uint expectedKopecks = 99;
            Money testObject = new Money(100);
            testObject = --testObject;

            Assert.IsInstanceOfType(testObject, typeof(Money));
            Assert.AreEqual(expectedRubles, testObject.Rubles);
            Assert.AreEqual(expectedKopecks, testObject.Kopecks);
        }
        [TestMethod]
        public void TestExplicitOperatorInt()
        {
            int expectedValue = 13;
            Money testObject = new Money(1384);
            int result = (int)testObject;

            Assert.IsInstanceOfType(result, typeof(int));
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void TestImplicitOperatorDouble()
        {
            double expectedValue = 0.84;
            Money testObject = new Money(1384);
            double result = testObject;

            Assert.IsInstanceOfType(result, typeof(double));
            Assert.AreEqual(expectedValue, result);
        }
        [TestMethod]
        public void TestGetInfoMethod()
        {
            string expectedValue = "12 руб. 32 коп.";
            Money testObject = new Money(1232);
            var result = testObject.GetInfo();

            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual(expectedValue, result);
        }
    }
    [TestClass]
    public class TestMoneyArrayClass
    {
        [TestMethod]
        public void TestConstructorNonParameters()
        {
            int expectedSize = 0;
            MoneyArray testArray = new MoneyArray();

            Assert.AreEqual(expectedSize, testArray.Length);
        }
        [TestMethod]
        public void TestConstructorParameters()
        {
            int expectedSize = 2;
            MoneyArray model = new MoneyArray(2, new Random());

            Assert.AreEqual(expectedSize, model.Length);
            Assert.IsInstanceOfType(model, typeof(MoneyArray));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Некорректный размер")]
        public void TestConstructorParametersException()
        {
            MoneyArray model = new MoneyArray(-2);
        }
        [TestMethod]
        public void TestCopyObject()
        {
            MoneyArray toCopy = new MoneyArray(5, new Random());
            MoneyArray model = new MoneyArray(toCopy);

            Assert.AreNotSame(toCopy, model);
            for (int i = 0; i < toCopy.Length; ++i) Assert.AreEqual(toCopy[i].ToKopecks(), model[i].ToKopecks());
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Индекс вне диапазона значений.")]
        public void TestIndexException()
        {
            MoneyArray testObj = new MoneyArray(5, new Random());
            var a = testObj[-1];
            var b = testObj[testObj.Length - 1];
        }
        [TestMethod]
        public void TestIndexSet()
        {
            MoneyArray testObj = new MoneyArray(5, new Random());
            MoneyArray prevObj = new MoneyArray(testObj);
            testObj[0] = new Money();
            testObj[testObj.Length - 1] = new Money();

            for (int i = 1; i < testObj.Length - 1; ++i) Assert.AreEqual(prevObj[i].ToKopecks(), testObj[i].ToKopecks());
            Assert.AreNotEqual(prevObj[0].ToKopecks(), testObj[0].ToKopecks());
            Assert.AreNotEqual(prevObj[testObj.Length - 1].ToKopecks(), testObj[testObj.Length - 1].ToKopecks());
        }
        [TestMethod]
        public void TestFindMin()
        {
            uint expectedMin = 50;
            MoneyArray testObj = new MoneyArray(5, new Random());
            testObj[0] = new Money(13, 3);
            testObj[1] = new Money(176, 12);
            testObj[2] = new Money(0, 50);
            testObj[3] = new Money(12, 0);
            testObj[4] = new Money(1990, 99);

            var result = Program.Min(testObj);
            Assert.AreEqual(result.ToKopecks(), expectedMin);
        }
    }
}
