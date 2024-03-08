using System;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using UnitTesting2;
using Moq;

[TestFixture]
public class TextFileProcessing_2Test
{
    [Test]
    public void TestProduceLines()
    {
        // Arrange
        string projectDirectory = Directory.GetCurrentDirectory().Parent.Parent.Parent.FullName;
        string filePath = Path.Combine(projectDirectory, "InputFile.txt");
        TextFileProcessor processor = new TextFileProcessor(filePath);

        // Act
        List<string> lines = processor.ProduceLines();

        // Assert
        Assert.AreEqual(lines[0], "1: 50");
        Assert.AreEqual(lines[1], "2: 60");
        Assert.AreEqual(lines[2], "3: 70");
        Assert.AreEqual(lines[3], "Invalid value");
        Assert.AreEqual(lines[4], "4: 80");
        Assert.AreEqual(lines[5], "Sum: 260");
        Assert.AreEqual(lines[6], "Average: 65");
        Assert.AreEqual(lines.Count, 7);
    }
}