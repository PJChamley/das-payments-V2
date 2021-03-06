﻿using SFA.DAS.Payments.Core.Configuration;
using System.Fabric;

namespace SFA.DAS.Payments.ServiceFabric.Core.Infrastructure.Configuration
{
    public class ServiceFabricConfigurationHelper : IConfigurationHelper
    {
        private readonly ConfigurationPackage config;

        public ServiceFabricConfigurationHelper()
        {
            config = FabricRuntime.GetActivationContext().GetConfigurationPackageObject("Config");
        }

        public bool HasSetting(string sectionName, string settingName)
        {
            return config.Settings.Sections.Contains(sectionName) && config.Settings.Sections[sectionName].Parameters.Contains(settingName);
        }

        public string GetSetting(string sectionName, string settingName)
        {
            return config.Settings.Sections[sectionName].Parameters[settingName].Value;
        }
    }
}