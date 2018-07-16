﻿using System;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace MiniLibs
{
    public class MiniConfig
    {

        private Configuration configuration;
        private ExeConfigurationFileMap map = null;

        private string _configName;
        private string baseConfigSchema = @"<?xml version='1.0' encoding='utf-8'?>
<configuration>
  <appSettings>
    <!-- <add key='port' value='1881' /> -->
  </appSettings>
</configuration>";

        public MiniConfig(string configName = "configfile")
        {
            _configName = configName;

            init();

            map = new ExeConfigurationFileMap { ExeConfigFilename = _configName };
        }

        private void init()
        {
            if (!File.Exists(_configName))
            {
                File.AppendAllText(_configName, baseConfigSchema);
            }

            configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        }

        private void loadConfigs()
        {
            configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        }

        public bool TryGet<T>(string key, out T value)
        {
            loadConfigs();

            var setting = configuration.AppSettings.Settings[key];

            if (setting != null)
            {
                try
                {
                    value = (T)Convert.ChangeType(setting.Value, typeof(T), CultureInfo.InvariantCulture);
                    return true;
                }
                catch
                {
                }
            }

            value = default(T);
            return false;

        }


        public void AddOrUpdate(string key, string value)
        {
            var old = configuration.AppSettings.Settings[key];
            if (old != null)
            {
                old.Value = value;
            }
            else
            {
                configuration.AppSettings.Settings.Add(key, value);
            }

            configuration.Save(ConfigurationSaveMode.Minimal);


        }

    }
}
