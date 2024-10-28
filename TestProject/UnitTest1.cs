using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PyramidTriangleTests
{
    [TestClass]
    public class TRTriangleTests
    {
        [TestMethod]

        // ������� ����������� �� ������������� ��� ���������� ������� ����� �� ���������
        public void TestDefaultConstructor_AssignsCorrectValues()
        {
            // Arrange
            TRTriangle triangle = new TRTriangle();

            // Act
            double expectedArea = 0.5;
            double expectedPerimeter = 3.414213562;

            // Assert
            Assert.AreEqual(expectedArea, triangle.Area(), 0.001, "����� �� ������������� ��������� �����������");
            Assert.AreEqual(expectedPerimeter, triangle.Perimeter(), 0.001, "�������� �� ������������� ���������� �����������");
        }

        [TestMethod]

        // ������� ���������������� ����������� ��� ���������� ������� ����� �� ���������

        public void TestParameterizedConstructor_AssignsCorrectValues()
        {
            // Arrange
            TRTriangle triangle = new TRTriangle(3, 4);

            // Act
            double expectedArea = 6.0;
            double expectedPerimeter = 12.0;

            // Assert
            Assert.AreEqual(expectedArea, triangle.Area(), 0.001, "����� � ����������� ��������� �����������");
            Assert.AreEqual(expectedPerimeter, triangle.Perimeter(), 0.001, "�������� � ����������� ���������� �����������");
        }

        [TestMethod]

        // ������� ����������� ��������� ��� ���������� ��������� �������
        public void TestCopyConstructor_CopiesValuesCorrectly()
        {
            // Arrange
            TRTriangle triangle1 = new TRTriangle(3, 4);
            TRTriangle triangle2 = new TRTriangle(triangle1);

            // Act
            double expectedArea = 6.0;

            // Assert
            Assert.AreEqual(expectedArea, triangle2.Area(), 0.001, "����������� ��������� ������ �����������");
        }

        [TestMethod]

        // ������� ����� Equals ��� ���� �����
        public void TestEquals_DifferentArea_ReturnsFalse()
        {
            // Arrange
            TRTriangle triangle1 = new TRTriangle(3, 4);
            TRTriangle triangle2 = new TRTriangle(2, 3);

            // Act
            bool result = triangle1.Equals(triangle2);

            // Assert
            Assert.IsFalse(result, "���������� � ����� ������ �� ������ ���� ������");
        }

        [TestMethod]

        // ������� ����� Equals ��� ������� ������� ��� �������� � null
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestEquals_NullObject_ThrowsException()
        {
            // Arrange
            TRTriangle triangle1 = new TRTriangle(3, 4);

            // Act
            bool result = triangle1.Equals(null); // �� ������� ��������� �������
        }

        [TestMethod]

        // ������� ����� Area ��� ���������� � ��������� ���������
        public void TestArea_ZeroSides_ReturnsZero()
        {
            // Arrange
            TRTriangle triangle = new TRTriangle(0, 0);

            // Act
            double expectedArea = 0;

            // Assert
            Assert.AreEqual(expectedArea, triangle.Area(), 0.001, "����� � ��������� ��������� ������� ���� ��������");
        }

        [TestMethod]

        // ������� ����� Area ��� ���������� � ����������� ���������
        public void TestArea_NegativeSides_ReturnsPositiveArea()
        {
            // Arrange
            TRTriangle triangle = new TRTriangle(-3, -4);

            // Act
            double expectedArea = 6.0;

            // Assert
            Assert.AreEqual(expectedArea, triangle.Area(), 0.001, "����� � ����������� ��������� ������� ���� ����������");
        }

        [TestMethod]

        // ������� ����� Perimeter ��� ���������� � ��������� ���������
        public void TestPerimeter_ZeroSides_ReturnsCorrectPerimeter()
        {
            // Arrange
            TRTriangle triangle = new TRTriangle(0, 0);

            // Act
            double expectedPerimeter = 0;

            // Assert
            Assert.AreEqual(expectedPerimeter, triangle.Perimeter(), 0.001, "�������� � ��������� ��������� ������� ���� ��������");
        }

        [TestMethod]

        // ������� ����� Perimeter ��� ���������� � ����������� ���������
        public void TestPerimeter_NegativeSides_ReturnsCorrectPerimeter()
        {
            // Arrange
            TRTriangle triangle = new TRTriangle(-3, -4);

            // Act
            double expectedPerimeter = 12.0;

            // Assert
            Assert.AreEqual(expectedPerimeter, triangle.Perimeter(), 0.001, "�������� � ����������� ��������� ������� ���� ����������");
        }
    }

    [TestClass]
    public class TRPyramidTests
    {
        [TestMethod]

        // ������� ��������� ���������� ��'��� ������
        public void TestVolume_CalculatesCorrectly()
        {
            // Arrange
            TRTriangle baseTriangle = new TRTriangle(3, 4);
            TRPyramid pyramid = new TRPyramid(baseTriangle, 5);
            double expectedVolume = (1.0 / 3.0) * baseTriangle.Area() * 5;

            // Act
            double actualVolume = pyramid.Volume();

            // Assert
            Assert.AreEqual(expectedVolume, actualVolume, 0.001, "��'�� ������ ���������� �����������");
        }

        [TestMethod]

        // ������� ���������� ��'��� � �������� �������
        public void TestVolume_ZeroHeight_ReturnsZero()
        {
            // Arrange
            TRTriangle baseTriangle = new TRTriangle(3, 4);
            TRPyramid pyramid = new TRPyramid(baseTriangle, 0);
            double expectedVolume = 0;

            // Act
            double actualVolume = pyramid.Volume();

            // Assert
            Assert.AreEqual(expectedVolume, actualVolume, 0.001, "��'�� ������ � �������� ������� ������� ���� ��������");
        }

        [TestMethod]

        // ������� ���� ������ ������ ����� ��������� �����
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
                Assert.AreEqual(expectedHeight, pyramid.Volume() / baseTriangle.Area() * 3, 0.001, "������ ������ ��������� �����������");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]

        // ������� ����� InputHeight ��� ������������ ����� (������ FormatException)
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
                pyramid.InputHeight(); // �� ������� ��������� FormatException
            }
        }

        [TestMethod]

        // ������� ��������� ���������� ��'��� ������ � ������� �������
        public void TestVolume_VeryLargeHeight_CalculatesCorrectly()
        {
            // Arrange
            TRTriangle baseTriangle = new TRTriangle(3, 4);
            TRPyramid pyramid = new TRPyramid(baseTriangle, 1e6);
            double expectedVolume = (1.0 / 3.0) * baseTriangle.Area() * 1e6;

            // Act
            double actualVolume = pyramid.Volume();

            // Assert
            Assert.AreEqual(expectedVolume, actualVolume, 0.001, "��'�� ������ � ������� ������� ���������� �����������");
        }

        [TestMethod]


        public void TestVolume_SmallBaseLargeHeight_CalculatesCorrectly()
        {
            // ���� ��� �������� ����������� ���������� ��'��� ������ � ����� ������� �� ������� �������.
            // Arrange
            TRTriangle baseTriangle = new TRTriangle(0.001, 0.001);
            TRPyramid pyramid = new TRPyramid(baseTriangle, 1e6);
            double expectedVolume = (1.0 / 3.0) * baseTriangle.Area() * 1e6;

            // Act
            double actualVolume = pyramid.Volume();

            // Assert
            Assert.AreEqual(expectedVolume, actualVolume, 0.001, "��'�� ������ � ����� ������� �� ������� ������� ���������� �����������");
        }

        [TestMethod]
        public void TestVolume_LargeBaseSmallHeight_CalculatesCorrectly()
        {
            // ���� ��� �������� ����������� ���������� ��'��� ������ � ������� ������� �� ����� �������.
            // Arrange
            TRTriangle baseTriangle = new TRTriangle(1e6, 1e6);
            TRPyramid pyramid = new TRPyramid(baseTriangle, 0.001);
            double expectedVolume = (1.0 / 3.0) * baseTriangle.Area() * 0.001;

            // Act
            double actualVolume = pyramid.Volume();

            // Assert
            Assert.AreEqual(expectedVolume, actualVolume, 0.001, "��'�� ������ � ������� ������� �� ����� ������� ���������� �����������");
        }

        [TestMethod]
        public void TestOutput_DisplaysCorrectValues()
        {
            // ���� ��� �������� ����������� ��������� ���������� ��� ��������� �� ������.
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
                Assert.IsTrue(result.Contains("��������� � �������� a = 3, b = 4"), "��������� ���������� ��� ��������� �����������");
                Assert.IsTrue(result.Contains("������ ������: 5"), "��������� ���������� ��� ������ ������ �����������");
                Assert.IsTrue(result.Contains("��'�� ������:"), "��������� ���������� ��� ��'�� ������ �����������");
            }
        }

        [TestMethod]
        public void TestOutput_HandlesLargeValues()
        {
            // ���� ��� �������� ����������� ��������� ���������� ��� ��������� �� ������ � �������� ����������.
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
                Assert.IsTrue(result.Contains("��������� � ��������"), "��������� ��� �������� ���������� ������� ���� ����������");
                Assert.IsTrue(result.Contains("��'�� ������:"), "��������� ��� ������ ������ ������� ���� ����������");
            }
        }

        [TestMethod]
        public void TestConstructor_ValidInput_CreatesPyramid()
        {
            // ���� ��� �������� ��������� ������ � ���������� �������� ������.
            // Arrange
            TRTriangle baseTriangle = new TRTriangle(3, 4);
            TRPyramid pyramid = new TRPyramid(baseTriangle, 5);

            // Assert
            Assert.IsNotNull(pyramid, "ϳ����� ������� ���� �������� ������");
        }

        [TestMethod]
        public void TestConstructor_NullBase_ThrowsException()
        {
            // ���� ��� ��������, �� ��������� ������ � null-������� ������� ����������.
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TRPyramid pyramid = new TRPyramid(null, 5);
            }, "����������� ������ � �������� ������� ������� �������� ����������");
        }

        [TestMethod]
        public void TestArea_LargeSides_CorrectCalculation()
        {
            // ���� ��� �������� ����������� ���������� ����� ���������� � �������� ���������.
            // Arrange
            TRTriangle triangle = new TRTriangle(1e6, 1e6);

            // Act
            double expectedArea = 0.5 * 1e6 * 1e6;

            // Assert
            Assert.AreEqual(expectedArea, triangle.Area(), 0.001, "����� � �������� ��������� ������� ������������� ���������");
        }

        [TestMethod]
        public void TestPerimeter_VerySmallSides_CorrectCalculation()
        {
            // ���� ��� �������� ����������� ���������� ��������� ���������� � ���� ������ ���������.
            // Arrange
            TRTriangle triangle = new TRTriangle(0.0001, 0.0001);

            // Act
            double expectedPerimeter = 0.0001 + 0.0001 + Math.Sqrt(0.0001 * 0.0001 + 0.0001 * 0.0001);

            // Assert
            Assert.AreEqual(expectedPerimeter, triangle.Perimeter(), 0.001, "�������� � ���� ������ ��������� ������� ���� ���������� ���������");
        }

    }
}