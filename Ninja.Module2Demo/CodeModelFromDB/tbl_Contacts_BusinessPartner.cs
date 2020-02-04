namespace CodeModelFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Contacts_BusinessPartner
    {
        public long SR_ID_pk { get; set; }

        [Key]
        public int CBP_ID_PK { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(9)]
        public string CT_PlaceholderID { get; set; }

        [StringLength(9)]
        public string CBP_ASP_Code { get; set; }

        [StringLength(30)]
        public string CBP_FullName { get; set; }

        [StringLength(50)]
        public string CBP_Position { get; set; }

        [StringLength(50)]
        public string CBP_Departament { get; set; }

        [StringLength(100)]
        public string CBP_Email { get; set; }

        [StringLength(20)]
        public string CBP_Phone { get; set; }

        [StringLength(20)]
        public string CBP_Mobile { get; set; }

        [StringLength(3)]
        public string CBP_BuyerRole { get; set; }

        [StringLength(30)]
        public string CBP_BuyerRole_Def { get; set; }

        [StringLength(100)]
        public string CBP_CurrentType { get; set; }

        [StringLength(5)]
        public string is_Deleted { get; set; }

        public DateTime? TimestampInregistrare { get; set; }

        [StringLength(300)]
        public string PINDataEntry { get; set; }
    }
}
