using System.Collections.Generic;
using System.Linq;
using AutoLot.Dal.Exceptions;
using AutoLot.Dal.Repos;
using AutoLot.Dal.Tests.Base;
using AutoLot.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Xunit;
namespace AutoLot.Dal.Tests.IntegrationTests
{
    [Collection("Integation Tests")]
    public class CarTests : BaseTest, IClassFixture<EnsureAutoLotDatabaseTestFixture>
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 3)]
        [InlineData(6, 1)]
        public void ShouldGetTheCarsByMake(int makeId, int expectedCount)
        {
            IQueryable<Car> query =
            Context.Cars.IgnoreQueryFilters().Where(x => x.MakeId == makeId);
            var qs = query.ToQueryString();
            var cars = query.ToList();
            Assert.Equal(expectedCount, cars.Count);
        }
        [Fact]
        public void ShouldReturnDrivableCarsWithQueryFilterSet()
        {
            IQueryable<Car> query = Context.Cars;
            var qs = query.ToQueryString();
            var cars = query.ToList();
            Assert.NotEmpty(cars);
            Assert.Equal(9, cars.Count);
        }
        [Fact]
        public void ShouldGetAllOfTheCars()
        {
            IQueryable<Car> query = Context.Cars.IgnoreQueryFilters();
            var qs = query.ToQueryString();
            var cars = query.ToList();
            Assert.Equal(10, cars.Count);
        }
        [Fact]
        public void ShouldGetAllOfTheCarsWithMakes()
        {
            IIncludableQueryable<Car, Make?> query =
            Context.Cars.Include(c => c.MakeNavigation);
            var queryString = query.ToQueryString();
            var cars = query.ToList();
            Assert.Equal(9, cars.Count);
        }
        [Fact]
        public void ShouldGetCarsOnOrderWithRelatedProperties()
        {
            IIncludableQueryable<Car, Customer?> query = Context.Cars
            .Where(c => c.Orders.Any())
            .Include(c => c.MakeNavigation)
            .Include(c => c.Orders).ThenInclude(o => o.CustomerNavigation);
            var queryString = query.ToQueryString();
            var cars = query.ToList();
            Assert.Equal(4, cars.Count);
            cars.ForEach(c =>
            {
                Assert.NotNull(c.MakeNavigation);
                Assert.NotNull(c.Orders.ToList()[0].CustomerNavigation);
            });
        }
        [Fact]
        public void ShouldGetCarsOnOrderWithRelatedPropertiesAsSplitQuery()
        {
            IQueryable<Car> query = Context.Cars.Where(c => c.Orders.Any())
            .Include(c => c.MakeNavigation)
            .Include(c => c.Orders).ThenInclude(o => o.CustomerNavigation)
            .AsSplitQuery();
            var cars = query.ToList();
            Assert.Equal(4, cars.Count);
            cars.ForEach(c =>
            {
                Assert.NotNull(c.MakeNavigation);
                Assert.NotNull(c.Orders.ToList()[0].CustomerNavigation);
            });
        }
        [Fact]
        public void ShouldGetReferenceRelatedInformationExplicitly()
        {
            var car = Context.Cars.First(x => x.Id == 1);
            Assert.Null(car.MakeNavigation);
            var query = Context.Entry(car).Reference(c => c.MakeNavigation).Query();
            var qs = query.ToQueryString();
            query.Load();
            Assert.NotNull(car.MakeNavigation);
        }
        [Fact]
        public void ShouldGetCollectionRelatedInformationExplicitly()
        {
            var car = Context.Cars.First(x => x.Id == 1);
            Assert.Empty(car.Orders);
            var query = Context.Entry(car).Collection(c => c.Orders).Query();
            var qs = query.ToQueryString();
            query.Load();
            Assert.Single(car.Orders);
        }
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 3)]
        [InlineData(6, 1)]
        public void ShouldGetAllCarsForAMakeExplicitlyWithQueryFilters(int makeId, int carCount)
        {
            var make = Context.Makes.First(x => x.Id == makeId);
            IQueryable<Car> query = Context.Entry(make).Collection(c => c.Cars).Query();
            var qs = query.ToQueryString();
            query.Load();
            Assert.Equal(carCount, make.Cars.Count());
        }
        [Fact]
        public void ShouldNotGetTheLemonsUsingFromSql()
        {
            var entity = Context.Model.FindEntityType($"{typeof(Car).FullName}");
            var tableName = entity.GetTableName();
            var schemaName = entity.GetSchema();
            var cars = Context.Cars.FromSqlRaw($"Select * from {schemaName}.{tableName}").ToList();
            Assert.Equal(9, cars.Count);
        }
        [Fact]
        public void ShouldGetTheCarsUsingFromSqlWithIgnoreQueryFilters()
        {
            var entity = Context.Model.FindEntityType($"{typeof(Car).FullName}");
            var tableName = entity.GetTableName();
            var schemaName = entity.GetSchema();
            var cars = Context.Cars.FromSqlRaw($"Select * from {schemaName}.{tableName}")
            .IgnoreQueryFilters().ToList();
            Assert.Equal(10, cars.Count);
        }
        [Fact]
        public void ShouldGetOneCarUsingInterpolation()
        {
            var carId = 1;
            var car = Context.Cars
            .FromSqlInterpolated($"Select * from dbo.Inventory where Id = {carId}")
            .Include(x => x.MakeNavigation)
            .First();
            Assert.Equal("Black", car.Color);
            Assert.Equal("VW", car.MakeNavigation.Name);
        }
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 3)]
        [InlineData(6, 1)]
        public void ShouldGetTheCarsByMakeUsingFromSql(int makeId, int expectedCount)
        {
            var entity = Context.Model.FindEntityType($"{typeof(Car).FullName}");
            var tableName = entity.GetTableName();
            var schemaName = entity.GetSchema();
            var cars = Context.Cars.FromSqlRaw($"Select * from {schemaName}.{tableName}")
            .Where(x => x.MakeId == makeId).ToList();
            Assert.Equal(expectedCount, cars.Count);
        }
        [Fact]
        public void ShouldGetTheCountOfCars()
        {
            var count = Context.Cars.Count();
            Assert.Equal(9, count);
        }
        [Fact]
        public void ShouldGetTheCountOfCarsIgnoreQueryFilters()
        {
            var count = Context.Cars.IgnoreQueryFilters().Count();
            Assert.Equal(10, count);
        }
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 3)]
        [InlineData(6, 1)]
        public void ShouldGetTheCountOfCarsByMakeP1(int makeId, int expectedCount)
        {
            var count = Context.Cars.Count(x => x.MakeId == makeId);
            Assert.Equal(expectedCount, count);
        }
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 3)]
        [InlineData(6, 1)]
        public void ShouldGetTheCountOfCarsByMakeP2(int makeId, int expectedCount)
        {
            var count = Context.Cars.Where(x => x.MakeId == makeId).Count();
            Assert.Equal(expectedCount, count);
        }
        [Theory]
        [InlineData(1, true)]
        [InlineData(11, false)]
        public void ShouldCheckForAnyCarsWithMake(int makeId, bool expectedResult)
        {
            var result = Context.Cars.Any(x => x.MakeId == makeId);
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData(1, false)]
        [InlineData(11, false)]
        public void ShouldCheckForAllCarsWithMake(int makeId, bool expectedResult)
        {
            var result = Context.Cars.All(x => x.MakeId == makeId);
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData(1, "Zippy")]
        [InlineData(2, "Rusty")]
        [InlineData(3, "Mel")]
        [InlineData(4, "Clunker")]
        [InlineData(5, "Bimmer")]
        [InlineData(6, "Hank")]
        [InlineData(7, "Pinky")]
        [InlineData(8, "Pete")]
        [InlineData(9, "Brownie")]
        public void ShouldGetValueFromStoredProc(int id, string expectedName)
        {
            Assert.Equal(expectedName, new CarRepo(Context).GetPetName(id));
        }
        [Fact]
        public void ShouldAddACar()
        {
            ExecuteInATransaction(RunTheTest);
            void RunTheTest()
            {
                var car = new Car
                {
                    Color = "Yellow",
                    MakeId = 1,
                    PetName = "Herbie"
                };
                var carCount = Context.Cars.Count();
                Context.Cars.Add(car);
                Context.SaveChanges();
                var newCarCount = Context.Cars.Count();
                Assert.Equal(carCount + 1, newCarCount);
            }
        }
        [Fact]
        public void ShouldAddACarWithAttach()
        {
            ExecuteInATransaction(RunTheTest);
            void RunTheTest()
            {
                var car = new Car
                {
                    Color = "Yellow",
                    MakeId = 1,
                    PetName = "Herbie"
                };
                var carCount = Context.Cars.Count();
                Context.Cars.Attach(car);
                Assert.Equal(EntityState.Added, Context.Entry(car).State);
                Context.SaveChanges();
                var newCarCount = Context.Cars.Count();
                Assert.Equal(carCount + 1, newCarCount);
            }
        }
        [Fact]
        public void ShouldAddMultipleCars()
        {
            ExecuteInATransaction(RunTheTest);
            void RunTheTest()
            {
                //Have to add 4 to activate batching
                var cars = new List<Car>
                {
                    new() { Color = "Yellow", MakeId = 1, PetName = "Herbie" },
                    new() { Color = "White", MakeId = 2, PetName = "Mach 5" },
                    new() { Color = "Pink", MakeId = 3, PetName = "Avon" },
                    new() { Color = "Blue", MakeId = 4, PetName = "Blueberry" }
                }; 
                var carCount = Context.Cars.Count();
                Context.Cars.AddRange(cars);
                Context.SaveChanges();
                var newCarCount = Context.Cars.Count();
                Assert.Equal(carCount + 4, newCarCount);
            }
        }
    }
}