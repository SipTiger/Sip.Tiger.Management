﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sip.Tiger.Api.Swagger
{
    public static class PascalCaseStringExtensions
    {
        public static string ToPascalCase(this string inputString)
        {
            if (inputString == null) return null;
            if (inputString.Length < 2) return inputString.ToUpper();
            return inputString.Substring(0, 1).ToUpper() + inputString.Substring(1);
        }
    }
}
