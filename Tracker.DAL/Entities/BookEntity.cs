using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tracker.DAL.Entities
{
    public class BookEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", ApplyFormatInEditMode = true)]
        public DateTime? DateRead { get; set; }
        [Range (1,10)]
        public int? Rating { get; set; }

        public Guid AuthorId { get; set; }
        public virtual AuthorEntity AuthorEntity { get; set; }
    }
}
