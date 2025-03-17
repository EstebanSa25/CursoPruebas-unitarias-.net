using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation.Tests
{
    public class StringOperationsTest
    {
        [Fact(Skip ="Esta prueba no es valida en este momento, TICKET-001")]
        public void ConcatenateStrings()
        {
            //Arrange
            var stringOperations = new StringOperations();
            //Act
            var result = stringOperations.ConcatenateStrings("Hello", "World");
            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hello World", result);
        }
        [Fact]
        public void IsPalindrome_True()
        {
            //Arrange
            var stringOperations = new StringOperations();
            //Act
            var result = stringOperations.IsPalindrome("ama");
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void IsPalindrome_False()
        {
            //Arrange
            var stringOperations = new StringOperations();
            //Act
            var result = stringOperations.IsPalindrome("Hello");
            //Assert
            Assert.False(result);
        }
        [Fact]
        public void QuantintyInWords()
        {
            //Arrange
            var stringOperations = new StringOperations();
            //Act
            var result = stringOperations.QuantintyInWords("cat", 10);
            //Assert
            Assert.StartsWith("diez", result);
            Assert.Contains("cats", result);
        }
        [Fact]
        public void GetStringLength()
        {
            //Arrange
            var strOperations = new StringOperations();
            //Assert
            Assert.ThrowsAny<ArgumentNullException>(()=>strOperations.GetStringLength(null));
        }
        [Theory]
        [InlineData("V", 5)]
        [InlineData("III", 3)]
        [InlineData("X", 10)]
        public void FromRomanToNumber(string romanNumber,int expected)
        {
            //Arrange
            var stringOperations = new StringOperations();
            //Act
            var result = stringOperations.FromRomanToNumber(romanNumber);
            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void CountOccurrences()
        {
            //Arrange
            var mockLogger=new Mock<ILogger<StringOperations>>();
            var stringOperations = new StringOperations(mockLogger.Object);
            //Act
            var result = stringOperations.CountOccurrences("Hello Platzi", 'l');
            //Assert
            Assert.Equal(3, result);
        }
        [Fact]
        public void ReadFile()
        {
            //Arrange
            var stringOperations = new StringOperations();
            var mockFileReader = new Mock<IFileReaderConector>();
            mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading file");
            //Act
            var result = stringOperations.ReadFile(mockFileReader.Object,"file.txt");
            //Assert
            Assert.Equal("Reading file", result);
        }
    }
}
