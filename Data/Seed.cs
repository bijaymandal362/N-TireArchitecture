using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            #region ListItemCategory
            if (!context.ListItemCategory.Any())
            {
                var listItemCategories = new List<ListItemCategory>
            {
                new ListItemCategory
                {
                    ListItemCategoryId=1,
                    ListItemCategoryName="Gender",
                    ListItemCategorySystemName="Gender",
                    InsertPersonId=1,
                    InsertDate=DateTimeOffset.UtcNow,
                    UpdatePersonId=1,
                    UpdateDate=DateTimeOffset.UtcNow,
                    IsSystemConfig=true

                },
                new ListItemCategory
                {
                    ListItemCategoryId=2,
                    ListItemCategoryName="Status",
                    ListItemCategorySystemName="Status",
                    InsertPersonId=1,
                    InsertDate=DateTimeOffset.UtcNow,
                    UpdatePersonId=1,
                    UpdateDate=DateTimeOffset.UtcNow,
                    IsSystemConfig=true
                },
             };
                await context.ListItemCategory.AddRangeAsync(listItemCategories);
                await context.SaveChangesAsync();
            }

            #endregion

            #region ListItem
            if (!context.ListItem.Any())
            {
                var listItems = new List<ListItem>
            {
                new ListItem
                {
                    ListItemId=1,
                    ListItemCategoryId=1,
                    ListItemName="Male",
                    ListItemSystemName="Male",
                    InsertPersonId=1,
                    InsertDate=DateTimeOffset.UtcNow,
                    UpdatePersonId=1,
                    UpdateDate=DateTimeOffset.UtcNow,
                    IsSystemConfig=true

                },
                 new ListItem
                {
                    ListItemId=2,
                    ListItemCategoryId=1,
                    ListItemName="Female",
                    ListItemSystemName="Female",
                    InsertPersonId=1,
                    InsertDate=DateTimeOffset.UtcNow,
                    UpdatePersonId=1,
                    UpdateDate=DateTimeOffset.UtcNow,
                    IsSystemConfig=true

                },
                new ListItem
                {
                    ListItemId=3,
                    ListItemCategoryId=2,
                    ListItemName="Active",
                    ListItemSystemName="Active",
                    InsertPersonId=1,
                    InsertDate=DateTimeOffset.UtcNow,
                    UpdatePersonId=1,
                    UpdateDate=DateTimeOffset.UtcNow,
                    IsSystemConfig=true

                },
                 new ListItem
                {
                    ListItemId=4,
                    ListItemCategoryId=2,
                    ListItemName="InActive",
                    ListItemSystemName="InActive",
                    InsertPersonId=1,
                    InsertDate=DateTimeOffset.UtcNow,
                    UpdatePersonId=1,
                    UpdateDate=DateTimeOffset.UtcNow,
                    IsSystemConfig=true

                }

             };
                await context.ListItem.AddRangeAsync(listItems);
                await context.SaveChangesAsync();
            }
            #endregion

            #region Person
            if (!context.Person.Any())
            {
                var persons = new List<Person>();

                var person1 = new Person
                {
                    PersonId = 1,
                    FirstName = "Anuj",
                    MiddleName = null,
                    LastName = "Tamrakar",
                    Email = "anuj@project.com",
                    InsertPersonId=1,
                    InsertDate=DateTimeOffset.UtcNow,
                    UpdatePersonId=1,
                    UpdateDate=DateTimeOffset.UtcNow,

                };
                person1.PasswordHash = new PasswordHasher<Person>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions() { IterationCount = 100000 })).HashPassword(person1, "Admin@123");

                var person2 = new Person
                {
                    PersonId = 2,
                    FirstName = "ram",
                    MiddleName = null,
                    LastName = "Shreshta",
                    Email = "ram@project.com",
                    InsertPersonId=1,
                    InsertDate=DateTimeOffset.UtcNow,
                    UpdatePersonId=1,
                    UpdateDate=DateTimeOffset.UtcNow,
                };
                person2.PasswordHash = new PasswordHasher<Person>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions() { IterationCount = 100000 })).HashPassword(person2, "Admin@123");

                persons.Add(person1);
                persons.Add(person2);
                await context.Person.AddRangeAsync(persons);
                await context.SaveChangesAsync();
            }
            #endregion

        }
    }
}