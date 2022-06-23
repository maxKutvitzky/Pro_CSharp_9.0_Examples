using System.Collections.Generic;
using System.Linq;
using AutoLot.Dal.Repos;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Dal.Tests.Base;
using AutoLot.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Xunit;
namespace AutoLot.Dal.Tests.IntegrationTests
{
    [Collection("Integation Tests")]
    public class MakeTests : BaseTest, IClassFixture<EnsureAutoLotDatabaseTestFixture>
    {
        private readonly IMakeRepo _repo;
        public MakeTests()
        {
            _repo = new MakeRepo(Context);
        }
        public override void Dispose()
        {
            _repo.Dispose();
        }
        [Fact]
        public void ShouldGetAllMakesAndCarsThatAreYellow()
        {
            var query = Context.Makes
                .IgnoreQueryFilters()
                .Include(x => x.Cars.Where(x => x.Color == "Yellow")); 
            var qs = query.ToQueryString();
            var makes = query.ToList();
            Assert.NotNull(makes);
            Assert.NotEmpty(makes);
            Assert.NotEmpty(makes.Where(x => x.Cars.Any()));
            Assert.Empty(makes.First(m => m.Id == 1).Cars);
            Assert.Empty(makes.First(m => m.Id == 2).Cars);
            Assert.Empty(makes.First(m => m.Id == 3).Cars);
            Assert.Single(makes.First(m => m.Id == 4).Cars);
            Assert.Empty(makes.First(m => m.Id == 5).Cars);
        }
        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 3)]
        [InlineData(6, 1)]
        public void ShouldGetAllCarsForAMakeExplicitly(int makeId, int carCount)
        {
            var make = Context.Makes.First(x => x.Id == makeId);
            IQueryable<Car> query =
            Context.Entry(make).Collection(c => c.Cars).Query().IgnoreQueryFilters();
            var qs = query.IgnoreQueryFilters().ToQueryString();
            query.Load();
            Assert.Equal(carCount, make.Cars.Count());
        }
        [Fact]
        public void ShouldAddAnObjectGraph()
        {
            ExecuteInATransaction(RunTheTest);
            void RunTheTest()
            {
                var make = new Make { Name = "Honda" };
                var car = new Car { Color = "Yellow", MakeId = 1, PetName = "Herbie" };
                //Cast the Cars property to List<Car> from IEnumerable<Car>
                ((List<Car>)make.Cars).Add(car);
                Context.Makes.Add(make);
                var carCount = Context.Cars.Count();
                var makeCount = Context.Makes.Count();
                Context.SaveChanges();
                var newCarCount = Context.Cars.Count();
                var newMakeCount = Context.Makes.Count();
                Assert.Equal(carCount + 1, newCarCount);
                Assert.Equal(makeCount + 1, newMakeCount);
            }
        }
    }
}