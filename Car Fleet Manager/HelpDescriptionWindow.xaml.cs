using Microsoft.Build.Tasks;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Car_Fleet_Manager
{
    /// <summary>
    /// Interaction logic for HelpDescriptionWindow.xaml
    /// </summary>
    public partial class HelpDescriptionWindow : Window
    {
        public HelpDescriptionWindow()
        {
            InitializeComponent();
            
            // change standart cursor (for editing)           
            richDescriptionBox.Cursor = Cursors.Arrow;
        }       
    }
}
