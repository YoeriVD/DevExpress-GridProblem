using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GridControlSample
{
	public class SampleItem : INotifyPropertyChanged
	{
		private string _item = "125541,00";

		public string Item
		{
			get
			{
				return _item;
			}
			set
			{
				_item = value;
				RaisePropertyChanged();
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;
		void RaisePropertyChanged([CallerMemberName] string fieldName = null)
		{
			if (PropertyChanged == null) return;
			PropertyChanged(this, new PropertyChangedEventArgs(fieldName));
		}
	}
}