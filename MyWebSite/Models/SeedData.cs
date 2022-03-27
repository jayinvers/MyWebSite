using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyWebSite.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bogus;

namespace MyWebSite.Models
{
    public static class SeedData
    {

        private static List<Message> FakeMessages(int count)
        {
            
            var messageFaker = new Faker<Message>()
                .RuleFor(m => m.Email, f => f.Person.Email)
                .RuleFor(m => m.FullName, f => f.Person.FullName)
                .RuleFor(m => m.Body, f => f.Lorem.Paragraph())
                .RuleFor(m => m.CreatedAt, f => f.Date.Past());
            return messageFaker.Generate(count);

        }
        private static Article[] GetArticleMd(string dirPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            FileInfo[] files = dirInfo.GetFiles();
            

            List<Article> articles = new List<Article>();

            foreach (FileInfo file in files)
            {
                Article article = new Article()
                {
                    Title = File.ReadAllText(file.FullName).Split("======").First().Replace("\n", "").Replace("# ", ""),
                    Body = File.ReadAllText(file.FullName).Split("======").Last()
                };
                articles.Add(article);
            }
            return articles.ToArray();
        }


        private static Skill[] AddSkill()
        {
            return new Skill[]
            {
                new Skill
                {
                    Name = "Java",
                    Percentage = 90
                },
                new Skill
                {
                    Name = "Python",
                    Percentage = 95
                },
                new Skill
                {
                    Name = "PHP",
                    Percentage = 90
                },
                new Skill
                {
                    Name = "Mysql",
                    Percentage = 90
                },
                new Skill
                {
                    Name = ".NET",
                    Percentage = 80
                },
                new Skill
                {
                    Name = "Go lang",
                    Percentage = 75
                },
            };
        }
        private static Article[] AddArticle()
        {
            return new Article[] { new Article
                {
                Title = "A brief history of the web",
                Body = "Back in the hazy days of 1999, Microsoft introduced an ActiveX component into Internet Explorer 5 that for the first time allowed Javascript within a page to fetch additional content from the server without reloading the entire page. These were heady days, and I remember writing a lot of Internet Explorer-only applications that leveraged this technology to load specific regions of content in response to user interactions.",
                Author = "Admin"
                },
                new Article{
                Title = "I’m betting on SPAs",
                Body = "We never considered writing a whole application like that however; navigation still fetched a brand new page from the server, causing a full reload. There were still multiple <SCRIPT> tags per page to load the different Javascript files required, and as this was before build pipe-lines, none of it was minified or compressed.",
                Author = "Admin"
                },
                new Article{
                Title = "Single Page App (SPA)",
                Body = "By 2005, the phrase Single Page App (SPA) had started to surface. The entire application could be loaded once, then handled by Javascript on the client. The only round-trips required to the server would be to fetch specific pieces of data used to generate content. 2010 saw the release of BackboneJS and AngularJS, two frameworks that not only provided the building blocks to construct SPAs more effectively, but also provide some organisation for the mountain of Javascript developers had started to write. In 2011 SproutCore 2.0 was renamed to EmberJS, 2013 saw the first version of React, and in 2016 the new version of Angular was released.",
                Author = "Admin"
                },

        };
        }

