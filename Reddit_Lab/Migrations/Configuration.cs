using FizzWare.NBuilder;
using Reddit_Lab.Models;

namespace Reddit_Lab.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Reddit_LabDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Reddit_LabDbContext context)
        {
            if (!context.Posts.Any())
            {
                var posts = Builder<Post>.CreateListOfSize(20).All()
                    .With(p => p.UpVote = Faker.NumberFaker.Number(0, 100))
                    .With(p => p.DownVote = Faker.NumberFaker.Number(0, 100))
                    .With(p => p.Title = Faker.TextFaker.Sentences(1))
                    .With(p => p.Author = Faker.NameFaker.FirstName())
                    .With(p => p.Posted = DateTime.Now)
                    .With(p => p.Link = Faker.InternetFaker.Url())
                    .With(p => p.Body = Faker.TextFaker.Sentences(12))
                    .Build();
                context.Posts.AddRange(posts);
            }

        }

    }
}
