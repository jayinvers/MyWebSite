using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyWebSite.Data;
using System;
using System.Linq;

namespace MyWebSite.Models
{
    public static class SeedData
    {

        private static Article[] addArticle()
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

        private static Portfolio[] addPortfolio()
        {
            return new Portfolio[] { new Portfolio
                {
                Title = "Hospital Information Management System",
                Description = "Haiyi (Yuemei) Ltd，- Advertisement Management System [ Ruby On Rails, MySQL, Java (Desktop client), JavaScript (Bootstrap for front-end) ]",
                Pic = "/pic/cases/01.png"
                },
                new Portfolio{
                Title = "Case 2",
                Description = "Haiyi (Yuemei) Ltd，- Advertisement Management System [ Ruby On Rails, MySQL, Java (Desktop client), JavaScript (Bootstrap for front-end) ]",
                Pic = "/pic/cases/02.png"
                },
                new Portfolio{
                Title = "Case 3",
                Description = "Haiyi (Yuemei) Ltd，- Advertisement Management System [ Ruby On Rails, MySQL, Java (Desktop client), JavaScript (Bootstrap for front-end) ]",
                Pic = "/pic/cases/03.png"
                },

        };
        }
        private static Experience[] addExperience()
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
                    Description = "Design and development of SMS reminder system. The system provides APIs and management panels for commercial customers to complete SMS reminders. The system uses Flask as the back-end framework and React as the front-end development framework."

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
            using (var context = new MyWebSiteContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyWebSiteContext>>()))
            {
                if(!context.Experience.Any())
                    context.Experience.AddRange(addExperience());
                if (!context.Portfolio.Any())
                    context.Portfolio.AddRange(addPortfolio());
                if (!context.Article.Any())
                    context.Article.AddRange(addArticle());
                context.SaveChanges();

                
            }
        }
    }
}