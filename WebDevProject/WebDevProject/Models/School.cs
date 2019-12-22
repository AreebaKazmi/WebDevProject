namespace WebDevProject.Views.Account
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("School")]
    public partial class School
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public School()
        {
            Candidates = new HashSet<Candidate>();
            Admit_Card = new HashSet<Admit_Card>();
        }

        [Key]
        [Column("School Code")]
        public int School_Code { get; set; }

        public int PrincipleID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Address { get; set; }

        [Column("Contact Number")]
        public long Contact_Number { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Candidate> Candidates { get; set; }

        public virtual Principle Principle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admit_Card> Admit_Card { get; set; }
    }
}
