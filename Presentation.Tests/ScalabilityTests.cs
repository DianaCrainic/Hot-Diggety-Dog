using Domain.Dtos.Account;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Persistence.Repository.v1;
using Presentation.Tests;
using Security.Services;
using Security.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using WebApi.v1.Controllers;
using Xunit;

namespace HotDiggetyDogTests
{
    public class ScalabilityTests : DatabaseBaseTest
    {
        private readonly ProductsController _productsController;
        private readonly UsersController _usersController;
        private const string SECRET = "JWT SECRET LONG KEY";

        public ScalabilityTests()
        {
            UsersRepository userRepository = new(dataContext);
            IOptions<SecuritySettings> securitySettings = Options.Create(new SecuritySettings());
            securitySettings.Value.Secret = SECRET;
            JwtService jwtService = new(securitySettings);
            _usersController = new UsersController(userRepository, jwtService);
            Repository<Product> productRepository = new(dataContext);
            _productsController = new ProductsController(productRepository);
        }

        [Fact]
        public async void Register10000CustomersInBatchesOf100_ShouldReturn_CreatedAt()
        {
            List<RegisterRequest> _regRequests = new();
            for (int i = 0; i < 10000; i++)
            {
                RegisterRequest _request = new();
                _request.Username = $"UserName{i}";
                _request.Email = $"{_request.Username}@gmail.com";
                _request.Password = Crypto.SHA256(_request.Username);
                _regRequests.Add(_request);
            }

            int batchSize = 100;
            int numberOfBatches = (int)Math.Ceiling((double)10000 / batchSize);

            for (int i = 0; i < numberOfBatches; i++)
            {
                var _currentRequests = _regRequests.Skip(i * batchSize).Take(batchSize);
                var tasks = _currentRequests.Select(_req => _usersController.Register(_req));

                ActionResult<User>[] actionResult = await Task.WhenAll(tasks);

                foreach (var result in actionResult)
                {
                    Assert.IsType<CreatedAtActionResult>(result.Result);
                }
            }
        }

        [Fact]
        public async void Authenticate10000CustomersInBatchesOf100_ShouldReturn_Ok()
        {
            List<AuthenticateRequest> _authRequests = new();
            for (int i = 0; i < 10000; i++)
            {
                AuthenticateRequest _request = new();
                _request.Username = "customer";
                _request.Password = "customer";

            }

            int batchSize = 100;
            int numberOfBatches = (int)Math.Ceiling((double)10000 / batchSize);

            for (int i = 0; i < numberOfBatches; i++)
            {
                var _currentRequests = _authRequests.Skip(i * batchSize).Take(batchSize);
                var tasks = _currentRequests.Select(_req => _usersController.Authenticate(_req));

                ActionResult[] actionResult = await Task.WhenAll(tasks);

                foreach (var result in actionResult)
                {
                    Assert.IsType<OkObjectResult>(result);
                }
            }
        }

        [Fact]
        public async void GetProductsFor10000CustomersInBatchesOf100_ShouldReturn_Ok()
        {
            int batchSize = 100;
            int numberOfBatches = (int)Math.Ceiling((double)10000 / batchSize);

            for (int i = 0; i < numberOfBatches; i++)
            {
                var _currentRequests = new List<int>(100);
                var tasks = _currentRequests.Select(_req => _productsController.GetProducts());

                ActionResult<IEnumerable<Product>>[] actionResult = await Task.WhenAll(tasks);

                foreach (var result in actionResult)
                {
                    Assert.IsType<OkObjectResult>(result);
                }
            }
        }
    }
}