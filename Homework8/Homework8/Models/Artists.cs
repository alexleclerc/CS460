using System;
using System.Collections.Generic;

namespace Homework8.Models
{
    public partial class Artists
    {
        public Artists()
        {
            Artworks = new HashSet<Artworks>();
        }

        public int ArtistId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthCity { get; set; }

        public ICollection<Artworks> Artworks { get; set; }
    }
}
