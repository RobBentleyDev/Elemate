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

        [Test]
        public void IsAttachedProperty_ShouldBeTrueWhenElementNameIsFollowedByAPeriod()
        {
            new XamlFragment("<ListView.View>").IsAttachedProperty()
                .Should().BeTrue();
        }

        [Test]
        public void IsAttachedProperty_ShouldBeFalseWhenFragmentDoesNotContainAPeriod()
        {
            new XamlFragment("<ListView>").IsAttachedProperty()
                .Should().BeFalse();
        }

        [Test]
        public void IsAttachedProperty_ShouldBeFalseWhenFragmentDoesNotContainASpace()
        {
            new XamlFragment("<ListView Margin=\"5\">").IsAttachedProperty()
                .Should().BeFalse();
        }

        [Test]
        public void HasNameAttribute_ShouldBeFalseWhenFragmentDoesNotContainANameAttribute()
        {
            new XamlFragment("<ListView Margin=\"5\">").HasNameAttribute()
                .Should().BeFalse();
        }

        [Test]
        public void HasNameAttribute_ShouldBeTrueWhenFragmentContainsANameAttribute()
        {
            new XamlFragment("<ListView Name=\"MyListView\">").HasNameAttribute()
                .Should().BeTrue();
        }

        [Test]
        public void HasNameAttribute_ShouldBeTrueWhenFragmentContainsAnXNameAttribute()
        {
            new XamlFragment("<ListView x:Name=\"MyListView\">").HasNameAttribute()
                .Should().BeTrue();
        }

        private XamlFragments NewXamlFragments()
        {
            return new XamlFragments();
        }
    }
}
