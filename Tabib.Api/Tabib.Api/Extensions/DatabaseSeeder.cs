using Bogus;
using System.Diagnostics;
using Tabib.Domain.Entities;
using Tabib.Domain.Enums;
using Tabib.Infrastructure.Persistence;

namespace Tabib.Api.Extensions;

internal static class DatabaseSeeder
{
    private static readonly Faker _faker = new("ru");
    private static readonly Random _random = new();

    public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<TabibDbContext>();

            SeedDatabase(context);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return app;
    }

    private static void SeedDatabase(TabibDbContext context)
    {
        try
        {
            CreateCities(context);
            CreateLocations(context);
            CreateSpecializations(context);
            CreateDoctors(context);
            CreateDoctorSpecializations(context);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    private static void CreateCities(TabibDbContext context)
    {
        if (context.Cities.Any()) { return; }

        for (int i = 0; i < 25; i++)
        {
            context.Cities.Add(new City
            {
                Name = _faker.Address.City()
            });
        }

        context.SaveChanges();
    }

    private static void CreateLocations(TabibDbContext context)
    {
        if (context.Locations.Any()) { return; }

        var cities = context.Cities.ToList();
        var locations = new List<string>();

        for (int i = 0; i < 500; i++)
        {
            var location = GetUniqueLocation();

            if (location is not null)
            {
                context.Locations.Add(location);
            }
        }

        Location? GetUniqueLocation()
        {
            var randomCityId = cities[_random.Next(cities.Count)].Id;
            int attemps = 0;

            while (attemps < 100)
            {
                string locationName = _faker.Address.StreetName();

                if (!locations.Contains(locationName))
                {
                    locations.Add(locationName);
                    return new Location
                    {
                        StreetName = locationName,
                        CityId = randomCityId
                    };
                }

                attemps++;
            }

            return null;
        }

        context.SaveChanges();
    }

    private static void CreateSpecializations(TabibDbContext context)
    {
        if (context.Specializations.Any()) { return; }

        for (int i = 0; i < 100; i++)
        {
            context.Specializations.Add(new Specialization
            {
                Name = _faker.Name.JobTitle()
            });
        }

        context.SaveChanges();
    }

    private static void CreateDoctors(TabibDbContext context)
    {
        if (context.Doctors.Any()) { return; }

        var locations = context.Locations.ToList();
        var genders = Enum.GetValues(typeof(Gender));

        for (int i = 0; i < 1000; i++)
        {
            var locationId = locations[_random.Next(locations.Count)].Id;
            var gender = (Gender)genders.GetValue(_random.Next(genders.Length - 1));

            context.Doctors.AddRange(new Doctor
            {
                FirstName = _faker.Name.FirstName(),
                LastName = _faker.Name.LastName(),
                Education = _faker.Lorem.Text(),
                Clinic = _faker.Company.CompanyName(),
                Experience = _faker.Lorem.Text(),
                Gender = gender,
                LocationId = locationId,
            });
        }

        context.SaveChanges();
    }

    private static void CreateDoctorSpecializations(TabibDbContext context)
    {
        if (context.DoctorSpecializations.Any()) { return; }

        var doctors = context.Doctors.ToList();
        var specializations = context.Specializations.ToList();

        foreach (var doctor in doctors)
        {
            int numberOfSpecializations = _random.Next(1, 5);

            for (int i = 0; i < numberOfSpecializations; i++)
            {
                var specializationId = specializations[_random.Next(specializations.Count)].Id;

                context.DoctorSpecializations.Add(new DoctorSpecialization
                {
                    DoctorId = doctor.Id,
                    SpecializationId = specializationId,
                    PricePerVisit = _faker.Random.Decimal(70_000, 1_000_000)
                });
            }
        }

        context.SaveChanges();
    }
}
