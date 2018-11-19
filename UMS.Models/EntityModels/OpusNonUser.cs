namespace UMS.Models.EntityModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    //OPUS NonLife User
    public class OpusNonUser
    {
        public int Id { get; set; }

        [Required]
        public string OpusUserName { get; set; }

        [Required]
        public string Agency { get; set; }

        [Required]
        public long Egn { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateClosed { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastModifiedDate { get; set; }
    }
}

