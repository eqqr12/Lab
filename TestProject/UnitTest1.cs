using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PyramidTriangleTests
{
    [TestClass]
    public class TRTriangleTests
    {
        [TestMethod]

        // Тестуємо конструктор за замовчуванням для правильних значень площі та периметру
        public void TestDefaultConstructor_AssignsCorrectValues()
        {
            // Arrange
            TRTriangle triangle = new TRTriangle();

            // Act
            double expectedArea = 0.5;
            double expectedPerimeter = 3.414213562;

            // Assert
            Assert.AreEqual(expectedArea, triangle.Area(), 0.001, "Площа за замовчуванням обчислена неправильно");
            Assert.AreEqual(expectedPerimeter, triangle.Perimeter(), 0.001, "Периметр за замовчуванням обчислений неправильно");
        }

        [TestMethod]

        // Тестуємо параметризований конструктор для правильних значень площі та периметру

        public void TestParameterizedConstructor_AssignsCorrectValues()
        {
            // Arrange
            TRTriangle triangle = new TRTriangle(3, 4);

            // Act
            double expectedArea = 6.0;
            double expectedPerimeter = 12.0;

            // Assert
            Assert.AreEqual(expectedArea, triangle.Area(), 0.001, "Площа з параметрами обчислена неправильно");
            Assert.AreEqual(expectedPerimeter, triangle.Perimeter(), 0.001, "Периметр з параметрами обчислений неправильно");
        }

        [TestMethod]

        // Тестуємо конструктор копіювання для коректного копіювання значень
        public void TestCopyConstructor_CopiesValuesCorrectly()
        {
            // Arrange
            TRTriangle triangle1 = new TRTriangle(3, 4);
            TRTriangle triangle2 = new TRTriangle(triangle1);

            // Act
            double expectedArea = 6.0;

            // Assert
            Assert.AreEqual(expectedArea, triangle2.Area(), 0.001, "Конструктор копіювання працює неправильно");
        }

        [TestMethod]

        // Тестуємо метод Equals для різної площі
        public void TestEquals_DifferentArea_ReturnsFalse()
        {
            // Arrange
            TRTriangle triangle1 = new TRTriangle(3, 4);
            TRTriangle triangle2 = new TRTriangle(2, 3);

            // Act
            bool result = triangle1.Equals(triangle2);

            // Assert
            Assert.IsFalse(result, "Трикутники з різною площею не повинні бути рівними");
        }

        [TestMethod]

        // Тестуємо метод Equals для виклику винятку при порівнянні з null
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestEquals_NullObject_ThrowsException()
        {
            // Arrange
            TRTriangle triangle1 = new TRTriangle(3, 4);

            // Act
            bool result = triangle1.Equals(null); // Це повинно викликати виняток
        }

        [TestMethod]

        // Тестуємо метод Area для трикутника з нульовими сторонами
        public void TestArea_ZeroSides_ReturnsZero()
        {
            // Arrange
            TRTriangle triangle = new TRTriangle(0, 0);

            // Act
            double expectedArea = 0;

            // Assert
            Assert.AreEqual(expectedArea, triangle.Area(), 0.001, "Площа з нульовими сторонами повинна бути нульовою");
        }

        [TestMethod]

        // Тестуємо метод Area для трикутника з негативними сторонами
        public void TestArea_NegativeSides_ReturnsPositiveArea()
        {
            // Arrange
            TRTriangle triangle = new TRTriangle(-3, -4);

            // Act
            double expectedArea = 6.0;

            // Assert
            Assert.AreEqual(expectedArea, triangle.Area(), 0.001, "Площа з негативними сторонами повинна бути позитивною");
        }

        [TestMethod]

        // Тестуємо метод Perimeter для трикутника з нульовими сторонами
        public void TestPerimeter_ZeroSides_ReturnsCorrectPerimeter()
        {
            // Arrange
            TRTriangle triangle = new TRTriangle(0, 0);

            // Act
            double expectedPerimeter = 0;

            // Assert
            Assert.AreEqual(expectedPerimeter, triangle.Perimeter(), 0.001, "Периметр з нульовими сторонами повинен бути нульовим");
        }

        [TestMethod]

        // Тестуємо метод Perimeter для трикутника з негативними сторонами
        public void TestPerimeter_NegativeSides_ReturnsCorrectPerimeter()
        {
            // Arrange
            TRTriangle triangle = new TRTriangle(-3, -4);

            // Act
            double expectedPerimeter = 12.0;

            // Assert
            Assert.AreEqual(expectedPerimeter, triangle.Perimeter(), 0.001, "Периметр з негативними сторонами повинен бути правильним");
        }
    }

    [TestClass]
    public class TRPyramidTests
    {
        [TestMethod]

        // Тестуємо правильне обчислення об'єму піраміди
        public void TestVolume_CalculatesCorrectly()
        {
            // Arrange
            TRTriangle baseTriangle = new TRTriangle(3, 4);
            TRPyramid pyramid = new TRPyramid(baseTriangle, 5);
            double expectedVolume = (1.0 / 3.0) * baseTriangle.Area() * 5;

            // Act
            double actualVolume = pyramid.Volume();

            // Assert
            Assert.AreEqual(expectedVolume, actualVolume, 0.001, "Об'єм піраміди обчислений неправильно");
        }

        [TestMethod]

        // Тестуємо обчислення об'єму з нульовою висотою
        public void TestVolume_ZeroHeight_ReturnsZero()
        {
            // Arrange
            TRTriangle baseTriangle = new TRTriangle(3, 4);
            TRPyramid pyramid = new TRPyramid(baseTriangle, 0);
            double expectedVolume = 0;

            // Act
            double actualVolume = pyramid.Volume();

            // Assert
            Assert.AreEqual(expectedVolume, actualVolume, 0.001, "Об'єм піраміди з нульовою висотою повинен бути нульовим");
        }

        [TestMethod]

        // Тестуємо зміну висоти піраміди через симуляцію вводу
        public void TestInputHeight_ChangesHeightCorrectly()
        {
            // Arrange
            TRTriangle baseTriangle = new TRTriangle(3, 4);
            TRPyramid pyramid = new TRPyramid(baseTriangle, 0);

            // Simulate user input
            string input = "7";
            using (var sw = new System.IO.StringReader(input))
            {
                Console.SetIn(sw);

                // Act
                pyramid.InputHeight();

                // Assert
                double expectedHeight = 7;
                Assert.AreEqual(expectedHeight, pyramid.Volume() / baseTriangle.Area() * 3, 0.001, "Висота піраміди обчислена неправильно");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]

        // Тестуємо метод InputHeight для некоректного вводу (виклик FormatException)
        public void TestInputHeight_InvalidInput_ThrowsFormatException()
        {
            // Arrange
            TRTriangle baseTriangle = new TRTriangle(3, 4);
            TRPyramid pyramid = new TRPyramid(baseTriangle, 0);

            // Simulate invalid user input
            string input = "abc";
            using (var sw = new System.IO.StringReader(input))
            {
                Console.SetIn(sw);

                // Act
                pyramid.InputHeight(); // Це повинно викликати FormatException
            }
        }

        [TestMethod]

        // Тестуємо правильне обчислення об'єму піраміди з великою висотою
        public void TestVolume_VeryLargeHeight_CalculatesCorrectly()
        {
            // Arrange
            TRTriangle baseTriangle = new TRTriangle(3, 4);
            TRPyramid pyramid = new TRPyramid(baseTriangle, 1e6);
            double expectedVolume = (1.0 / 3.0) * baseTriangle.Area() * 1e6;

            // Act
            double actualVolume = pyramid.Volume();

            // Assert
            Assert.AreEqual(expectedVolume, actualVolume, 0.001, "Об'єм піраміди з великою висотою обчислений неправильно");
        }

        [TestMethod]


        public void TestVolume_SmallBaseLargeHeight_CalculatesCorrectly()
        {
            // Тест для перевірки правильності обчислення об'єму піраміди з малою основою та великою висотою.
            // Arrange
            TRTriangle baseTriangle = new TRTriangle(0.001, 0.001);
            TRPyramid pyramid = new TRPyramid(baseTriangle, 1e6);
            double expectedVolume = (1.0 / 3.0) * baseTriangle.Area() * 1e6;

            // Act
            double actualVolume = pyramid.Volume();

            // Assert
            Assert.AreEqual(expectedVolume, actualVolume, 0.001, "Об'єм піраміди з малою основою та великою висотою обчислений неправильно");
        }

        [TestMethod]
        public void TestVolume_LargeBaseSmallHeight_CalculatesCorrectly()
        {
            // Тест для перевірки правильності обчислення об'єму піраміди з великою основою та малою висотою.
            // Arrange
            TRTriangle baseTriangle = new TRTriangle(1e6, 1e6);
            TRPyramid pyramid = new TRPyramid(baseTriangle, 0.001);
            double expectedVolume = (1.0 / 3.0) * baseTriangle.Area() * 0.001;

            // Act
            double actualVolume = pyramid.Volume();

            // Assert
            Assert.AreEqual(expectedVolume, actualVolume, 0.001, "Об'єм піраміди з великою основою та малою висотою обчислений неправильно");
        }

        [TestMethod]
        public void TestOutput_DisplaysCorrectValues()
        {
            // Тест для перевірки правильності виведення інформації про трикутник та піраміду.
            // Arrange
            TRTriangle baseTriangle = new TRTriangle(3, 4);
            TRPyramid pyramid = new TRPyramid(baseTriangle, 5);

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);

                // Act
                pyramid.Output();

                // Assert
                string result = sw.ToString();
                Assert.IsTrue(result.Contains("Трикутник з катетами a = 3, b = 4"), "Виведення інформації про трикутник неправильне");
                Assert.IsTrue(result.Contains("Висота піраміди: 5"), "Виведення інформації про висоту піраміди неправильне");
                Assert.IsTrue(result.Contains("Об'єм піраміди:"), "Виведення інформації про об'єм піраміди неправильне");
            }
        }

        [TestMethod]
        public void TestOutput_HandlesLargeValues()
        {
            // Тест для перевірки правильності виведення інформації про трикутник та піраміду з великими значеннями.
            // Arrange
            TRTriangle baseTriangle = new TRTriangle(1e6, 1e6);
            TRPyramid pyramid = new TRPyramid(baseTriangle, 1e6);

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);

                // Act
                pyramid.Output();

                // Assert
                string result = sw.ToString();
                Assert.IsTrue(result.Contains("Трикутник з катетами"), "Виведення для великого трикутника повинно бути правильним");
                Assert.IsTrue(result.Contains("Об'єм піраміди:"), "Виведення для великої піраміди повинно бути правильним");
            }
        }

        [TestMethod]
        public void TestConstructor_ValidInput_CreatesPyramid()
        {
            // Тест для перевірки створення піраміди з коректними вхідними даними.
            // Arrange
            TRTriangle baseTriangle = new TRTriangle(3, 4);
            TRPyramid pyramid = new TRPyramid(baseTriangle, 5);

            // Assert
            Assert.IsNotNull(pyramid, "Піраміда повинна бути створена успішно");
        }

        [TestMethod]
        public void TestConstructor_NullBase_ThrowsException()
        {
            // Тест для перевірки, що створення піраміди з null-основою викликає виключення.
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TRPyramid pyramid = new TRPyramid(null, 5);
            }, "Конструктор піраміди з нульовою основою повинен викидати виключення");
        }

        [TestMethod]
        public void TestArea_LargeSides_CorrectCalculation()
        {
            // Тест для перевірки правильності обчислення площі трикутника з великими сторонами.
            // Arrange
            TRTriangle triangle = new TRTriangle(1e6, 1e6);

            // Act
            double expectedArea = 0.5 * 1e6 * 1e6;

            // Assert
            Assert.AreEqual(expectedArea, triangle.Area(), 0.001, "Площа з великими сторонами повинна обчислюватись правильно");
        }

        [TestMethod]
        public void TestPerimeter_VerySmallSides_CorrectCalculation()
        {
            // Тест для перевірки правильності обчислення периметра трикутника з дуже малими сторонами.
            // Arrange
            TRTriangle triangle = new TRTriangle(0.0001, 0.0001);

            // Act
            double expectedPerimeter = 0.0001 + 0.0001 + Math.Sqrt(0.0001 * 0.0001 + 0.0001 * 0.0001);

            // Assert
            Assert.AreEqual(expectedPerimeter, triangle.Perimeter(), 0.001, "Периметр з дуже малими сторонами повинен бути обчислений правильно");
        }

    }
}