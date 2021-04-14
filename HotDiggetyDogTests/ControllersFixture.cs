using Microsoft.EntityFrameworkCore;
using System;
using WebAPI.Data.Context;

namespace HotDiggetyDogTests
{
    public class ControllersFixture : IDisposable
    {
        public DataContext DataContext { get; private set; }

        public ControllersFixture()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                    .UseInMemoryDatabase("HotDogDatabase")
                    .Options;

            DataContext = new DataContext(options);
            DataContext.Database.EnsureCreated();
            DatabaseInitializer.Initialize(DataContext);
        }

        public void Dispose()
        {
            DataContext.Database.EnsureDeleted();
            DataContext.Dispose();
        }
    }
}
