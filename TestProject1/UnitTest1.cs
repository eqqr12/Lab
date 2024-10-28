using NUnit.Framework;
using System;

[TestFixture]
public class TRTriangleTests
{
    [Test]
    public void Area_CorrectAreaCalculation_ReturnsExpectedValue()
    {
        // Arrange
        TRTriangle triangle = new TRTriangle(3, 4);

        // Act
        double result = triangle.Area();

        // Assert
        Assert.AreEqual(6, result, "Площа трикутника обчислена неправильно.");
    }

    [Test]
    public void Perimeter_CorrectPerimeterCalculation_ReturnsExpectedValue()
    {
        // Arrange
        TRTriangle triangle = new TRTriangle(3, 4);

        // Act
        double result = triangle.Perimeter();

        // Assert
        Assert.AreEqual(12, result, "Периметр трикутника обчислений неправильно.");
    }

    [Test]
    public void Equals_SameTriangles_ReturnsTrue()
    {
        // Arrange
        TRTriangle triangle1 = new TRTriangle(3, 4);
        TRTriangle triangle2 = new TRTriangle(3, 4);

        // Act
        bool result = triangle1.Equals(triangle2);

        // Assert
        Assert.IsTrue(result, "Трикутники повинні бути однакові за площею.");
    }

    [Test]
    public void Equals_DifferentTriangles_ReturnsFalse()
    {
        // Arrange
        TRTriangle triangle1 = new TRTriangle(3, 4);
        TRTriangle triangle2 = new TRTriangle(5, 6);

        // Act
        bool result = triangle1.Equals(triangle2);

        // Assert
        Assert.IsFalse(result, "Трикутники повинні бути різні за площею.");
    }
}

[TestFixture]
public class TRPyramidTests
{
    [Test]
    public void Volume_CorrectVolumeCalculation_ReturnsExpectedValue()
    {
        // Arrange
        TRTriangle baseTriangle = new TRTriangle(3, 4);
        TRPyramid pyramid = new TRPyramid(baseTriangle, 10);

        // Act
        double result = pyramid.Volume();

        // Assert
        Assert.AreEqual(20, result, "Об'єм піраміди обчислений неправильно.");
    }
}
