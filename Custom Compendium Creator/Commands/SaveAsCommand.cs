using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Custom_Compendium_Creator.Models;
namespace Custom_Compendium_Creator.Commands
{
    public class SaveAsCommand : CommandBase
    {
        private Compendium compendium;

        public SaveAsCommand(Compendium compendium)
        {
            this.compendium = compendium;
        }

        public override void Execute(object parameter)
        {
            string folderPath = "";

            // Ask the user where they want to save their Compendium
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    folderPath = folderBrowser.SelectedPath;
                }
            }

            // Create a Compendium folder to hold all other folders
            string compendiumDir = folderPath + @"/" + "Compendium";

            if (!Directory.Exists(compendiumDir))
            {
                Directory.CreateDirectory(compendiumDir);
            }

            // Create a File for the Feats and empty anything currently in there
            string featDir = compendiumDir + @"/Feats";

            if (!Directory.Exists(featDir))
            {
                Directory.CreateDirectory(featDir);
            }

            foreach (FileInfo file in new DirectoryInfo(featDir).GetFiles())
            {
                file.Delete();
            }

            // Iterate through the FeatList and serialize each Feat as its own file
            foreach (Feat feat in compendium.FeatList.GetAllFeats())
            {
                string featFileName = featDir + @"/" + feat.Name;

                // Account for the possiblity of similarly named feats
                int i = 1;
                string testFileName = featFileName;
                while (File.Exists(testFileName + ".json"))
                {
                    testFileName = featFileName + "-" + i;
                    i++;
                }

                // Add the .json extension
                featFileName = testFileName + ".json";

                // Save the JSON in the Feat folder
                using (FileStream stream = File.Create(featFileName))
                {
                    //feat.Description = feat.Description.Replace("{\\colortbl\\red0\\green0\\blue0;\\red255\\green255\\blue255;}", "");
                    //feat.Description = feat.Description.Replace("{\\colortbl\\red0\\green0\\blue0;\\red255\\green255\\blue255;\\red235\\green235\\blue235;\\red128\\green128\\blue128;}", "");

                    feat.Description = RemoveColor(feat.Description);

                    JsonSerializer.Serialize(stream, feat);
                    stream.Dispose();
                }
            }

            MessageBox.Show("Finished saving homebrew collection!");
        }

        string RemoveColor(string str)
        {
            int firstPassIndex = str.IndexOf("{\\colortbl", 0, str.Length);
            int firstPassLength = str.Length - firstPassIndex;
            string firstPass = str.Substring(firstPassIndex, firstPassLength);

            int secondPassIndex = firstPass.IndexOf(";}", 0, firstPass.Length);
            int secondPassLength = firstPass.Length - secondPassIndex;
            string secondPass = firstPass.Substring(0, secondPassIndex + 2);

            return str.Replace(secondPass, "");
        }
    }
}
