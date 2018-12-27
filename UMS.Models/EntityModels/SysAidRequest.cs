namespace UMS.Models.EntityModels
{
    using System;

    public class SysAidRequest
    {
        public int Id { get; set; }

        public long RequestId { get; set; }

        public string FirstLevel { get; set; }

        public string SecondLevel { get; set; }

        public string ThirdLevel { get; set; }

        public string Status { get; set; }

        public DateTime InsertTime { get; set; }

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
