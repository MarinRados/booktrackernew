using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Tracker.Model
{
    public class Book : IBook
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", ApplyFormatInEditMode = true)]
        public DateTime? DateRead { get; set; }
        public int? Rating { get; set; }

        //Foreign key
        public Guid AuthorId { get; set; }

        //One to one
        public virtual IAuthor Author { get; set; }
    }
}
