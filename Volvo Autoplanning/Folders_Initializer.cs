using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Volvo_Autoplanning
{
    public class Folders_Initializer
    {
        public void CreateFolder()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (!File.Exists(Path.Combine(desktopPath, "Volvo Autoplan"))) //If folder doesn't exists, create it with all subfolders
            {
                Directory.CreateDirectory(Path.Combine(desktopPath, "Volvo Autoplan"));

                string fullPathDirectory = Path.Combine(Path.Combine(desktopPath, "Volvo Autoplan"));

                Directory.CreateDirectory(Path.Combine(fullPathDirectory, "ALEX")); //Creating directories for all carriers
                Directory.CreateDirectory(Path.Combine(fullPathDirectory, "CAT"));
                Directory.CreateDirectory(Path.Combine(fullPathDirectory, "DHL"));
                Directory.CreateDirectory(Path.Combine(fullPathDirectory, "DUVENBECK"));
                Directory.CreateDirectory(Path.Combine(fullPathDirectory, "EKOL"));
                Directory.CreateDirectory(Path.Combine(fullPathDirectory, "EWALS"));
                Directory.CreateDirectory(Path.Combine(fullPathDirectory, "LKW"));
                Directory.CreateDirectory(Path.Combine(fullPathDirectory, "VOLVO"));

                if (!File.Exists(Path.Combine(fullPathDirectory, "ADR.txt"))) //If ADR.txt doesn't exists, create it
                {
                    File.Create(Path.Combine(fullPathDirectory, "ADR.txt"));
                }
                else
                {
                    //Do nothing
                }
                
                CreateREADME(fullPathDirectory, "README.txt"); //Create README.txt
                CreateVersions(fullPathDirectory, "versions.txt"); //Create Versions.txt
                //CreateAppendedCSV(fullPathDirectory, "SOURCE_COMPLETE.csv"); //Concatenated SourceF and SourceP
            }
            else
            {
                //Do nothing
            }
        }

        public void CreateREADME(string path, string name) //Creating Readme file with instructions, how to use Volvo Autoplanning tool
        {
            using (var w = new StreamWriter(Path.Combine(path, name)))
            {
                w.WriteLine("Guide how to use Volvo Autoplanning tool:");
                w.WriteLine();
                w.WriteLine("Input data:");
                w.WriteLine("- Paste Freight Load data to Volvo Autoplan folder on your desktop");
                w.WriteLine("- Rename Load data to 'SOURCE_F'");
                w.WriteLine("- Open Volvo Autoplanning.exe");
                w.WriteLine();
                w.WriteLine("For Autoplanning Inbound:");
                w.WriteLine("- Select option 1.");
                w.WriteLine("- Input date on what you want to plan and hit enter");
                w.WriteLine("- Now planning files are generated severally in specific folder here");
                w.WriteLine();
                w.WriteLine("For Sending emails:");
                w.WriteLine("- Select optin 2.");
                w.WriteLine("- Select option 1-3.");
                w.WriteLine("- If selected option 1., It will generate emails for all carriers one by one");
                w.WriteLine("- If selected option 2., You can choose what email you want to generate");
                w.WriteLine();
                w.WriteLine("How to close application:");
                w.WriteLine("- Select option 3. or selection 'Go back' / 'Exit'");
                w.WriteLine("");
                w.WriteLine("If application crashes:");
                w.WriteLine("- No data is in folder that it can process");
                w.WriteLine("- Wrong name of imported data (SOURCE_F/SOURCE_P)");
                w.WriteLine("- Wrong date format (Must be [dd.mm.yyyy])");
                w.WriteLine("- Wrong input data structure in .csv");
                w.WriteLine("- Wrong data in Column AG/AH (Too long, Unsupported chars)");
            }
        }

        public void CreateAppendedCSV (string path, string name)
        {
            File.Create(Path.Combine(path, name));            
        }

        public void CreateVersions(string path, string name) //Create Versions.txt with version descriptions
        {
            using (var w = new StreamWriter(Path.Combine(path, name)))
            {
                w.WriteLine("Versions:");
                w.WriteLine();
                w.WriteLine("v1.0.0:");
                w.WriteLine("- Slave was programmed");
                w.WriteLine("- Now about 1 950 lines of code");
                w.WriteLine("- It can plan from Load data");
                w.WriteLine("- It can generate email");
                w.WriteLine();
                w.WriteLine("v1.1.0");
                w.WriteLine("- Now about 2 275 lines of code");
                w.WriteLine("- Automatic setup of folders");
                w.WriteLine("- Sorted structure in root folder");
                w.WriteLine();
                w.WriteLine("v1.2.0");
                w.WriteLine("- Now about 2 400 lines of code");
                w.WriteLine("- Better algorhytm for planning");
                w.WriteLine("- Better UI");
                w.WriteLine();
                w.WriteLine("v1.3.0");
                w.WriteLine("- Now about 2 550 lines of code");
                w.WriteLine("- Planned trucks can be edited");
                w.WriteLine();
                w.WriteLine("v1.4.0");
                w.WriteLine("- Now about 2 800 lines of code");
                w.WriteLine("- Working packaging inbound planning");
            }
        }
    }
}
