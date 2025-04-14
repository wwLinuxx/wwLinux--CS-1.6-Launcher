using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ZBobb;

namespace wwLinux_Launcher
{
    public static class Extensions
    {
        public static void FontBatmanForever(this Label label)
        {
            PrivateFontCollection batmanforever = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.batmanforever))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                batmanforever.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }

            label.Font = new Font(batmanforever.Families[0], label.Font.Size);
        }
        public static void FontJetBrains(this Label label)
        {
            PrivateFontCollection jetbrains = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.JetBrains))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                jetbrains.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }

            label.Font = new Font(jetbrains.Families[0], label.Font.Size);
        }
        public static void FontJetBrains(this CheckBox checkBox)
        {
            PrivateFontCollection jetbrains = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.JetBrains))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                jetbrains.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }

            checkBox.Font = new Font(jetbrains.Families[0], checkBox.Font.Size);
        }
        public static void FontJetBrains(this ComboBox ComboBox)
        {
            PrivateFontCollection jetbrains = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.JetBrains))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                jetbrains.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }

            ComboBox.Font = new Font(jetbrains.Families[0], ComboBox.Font.Size);
        }
        public static void FontJetBrains(this AlphaBlendTextBox alphaBlendTextBox)
        {
            PrivateFontCollection jetbrains = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.JetBrains))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                jetbrains.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }

            alphaBlendTextBox.Font = new Font(jetbrains.Families[0], alphaBlendTextBox.Font.Size);
        }
        public static void FontMichroma(this Button button)
        {
            PrivateFontCollection michroma = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.Michroma))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                michroma.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }

            button.Font = new Font(michroma.Families[0], button.Font.Size);
        }
        public static void FontMichroma(this Label Label)
        {
            PrivateFontCollection michroma = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.Michroma))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                michroma.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }

            Label.Font = new Font(michroma.Families[0], Label.Font.Size);
        }
        public static void FontMichroma(this ComboBox ComboBox)
        {
            PrivateFontCollection michroma = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.Michroma))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                michroma.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }

            ComboBox.Font = new Font(michroma.Families[0], ComboBox.Font.Size);
        }
        public static void FontMichroma(this CheckBox CheckBox)
        {
            PrivateFontCollection michroma = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.Michroma))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                michroma.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }

            CheckBox.Font = new Font(michroma.Families[0], CheckBox.Font.Size);
        }
        public static void FontMichroma(this AlphaBlendTextBox alphaBlendTextBox)
        {
            PrivateFontCollection michroma = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.Michroma))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                michroma.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }

            alphaBlendTextBox.Font = new Font(michroma.Families[0], alphaBlendTextBox.Font.Size);
        }
    }
}
