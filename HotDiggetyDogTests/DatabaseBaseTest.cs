using Microsoft.EntityFrameworkCore;
using System;
using WebAPI.Data.Context;

namespace HotDiggetyDogTests
{
    public class DatabaseBaseTest : IDisposable
    {
        protected readonly DataContext dataContext;

        public DatabaseBaseTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                    .UseInMemoryDatabase("HotDogDatabase")
                    .Options;

            dataContext = new DataContext(options);
            dataContext.Database.EnsureCreated();
            DatabaseInitializer.Initialize(dataContext);
        }

        public void Dispose()
        {
            dataContext.Database.EnsureDeleted();
            dataContext.Dispose();
        }
    }
}
