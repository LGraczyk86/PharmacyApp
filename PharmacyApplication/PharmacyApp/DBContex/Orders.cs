using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
{
    class Orders
    {
        public long ID { get; set; }
        public long PrescriptionID { get; set; }
        public long MedicinID { get; set; }
        public System.DateTime Data { get; set; }
        public long Amount { get; set; }

    }
}
