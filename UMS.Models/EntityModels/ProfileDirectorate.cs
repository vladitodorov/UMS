namespace UMS.Models.EntityModels
{
    using System.ComponentModel;

    public  class ProfileDirectorate
    {
        public int Id { get; set; }

        public string DirectorateName { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }
    }
}
