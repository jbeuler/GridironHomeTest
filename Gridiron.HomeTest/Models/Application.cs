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
        public string Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        // mm/dd/yy
        [Column(TypeName = "nvarchar(8)")]
        public string EffectiveDate { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string AddressStreet { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string AddressCity { get; set; }

        [Column(TypeName = "nvarchar(2)")]
        public string AddressState { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string AddressZip { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string InsuredValueAmount { get; set; }


    }
}
