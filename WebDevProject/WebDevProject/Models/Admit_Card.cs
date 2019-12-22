namespace WebDevProject.Views.Account
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admit Card")]
    public partial class Admit_Card
    {
        [Key]
        [Column("School Code", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int School_Code { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GuardianID { get; set; }

        [Key]
        [Column("Roll Number", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Roll_Number { get; set; }

        public virtual Candidate Candidate { get; set; }

        public virtual Guardian Guardian { get; set; }

        public virtual School School { get; set; }
    }
}
