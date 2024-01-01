using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Entities
{
    public class ProductReview
    {
        public int ProductReviewId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string AuthorName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
