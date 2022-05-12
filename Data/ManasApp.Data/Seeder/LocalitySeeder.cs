using Bogus;
using ManasApp.Data.Contract.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace ManasApp.Data.Seeder
{
    public static class LocalitySeeder
    {
        public static void Initialize(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            using (var context = provider.GetService<AppDbContext>())
            {
                context.Database.EnsureCreated();
                
                if (!context.Localities.Any())
                {
                    int index = 0;
                    var faker = new Faker<Locality>()
                    .RuleFor(x => x.Id, f => f.Random.Guid())
                    .RuleFor(x => x.Name, f => f.Random.Word()+index++)
                    .RuleFor(x => x.NormalizedName, (f, l) => l.Name.ToUpper())
                    .RuleFor(x => x.Description, f => f.Lorem.Text())
                    .RuleFor(x => x.CreatedOn, f => f.Date.Between(new DateTime(2022, 04, 1), DateTime.Now));
                    var localities = Enumerable.Range(1, 500)
                        .Select(_ => faker.Generate())
                        .ToList();

                    context.Localities.AddRange(localities);
                    context.SaveChanges();
                }
            }
        }
    }
}
