namespace Proj_BTL_NguyenMinhQuang_2018600016.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProduct")]
    public partial class tblProduct
    {
        [Key]
        public int Pid { get; set; }

        public int Categoryid { get; set; }

        [StringLength(250)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string MetaTittle { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [StringLength(550)]
        public string ImagePath { get; set; }

        public decimal Price { get; set; }

        [StringLength(250)]
        public string AdditionalImage1 { get; set; }

        [StringLength(250)]
        public string AdditionalImage2 { get; set; }

        [StringLength(250)]
        public string AdditionalDetail { get; set; }

        public virtual tblCategory tblCategory { get; set; }
    }
}
