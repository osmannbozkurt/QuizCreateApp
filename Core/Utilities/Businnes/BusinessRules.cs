using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Businnes
{
   public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) // logics= business codes.
        {
            foreach (var logic in logics)
            {
                if (!logic.isSuccess)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
