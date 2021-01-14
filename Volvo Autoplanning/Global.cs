using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volvo_Autoplanning
{
    public static class Global
    {
        public static string Date { get; set; } //Set up pseudo-global variable for multiple data usage of Date input for planning

        //SLOTS GLOBALS VALUES
        public static string S1 { get; set; }
        public static string S2 { get; set; }
        public static string S3 { get; set; }
        public static string S4 { get; set; }
        public static string S5 { get; set; }
        public static string S6 { get; set; }
        public static string S7 { get; set; }
        public static string S8 { get; set; }
        public static string S9 { get; set; }
        public static string S10 { get; set; }
        public static string S11 { get; set; }
        public static string S12 { get; set; }

        public static string SS1 { get; set; }
        public static string SS2 { get; set; }

        public static int BE { get; set; }
        public static int SE { get; set; }

        public static int CZ { get; set; }
        public static int RS { get; set; }
        public static int SK { get; set; }
        public static int TR { get; set; }
        public static int AT { get; set; }
        public static int HR { get; set; }
        public static int SI { get; set; }
        public static int BG { get; set; }
        public static int HU { get; set; }
        public static int RO { get; set; }
        public static int PL { get; set; }

        public static List<TruckData_Image> listTruck { get; set; }
    }
}
