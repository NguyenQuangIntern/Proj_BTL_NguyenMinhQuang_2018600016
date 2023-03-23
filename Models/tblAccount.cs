namespace Proj_BTL_NguyenMinhQuang_2018600016.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblAccount")]
    public partial class tblAccount
    {
        [Key]
        [StringLength(100)]
        public string AccountName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public bool Status { get; set; }

        public bool Type { get; set; }
    }
}
