using System;
using System.Windows.Input;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;

namespace GridControlSample
{
	public class MyGridControl : GridControl
	{
		public MyGridControl()
		{
			this.Initialized += OnInitialized;
		}

		private void OnInitialized(object sender, EventArgs eventArgs)
		{
			View.PreviewKeyDown += ViewOnPreviewKeyDown;
		}

		private void ViewOnPreviewKeyDown(object sender, KeyEventArgs e)
		{
			var tableView = (sender as TableView);
			var actEditor = tableView == null ? null : tableView.ActiveEditor as TextEdit;
			if ((e.Key == Key.Right || e.Key == Key.Left) && actEditor != null && actEditor.SelectedText.Length == 0)
			{
				//actEditor.CaretIndex = e.Key == Key.Left ? actEditor.CaretIndex - 1 : actEditor.CaretIndex + 1;
				//e.Handled = true;
			}
		}
	}
}
