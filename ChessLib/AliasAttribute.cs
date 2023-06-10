using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    internal class AliasAttribute : Attribute
    {
        public AliasAttribute(string alias)
        {
            Alias = alias;
        }

        public string Alias { get; }
    }
}
