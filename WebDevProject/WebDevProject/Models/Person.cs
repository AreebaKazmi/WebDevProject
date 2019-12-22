namespace WebDevProject.Views.Account
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            Candidates = new HashSet<Candidate>();
            Guardians = new HashSet<Guardian>();
            Principles = new HashSet<Principle>();
        }

        public int PersonID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Name { get; set; }

        [Column("CNIC/B-Form")]
        [Display(Name = "CNIC/B-Form")]
        public long CNIC_B_Form { get; set; }

        [Column("Mobile Number")]
        public long? Mobile_Number { get; set; }

        [Column("Residence Telephone Number")]
        [Display(Name = "Residence No.")]
        public long? Residence_Telephone_Number { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Candidate> Candidates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Guardian> Guardians { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Principle> Principles { get; set; }
    }
}
