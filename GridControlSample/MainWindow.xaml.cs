
using System.Windows;

namespace GridControlSample {
    public partial class MainWindow : Window {
	    public SampleViewModel ViewModel { get; set; }

	    public MainWindow() {
			ViewModel = new SampleViewModel();
			InitializeComponent();
            DataContext = this;
        }

    }
}
