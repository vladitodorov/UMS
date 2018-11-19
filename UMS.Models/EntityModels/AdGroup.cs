namespace UMS.Models.EntityModels
{
    using System.Collections.Generic;

    public class AdGroup
    {
        public AdGroup()
        {
            this.AdAccounts = new HashSet<AdUser>();
        }

        public int Id { get; set; }

        public string GroupName { get; set; }

        public virtual ICollection<AdUser> AdAccounts { get; set; }
    }
}
