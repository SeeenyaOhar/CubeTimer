using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMSpeedCubeTimer
{
    partial class App : Application
    {
        public static string SolvedTimesTextDocPath { get; internal set; } = Environment.CurrentDirectory + "\\solved.txt";
        public static CultureInfo Language { get; internal set; } = CultureInfo.CurrentCulture;
        public static void Serialize()
        {
            var path = Environment.CurrentDirectory + "//settings.txt";
            BinaryFormatter bf = new BinaryFormatter();
            using (Stream s = new FileStream(path, FileMode.Create))
            {
                var mi = typeof(App).GetProperties().Where((a) => { return a.DeclaringType == typeof(App); });

                foreach (var v in mi)
                {
                    var val = v.GetValue(v);
                    bf.Serialize(s, val);
                }
            }

        }
        public static void Deserialize()
        {
            var path = Environment.CurrentDirectory + "//settings.txt";
            if (File.Exists(path))
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (Stream s = new FileStream(path, FileMode.Open))
                {
                    var mi = typeof(App).GetProperties().Where((a) => { return a.DeclaringType == typeof(App); });
                    s.Position = 0;
                    foreach (var v in mi)
                    {
                        var d = bf.Deserialize(s);
                        v.SetValue(null, d);

                    }
                }
            }
            // TODO: Implement a changing language UI on that one which is deserialized

        }
    }
}
