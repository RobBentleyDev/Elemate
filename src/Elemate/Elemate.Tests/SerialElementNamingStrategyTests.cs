using FluentAssertions;
using NUnit.Framework;

namespace Elemate.Tests
{
    public class SerialElementNamingStrategyTests
    {
        [Test]
        public void AddName_ShouldAddNameToFragment()
        {
            var namimgStrategy = new SerialElementNamingStrategy("MPV");

            var xamlFragment = new XamlFragment("<TextBox>");

            var namedXamlFragment = namimgStrategy.AddName(xamlFragment);

            namedXamlFragment
                .Should().Be(new XamlFragment("<TextBox x:Name=\"MPV_TextBox_0000\">"));
        }

        [Test]
        public void AddName_ShouldAddNameToFragmentWithSequentialSerialNumbers()
        {
            var namimgStrategy = new SerialElementNamingStrategy("MPV");

            namimgStrategy.AddName(new XamlFragment("<TextBox>"));

            var namedXamlFragment2 = namimgStrategy.AddName(new XamlFragment("<TextBox>"));

            namedXamlFragment2
                .Should().Be(new XamlFragment("<TextBox x:Name=\"MPV_TextBox_0001\">"));
        }
    }
}
