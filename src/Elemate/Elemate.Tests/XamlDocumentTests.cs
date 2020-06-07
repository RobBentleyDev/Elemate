using FluentAssertions;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Elemate.Tests
{
    [ExcludeFromCodeCoverage]
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
                .Should().NotBe(new XamlDocument("<UserControl></UserControl>"));
        }

        [Test]
        public void XamlDocument_ShouldBeEqualToAnotherXamlDocumentWhichIsTheSameUsingOperator()
        {
            Assert.IsTrue(NewXamlDocument() == NewXamlDocument());
        }

        [Test]
        public void XamlDocument_ShouldNotBeEqualToAnotherXamlDocumentWhichIsDifferentUsingOperator()
        {
            Assert.IsTrue(NewXamlDocument() != new XamlDocument("<UserControl></UserControl>"));
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

        [Test]
        public void Fragments_ShouldExtractStartTagForEachElement()
        {
            var expectedFragments = new XamlFragments
            {
                new XamlFragment("<Window>"),
                new XamlFragment("<TextBox>"),
                new XamlFragment("<Button Command=\"{Binding AddCommand}\">"),
                new XamlFragment("<TextBox x:Name=\"namedTextBox\">"),
                new XamlFragment("<TextBox>"),
                new XamlFragment("<ListView x:ConnectionId='1'>"),
                new XamlFragment("<ListView.Views>"),
            };

            var actualFragments = NewXamlDocument().Fragments();

            actualFragments
                .Should().BeEquivalentTo(expectedFragments);
        }

        private XamlDocument NewXamlDocument()
        {
            return new XamlDocument(@"<Window>"
                + "<TextBox>content</TextBox>"
                + "<Button Command=\"{Binding AddCommand}\">Add</Button>"
                + "<TextBox x:Name=\"namedTextBox\">content</TextBox>"
                + "<TextBox>content</TextBox>"
                + "<ListView x:ConnectionId='1'>"
                + "<ListView.Views></ListView.Views>"
                + "</ListView>"
                + @"</Window>");
        }
    }
}
