using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
{
    class Prescription
    {
        public long ID { get; set; }
        public string CustomersName { get; set; }
        public string Pesel { get; set; }
        public string PrescriptionNumber { get; set; }
    }
}
