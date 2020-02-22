using System;
using System.IO;
using System.Windows.Forms;
using dnlib.DotNet;
using dnlib.DotNet.Writer;

namespace asfpaifhaipfahfipasfhaipsfashjfpiqsfh190f1hf1ifp1hf1ipf1wf1
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        #region Textbox
        public string DirectoryName = "";
        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
                if (array != null)
                {
                    string text = array.GetValue(0).ToString();
                    int num = text.LastIndexOf(".", StringComparison.Ordinal);
                    if (num != -1)
                    {
                        string text2 = text.Substring(num);
                        text2 = text2.ToLower();
                        if (text2 == ".exe" || text2 == ".dll")
                        {
                            Activate();
                            textBox1.Text = text;
                            int num2 = text.LastIndexOf("\\", StringComparison.Ordinal);
                            if (num2 != -1)
                            { DirectoryName = text.Remove(num2, text.Length - num2); }
                            if (DirectoryName.Length == 2)
                            { DirectoryName += "\\"; }
                        }
                    }
                }
            }
            catch { }
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            { e.Effect = DragDropEffects.Copy; }
            else
            { e.Effect = DragDropEffects.None; }
        }
        #endregion


        private void button2_Click(object sender, EventArgs e)
        {
            ModuleDefMD module = ModuleDefMD.Load(textBox1.Text);
            IntControlFlow.Execute(module);
            AssemblyRenaming.Execute(module.Assembly);

            string text2 = Path.GetDirectoryName(textBox1.Text);

            if (!text2.EndsWith("\\"))
            {
                text2 += "\\";
            }
            string path = text2 + Path.GetFileNameWithoutExtension(textBox1.Text) + "_WithIntControlFlow" + Path.GetExtension(textBox1.Text);

            var opts = new ModuleWriterOptions(module);

            opts.PEHeadersOptions.NumberOfRvaAndSizes = 13;

            opts.MetadataOptions.TablesHeapOptions.ExtraData = 0x1337;

            opts.Logger = DummyLogger.NoThrowInstance;
            module.Write(path, opts);
        }

    }
}
