using System;
using System.Collections.Generic;

#nullable disable

namespace ApartmentManagementSystem.Models
{
    public partial class Announcement
    {
        public int AnnouncementId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}
