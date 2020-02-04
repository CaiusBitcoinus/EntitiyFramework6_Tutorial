namespace CodeModelFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SalesReport
    {
        [Key]
        public long SR_ID_pk { get; set; }

        public DateTime SR_DateTime { get; set; }

        [StringLength(9)]
        public string SR_Author { get; set; }

        [StringLength(35)]
        public string SR_Author_Name { get; set; }

        [StringLength(30)]
        public string SR_ReasonOfVisit { get; set; }

        public string SR_Subject { get; set; }

        [StringLength(100)]
        public string SR_LocationOrt { get; set; }

        public string SR_NextSteps { get; set; }

        public string SR_Fazit { get; set; }

        public int? SR_Result { get; set; }

        [StringLength(50)]
        public string SR_Result_Def { get; set; }

        public int? SR_CurrentStatus { get; set; }

        [StringLength(50)]
        public string SR_CurrentStatus_Def { get; set; }

        [StringLength(100)]
        public string SR_InformationIntegrity_Type { get; set; }

        [StringLength(100)]
        public string SR_CurrentType { get; set; }

        [StringLength(5)]
        public string is_Deleted { get; set; }

        public DateTime? TimestampInregistrare { get; set; }

        [StringLength(300)]
        public string PINDataEntry { get; set; }
    }
}
