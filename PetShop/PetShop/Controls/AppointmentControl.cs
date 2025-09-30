using PetShop.Data;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Controls
{
    public class AppointmentControl
    {
        private readonly PetShopContext Context;
        AppointmentControl(PetShopContext _Context)
        {
            Context = _Context;
        }
        public void ScheduleAppointment(DateTime Day, Timeslot Time)
        {
        }
    }
}
