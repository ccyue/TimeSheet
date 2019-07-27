using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TimeSheet.API
{
    public class NameSpaceVersionRoutingConvertion : IApplicationModelConvention
    {
        private readonly string apiPrefix;
        private const string urlTemplate = "{0}/{1}/{2}";
        public NameSpaceVersionRoutingConvertion(string apiPrefix = "api")
        {
            this.apiPrefix = apiPrefix;
        }
        public void Apply(ApplicationModel application)
        {
            foreach(var controller in application.Controllers)
            {
                var hasRouteAttribute = controller.Selectors
                    .Any(p => p.AttributeRouteModel != null);
                if(hasRouteAttribute)
                {
                    continue;
                }
                var nameSpaces = controller.ControllerType.Namespace.Split('.');
                var version = nameSpaces.FirstOrDefault(p => Regex.IsMatch(p, @"^v(\d+)$"));
                if(string.IsNullOrEmpty(version))
                {
                    continue;
                }
                string template = string.Format(urlTemplate, apiPrefix, version, controller.ControllerName);
                controller.Selectors[0].AttributeRouteModel = new AttributeRouteModel()
                {
                    Template = template
                };
            }
        }
    }
}
