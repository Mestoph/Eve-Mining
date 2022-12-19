using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Eve_Mining.Tools
{
    internal static class Config
    {
        #region Variables

        private static readonly NameValueCollection m_settings = ConfigurationManager.AppSettings;
        private static bool m_bAutoSave = false;

        #endregion
        #region Getters/Setters

        internal static bool AutoSave
        {
            get
            {
                return m_bAutoSave;
            }
            set
            {
                m_bAutoSave = value;
            }
        }


        #endregion
        #region Read functions

        internal static bool ReadBoolean(string _sKey)
        {
            return ReadBoolean(_sKey, false);
        }

        internal static bool ReadBoolean(string _sKey, bool _bDefault)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return _bDefault;

            try
            {
                return Convert.ToBoolean(m_settings[_sKey] ?? _bDefault.ToString());
            }
            catch
            {
                return _bDefault;
            }
        }

        internal static string ReadString(string _sKey)
        {
            return ReadString(_sKey, string.Empty);
        }

        internal static string ReadString(string _sKey, string _sDefault)
        {
            if (string.IsNullOrWhiteSpace(_sDefault))
                return string.Empty;

            if (string.IsNullOrWhiteSpace(_sKey))
                return _sDefault;

            try
            {
                return m_settings[_sKey] ?? _sDefault;
            }
            catch
            {
                return _sDefault;
            }

        }

        internal static short ReadInt16(string _sKey)
        {
            return ReadInt16(_sKey, 0);
        }

        internal static short ReadInt16(string _sKey, short _sDefault)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return _sDefault;

            try
            {
                return Convert.ToInt16(m_settings[_sKey] ?? _sDefault.ToString());
            }
            catch
            {
                return _sDefault;
            }
        }

        internal static int ReadInt32(string _sKey)
        {
            return ReadInt32(_sKey, 0);
        }

        internal static int ReadInt32(string _sKey, int _iDefault)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return _iDefault;

            try
            {
                return Convert.ToInt32(m_settings[_sKey] ?? _iDefault.ToString());
            }
            catch
            {
                return _iDefault;
            }
        }

        internal static long ReadInt64(string _sKey)
        {
            return ReadInt64(_sKey, 0);
        }

        internal static long ReadInt64(string _sKey, int _lDefault)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return _lDefault;

            try
            {
                return Convert.ToInt64(m_settings[_sKey] ?? _lDefault.ToString());
            }
            catch
            {
                return _lDefault;
            }
        }

        internal static byte ReadByte(string _sKey)
        {
            return ReadByte(_sKey, 0);
        }

        internal static byte ReadByte(string _sKey, byte _bDefault)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return _bDefault;

            try
            {
                return Convert.ToByte(m_settings[_sKey] ?? _bDefault.ToString());
            }
            catch
            {
                return _bDefault;
            }
        }

        internal static sbyte ReadSByte(string _sKey)
        {
            return ReadSByte(_sKey, 0);
        }

        internal static sbyte ReadSByte(string _sKey, sbyte _sbDefault)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return _sbDefault;

            try
            {
                return Convert.ToSByte(m_settings[_sKey] ?? _sbDefault.ToString());
            }
            catch
            {
                return _sbDefault;
            }
        }

        internal static char ReadChar(string _sKey)
        {
            return ReadChar(_sKey, ' ');
        }

        internal static char ReadChar(string _sKey, char _cDefault)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return _cDefault;

            try
            {
                return Convert.ToChar(m_settings[_sKey] ?? _cDefault.ToString());
            }
            catch
            {
                return _cDefault;
            }
        }

        internal static char ReadChar(string _sKey, string _sDefault)
        {
            if (string.IsNullOrWhiteSpace(_sDefault))
                return ' ';

            if (string.IsNullOrWhiteSpace(_sKey))
                return _sDefault[0];

            try
            {
                return Convert.ToChar(m_settings[_sKey] ?? _sDefault.ToString());
            }
            catch
            {
                return _sDefault[0];
            }
        }

        internal static decimal ReadDecimal(string _sKey)
        {
            return ReadDecimal(_sKey, 0);
        }

        internal static decimal ReadDecimal(string _sKey, decimal _dDefault)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return _dDefault;

            try
            {
                return Convert.ToDecimal(m_settings[_sKey] ?? _dDefault.ToString());
            }
            catch
            {
                return _dDefault;
            }
        }

        internal static double ReadDouble(string _sKey)
        {
            return ReadDouble(_sKey, 0);
        }

        internal static double ReadDouble(string _sKey, double _dDefault)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return _dDefault;

            try
            {
                return Convert.ToDouble(m_settings[_sKey] ?? _dDefault.ToString());
            }
            catch
            {
                return _dDefault;
            }
        }

        internal static float ReadSingle(string _sKey)
        {
            return ReadSingle(_sKey, 0);
        }

        internal static float ReadSingle(string _sKey, float _fDefault)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return _fDefault;

            try
            {
                return Convert.ToSingle(m_settings[_sKey] ?? _fDefault.ToString());
            }
            catch
            {
                return _fDefault;
            }
        }

        internal static ushort ReadUInt16(string _sKey)
        {
            return ReadUInt16(_sKey, 0);
        }

        internal static ushort ReadUInt16(string _sKey, ushort _uiDefault)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return _uiDefault;

            try
            {
                return Convert.ToUInt16(m_settings[_sKey] ?? _uiDefault.ToString());
            }
            catch
            {
                return _uiDefault;
            }
        }

        internal static uint ReadUInt32(string _sKey)
        {
            return ReadUInt32(_sKey, 0);
        }

        internal static uint ReadUInt32(string _sKey, uint _uiDefault)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return _uiDefault;

            try
            {
                return Convert.ToUInt32(m_settings[_sKey] ?? _uiDefault.ToString());
            }
            catch
            {
                return _uiDefault;
            }
        }

        internal static ulong ReadUInt64(string _sKey)
        {
            return ReadUInt64(_sKey, 0);
        }

        internal static ulong ReadUInt64(string _sKey, ulong _ulDefault)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return _ulDefault;

            try
            {
                return Convert.ToUInt64(m_settings[_sKey] ?? _ulDefault.ToString());
            }
            catch
            {
                return _ulDefault;
            }
        }

        #endregion
        #region Write functions

        internal static bool AddOrUpdate(string _sKey, object _o)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return false;

            if (_o == null)
                return false;

            var c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var s = c.AppSettings.Settings;

            if (s[_sKey] == null)
                s.Add(_sKey, Convert.ToString(_o));
            else
                s[_sKey].Value = Convert.ToString(_o);

            if (m_bAutoSave)
                Save();

            return true;
        }

        internal static bool Remove(string _sKey)
        {
            if (string.IsNullOrWhiteSpace(_sKey))
                return false;

            var c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var s = c.AppSettings.Settings;

            s.Remove(_sKey);

            if (m_bAutoSave)
                Save();

            return true;
        }

        internal static void Save()
        {
            var c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            c.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(c.AppSettings.SectionInformation.Name);
        }

        #endregion
    }
}
