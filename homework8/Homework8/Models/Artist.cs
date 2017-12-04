namespace Homework8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Artist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artist()
        {
            Artworks = new HashSet<Artwork>();
        }

        public int ArtistID { get; set; }

        [StringLength(50, ErrorMessage = "First name can't be longer than 50 characters.")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Middle name can't be longer than 50 characters.")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "First name can't be longer than 50 characters.")]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}")]
        [RestrictedDate]
        public DateTime? BirthDate { get; set; }

        [StringLength(100)]
        public string BirthCity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Artwork> Artworks { get; set; }

        public class RestrictedDate : ValidationAttribute
        {
            public override bool IsValid(object date)
            {
                DateTime Date = (DateTime)date;
                return Date < DateTime.Now;
            }
        }
    }
}
