using System;
using System.Diagnostics.CodeAnalysis;

namespace Elemate
{
    public class XamlFragment
    {
        private readonly string _xamlFragment;

        public XamlFragment(string xamlFragment)
        {
            _xamlFragment = xamlFragment ?? throw new ArgumentNullException(nameof(xamlFragment));
        }

        protected bool Equals(XamlFragment other)
        {
            return _xamlFragment == other._xamlFragment;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((XamlFragment)obj);
        }

        public static bool operator ==(XamlFragment left, XamlFragment right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(XamlFragment left, XamlFragment right)
        {
            return !Equals(left, right);
        }

        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            return _xamlFragment.GetHashCode();
        }

        public override string ToString()
        {
            return _xamlFragment;
        }

        public bool IsAttachedProperty()
        {
            if (_xamlFragment.Contains(" "))
            {
                return false;
            }

            if (_xamlFragment.Contains("."))
            {
                return true;
            }

            return false;
        }

        public bool HasNameAttribute()
        {
            if (_xamlFragment.Contains("x:Name=")
                || _xamlFragment.Contains("Name="))
            {
                return true;
            }

            return false;
        }

        public bool Contains(string elementName)
        {
            return _xamlFragment.Contains(elementName);
        }

        public XamlFragment Replace(string findValue, string replaceValue)
        {
            return new XamlFragment(_xamlFragment.Replace(findValue, replaceValue));
        }
    }
}