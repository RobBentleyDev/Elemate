using System.Collections;
using System.Collections.Generic;

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

        public IEnumerator<XamlFragment> GetEnumerator()
        {
            return _xamlFragments.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}