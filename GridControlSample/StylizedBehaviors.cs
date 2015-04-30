using System.Windows;
using DevExpress.Mvvm.UI.Interactivity;

namespace GridControlSample
{
	public class StylizedBehaviors
	{
		/// <summary>
		/// Add behaviors to ui elements
		/// </summary>
		public static readonly DependencyProperty AddProperty = DependencyProperty.RegisterAttached(
			@"Add",
			typeof(StylizedBehaviorCollection),
			typeof(StylizedBehaviors),
			new FrameworkPropertyMetadata(null, OnPropertyChanged));

		/// <summary>
		/// Gets the behaviors to be added
		/// </summary>
		/// <param name="uie"></param>
		/// <returns></returns>
		public static StylizedBehaviorCollection GetAdd(DependencyObject uie)
		{
			return (StylizedBehaviorCollection)uie.GetValue(AddProperty);
		}

		/// <summary>
		/// Sets the behaviors to be added
		/// </summary>
		/// <param name="uie"></param>
		/// <param name="value"></param>
		public static void SetAdd(DependencyObject uie, StylizedBehaviorCollection value)
		{
			uie.SetValue(AddProperty, value);
		}

		private static void OnPropertyChanged(DependencyObject dpo, DependencyPropertyChangedEventArgs e)
		{
			var itemBehaviors = Interaction.GetBehaviors(dpo);
			var newBehaviors = e.NewValue as StylizedBehaviorCollection;

			if (newBehaviors != null)
			{
				foreach (var behavior in newBehaviors)
				{
					var clone = (Behavior)behavior.Clone();
					itemBehaviors.Add(clone);
				}
			}
		}
	}
}