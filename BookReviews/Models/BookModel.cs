using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviews.Models
{
    internal class BookModel
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string PublishYear { get; set; }
        public string Rating { get; set; }
        public string UserDescription { get; set; }
        public string UserThoughts { get; set; }
    }
}
