using NUnit.Framework;

[TestFixture]
public class TRTriangleTests
{
    [Test]
    public void TestArea_CalculatesCorrectly()
    {
        // Arrange
        TRTriangle triangle = new TRTriangle(3, 4);
        double expectedArea = 6.0;

        // Act
        double actualArea = triangle.Area();

        // Assert
        Assert.AreEqual(expectedArea, actualArea, 0.001, "Площа трикутника обчислена неправильно"); // Додано третій параметр для точності
    }

    [Test]
    public void TestPerimeter_CalculatesCorrectly()
    {
        // Arrange
        TRTriangle triangle = new TRTriangle(3, 4);
        double expectedPerimeter = 12.0;

        // Act
        double actualPerimeter = triangle.Perimeter();

        // Assert
        Assert.AreEqual(expectedPerimeter, actualPerimeter, 0.001, "Периметр трикутника обчислений неправильно");
    }

    [Test]
    public void TestEquals_SameArea_ReturnsTrue()
    {
        // Arrange
        TRTriangle triangle1 = new TRTriangle(3, 4);
        TRTriangle triangle2 = new TRTriangle(6, 8);

        // Act
        bool result = triangle1.Equals(triangle2);

        // Assert
        Assert.IsTrue(result, "Трикутники повинні мати однакову площу");
    }

    [Test]
    public void TestEquals_DifferentArea_ReturnsFalse()
    {
        // Arrange
        TRTriangle triangle1 = new TRTriangle(3, 4);
        TRTriangle triangle2 = new TRTriangle(2, 3);

        // Act
        bool result = triangle1.Equals(triangle2);

        // Assert
        Assert.IsFalse(result, "Трикутники повинні мати різну площу");
    }
}

[TestFixture]
public class TRPyramidTests
{
    [Test]
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
}
