using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tracker.Models
{
    public class AuthorModel
    {
        public Guid AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }

        public virtual ICollection<BookModel> BookModels { get; set; }
    }
}