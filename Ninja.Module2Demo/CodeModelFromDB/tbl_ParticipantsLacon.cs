namespace CodeModelFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ParticipantsLacon
    {
        public long SR_ID_pk { get; set; }

        [Key]
        public int PL_ID_PK { get; set; }

        [Required]
        [StringLength(9)]
        public string PL_LaconCode { get; set; }

        [Required]
        [StringLength(50)]
        public string PL_FullName { get; set; }

        [StringLength(100)]
        public string PL_InformationIntegrity_Type { get; set; }

        [StringLength(5)]
        public string is_Deleted { get; set; }

        public DateTime? TimestampInregistrare { get; set; }

        [StringLength(300)]
        public string PINDataEntry { get; set; }
    }
}
