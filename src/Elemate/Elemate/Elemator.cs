using System;
using System.IO;
using System.Linq;

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
            var originalXamlDocument = new XamlDocument(fileContent);
            var newXamlDocument = new XamlDocument(fileContent);

            Console.ForegroundColor = ConsoleColor.Gray;
            
            var moduleAcronym = GenerateModuleAcronym(Path.GetFileName(fileName));
            var namingStrategy = new SerialElementNamingStrategy(moduleAcronym);
            
            var fragmentsToName = originalXamlDocument
                .Fragments()
                .Where(fragment => !fragment.IsAttachedProperty()
                                   && !fragment.HasNameAttribute());

            foreach (var xamlFragment in fragmentsToName)
            {
                var namedXamlFragment = AddNameToFragment(namingStrategy, xamlFragment);

                newXamlDocument = newXamlDocument
                    .ReplaceFragment(xamlFragment, namedXamlFragment);
            }

            if (newXamlDocument != originalXamlDocument)
            {
                File.WriteAllText(fileName, newXamlDocument.ToString());
            }
        }

        private XamlFragment AddNameToFragment(INamingStrategy namingStrategy, XamlFragment xamlFragment)
        {
            var namedXamlFragment = namingStrategy.AddName(xamlFragment);

            if (namedXamlFragment != xamlFragment)
            {
                Console.Write(namedXamlFragment + Environment.NewLine);
            }

            return namedXamlFragment;
        }

        private static string GenerateModuleAcronym(string fileName)
        {
            return string.Concat(fileName.Where(c => c >= 'A' && c <= 'Z'));
        }
    }
}
