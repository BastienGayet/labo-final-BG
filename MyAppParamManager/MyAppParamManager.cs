using Microsoft.Win32;
namespace MyAppParamManager
{
    public class MyAppParamManager
    {
        private const string REGISTRY_KEY = @"SOFTWARE\MyApp";
        private const string PARAM_NAME = "myParam";
        private int _myParam;

        public int MyParam
        {
            get { return _myParam; }
            set
            {
                _myParam = value;
                SaveRegistryParameter(PARAM_NAME,_myParam);
            }
        }

        private void SaveRegistryParameter(string name, object value)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(REGISTRY_KEY))
            {
                key.SetValue(name,value);
            }
        }
        public void LoadRegistryParameter()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(REGISTRY_KEY))
            {
                if (key != null)
                {
                    _myParam = (int)key.GetValue(PARAM_NAME, 0);
                }
            }
        }

    }
}