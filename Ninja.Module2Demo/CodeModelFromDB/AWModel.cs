namespace CodeModelFromDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AWModel : DbContext
    {
        public AWModel()
            : base("name=AWModel")
        {
        }

        public virtual DbSet<tbl_BusinessPartner> tbl_BusinessPartner { get; set; }
        public virtual DbSet<tbl_Contacts_BusinessPartner> tbl_Contacts_BusinessPartner { get; set; }
        public virtual DbSet<tbl_ParticipantsLacon> tbl_ParticipantsLacon { get; set; }
        public virtual DbSet<tbl_SalesReport> tbl_SalesReport { get; set; }
        public virtual DbSet<tbl_CBP_Attributes> tbl_CBP_Attributes { get; set; }
        public virtual DbSet<tbl_CBP_Categories> tbl_CBP_Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_BusinessPartner>()
                .Property(e => e.BP_PlaceholderID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Contacts_BusinessPartner>()
                .Property(e => e.CT_PlaceholderID)
                .IsUnicode(false);
        }
    }
}