        private static Portfolio[] AddPortfolio()
        {
            return new Portfolio[] { new Portfolio
                {
                Title = "DOCCMS",
                Description = "Doccms is a popular open-source content management system in China. It was established in 2006 and has a history of 15 years. According to incomplete statistics, it has more than 40,000 website users. I am one of the founders and use PHP+Mysql to code the entire system. url: https://www.doccms.com",
                Pic = "/pic/cases/01.png"
                },
                new Portfolio{
                Title = "MaxCMS (JAVA)",
                Description = "Built in 2019, it is a full-featured blog system, which is implemented by SpringBoot + Apache Shiro + Mybatis Plus + Thymeleaf + Bootstrap. I call it MaxCMS. It is a personal project and I have used it to make some simple websites for some businesses.",
                Pic = "/pic/cases/02.png"
                },
                new Portfolio{
                Title = "Interview Questionnaire System",
                Description = "Established in 2020, it is an online exam system for a Chinese company to conduct remote interviews for the company during the COVID-19 period. It is based on PHP + Mysql, which includes my custom template system. On the front end, Bootstrap is used for CSS and JS development. ",
                Pic = "/pic/cases/03.png"
                },
                new Portfolio{
                Title = "Enterprise website management system",
                Description = "Established in 2019, it is another PHP version of CMS, but it is lighter. It uses PHP+SQLite and can be easily deployed to the server without excessive configuration. Of course, it also supports Mysql. The front end uses Bootstrap. This is a personal project. ",
                Pic = "/pic/cases/02.png"
                },
                new Portfolio{
                Title = "WorkLog",
                Description = "Established in 2020, a remote work log reporting system established for a company during the COVID19 period. It is a very simple system, but it is very useful and is used daily by the company. It uses Python + Flask + VUE + VUX + ELEMENTUI technology stack.",
                Pic = "/pic/cases/03.png"
                },
                new Portfolio{
                Title = "Safeheron Website",
                Description = "The project started in May 2021. Safeheron is a blockchain security product of Xuanbing Technology. It is committed to providing customers with more secure digital asset Custody solutions. I am responsible for the front-end part of this project, mainly using VUE to convert design drawings to web pages. It is an exciting project. Under the project confidentiality agreement, could not to display the management panel. ",
                Pic = "/pic/cases/01.png"
                },

        };
        }
        private static Experience[] AddExperience()
        {


            return new Experience[] { new Experience
                {
                    Title = "Full-Stack Developer",
                    Location = "Invercargill (Remote)",
                    Duration = "2022-Now",
                    Description = "Design and implement to a hospital case review system with .NET Core, MySql and React. This system is mainly used to check patient information such as prescriptions, medication specifications, and hospitalization records. It conducts text analysis through artificial intelligence to judge whether the medical process is in compliance with regulations, and give advice to health workers."

                },
                new Experience
                {
                    Title = "Volunteer",
                    Location = "Invercargill & Auckland",
                    Duration = "2017-2021",
                    Description = "Since arriving in New Zealand to attend an English language college in Auckland, I have been teaching people who want to learn programming in Java or Android through Meetup.com. I did this in order to improve my English language skill and also to make friends. After completing my language studies I moved to Invercargill and continued volunteer job - helping people to solve their IT problems and offering a free IT service to help people and businesses who need help with web-based software or to build websites."

                },
                new Experience
                {
                    Title = "Software Developer",
                    Location = "Auckland",
                    Duration = "2019-2021",
                    Description = "Design and development of SMS reminder system. The system provides APIs and management panels for commercial customers to complete SMS reminders. The system uses Flask as the back-end framework and React as the front-end development framework.",
                    CreateAt = DateTime.Now

                },
                new Experience
                {
                    Title = "Lead of Software developers",
                    Location = "Beijing, China",
                    Duration = "2011-2017",
                    Description = "Helping the company to provid software development consulting service. We have created massive middlewares for Enterprise Management Information Systems, SEO Management Systems, Server Deploying, Database Architecture Design. I used Ruby on Rails to implement these solutions to the requirements of my clients."

                },
                new Experience
                {
                    Title = "IT Director",
                    Location = "Beijing, China",
                    Duration = "2008 - 2011",
                    Description = "Leader of the development team in charge of creating and managing their own MHIS (Management Hospital Information System)."
                  
                },
                new Experience
                {
                    Title = "Software Development Manager",
                    Location = "Beijing, China",
                    Duration = "2006 - 2008",
                    Description = "Establishing a pet portal website (Baopet) for the company."

                },
                new Experience
                {
                    Title = "Software Engineer",
                    Location = "Zhengzhou, China",
                    Duration = "2004 - 2006",
                    Description = "Worked in Communication System Development, working with programmes such as IP BPX Software (.NET C#), IP BPX middleware, DS-iTouch Connect Center. Established and maintained the company website."

                }
            };
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyWebSiteContext(serviceProvider.GetRequiredService<DbContextOptions<MyWebSiteContext>>())){

                if (!context.Skill.Any())
                    context.Skill.AddRange(AddSkill());
                if (!context.Experience.Any())
                    context.Experience.AddRange(AddExperience());
                if (!context.Portfolio.Any())
                    context.Portfolio.AddRange(AddPortfolio());
                if (!context.Article.Any())
                    context.Article.AddRange(GetArticleMd("db\\md\\"));
                if (!context.Message.Any())
                    context.Message.AddRange(FakeMessages(100));

                
                context.SaveChanges();
            }
        }
    }
}