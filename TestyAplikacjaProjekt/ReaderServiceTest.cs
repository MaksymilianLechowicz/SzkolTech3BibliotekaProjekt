using CzytelnikAplikacjaProjekt.Services;
using CzytelnikAplikacjaProjekt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using CzytelnikAplikacjaProjekt.Entities;

namespace CzytelnikAplikacjaProjekt.UnitTests
{
    public class ReaderServiceTests
    {
        private ReaderService GetServiceWithDb(out ReaderDbContext context)
        {
            var options = new DbContextOptionsBuilder<ReaderDbContext>()
                .UseInMemoryDatabase($"ReaderDb_{Guid.NewGuid()}")
                .Options;

            var config = new ConfigurationBuilder().Build();
            context = new ReaderDbContext(config);
            typeof(ReaderDbContext).GetProperty("Options", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(context, options);

            context.Database.EnsureCreated();

            return new ReaderService(context);
                
        }

        [Fact]
        public void AddReader_ShouldAddReader()
        {
            var service = GetServiceWithDb(out var context);
            var reader = new Reader
            {
                Name = "Jan",
                Surname = "Kowalski",
                Email = "jan.kowalski@example.com"
            };

            service.Create(reader);
            var added = context.Readers.FirstOrDefault(r => r.Email == "jan.kowalski@example.com");

            Assert.NotNull(added);
            Assert.Equal("Jan", added.Name);
        }

        [Fact]
        public async void GetReaders_ShouldReturnAllReaders()
        {
            var service = GetServiceWithDb(out var context);
            context.Readers.Add(new Reader { Name = "Anna", Surname = "Nowak", Email = "anna.nowak@example.com" });
            context.Readers.Add(new Reader { Name = "Piotr", Surname = "Zielinski", Email = "piotr.zielinski@example.com" });
            context.SaveChanges();

            var readers = (await service.Get()).ToList();

            Assert.Equal(2, readers.Count);
            Assert.Contains(readers, r => r.Name == "Anna");
            Assert.Contains(readers, r => r.Name == "Piotr");
        }
    }
}
