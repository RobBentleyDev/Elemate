using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Elemate
{
    public class XamlFragments : IEnumerable<XamlFragment>
    {
        private readonly List<XamlFragment> _xamlFragments;

        public XamlFragments()
        {
            _xamlFragments = new List<XamlFragment>();
        }

        public void Add(XamlFragment xamlFragment)
        {
            _xamlFragments.Add(xamlFragment);
        }

        protected bool Equals(XamlFragments other)
        {
            return _xamlFragments.Equals(other._xamlFragments);
        }

        public IEnumerator<XamlFragment> GetEnumerator()
        {
            return _xamlFragments.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((XamlFragments)obj);
        }

        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            return _xamlFragments.GetHashCode();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}