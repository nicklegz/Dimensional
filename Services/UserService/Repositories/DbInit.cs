using System;
using System.Linq;
using UserService.Models;

namespace UserService.Repositories
{
    public class DbInit
    {
        public static void Init(UserContext context)
        {
            context.Database.EnsureCreated();

            if(context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User{Id = Guid.Parse("844d024c-a958-11eb-bcbc-0242ac130002"), FirstName="Nick", LastName="LeGuerrier", Username="nicklegz", OrganizationName=""},
                new User{Id = Guid.Parse("844d0508-a958-11eb-bcbc-0242ac130002"), FirstName="Joe", LastName="Foo", Username="test1",  OrganizationName=""},
                new User{Id = Guid.Parse("844d05f8-a958-11eb-bcbc-0242ac130002"), FirstName="Mark", LastName="Bar", Username="test2", OrganizationName=""},
                new User{Id = Guid.Parse("844d0756-a958-11eb-bcbc-0242ac130002"), FirstName="Jake", LastName="Hum", Username="test3", OrganizationName=""},
                new User{Id = Guid.Parse("844d0828-a958-11eb-bcbc-0242ac130002"), FirstName="Steve", LastName="Lo", Username="test4", OrganizationName=""}
            };

            foreach(User u in users)
            {
                context.Users.Add(u);
            }

            var addresses = new Address[]
            {
                new Address{Id = 1, UserId = Guid.Parse("844d024c-a958-11eb-bcbc-0242ac130002"), Country="Canada", AdminArea="Ontario", City="Ottawa", PostalCode="K1J 5E7", StreetAddress="123 Hi Lane"},
                new Address{Id = 2, UserId = Guid.Parse("844d0508-a958-11eb-bcbc-0242ac130002"), Country="Canada", AdminArea="Ontario", City="Ottawa", PostalCode="K1J 5E7", StreetAddress="123 Hi Lane"},
                new Address{Id = 3, UserId = Guid.Parse("844d05f8-a958-11eb-bcbc-0242ac130002"), Country="Canada", AdminArea="Ontario", City="Ottawa", PostalCode="K1J 5E7", StreetAddress="123 Hi Lane"},
                new Address{Id = 4, UserId = Guid.Parse("844d0756-a958-11eb-bcbc-0242ac130002"), Country="Canada", AdminArea="Ontario", City="Ottawa", PostalCode="K1J 5E7", StreetAddress="123 Hi Lane"},
                new Address{Id = 5, UserId = Guid.Parse("844d0828-a958-11eb-bcbc-0242ac130002"), Country="Canada", AdminArea="Ontario", City="Ottawa", PostalCode="K1J 5E7", StreetAddress="123 Hi Lane"},
            };

            foreach(Address a in addresses)
            {
                context.Addresses.Add(a);
            }

            context.SaveChanges();
        }
    }
}