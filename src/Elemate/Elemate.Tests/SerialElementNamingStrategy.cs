using System.Collections.Generic;

namespace Elemate.Tests
{
    public class SerialElementNamingStrategy : INamingStrategy
    {
        private readonly string _moduleAcronym;
        private List<string> _elementNames;
        private Dictionary<string, int> _elementSerialNumbers;

        public SerialElementNamingStrategy(string moduleAcronym)
        {
            _moduleAcronym = moduleAcronym;
            InitialiseElementNames();
            InitialiseElementSerialNumbers();
        }

        private void InitialiseElementNames()
        {
            _elementNames = new List<string>
            {
                "Window",
                "Button",
                "TextBlock",
                "TextBox",
                "RadioButton",
                "CheckBox",
                "ComboBox",
                "ListView",
                "ListBox",
                "GridView"
            };
        }

        private void InitialiseElementSerialNumbers()
        {
            // element name and serial number
            _elementSerialNumbers = new Dictionary<string, int>();

            foreach (var elementName in _elementNames)
            {
                _elementSerialNumbers.Add(elementName, 0);
            }
        }

        public XamlFragment AddName(XamlFragment xamlFragment)
        {
            foreach (var elementName in _elementNames)
            {
                if (xamlFragment.Contains(elementName))
                {
                    var serialNumber = _elementSerialNumbers[elementName].ToString("D4");
                    _elementSerialNumbers[elementName]++;

                    var nameAttributeValue = $"{_moduleAcronym}_{elementName}_{serialNumber}";

                    var findValue = "<" + elementName;
                    var replaceValue = findValue + $" x:Name=\"{nameAttributeValue}\"";

                    return xamlFragment.Replace(findValue, replaceValue);
                }
            }

            return xamlFragment;
        }
    }
}