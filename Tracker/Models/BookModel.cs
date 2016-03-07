using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tracker.Models
{
    public class BookModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateRead { get; set; }
        [Range(1, 10)]
        public int? Rating { get; set; }

        public Guid AuthorId { get; set; }

        //one to one, one missing person can be reported in only one Red cross
        public virtual AuthorModel AuthorModel { get; set; }
    }
}