namespace UMS.Models.EntityModels
{
    using System.ComponentModel;

    public class ProfilePosition
    {
        public int Id { get; set; }

        public string PositionName { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }
    }
}
