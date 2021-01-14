using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volvo_Autoplanning
{
    public class LoadData_Image
    {
        public string LN { get; set; }
        public string TO { get; set; }
        public string DeliveryName { get; set; }
        public string StatusTO { get; set; }
        public string TransportMode { get; set; }
        public string Supplier { get; set; }
        public string SupplierCountry { get; set; }
        public string PlannedPickupDay { get; set; }
        public string CarrierName { get; set; }
        public string PlannedEarliestArrival { get; set; }
        public int CTW { get; set; }
        public string Colli { get; set; }
        public string EstimatedDayArrival { get; set; }
        public string EstimatedTimeArrival { get; set; }
        public string ADR { get; set; }
        public string PlateTrailer { get; set; }
        public string PlannedSlot { get; set; }
        public string Gate { get; set; }
    }
}
