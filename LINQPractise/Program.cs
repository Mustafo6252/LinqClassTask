using System.Diagnostics.CodeAnalysis;
using LINQPractise;

List<Person> people = new List<Person>
{
    new Person { Id=1, Name = "Alice", Age = 25, CityId = 1 },
    new Person { Id=2, Name = "Georgiana", Age = 30, CityId = 2 },
    new Person { Id=3, Name = "Charlie", Age = 25, CityId = 1 },
    new Person { Id=4, Name = "Diana", Age = 35, CityId = 1 },
    new Person { Id=5, Name = "Ethan", Age = 26, CityId = 1 },
    new Person { Id=6, Name = "Alex", Age = 22, CityId = 2 },
    new Person { Id=7, Name = "George", Age = 27, CityId = 5 },
    new Person { Id=8, Name = "Hannah", Age = 33, CityId = 3 },
    new Person { Id=9, Name = "Ian", Age = 29, CityId = 4 },
    new Person { Id=10, Name = "Chaplin", Age = 26, CityId = 5 }
};

List<City> cities = new List<City>
{
    new City { Id = 1, Name = "New York", Population = 15,CountryId = 1 },
    new City { Id = 2, Name = "London", Population = 7 ,CountryId = 2},
    new City { Id = 3, Name = "Paris", Population = 12 ,CountryId = 1 },
    new City { Id = 4, Name = "Tokyo" , Population = 3 ,CountryId = 3},
    new City { Id = 5, Name = "Sydney" , Population = 5 ,CountryId = 2}
};

List<Country> countries = new List<Country>
{
    new Country { Id = 1, Name = "USA" },
    new Country { Id = 2, Name = "UK" },
    new Country { Id = 3, Name = "Japan" },
    new Country { Id = 4, Name = "Jersey" },
    new Country { Id = 5, Name = "Jordan" },
};

Console.WriteLine("============================  Task 1 ================================");

// ------------------------------  Task 1  --------------------------------------
var odamlar1 = people
    .Join(cities,
        person => person.CityId,
        city => city.Id,
        (person, city) => new
        {
            personName = person.Name,
            CityPopulation = city.Population,
        })
    .Where(person => person.CityPopulation > 3)
    .Select(person => person.personName);
  
    
foreach (var odam in odamlar1)
{
    Console.WriteLine(odam);
}    
Console.WriteLine("============================  Task 2 ================================");

// ------------------------------  Task 2  --------------------------------------
var odamlar2 = cities
    .Where(city => city.Population>cities.Average(city => city.Population))
    .Select(city => city.Name);
    
    
foreach (var odam in odamlar2)
{
    Console.WriteLine(odam);
}    
Console.WriteLine("===========================  Task 3 =================================");

// ------------------------------  Task 3  --------------------------------------
var odamlar3 = cities
    .Join(countries,
        city => city.CountryId,
        country => country.Id,
        (city, country) => new
        {
            CityName = city.Name,
            CountryId = country.Id,
            CountryName = country.Name,
            Population = city.Population
        })
    .GroupBy(x => new { x.CountryId, x.CountryName })
    .Select(g => g
        .OrderByDescending(x => x.Population)
        .First())
    .Select(result =>result.CountryName + " - " + result.CityName);

foreach (var odam in odamlar3)
{
    Console.WriteLine(odam);
}

Console.WriteLine("===========================  Task 4 =================================");

// ------------------------------  Task 4  --------------------------------------

var odamlar4 = people
    .Join(cities,
        person => person.CityId,
        city => city.Id,
        (person, city) => new { person, city })
    .Join(countries,
        person => person.city.CountryId,
        country => country.Id,
        (person, country) => new
        {
            PersonName = person.person.Name,
            CityName = person.city.Name,
            CountryName = country.Name
        })
    .Select(person=>person.PersonName+" - "+person.CityName+" - "+person.CountryName);

