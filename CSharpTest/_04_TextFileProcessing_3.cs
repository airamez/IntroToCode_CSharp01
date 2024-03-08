using System;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using UnitTesting3;
using Moq;

[TestFixture]
public class TextFileProcessing_3Test
{
    [Test]
    public void TestProduceLines()
    {
        // Arrange
        var mockReader = new Mock<IStreamReader>();
        mockReader.SetupSequence(r => r.ReadLine())
            .Returns("10")
            .Returns("20")
            .Returns("30")
            .Returns("invalid number")
            .Returns("40")
            .Returns((string)null);
        mockReader.SetupSequence(r => r.EndOfStream)
            .Returns(false)
            .Returns(false)
            .Returns(false)
            .Returns(false)
            .Returns(false)
            .Returns(true);

        // Act
        TextFileProcessor processor = new TextFileProcessor(mockReader.Object);
        List<string> lines = processor.ProduceLines();

        // Assert
        Assert.AreEqual(lines[0], "1: 10");
        Assert.AreEqual(lines[1], "2: 20");
        Assert.AreEqual(lines[2], "3: 30");
        Assert.AreEqual(lines[3], "Invalid value");
        Assert.AreEqual(lines[4], "4: 40");
        Assert.AreEqual(lines[5], "Sum: 100");
        Assert.AreEqual(lines[6], "Average: 25");
        Assert.AreEqual(lines.Count, 7);
    }
}