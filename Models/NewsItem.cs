using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagementApi.Models
{
    public class NewsItem
    {

        public int Id { get; set; }
        public string Title { get; set; } = "";

        public string Content { get; set; } = "";
    }
}