foreach (var odam in odamlar4)
{
    Console.WriteLine(odam);
}    
Console.WriteLine("===========================  Task 5 =================================");

// ------------------------------  Task 5  --------------------------------------
var odamlar5= people
    .Join(cities,
        person => person.CityId,
        city => city.Id,
        (person, city) =>
            new
            {
                personName=person.Name, 
                cityName=city.Name,
            })
    .Where(person => person.personName.Equals("Alice", StringComparison.OrdinalIgnoreCase))
    .Select(person => person.cityName+" - "+person.personName);
foreach (var odam in odamlar5)
{
    Console.WriteLine(odam);
}    
Console.WriteLine("===========================  Task 6 =================================");

// ------------------------------  Task 6  --------------------------------------
var odamlar6 = people
    .Join(cities,
        person => person.CityId,
        city => city.Id,
        (person, city) =>
            new
            {
                personAge = person.Age,
                personName = person.Name,
                cityName = city.Name,
            })
    .GroupBy(x => new { x.cityName })
    .Select(g => g
        .OrderByDescending(x => x.personAge)
        .First())
    .Select(result => result.personName + " - " + result.cityName+" - "+result.personAge);
foreach (var odam in odamlar6)
{
    Console.WriteLine(odam);
}   
Console.WriteLine("===========================  Task 7 =================================");

// ------------------------------  Task 7  --------------------------------------
var odamlar7 = people
    .Join(cities.GroupBy(c => c.CountryId)
            .Select(g => g.OrderByDescending(c => c.Population).First()),
        person => person.CityId,
        city => city.Id,
        (person, city) => new { person, city })
    .Join(countries,
        pc => pc.city.CountryId,
        country => country.Id,
        (pc, country) => new
        {
            PersonName = pc.person.Name,
            CityName = pc.city.Name,
            CountryName = country.Name
        })
    .Select(pc => pc.PersonName + " - " + pc.CityName + " - " + pc.CountryName);

foreach (var odam in odamlar7)
{
    Console.WriteLine(odam);
}
Console.WriteLine("===========================  Task 8 =================================");

// ------------------------------  Task 8  --------------------------------------
var odamlar8 = people
    .Join(cities,
        person => person.CityId,
        city => city.Id,
        (person, city) =>
            new
            {
                personName = person.Name,
                cityName = city.Name,
            })
    .Where(city => city.cityName.Length ==5)
    .Select(person => person.personName + " - " + person.cityName);    
foreach (var odam in odamlar8)
{
    Console.WriteLine(odam);
}    
Console.WriteLine("===========================  Task 9 =================================");

// ------------------------------  Task 9  --------------------------------------
var odamlar9 = people
    .Join(cities,
        person => person.CityId,
        city => city.Id,
        (person, city) => new { person, city })
    .Join(countries,
        person => person.city.CountryId,
        country => country.Id,
        (person, country) => new
        {
            PersonAge = person.person.Age,
            PersonName = person.person.Name,
            CityName = person.city.Name,
            CountryName = country.Name
        })
    .GroupBy(x => x.CountryName)
    .Select(g => g.OrderBy(x => x.PersonAge).First())
    .Select(result => result.PersonName + " - " + result.CityName);
foreach (var odam in odamlar9)
{
    Console.WriteLine(odam);
}
Console.WriteLine("===========================  Task 10 =================================");

// ------------------------------  Task 10  --------------------------------------
var odamlar10 = people
    .Where(p => p.Age >= people.Min(m=>m.Age) && p.Age <= people.Max(m=>m.Age)) 
    .Join(cities,
        person => person.CityId,
        city => city.Id,
        (person, city) => new { person, city })
    .GroupBy(pc => pc.city) 
    .Select(g => new
    {
        CityName = g.Key.Name,
        PopulationInRange = g.Count()
    })
    .OrderByDescending(x => x.PopulationInRange)
    .FirstOrDefault(); 
