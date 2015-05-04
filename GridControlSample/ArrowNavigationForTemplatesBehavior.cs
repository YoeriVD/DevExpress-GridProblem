using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Grid;

namespace GridControlSample
{
	/// <summary>
	/// 
	/// </summary>
	public class ArrowNavigationForTemplatesBehavior : Behavior<GridControl>
	{
		/// <summary>
		/// 
		/// </summary>
		private TableView TableView { get { return AssociatedObject.View as TableView; } }
		/// <summary>
		/// Called after the behavior is attached to an AssociatedObject.
		/// </summary>
		/// <remarks>
		/// Override this to hook up functionality to the AssociatedObject.
		/// </remarks>
		protected override void OnAttached()
		{
			base.OnAttached();
			TableView.PreviewKeyDown += AssociatedObjectOnPreviewKeyDown;
		}

		private void AssociatedObjectOnPreviewKeyDown(object sender, KeyEventArgs e)
		{
			var textBox = e.OriginalSource as TextBox;
			var currentCellValue = AssociatedObject.CurrentCellValue;
			if (textBox != null && (currentCellValue is SampleItem)) //in stead of SampleItem check for FormattedValues or something
			{
				HandleArrowPresses(textBox, e);
			}
		}

		private void HandleArrowPresses(TextBox textBox, KeyEventArgs e)
		{
			var selectedText = textBox.SelectedText;
			var text = textBox.Text;
			var allTextIsSelected = selectedText.Length == text.Length;

			if ((e.Key == Key.Right || e.Key == Key.Left) && !allTextIsSelected)
			{
				if (e.Key == Key.Left)
				{
					if (textBox.CaretIndex == 0) return; //let the grid navigate when the cursor is already at maximum left
					textBox.CaretIndex--;
				}
				else //right key pressed
				{
					if (textBox.CaretIndex == text.Length) return; //let the grid navigate when the cursor is already at maximum right
					textBox.CaretIndex++;
				}
				e.Handled = true;
			}
		}
	}
}
