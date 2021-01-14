using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Volvo_Autoplanning
{
    public class GenerateCSVs
    {
        public void CompletedPlanToCSV(List<LoadData_Image> loadData) //Generating csv for Volvo with all data on date
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(Path.Combine(Path.Combine(desktopPath, "Volvo Autoplan"), "VOLVO"), "VOLVO_" + DateTime.Now.ToShortDateString() + ".csv"); //Full path of file with date in name for sorting

            using (var w = new StreamWriter(fullPath)) //Initialize StreamWrite to write into csv
            {
                w.WriteLine("Load number; Transport number; Delivery name; Status TO; Transport mode; Supplier (Partner code); Supplier Country; Planned pickup day; Carrier name; Planned earliest time of arrival [day]; Confirmed time window; Number of packages; Estimated day of arrival [DD:MM:YYYY]; Estimated time of arrival [HH:MM]; ADR; Plate trailer; Planned Slot; Gate"); //Write first line header

                foreach (var iterate in loadData) //Start foreach iteration in whole list and write particular data
                {
                    if (iterate.PlateTrailer == "") //If entry doesn't have a Trailer License Plate, it will replace it with Load number
                    {
                        switch (iterate.CTW.ToString()) //Editing data in CTW. Instead of CTW = 6 -> CTW = 6:00-10:00
                        {
                            case "6":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "6:00-10:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "10":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "10:00-14:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "14":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "14:00-18:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "18":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-23:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "20":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "21":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                        }
                    }
                    else
                    {
                        switch (iterate.CTW.ToString()) //If entry has Traielr License Plate, write it and change/replace nothing
                        {
                            case "6":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "6:00-10:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "10":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "10:00-14:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "14":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "14:00-18:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "18":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-23:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "20":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "21":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                        }
                    }                    
                }
            }
        }

        //Generate for LKW //For documentation look into CompletedPlanToCSV //Here you can find addition particular comments for selective write and file creation
        public void PlanForLKW(List<LoadData_Image> loadData)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(Path.Combine(Path.Combine(desktopPath, "Volvo Autoplan"), "LKW"), "LKW_" + DateTime.Now.ToShortDateString() + ".csv");

            using (var w = new StreamWriter(fullPath))
            {
                w.WriteLine("Load number; Transport number; Delivery name; Status TO; Transport mode; Supplier (Partner code); Supplier Country; Planned pickup day; Carrier name; Planned earliest time of arrival [day]; Confirmed time window; Number of packages; Estimated day of arrival [DD:MM:YYYY]; Estimated time of arrival [HH:MM]; ADR; Plate trailer; Planned Slot; Gate");

                foreach (var iterate in loadData)
                {
                    if (iterate.PlateTrailer == "" && iterate.CarrierName == "ABVHF LKW Walter Internationale") //Adding statement by Carrier name to select data for particular carrier and create csv just for him
                    {
                        switch (iterate.CTW.ToString())
                        {
                            case "6":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "6:00-10:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "10":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "10:00-14:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "14":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "14:00-18:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "18":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-23:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "20":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "21":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                        }
                    }
                    else if (iterate.PlateTrailer != "" && iterate.CarrierName == "ABVHF LKW Walter Internationale")
                    {
                        switch (iterate.CTW.ToString())
                        {
                            case "6":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "6:00-10:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "10":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "10:00-14:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "14":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "14:00-18:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "18":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-23:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "20":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "21":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                        }
                    }
                }
            }
        }

        //Generate for EKOL //For documentation look into CompletedPlanToCSV/PlanForLKW
        public void PlanForEKOL(List<LoadData_Image> loadData)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(Path.Combine(Path.Combine(desktopPath, "Volvo Autoplan"), "EKOL"), "EKOL_" + DateTime.Now.ToShortDateString() + ".csv");

            using (var w = new StreamWriter(fullPath))
            {
                w.WriteLine("Load number; Transport number; Delivery name; Status TO; Transport mode; Supplier (Partner code); Supplier Country; Planned pickup day; Carrier name; Planned earliest time of arrival [day]; Confirmed time window; Number of packages; Estimated day of arrival [DD:MM:YYYY]; Estimated time of arrival [HH:MM]; ADR; Plate trailer; Planned Slot; Gate");

                foreach (var iterate in loadData)
                {
                    if (iterate.PlateTrailer == "" && iterate.CarrierName == "AEAIK EKOL Lojistik A.S")
                    {
                        switch (iterate.CTW.ToString())
                        {
                            case "6":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "6:00-10:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "10":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "10:00-14:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "14":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "14:00-18:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "18":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-23:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "20":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "21":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                        }
                    }
                    else if (iterate.PlateTrailer != "" && iterate.CarrierName == "AEAIK EKOL Lojistik A.S")
                    {
                        switch (iterate.CTW.ToString())
                        {
                            case "6":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "6:00-10:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "10":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "10:00-14:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "14":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "14:00-18:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "18":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-23:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "20":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "21":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                        }
                    }
                }
            }
        }

        //Generate for CAT //For documentation look into CompletedPlanToCSV/PlanForLKW
        public void PlanForCAT(List<LoadData_Image> loadData)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(Path.Combine(Path.Combine(desktopPath, "Volvo Autoplan"), "CAT"), "CAT_" + DateTime.Now.ToShortDateString() + ".csv");

            using (var w = new StreamWriter(fullPath))
            {
                w.WriteLine("Load number; Transport number; Delivery name; Status TO; Transport mode; Supplier (Partner code); Supplier Country; Planned pickup day; Carrier name; Planned earliest time of arrival [day]; Confirmed time window; Number of packages; Estimated day of arrival [DD:MM:YYYY]; Estimated time of arrival [HH:MM]; ADR; Plate trailer; Planned Slot; Gate");

                foreach (var iterate in loadData)
                {
                    if (iterate.PlateTrailer == "" && iterate.CarrierName == "AEALC Cat Groupe")
                    {
                        switch (iterate.CTW.ToString())
                        {
                            case "6":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "6:00-10:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "10":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "10:00-14:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "14":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "14:00-18:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "18":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-23:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "20":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "21":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                        }
                    }
                    else if (iterate.PlateTrailer != "" && iterate.CarrierName == "AEALC Cat Groupe")
                    {
                        switch (iterate.CTW.ToString())
                        {
                            case "6":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "6:00-10:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "10":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "10:00-14:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "14":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "14:00-18:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "18":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-23:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "20":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "21":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                        }
                    }
                }
            }
        }

        //Generate for DUVENBECK //For documentation look into CompletedPlanToCSV/PlanForLKW
        public void PlanForDUVENBECK(List<LoadData_Image> loadData)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(Path.Combine(Path.Combine(desktopPath, "Volvo Autoplan"), "DUVENBECK"), "DUVENBECK_" + DateTime.Now.ToShortDateString() + ".csv");

            using (var w = new StreamWriter(fullPath))
            {
                w.WriteLine("Load number; Transport number; Delivery name; Status TO; Transport mode; Supplier (Partner code); Supplier Country; Planned pickup day; Carrier name; Planned earliest time of arrival [day]; Confirmed time window; Number of packages; Estimated day of arrival [DD:MM:YYYY]; Estimated time of arrival [HH:MM]; ADR; Plate trailer; Planned Slot; Gate");

                foreach (var iterate in loadData)
                {
                    if (iterate.PlateTrailer == "" && iterate.CarrierName == "AEC2M Duvenbeck Kraftverkehr GmbH &Co")
                    {
                        switch (iterate.CTW.ToString())
                        {
                            case "6":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "6:00-10:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "10":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "10:00-14:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "14":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "14:00-18:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "18":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-23:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "20":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "21":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                        }
                    }
                    else if (iterate.PlateTrailer != "" && iterate.CarrierName == "AEC2M Duvenbeck Kraftverkehr GmbH &Co")
                    {
                        switch (iterate.CTW.ToString())
                        {
                            case "6":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "6:00-10:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "10":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "10:00-14:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "14":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "14:00-18:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "18":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-23:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "20":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "21":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                        }
                    }
                }
            }
        }

        //Generate for EWALS //For documentation look into CompletedPlanToCSV/PlanForLKW
        public void PlanForEWALS(List<LoadData_Image> loadData)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(Path.Combine(Path.Combine(desktopPath, "Volvo Autoplan"), "EWALS"), "EWALS_" + DateTime.Now.ToShortDateString() + ".csv");

            using (var w = new StreamWriter(fullPath))
            {
                w.WriteLine("Load number; Transport number; Delivery name; Status TO; Transport mode; Supplier (Partner code); Supplier Country; Planned pickup day; Carrier name; Planned earliest time of arrival [day]; Confirmed time window; Number of packages; Estimated day of arrival [DD:MM:YYYY]; Estimated time of arrival [HH:MM]; ADR; Plate trailer; Planned Slot; Gate");

                foreach (var iterate in loadData)
                {
                    if (iterate.PlateTrailer == "" && iterate.CarrierName == "AEC3B EWALS CARGO CARE B.V.")
                    {
                        switch (iterate.CTW.ToString())
                        {
                            case "6":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "6:00-10:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "10":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "10:00-14:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "14":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "14:00-18:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "18":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-23:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "20":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "21":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                        }
                    }
                    else if (iterate.PlateTrailer != "" && iterate.CarrierName == "AEC3B EWALS CARGO CARE B.V.")
                    {
                        switch (iterate.CTW.ToString())
                        {
                            case "6":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "6:00-10:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "10":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "10:00-14:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "14":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "14:00-18:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "18":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-23:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "20":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "21":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                        }
                    }
                }
            }
        }

        //Generate for ALEX //For documentation look into CompletedPlanToCSV/PlanForLKW
        public void PlanForALEX(List<LoadData_Image> loadData)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(Path.Combine(Path.Combine(desktopPath, "Volvo Autoplan"), "ALEX"), "ALEX_" + DateTime.Now.ToShortDateString() + ".csv");

            using (var w = new StreamWriter(fullPath))
            {
                w.WriteLine("Load number; Transport number; Delivery name; Status TO; Transport mode; Supplier (Partner code); Supplier Country; Planned pickup day; Carrier name; Planned earliest time of arrival [day]; Confirmed time window; Number of packages; Estimated day of arrival [DD:MM:YYYY]; Estimated time of arrival [HH:MM]; ADR; Plate trailer; Planned Slot; Gate");

                foreach (var iterate in loadData)
                {
                    if (iterate.PlateTrailer == "" && iterate.CarrierName == "AER3R SC International Alexzander")
                    {
                        switch (iterate.CTW.ToString())
                        {
                            case "6":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "6:00-10:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "10":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "10:00-14:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "14":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "14:00-18:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "18":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-23:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "20":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "21":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                        }
                    }
                    else if (iterate.PlateTrailer != "" && iterate.CarrierName == "AER3R SC International Alexzander")
                    {
                        switch (iterate.CTW.ToString())
                        {
                            case "6":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "6:00-10:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "10":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "10:00-14:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "14":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "14:00-18:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "18":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-23:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "20":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "21":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                        }
                    }
                }
            }
        }

        //Generate for DHL //For documentation look into CompletedPlanToCSV/PlanForLKW
        public void PlanForDHL(List<LoadData_Image> loadData)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(Path.Combine(Path.Combine(desktopPath, "Volvo Autoplan"), "DHL"), "DHL_" + DateTime.Now.ToShortDateString() + ".csv");

            using (var w = new StreamWriter(fullPath))
            {
                w.WriteLine("Load number; Transport number; Delivery name; Status TO; Transport mode; Supplier (Partner code); Supplier Country; Planned pickup day; Carrier name; Planned earliest time of arrival [day]; Confirmed time window; Number of packages; Estimated day of arrival [DD:MM:YYYY]; Estimated time of arrival [HH:MM]; ADR; Plate trailer; Planned Slot; Gate");

                foreach (var iterate in loadData)
                {
                    if (iterate.PlateTrailer == "" && iterate.CarrierName == "AES9X DHL Transport Control")
                    {
                        switch (iterate.CTW.ToString())
                        {
                            case "6":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "6:00-10:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "10":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "10:00-14:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "14":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "14:00-18:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "18":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-23:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "20":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "21":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.LN + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                        }
                    }
                    else if (iterate.PlateTrailer != "" && iterate.CarrierName == "AES9X DHL Transport Control")
                    {
                        switch (iterate.CTW.ToString())
                        {
                            case "6":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "6:00-10:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "10":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "10:00-14:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "14":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "14:00-18:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "18":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-23:00" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "20":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                            case "21":
                                w.WriteLine(iterate.LN + ";" + iterate.TO + ";" + iterate.DeliveryName + ";" + iterate.StatusTO + ";" + iterate.TransportMode + ";" + iterate.Supplier + ";" + iterate.SupplierCountry + ";" + iterate.PlannedPickupDay + ";" + iterate.CarrierName + ";" + iterate.PlannedEarliestArrival + ";" + "18:00-19:30" + ";" + iterate.Colli + ";" + iterate.EstimatedDayArrival + ";" + iterate.EstimatedTimeArrival + ";" + iterate.ADR + ";" + iterate.PlateTrailer + ";" + iterate.PlannedSlot + ";" + iterate.Gate);
                                break;
                        }
                    }
                }
            }
        }

    }
}
