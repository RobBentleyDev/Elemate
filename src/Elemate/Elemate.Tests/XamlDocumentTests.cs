using FluentAssertions;
using NUnit.Framework;
using System;

namespace Elemate.Tests
{
    public class XamlDocumentTests
    {
        [Test]
        public void XamlDocument_ShouldBeEqualToAnotherXamlDocumentWhichIsTheSame()
        {
            NewXamlDocument()
                .Should().Be(NewXamlDocument());
        }

        [Test]
        public void XamlDocument_ShouldNotBeEqualToAnotherXamlDocumentWhichIsDifferent()
        {
            NewXamlDocument()
                .Should().NotBe(new XamlDocument(@"<UserControl><\UserControl>"));
        }

        [Test]
        public void XamlDocument_ShouldBeEqualToAnotherXamlDocumentWhichIsTheSameUsingOperator()
        {
            Assert.IsTrue(NewXamlDocument() == NewXamlDocument());
        }

        [Test]
        public void XamlDocument_ShouldNotBeEqualToAnotherXamlDocumentWhichIsDifferentUsingOperator()
        {
            Assert.IsTrue(NewXamlDocument() != new XamlDocument(@"<UserControl><\UserControl>"));
        }

        [Test]
        public void XamlDocument_ShouldThrowArgumentNullExceptionWhenXamlIsNull()
        {
            Action xamlDocumentWithNull = () =>
            {
                new XamlDocument(null);
            };

            xamlDocumentWithNull
                .Should().Throw<ArgumentNullException>();
        }


        private XamlDocument NewXamlDocument()
        {
            return new XamlDocument(@"<Window><\Window>");
        }
    }
}
