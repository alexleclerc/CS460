using System;
using System.Collections.Generic;

namespace Homework8.Models
{
    public partial class Genres
    {
        public Genres()
        {
            Classifications = new HashSet<Classifications>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; }

        public ICollection<Classifications> Classifications { get; set; }
    }
}
