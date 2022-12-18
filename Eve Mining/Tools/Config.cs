using System;
using System.Configuration;

namespace Eve_Mining.Tools
{
    internal class Config
    {
        internal Config()
        {
        }

        internal bool ReadBoolean(string _sKey)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return false;

            var s = ConfigurationManager.AppSettings;

            return Convert.ToBoolean(s[_sKey] ?? "false");
        }

        internal string ReadString(string _sKey)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return string.Empty;

            var s = ConfigurationManager.AppSettings;

            return Convert.ToString(s[_sKey] ?? string.Empty);
        }

        internal short ReadInt16(string _sKey)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return 0;

            var s = ConfigurationManager.AppSettings;

            return Convert.ToInt16(s[_sKey] ?? "0");
        }

        internal int ReadInt32(string _sKey)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return 0;

            var s = ConfigurationManager.AppSettings;

            return Convert.ToInt32(s[_sKey] ?? "0");
        }

        internal long ReadInt64(string _sKey)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return 0;

            var s = ConfigurationManager.AppSettings;

            return Convert.ToInt64(s[_sKey] ?? "0");
        }

        internal byte ReadByte(string _sKey)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return 0;

            var s = ConfigurationManager.AppSettings;

            return Convert.ToByte(s[_sKey] ?? "0");
        }

        internal char ReadChar(string _sKey)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return '0';

            var s = ConfigurationManager.AppSettings;

            return Convert.ToChar(s[_sKey] ?? "0");
        }

        internal decimal ReadDecimal(string _sKey)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return 0;

            var s = ConfigurationManager.AppSettings;

            return Convert.ToDecimal(s[_sKey] ?? "0");
        }

        internal double ReadDouble(string _sKey)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return 0;

            var s = ConfigurationManager.AppSettings;

            return Convert.ToDouble(s[_sKey] ?? "0");
        }

        internal float ReadSingle(string _sKey)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return 0;

            var s = ConfigurationManager.AppSettings;

            return Convert.ToSingle(s[_sKey] ?? "0");
        }

        internal ushort ReadUInt16(string _sKey)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return 0;

            var s = ConfigurationManager.AppSettings;

            return Convert.ToUInt16(s[_sKey] ?? "0");
        }

        internal uint ReadUInt32(string _sKey)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return 0;

            var s = ConfigurationManager.AppSettings;

            return Convert.ToUInt32(s[_sKey] ?? "0");
        }

        internal ulong ReadUInt64(string _sKey)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return 0;

            var s = ConfigurationManager.AppSettings;

            return Convert.ToUInt64(s[_sKey] ?? "0");
        }

        internal bool AddOrUpdate(string _sKey, object _o)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return false;

            if (_o == null)
                return false;

            var c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            var s = c.AppSettings.Settings;
            if (s[_sKey] == null)
            {
                s.Add(_sKey, _o.ToString());
            }
            else
            {
                s[_sKey].Value = _o.ToString();
            }

            c.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection(c.AppSettings.SectionInformation.Name);

            return true;
        }

        internal bool Remove(string _sKey)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return false;

            var c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            var s = c.AppSettings.Settings;
            s.Remove(_sKey);

            return true;
        }
    }
}
