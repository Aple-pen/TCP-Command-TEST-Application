using System.Runtime.InteropServices;
using System.Text;

namespace TCP_Command_Test.utils
{
    public class IniFile
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string name,string key,string val,string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,string key,string def,StringBuilder retVal,int size,string filePath);

        public static void SetValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, IniPath());
        }

        public static string GetValue(string Section, string Key, string Default = "")
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, Default, temp, 255, IniPath());
            if (temp != null && temp.Length > 0) return temp.ToString() ;
            else return Default;
        }
    
        public static void inifileSetting()
        {
            string iniPath =  System.AppContext.BaseDirectory + @"\config.ini";
        }


        private static string IniPath()
        {
            return System.AppContext.BaseDirectory + @"\config.ini";
        }
    }
}