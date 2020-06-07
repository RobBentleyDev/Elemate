using FluentAssertions;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Elemate.Tests
{
    [ExcludeFromCodeCoverage]
    public class XamlFragmentTests
    {
        [Test]
        public void XamlFragment_ShouldBeEqualToAnotherXamlFragmentWhichIsTheSame()
        {
            NewXamlFragment()
                .Should().Be(NewXamlFragment());
        }

        [Test]
        public void XamlFragment_ShouldNotBeEqualToAnotherXamlFragmentWhichIsDifferent()
        {
            NewXamlFragment()
                .Should().NotBe(new XamlFragment("<UserControl/>"));
        }

        [Test]
        public void XamlFragment_ShouldThrowArgumentNullExceptionWhenXamlFragmentIsNull()
        {
            Action xamlFragmentWithNull = () =>
            {
                new XamlFragment(null);
            };

            xamlFragmentWithNull
                .Should().Throw<ArgumentNullException>();
        }

        private XamlFragment NewXamlFragment()
        {
            return new XamlFragment("<Window/>");
        }
    }
}
