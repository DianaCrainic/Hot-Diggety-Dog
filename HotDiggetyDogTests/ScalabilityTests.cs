using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using WebAPI.Controllers;
using WebAPI.Data.Repository.v1;
using WebAPI.Dtos.Account;
using WebAPI.Entities;
using WebAPI.Helpers;
using WebAPI.Services;
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
            IOptions<AppSettings> appSettings = Options.Create(new AppSettings());
            appSettings.Value.Secret = SECRET;
            JwtService jwtService = new(appSettings);
            _usersController = new UsersController(userRepository, jwtService);
            Repository<Product> productRepository = new(dataContext);
            _productsController = new ProductsController(productRepository);
        }

        [Fact]
        public async void Register10000CustomersAsync_ShouldReturn_CreatedAt()
        {
            for (int i = 0; i < 10000; i++)
            {
                RegisterRequest _request = new RegisterRequest();
                _request.Username = $"UserName{i}";
                _request.Email = $"{_request.Username}@gmail.com";
                _request.Password = Crypto.SHA256(_request.Username);

                ActionResult<User> actionResult = await _usersController.Register(_request);

                Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            }
        }

        [Fact]
        public async void Register10000CustomersInBatchesOf100_ShouldReturn_CreatedAt()
        {
            List<RegisterRequest> _regRequests = new List<RegisterRequest>();
            for (int i = 0; i < 10000; i++)
            {
                RegisterRequest _request = new RegisterRequest();
                _request.Username = $"UserName{i}";
                _request.Email = $"{_request.Username}@gmail.com";
                _request.Password = Crypto.SHA256(_request.Username);
                _regRequests.Add(_request);
            }

            int batchSize = 100;
            int numberOfBatches = (int)Math.Ceiling((double) 10000 / batchSize);

            for(int i=0;i<numberOfBatches;i++)
            {
                var _currentRequests = _regRequests.Skip(i * batchSize).Take(batchSize);
                var tasks = _currentRequests.Select(_req => _usersController.Register(_req));

                ActionResult<User>[] actionResult = await Task.WhenAll(tasks);

                foreach (var result in actionResult)
                {
                    Assert.IsType<CreatedAtActionResult>(result.Result);
                }

            }

            //Assert.True(true);
        }
        
        [Fact]
        public async void Authenticate10000Customers_ShouldReturn_Ok()
        {
            for (int i = 0; i < 10000; i++)
            {
                AuthenticateRequest _request = new AuthenticateRequest();
                _request.Username = "customer";
                _request.Password = "customer";

                ActionResult<User> actionResult = await _usersController.Authenticate(_request);

                Assert.IsType<OkObjectResult>(actionResult.Result);
            }
        }

        [Fact]
        public async void GetProductsFor10000Customers_ShouldReturn_Ok()
        {
            for (int i = 0; i < 10000; i++)
            {
                ActionResult<IEnumerable<Product>> actionResult = await _productsController.GetProducts();

                Assert.IsType<OkObjectResult>(actionResult.Result);
            }
        }

    }
}
