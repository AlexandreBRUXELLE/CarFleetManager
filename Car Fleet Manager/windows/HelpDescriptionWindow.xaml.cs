using System.Windows;
using System.Windows.Input;

namespace Car_Fleet_Manager
{
    /// <summary>
    /// Interaction logic for HelpDescriptionWindow.xaml
    /// </summary>
    public partial class HelpDescriptionWindow : Window
    {
        /// <summary>
        /// Initialize Description Window
        /// </summary>
        public HelpDescriptionWindow()
        {
            InitializeComponent();

            // change standard cursor (for editing)           
            richDescriptionBox.Cursor = Cursors.Arrow;
        }
    }
}
