namespace CodeModelFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_BusinessPartner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SR_ID_pk { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(9)]
        public string BP_PlaceholderID { get; set; }

        [StringLength(9)]
        public string BP_ID { get; set; }

        [StringLength(35)]
        public string BP_Name { get; set; }

        [StringLength(100)]
        public string BP_UST_Nu { get; set; }

        public int? BP_EmployeesNr { get; set; }

        [StringLength(3)]
        public string BP_EMSPotential { get; set; }

        [StringLength(50)]
        public string BP_EMPSPotential_Def { get; set; }

        public int? BP_Rating { get; set; }

        [StringLength(10)]
        public string BP_Rating_Def { get; set; }

        [StringLength(10)]
        public string BP_BussinesBranche { get; set; }

        [StringLength(30)]
        public string BP_BussinesBranche_Def { get; set; }

        [StringLength(3)]
        public string BP_Language { get; set; }

        [StringLength(3)]
        public string BP_Currency { get; set; }

        [StringLength(30)]
        public string BP_Street { get; set; }

        [StringLength(10)]
        public string BP_HouseNr { get; set; }

        [StringLength(10)]
        public string BP_ZipCode { get; set; }

        [StringLength(90)]
        public string BP_City { get; set; }

        [StringLength(50)]
        public string BP_Country { get; set; }

        [StringLength(150)]
        public string BP_Website { get; set; }

        [StringLength(100)]
        public string BP_CurrentType { get; set; }

        [StringLength(5)]
        public string is_Deleted { get; set; }

        public DateTime? TimestampInregistrare { get; set; }

        [StringLength(300)]
        public string PINDataEntry { get; set; }
    }
}
