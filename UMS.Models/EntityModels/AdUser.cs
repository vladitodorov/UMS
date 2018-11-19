namespace UMS.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AdUser
    {
        public AdUser()
        {
            this.AdGroups = new HashSet<AdGroup>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 7)]
        public string SamAccount { get; set; }

        public long Egn { get; set; }

        public int HermesId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public bool IsAcive { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateClosed { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LastModifiedDate { get; set; }

        public virtual ICollection<AdGroup> AdGroups { get; set; }
    }
}
