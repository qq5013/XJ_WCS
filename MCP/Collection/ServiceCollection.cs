using System;
using System.Collections.Generic;
using System.Text;

namespace MCP.Collection
{
    public class ServiceCollection
    {
        private Dictionary<string, IService> services = new Dictionary<string, IService>();

        ~ServiceCollection()
        {
            foreach (IService service in services.Values)
            {
                service.Stop();
                service.Release();
            }
            services.Clear();
        }

        internal void Add(IService service)
        {
            if (service.Name == null)
                service.Name = string.Format("Service{0}", Environment.TickCount);

            string key = service.Name.ToUpper();
            if (services.ContainsKey(key))
                throw new Exception(string.Format("����Ϊ'{0}'��Service�Ѵ��ڡ�", service.Name));
            else
                services.Add(key, service);
        }

        public IService this[string serviceName]
        {
            get
            {
                string key = serviceName.ToUpper();

                if (services.ContainsKey(key))
                    return services[serviceName.ToUpper()];
                else return null;
            }
        }
    }
}
