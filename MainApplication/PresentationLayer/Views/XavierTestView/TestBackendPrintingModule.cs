using MainApplication.LogicLayer.Backend.PrintingModule;
using MainApplication.PresentationLayer.BackendSubsystemFactory;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApplication.PresentationLayer.Views.XavierTestView
{
    public partial class TestBackendPrintingModule : Form
    {
        private AbVenusBackendFactory venusBackendFactory;
        private AbPrintingModule venusPrintingModule;
        EnumPrintingModule printingModuleName;

        public TestBackendPrintingModule()
        {
            InitializeComponent();
        }

        private void TestBackendModulePrintingFunction_Load(object sender, EventArgs e)
        {
            venusBackendFactory = new PrintingModuleFactoryImp();
            venusPrintingModule = venusBackendFactory.createPrintingModuleMethod((int)EnumPrintingModule.VenusPrintingModuleImp);
            venusBackendFactory.createPrintingModuleMethod((int)EnumPrintingModule.VenusPrintingModuleImp);

            venusPrintingModule.setParameters(printDocument1, printPreviewDialog1, printDialog1, pageSetupDialog1, textBox1);
        }

        private void TestBackendModulePrinting_Load(object sender, EventArgs e)
        {
            venusBackendFactory = new PrintingModuleFactoryImp();
            venusPrintingModule = venusBackendFactory.createPrintingModuleMethod((int)EnumPrintingModule.VenusPrintingModuleImp);
            venusBackendFactory.createPrintingModuleMethod((int)EnumPrintingModule.VenusPrintingModuleImp);

            venusPrintingModule.setParameters(printDocument1, printPreviewDialog1, printDialog1, pageSetupDialog1, textBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            venusPrintingModule.setPageLayot();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            venusPrintingModule.preview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            venusPrintingModule.print();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
