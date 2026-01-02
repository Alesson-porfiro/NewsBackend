using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoIntelligence.Api.Domain.Entities
{
    public class NewsTube
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Image {get; set;} = string.Empty;
        public string Source { get; set; } = string.Empty;
        public DateTime PublishedAt { get; set; }
    }
}