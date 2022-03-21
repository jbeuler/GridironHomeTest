using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gridiron.HomeTest.Models
{
    public class Application
    {
        public Application()
        {
        }

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        // yyyy-mm-dd
        [Column(TypeName = "datetime, not null")]
        public DateTime EffectiveDate { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string AddressStreet { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string AddressCity { get; set; }

        [Column(TypeName = "nvarchar(2)")]
        public string AddressState { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string AddressZip { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal InsuredValueAmount { get; set; }
    }
}
