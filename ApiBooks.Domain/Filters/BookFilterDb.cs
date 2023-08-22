using ApiBooks.Domain.Paged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Domain.Filters
{
    public class BookFilterDb : PagedBaseRequest
    {
        public string? Title { get; set; }
    }
}
