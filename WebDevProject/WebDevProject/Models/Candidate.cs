namespace WebDevProject.Views.Account
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Candidate")]
    public partial class Candidate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Candidate()
        {
            Admit_Card = new HashSet<Admit_Card>();
            Examinations = new HashSet<Examination>();
        }

        [Key]
        [Column("Roll Number")]
        public int Roll_Number { get; set; }

        public int StatusID { get; set; }

        public int PersonID { get; set; }

        [Column("School Code")]
        public int? School_Code { get; set; }

        public int GuardianID { get; set; }

        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Gender { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Religion { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Picture { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Address { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Email { get; set; }

        [Column("Private Candidate")]
        public bool Private_Candidate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admit_Card> Admit_Card { get; set; }

        public virtual Guardian Guardian { get; set; }

        public virtual Person Person { get; set; }

        public virtual School School { get; set; }

        public virtual Status_2 Status_2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Examination> Examinations { get; set; }
    }
}
