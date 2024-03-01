using System.Collections.Generic;

namespace SharedKernel.Domain
{
    public abstract class BaseEntity
    {
        protected void DwellerValidation(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new DwellerRuleValidationException(rule);
            }
        }
    }
}
