using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using phonebook_core.Entities;
using phonebook_core.Interfaces;
using phonebook_spa.Controllers;

namespace phonebook_spa.tests
{
    public class PhoneBookControllerTests
    {
        private Mock<IRepository<PhoneBookEntry>> mockRepo = new Mock<IRepository<PhoneBookEntry>>();
        private Mock<ILogger<PhoneBookController>> mockLogger = new Mock<ILogger<PhoneBookController>>();

        public PhoneBookControllerTests()
        {

        }

        [Fact]
        public async void GetAllReturnsAllEntries()
        {
            // Assemble
            var expectedResults = new List<PhoneBookEntry>()
            {
                new PhoneBookEntry()
                {
                    FirstName = "Tester",
                    LastName = "Person",
                    PhoneNumber = "555-000-1111"
                },
                new PhoneBookEntry()
                {
                    FirstName = "Second",
                    LastName = "Tester",
                    PhoneNumber = "555-222-1111"
                }
            };
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(expectedResults);

            var controller = new PhoneBookController(mockLogger.Object, mockRepo.Object);

            // Act
            var actionResult = await controller.GetAllAsync();
            var result = actionResult.Result as OkObjectResult;

            // Assert
            Assert.Equal(expectedResults, result.Value);
        }
    }
}