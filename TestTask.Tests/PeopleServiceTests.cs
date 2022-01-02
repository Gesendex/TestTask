using System;
using Xunit;
using Moq;
using TestTask.Interfaces;
using TestTask.Api.Services;
using TestTask.Models;

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
        
        #endregion

    }
}
