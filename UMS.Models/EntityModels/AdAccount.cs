namespace UMS.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AdAccount
    {
        public AdAccount()
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

        public virtual ICollection<AdGroup> AdGroups { get; set; }
    }
}
