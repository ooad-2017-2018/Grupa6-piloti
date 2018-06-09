using Windows.UI.Xaml.Controls;
using Aerodrom.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Aerodrom
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Uprava : Page
    {
        public Uprava()
        {
            this.InitializeComponent();
            DataContext = new UpravaViewModel();
        }
    }
}
