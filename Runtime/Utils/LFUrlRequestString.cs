using System;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Text;
using System.Collections.Generic;

namespace Kebab.LyricFindAPIWrapper.Utils
{
    public class LFUrlRequestStringBuilder
    {
        private const string TERRITORY = "FR";
        private const string OUTPUT = "JSON";
        private StringBuilder stringBuilder = new StringBuilder();

        private int paramNumber = 0;

        public LFUrlRequestStringBuilder(string baseUrl)
        {
            stringBuilder.Append(baseUrl);
            AddDefaultParameters();
        }

        private void AddDefaultParameters()
        {
            AddParameter("territory", TERRITORY);
            AddParameter("output", OUTPUT);
            AddParameter("reqtype", "default");
        }

        public void AddParameter(string key, string value)
        {
            value = FormatParameterString(value);
            stringBuilder.Append((paramNumber > 0) ? "&" : "?");
            stringBuilder.AppendFormat("{0}={1}", key, value);
            paramNumber++;
        }

        public void AddParametersFromObject(object parameters)
        {
            Dictionary<string, object> properties = GetPropertiesFromClass(parameters);

            foreach (var item in properties)
            {
                if (item.Value == null)
                    continue;
                if (item.Value.GetType() == typeof(string) && (string)item.Value == "")
                    continue;

                AddParameter(item.Key, item.Value.ToString());
            }
        }

        private Dictionary<string, object> GetPropertiesFromClass(object atype)
        {
            if (atype == null) return new Dictionary<string, object>();
            Type t = atype.GetType();
            FieldInfo[] props = t.GetFields();
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (FieldInfo prp in props)
            {
                object value = prp.GetValue(atype);
                dict.Add(prp.Name, value);
            }
            return dict;
        }

        public string FormatParameterString(string parameterString)
        {
            if (parameterString == null)
                return (null);
            parameterString.Trim();
            return Regex.Replace(parameterString, @"\s+", "+");
        }

        public override string ToString()
        {
            return stringBuilder.ToString();
        }
    }
}