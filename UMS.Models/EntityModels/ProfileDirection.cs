namespace UMS.Models.EntityModels
{
    using System.ComponentModel;

    public class ProfileDirection
    {
        public int Id { get; set; }

        public string DirectionName { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }
    }
}
