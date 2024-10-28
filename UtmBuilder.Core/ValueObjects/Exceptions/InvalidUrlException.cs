using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UtmBuilder.Core.ValueObjects.Exceptions
{
    public class InvalidUrlException : Exception
    {
        private const string UrlRegexPattern = @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-zA-Z0-9]+([\-\.]{1}[a-zA-Z0-9]+)*\.[a-zA-Z]{2,5}(:[0-9]{1,5})?(\/.*)?$";

        private const string DefaultErrorMessage = "Invalid URL";
        
        public InvalidUrlException(string message = DefaultErrorMessage)
        :base(message)
        {

        }

        public static void ThrowIfInvalid(string address, string message = DefaultErrorMessage)
        {
            if (string.IsNullOrEmpty(address))
                throw new InvalidUrlException(message);

            if (!Regex.IsMatch(address, UrlRegexPattern))
                throw new InvalidUrlException(message);
        }

       
    }
}
