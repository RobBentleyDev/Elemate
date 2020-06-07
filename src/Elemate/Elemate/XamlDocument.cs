using System;
using System.Diagnostics.CodeAnalysis;

namespace Elemate
{
    public class XamlDocument
    {
        private readonly string _xaml;

        public XamlDocument(string xaml)
        {
            _xaml = xaml ?? throw new ArgumentNullException(nameof(xaml));
        }

        public XamlFragments Fragments()
        {
            var currentPosition = 0;

            var fragments = new XamlFragments();

            while (_xaml.IndexOf('<', currentPosition) != -1)
            {
                var elementStartPosition = _xaml.IndexOf('<', currentPosition);

                var nextClosingChar = _xaml.IndexOf('>', elementStartPosition);

                // Ignore closing tags
                if (_xaml.Substring(elementStartPosition + 1, 1) != @"/")
                {
                    var fragment = _xaml.Substring(elementStartPosition, nextClosingChar - elementStartPosition + 1);
                    fragments.Add(new XamlFragment(fragment));
                }

                currentPosition = nextClosingChar;
            }

            return fragments;
        }

        protected bool Equals(XamlDocument other)
        {
            return _xaml == other._xaml;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((XamlDocument)obj);
        }

        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            return _xaml.GetHashCode();
        }

        public static bool operator ==(XamlDocument left, XamlDocument right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(XamlDocument left, XamlDocument right)
        {
            return !Equals(left, right);
        }
    }
}