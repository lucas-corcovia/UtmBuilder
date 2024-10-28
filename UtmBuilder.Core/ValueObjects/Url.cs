using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects
{
    public class Url : ValueObject
    {
        /// <summary>
        /// Address of URL (Website Link)
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Create a new URL
        /// </summary>
        /// <param name="address"> Address of URL (Website Link)</param>
        public Url(string address)
        {
            Address = address;
            InvalidUrlException.ThrowIfInvalid(address);
        }

       
    }
}
