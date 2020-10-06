using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Util
{
    public class TextValidator
    {
      public bool IsValidEmail(string txt)
        {
            if (new EmailAddressAttribute().IsValid(txt))
                return true;
            else
                return false;
        }
    }
}
