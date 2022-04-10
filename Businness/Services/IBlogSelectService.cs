using Businness.Model;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Services
{
    public interface IBlogSelectService
    {
        //IDataResult<List<string>> GetLatestNewsUrl();
        //IDataResult<NewsContentModel> GetNewsContentFromUrl(string NewsUrl);
        IDataResult<List<NewsContentModel>> GetLatestNews();

    }
}
