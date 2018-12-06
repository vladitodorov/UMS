namespace UMS.Models.EntityModels
{
    using System.ComponentModel;

    public class ProfileHeading
    {
        public int Id { get; set; }

        public string HeadingName { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }
    }
}
