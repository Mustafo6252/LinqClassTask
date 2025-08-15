using System.Diagnostics.CodeAnalysis;
using LINQPractise;

List<Person> people = new List<Person>
{
    new Person { Id=1, Name = "Alice", Age = 25, CityId = 1 },
    new Person { Id=2, Name = "Georgiana", Age = 30, CityId = 2 },
    new Person { Id=3, Name = "Charlie", Age = 25, CityId = 3 },
    new Person { Id=4, Name = "Diana", Age = 35, CityId = 1 },
    new Person { Id=5, Name = "Ethan", Age = 26, CityId = 4 },
    new Person { Id=6, Name = "Alex", Age = 22, CityId = 2 },
    new Person { Id=7, Name = "George", Age = 27, CityId = 5 },
    new Person { Id=8, Name = "Hannah", Age = 33, CityId = 3 },
    new Person { Id=9, Name = "Ian", Age = 29, CityId = 4 },
    new Person { Id=10, Name = "Chaplin", Age = 26, CityId = 5 }
};

List<City> cities = new List<City>
{
    new City { Id = 1, Name = "New York" },
    new City { Id = 2, Name = "London" },
    new City { Id = 3, Name = "Paris" },
    new City { Id = 4, Name = "Tokyo" },
    new City { Id = 5, Name = "Sydney" }
};

Console.WriteLine("============================  Task 1 ================================");

// ------------------------------  Task 1  --------------------------------------
var odamlar1= from person in people.AsParallel()
    where person.Age >30
    select new
    {
        personName=person.Name, 
    };
foreach (var odam in odamlar1)
{
    Console.WriteLine(odam.personName);
}    
Console.WriteLine("============================  Task 2 ================================");

// ------------------------------  Task 2  --------------------------------------
var odamlar2 = from person in people.AsParallel()
    group person by new { person.Age }
    into g
    select new
    {
        personAge=g.Key.Age,
        numberOfPeople=g.Count()
    };
foreach (var odam in odamlar2)
{
    Console.WriteLine(odam.personAge + " - " + odam.numberOfPeople);
}    
Console.WriteLine("===========================  Task 3 =================================");

// ------------------------------  Task 3  --------------------------------------
var odamlar3 = people.AsParallel()
    .OrderByDescending(person=>person.Age).Take(5)
    .Select(person=>person.Name+" - "+person.Age);

foreach (var odam in odamlar3)
{
    Console.WriteLine(odam);
}    
Console.WriteLine("===========================  Task 4 =================================");

// ------------------------------  Task 4  --------------------------------------

var odamlar4 = people.AsParallel()
    .Where(person =>IsPrime(person.Id)) 
    .Select(person=>person.Id+" - "+person.Name);
foreach (var odam in odamlar4)
{
    Console.WriteLine(odam);
}

static bool IsPrime(int number)
{
    if (number < 2) return false;
    if (number == 2) return true;
    if (number % 2 == 0) return false;

    int boundary = (int)Math.Sqrt(number);

    for (int i = 3; i <= boundary; i ++)
        if (number % i == 0)
            return false;

    return true;
}    
Console.WriteLine("===========================  Task 5 =================================");

// ------------------------------  Task 5  --------------------------------------
var odamlar5= people.AsParallel()
    .OrderByDescending(person=>person.Age)
    .GroupBy(person=>person.Age)
    .Select(person=>person.Key + " - " + person.Count());
    
foreach (var odam in odamlar5)
{
    Console.WriteLine(odam);
}    