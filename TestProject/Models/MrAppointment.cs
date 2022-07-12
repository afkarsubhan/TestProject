using System;
using System.Collections.Generic;

namespace Appointments.Models
{
    public partial class MrAppointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string PetName { get; set; } = null!;
        public string OwnerName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
