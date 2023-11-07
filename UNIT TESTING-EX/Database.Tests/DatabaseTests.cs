namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    
    [TestFixture]        
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database(1,2);
        }

        [Test]
        public void CreatingDatabaseCountShouldBeCorrect()
        {
            //Arrange
            int actualResult = database.Count;
            int expectedResult = 2;

            //Act
            //database = new Database(1, 2); - moved to Setup

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CreatingDatabaseShouldAddElementsCorrectly(int[] data)
        {
            database = new Database(data);

            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void CreatingDatabaseShouldThrowExceptionWhenCountIsMoreThan16(int[] data)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database = new Database(data));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void DatabaseCountShouldWorkCorrectly()
        {
            int expectedResult = 2;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(-10)]
        [TestCase(3)]
        public void DatabaseAddMethodShouldIncreaseCount(int number)
        {
            int expectedResult = 3;

            database.Add(number);
            Assert.AreEqual(expectedResult, database.Count);
        }

        [TestCase(new int[] {1, 2, 3 ,4 ,5})]
        public void DatabaseAddMethodShouldAddElementCorrectly(int[] data)
        {
            database = new();

            foreach (var number in data)
            {
                database.Add(number);
            }

            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }

        [Test]
        public void DatabaseAddMethodShouldThrowExceptionWhenCountIsMoreThan16()
        {
            for (int i = 0; i < 14; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() 
                => database.Add(3), "Array's capacity must be exactly 16 integers!");
        }
    }
}
