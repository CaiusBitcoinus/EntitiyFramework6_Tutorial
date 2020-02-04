namespace CodeModelFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_CBP_Attributes
    {
        [Key]
        [StringLength(9)]
        public string CBP_ASP_Code { get; set; }

        [StringLength(10)]
        public string Att_Code { get; set; }

        [StringLength(50)]
        public string Att_Def { get; set; }

        [StringLength(3)]
        public string Att_Value { get; set; }

        [StringLength(5)]
        public string is_Deleted { get; set; }

        public DateTime? TimestampInregistrare { get; set; }

        [StringLength(300)]
        public string PINDataEntry { get; set; }
    }
}
