using ExamForWired.Data.Models;
using ExamForWired.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ExamForWired.Business.Service
{
    public class ArticleService : BaseService, IArticleService
    {
        public ArticleService(ExamForWiredDbContext examForWiredDbContext):base(examForWiredDbContext)
        {
        }
        public List<ArticleModel> GetArticleListFromWired()
        {
            var xml = XDocument.Load("https://www.wired.com/feed/rss");

            var articleList = xml.Root.Descendants("item").Select(
                p => new ArticleModel
                {
                    Title = p.Element("title").Value,
                    PubDate = Convert.ToDateTime(p.Element("pubDate").Value),
                    URL = p.Element("link").Value
                })
                .Take(5)
                .ToList();
            articleList = FillArticleContent(articleList);
            return articleList;
        }

        private List<ArticleModel> FillArticleContent(List<ArticleModel> articleList)
        {
            HtmlWeb web = new HtmlWeb();
            foreach (var item in articleList)
            {
                HtmlDocument document = web.Load(item.URL);
                HtmlNode[] nodes = document.DocumentNode.SelectNodes("//p").ToArray();
                for (var i = 0; i < nodes.Count(); i++)
                {
                    HtmlNode htmlNote = nodes[i];

                    if (i < nodes.Count() - 5)
                    {
                        item.Content += "<br>" + htmlNote.InnerText;
                    }
                }
            }
            return articleList;
        }
    }
}
