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

        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            return _xamlFragment.GetHashCode();
        }

        public override string ToString()
        {
            return _xamlFragment;
        }
    }
}