namespace UMS.Models.ViewModels.AdAccount
{
    using System.Collections.Generic;
    using UMS.Models.EntityModels;

    public class AdAccountViewModel
    {
        public int Id { get; set; }

        public string SamAccount { get; set; }

        public long Egn { get; set; }

        public int HermesId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsAcive { get; set; }

        public virtual ICollection<AdGroup> AdGroups { get; set; }
    }
}
