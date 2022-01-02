using System;
using Xunit;
using Moq;
using TestTask.Interfaces;
using TestTask.Api.Services;
using TestTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace TestTask.Tests
{
    public class PeopleServiceTests
    {
        private readonly PeopleService _sut; //system under tests
        private readonly Mock<IPeopleRepository> _peopleRepositoryMock = new Mock<IPeopleRepository>();
        public PeopleServiceTests()
        {
            _sut = new PeopleService(_peopleRepositoryMock.Object);
        }
        #region GetPersonTests
        [Fact]
        public void GetPerson_ShouldReturnPerson_WhenPersonExists()
        {
            // Arrange
            var personId = "someId";
            var personName = "someName";
            var personSex = "someSex";
            var personAge = 18;
            var newPerson = new Person
            {
                Id = personId,
                Name = personName,
                Sex = personSex,
                Age = personAge
            };
            _peopleRepositoryMock.Setup(x => x.GetPersonById(personId)).Returns(newPerson);

            // Act
            var person = _sut.GetPerson(personId);

            // Assert
            Assert.Equal(personId, person.Id);
        }

        [Fact]
        public void GetPerson_ShouldReturnNull_WhenPersonDoesNotExists()
        {
            // Arrange
            _peopleRepositoryMock.Setup(x => x.GetPersonById(It.IsAny<string>())).Returns(() => null);

            // Act
            var person = _sut.GetPerson("someId");

            // Assert
            Assert.Null(person);
        }

        [Fact]
        public void GetPerson_ShouldThrowArgumentNullException_WhenIdEqualsToNull()
        {
            // Arrange
            _peopleRepositoryMock.Setup(x => x.GetPersonById(null)).Throws(new ArgumentNullException());

            // Act Assert
            Assert.Throws<ArgumentNullException> (() => _sut.GetPerson(null));

        }
        #endregion

        #region GetPeopleTests

        private IQueryable<Person> MockCollectionOfPeopleInit()
        {
            var people = new Person[]
            {
                new Person
                {
                    Id = "id1",
                    Name = "Ivan",
                    Sex = "male",
                    Age = 10
                },
                new Person
                {
                    Id = "id2",
                    Name = "Anna",
                    Sex = "female",
                    Age = 20
                },
                new Person
                {
                    Id = "id3",
                    Name = "Katya",
                    Sex = "female",
                    Age = 30
                },
                new Person
                {
                    Id = "id4",
                    Name = "Petr",
                    Sex = "male",
                    Age = 40
                }
            };
            return people.AsQueryable();
        }

        [Fact]
        public void GetPeople_ShouldReturnPeople_WhithoutParams()
        {
            // Arrange
            var testPeople = MockCollectionOfPeopleInit();
            _peopleRepositoryMock.Setup(x => x.GetPeople()).Returns(testPeople);

            // Act
            var people = _sut.GetPeople();

            // Assert
            Assert.Equal(people, testPeople);
            
        }
        [Fact]
        public void GetPeople_ShouldReturnOnlyMen_WhenSexEqualToMale()
        {
            // Arrange
            var testPeople = MockCollectionOfPeopleInit();
            _peopleRepositoryMock.Setup(x => x.GetPeople()).Returns(testPeople);

            // Act
            var people = _sut.GetPeople(sex:"male");

            // Assert
            Assert.True(people.All(p => p.Sex == "male"));

        }
        [Fact]
        public void GetPeople_ShouldReturnOnlyWomen_WhenSexEqualToFemale()
        {
            // Arrange
            var testPeople = MockCollectionOfPeopleInit();
            _peopleRepositoryMock.Setup(x => x.GetPeople()).Returns(testPeople);

            // Act
            var people = _sut.GetPeople(sex: "female");

            // Assert
            Assert.True(people.All(p => p.Sex == "female"));
        }

        [Fact]
        public void GetPeople_ShouldReturnPeopleInAgeRange_When_X_20_Y_50()
        {
            // Arrange
            var testPeople = MockCollectionOfPeopleInit();
            _peopleRepositoryMock.Setup(x => x.GetPeople()).Returns(testPeople);

            // Act
            var people = _sut.GetPeople(x: 20, y:50);

            // Assert
            Assert.True(people.All(p => p.Age < 50 && p.Age > 20));
        }

        [Fact]
        public void GetPeople_ShouldReturnPeopleInAgeRange_When_X_50_Y_20()
        {
            // Arrange
            var testPeople = MockCollectionOfPeopleInit();
            _peopleRepositoryMock.Setup(x => x.GetPeople()).Returns(testPeople);

            // Act
            var people = _sut.GetPeople(x: 50, y: 20);

            // Assert
            Assert.False(people.All(p => p.Age < 50 && p.Age > 20));
        }

        [Fact]
        public void GetPeople_ShouldReturn2Records_When_Count_2()
        {
            // Arrange
            int expected = 2;
            var testPeople = MockCollectionOfPeopleInit();
            _peopleRepositoryMock.Setup(x => x.GetPeople()).Returns(testPeople);

            // Act
            var people = _sut.GetPeople(count: 2);

            // Assert
            Assert.Equal(expected, people.Count());
        }
        [Fact]
        public void GetPeople_ShouldSkip2RecordsAndReturnOthers_When_Start_2()
        {
            // Arrange
            int expected = 2;
            var testPeople = MockCollectionOfPeopleInit();
            _peopleRepositoryMock.Setup(x => x.GetPeople()).Returns(testPeople);

            // Act
            var people = _sut.GetPeople(start: 2);

            // Assert
            Assert.Equal(expected, people.Count());
            Assert.True(people.First().Id == "id3");
            Assert.True(people.Last().Id == "id4");
        }
        #endregion

    }
}
