using System;

namespace Elemate
{
    public class XamlDocument
    {
        private readonly string _xaml;

        public XamlDocument(string xaml)
        {
            _xaml = xaml ?? throw new ArgumentNullException(nameof(xaml));
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

        public override string ToString()
        {
            return _xaml;
        }
    }
}