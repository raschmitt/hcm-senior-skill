using Newtonsoft.Json;

namespace Hcm.Skill.Domain.Models
{
    public class ClockingEventFilter
    {
        [JsonProperty("filter")]
        public Filter Filter { get; set; }

        public ClockingEventFilter()
        {
            Filter = new Filter();
        }
    }

    public class Filter
    {
        [JsonProperty("pageInfo")]
        public PageInfo PageInfo { get; set; }

        [JsonProperty("nameSearch")]
        public string NameSearch { get; set; }

        public Filter()
        {
            PageInfo = new PageInfo();
            NameSearch = "";
        }
    }

    public class PageInfo
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        public PageInfo()
        {
            Page = 0;
            PageSize = 10;
        }
    }
}
