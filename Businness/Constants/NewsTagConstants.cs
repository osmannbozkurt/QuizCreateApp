using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Constants
{
    public static class NewsTagConstants
    {
        public const string RootUrl = "https://www.wired.com";
        public const string NewsUrl = RootUrl +"/most-recent";
        public const string MostRecentUrlTag = "SummaryItemHedLink-cgPsOZ cEGVhT summary-item-tracking__hed-link summary-item__hed-link";
        public const string NewsTitleTag = "ContentHeaderHed";
        public const string NewsContentTag = "data-attribute-verso-pattern";

    }
}
