using System;
using System.IO;

namespace Elemate
{
    public class Elemator
    {
        /// <summary>
        /// Adds the x:Name attribute to elements within all XAML files found
        /// within the given rootDirectory and all subdirectories
        /// </summary>
        public void AddName(string rootDirectory)
        {
            var fileNames = Directory.EnumerateFiles(
                rootDirectory,
                "*.xaml",
                SearchOption.AllDirectories);

            foreach (var fileName in fileNames)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine(
                    "Processing: \""
                    + fileName
                    + "\"" + Environment.NewLine);

                AddNamesInFile(fileName);
            }
        }

        private void AddNamesInFile(string fileName)
        {
            var fileContent = File.ReadAllText(fileName);
            var xamlDocument = new XamlDocument(fileContent);

            Console.ForegroundColor = ConsoleColor.Gray;

            foreach (var xamlFragment in xamlDocument.Fragments())
            {
                AddNameInFragment(xamlFragment);
            }
        }

        private void AddNameInFragment(XamlFragment xamlFragment)
        {

            if (xamlFragment.IsAttachedProperty()
                || xamlFragment.HasNameAttribute())
            {
                return;
            }

            Console.Write(xamlFragment + Environment.NewLine);
        }
    }
}
