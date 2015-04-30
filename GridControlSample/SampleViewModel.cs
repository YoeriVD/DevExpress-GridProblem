using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GridControlSample
{
	public class SampleViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<ClientSampleRow> Items { get; set; }

		public SampleViewModel()
		{
			this.Items = new ObservableCollection<ClientSampleRow>();

			for (var i = 0; i < 5; i++)
			{
				Items.Add(CreateRow(i));
			}
		}

		private ClientSampleRow CreateRow(int i)
		{
			var sampleRow = new ClientSampleRow()
			{
				Item = new SampleItem() {  Item = "Item number " + i}
			};
			sampleRow.ItemEdit = new SampleItemEdit(() => sampleRow.Item, val => sampleRow.Item.Item = val /* this dummy code is in reality sending a request to the server with the newly entered value */);
			return sampleRow;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
