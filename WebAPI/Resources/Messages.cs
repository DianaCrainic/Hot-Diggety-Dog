using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Resources
{
    public static class Messages
    {
        public static string NotFoundMessage(string entityName, System.Guid entityId)
        {
            return $"{entityName} with id {entityId} not found.";
        }
    }
}
