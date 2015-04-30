using System.Windows;
using DevExpress.Mvvm.UI.Interactivity;

namespace GridControlSample
{
	public class StylizedBehaviorCollection : FreezableCollection<Behavior>
	{
		/// <summary>
		/// Creates an instance
		/// </summary>
		/// <returns></returns>
		protected override Freezable CreateInstanceCore()
		{
			return new StylizedBehaviorCollection();
		}
	}
}
