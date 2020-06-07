using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using NUnit.Framework;

namespace Elemate.Tests
{
    [ExcludeFromCodeCoverage]
    public class XamlFragmentsTests
    {
        [Test]
        public void XamlFragments_ShouldBeEqualToAnotherXamlFragmentsWhichIsTheSame()
        {
            NewXamlFragments()
                .Should().BeEquivalentTo(NewXamlFragments());
        }

        [Test]
        public void XamlFragments_ShouldNotBeEqualToAnotherXamlFragmentsWhichIsDifferent()
        {
            NewXamlFragments()
                .Should().NotBeEquivalentTo(new XamlFragments
                {
                    new XamlFragment("<Window/>")
                });
        }

        private XamlFragments NewXamlFragments()
        {
            return new XamlFragments();
        }
    }
}
