using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entidades
{
    public class Email
    {
        [Key]
        public int Id { get; set; }
        public int TitularId { get; set; }
        [EmailAddress]
        [Column(TypeName = "nvarchar(100)")]
        public string DireccionEmail { get; set; }

        public virtual Titular Titular { get; set; }
    }
}
