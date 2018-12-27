namespace UMS.Models.ViewModels.Home
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AllRequestsForProfilingViewModel
    {
        public int Id { get; set; }

        public long RequestId { get; set; }

        public string FirstLevel { get; set; }

        public string SecondLevel { get; set; }

        public string ThirdLevel { get; set; }

        public string Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime InsertTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CloseTime { get; set; }

        public string UserFirstName { get; set; }

        public string UserSurName { get; set; }

        public string UserFamilyName { get; set; }

        public string UserEGN { get; set; }

        public string UserAddress { get; set; }

        public string HermesId { get; set; }

        public string Email { get; set; }

        public string AdAccount { get; set; }

        public string Napravlenie { get; set; }

        public string Upravlenie { get; set; }

        public string Direction { get; set; }

        public string Otdel { get; set; }

        public string Position { get; set; }

        public string RequestUser { get; set; }

        public string RequestStatus { get; set; }
    }
}
