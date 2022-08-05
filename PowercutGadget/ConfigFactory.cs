using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PowercutGadget
{
    class ConfigFactory
    {
        public static String writeSheduleGroup(String group)
        {
            string file = group; 
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\powercut_gadget_config.txt"; 
            FileStream FS = new FileStream(filePath, FileMode.Create);
            StreamWriter SR = new StreamWriter(FS);
            SR.Write(file);
            SR.Close();

            return file;
        }

        public static String getSheduleGroup()
        {
            string file = ""; 
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+ "\\powercut_gadget_config.txt"; 
            FileStream FS = new FileStream(filePath, FileMode.OpenOrCreate);
            StreamReader SR = new StreamReader(FS);

            try
            {
                file = SR.ReadLine().Trim();
                SR.Close();
            }
            catch (Exception)
            {
                SR.Close();
                writeSheduleGroup("A");
                MessageBox.Show("Your powercut group is set to Group 'A' by default. You can change it in settings.");
                return "A";
            }
            
            if (file.Length == 1 && file.All(Char.IsLetter)){
                return file.ToUpper();
            }
            else
            {
                writeSheduleGroup("A");
                MessageBox.Show("Your powercut group is set to Group 'A' by default. You can change it in settings.");
                return "A";
            }
        }
    }
}
