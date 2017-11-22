using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.ServiceBus.Messaging;
using Kaseya.AuthAnvil.Models;
using Newtonsoft.Json;

namespace SCIM004
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([ServiceBusTrigger("sb-q-change-notifications", AccessRights.Listen, Connection = "KServiceBusQueue")]EntityChange myQueueItem, TraceWriter log)
        {
            //log.Info($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            var asString = JsonConvert.SerializeObject(myQueueItem);
            log.Info($"C# ServiceBus queue trigger function processed message as string: {asString}, Making a change");
        }
    }
}
