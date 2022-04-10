using Businness.Constants;
using Businness.Model;
using Businness.Services;
using Core.Utilities.Results;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Managers
{
    public class BlogServiceManager : IBlogSelectService
    {
        public IDataResult<List<NewsContentModel>> GetLatestNews()
        {
            List<NewsContentModel> result = new List<NewsContentModel>();

            var url = GetLatestNewsUrl();

            foreach (var item in url)
            {
                var singleNew = GetNewsContentFromUrl(item);
                result.Add(singleNew);
            }


            return new SuccessDataResult<List<NewsContentModel>>(result);
        }

        private List<string> GetLatestNewsUrl()
        {
            List<string> resultList = new List<string>();
            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(NewsTagConstants.NewsUrl);

            var result = htmlDoc.DocumentNode.SelectNodes("//a[contains(@class, '" + NewsTagConstants.MostRecentUrlTag + "')]");


            foreach (var item in result)
            {
                var href = item.GetAttributeValue("href", "");
                if (!string.IsNullOrEmpty(href))
                {
                    string fullUrl = NewsTagConstants.RootUrl + href;
                    resultList.Add(fullUrl);
                }
                if (resultList.Count == 5)
                {
                    break;
                }
            }
            return resultList;
        }

        private NewsContentModel GetNewsContentFromUrl(string NewsUrl)
        {
            NewsContentModel result = new NewsContentModel();
            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(NewsUrl);

            var htmlAresList = htmlDoc.DocumentNode.SelectNodes("//*[@data-testid]");
            var bodyFull = htmlDoc.DocumentNode.SelectNodes("//*[@" + NewsTagConstants.NewsContentTag + "]");
            string newsTitle = "";

            foreach (var item in htmlAresList)
            {
                var atttR = item.GetAttributeValue("data-testid", "");

                if (atttR == NewsTagConstants.NewsTitleTag)
                {
                    newsTitle = item.InnerText;
                }
            }
            result.NewsUrl = NewsUrl;
            result.NewsTitle = newsTitle;
            result.NewsContent = bodyFull[0].InnerText;


            return result;
        }


    }
}
