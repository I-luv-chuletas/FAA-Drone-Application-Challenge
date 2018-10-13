using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAADroneRegistrationApplication.Models
{
    public class ConsumerDrones
    {
        public int ID { get; set; }
        private int DroneIdNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

    }
}
