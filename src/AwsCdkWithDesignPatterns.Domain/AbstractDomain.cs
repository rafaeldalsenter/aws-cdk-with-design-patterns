using System.Collections.Generic;
using System.Linq;

namespace AwsCdkWithDesignPatterns.Domain
{
    public abstract class AbstractDomain
    {
        public IList<string> ErrorMessages { get; private set; }

        protected void AddError(string message)
        {
            ErrorMessages ??= new List<string>();
            ErrorMessages.Add(message);
        }

        public bool IsValid()
        {
            return !ErrorMessages?.Any() ?? true;
        }
    }
}