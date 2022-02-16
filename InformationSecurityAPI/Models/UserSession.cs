using System;
using System.Collections.Generic;

#nullable disable

namespace InformationSecurityAPI.Models
{
    public partial class UserSession
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime? DateLogin { get; set; }
        public bool? IsLogged { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
