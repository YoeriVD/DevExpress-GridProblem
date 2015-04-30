using System;
using System.Windows.Input;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;

namespace GridControlSample
{
	public sealed class SelectAllTextOnFocusBehavior : Behavior<TextEdit>
	{
		private bool _keyboardFocusReceivedByClickingTheMouse;

		/// <summary>
		/// Fires when the behavior is attached to a control
		/// </summary>
		protected override void OnAttached()
		{
			base.OnAttached();

			AssociatedObject.PreviewMouseLeftButtonDown += PreviewMouseLeftButtonDown;
			AssociatedObject.MouseDoubleClick += OnMousDoubleClick;
			AssociatedObject.GotKeyboardFocus += OnGotKeyBoardFocus;
		}

		private void OnMousDoubleClick(object sender, MouseButtonEventArgs e)
		{
			SelectAllText();
		}

		private void OnGotKeyBoardFocus(object sender, KeyboardFocusChangedEventArgs e)
		{
			if (Mouse.LeftButton == MouseButtonState.Pressed)
			{
				_keyboardFocusReceivedByClickingTheMouse = true;
				SelectAllText(); //select text if focus received by clicking
			}

			//select text if focus received by navigating by keyboard
			if (Keyboard.IsKeyDown(Key.Tab) || //normal screen navigation and gridcontrol navigation
				Keyboard.IsKeyDown(Key.Up) ||  //arrows, enter and return are used for gridcontrol navigation
				Keyboard.IsKeyDown(Key.Down) ||
				Keyboard.IsKeyDown(Key.Left) ||
				Keyboard.IsKeyDown(Key.Right) ||
				Keyboard.IsKeyDown(Key.Enter) ||
				Keyboard.IsKeyDown(Key.Return)
				)
			{
				SelectAllText();
			}

		}

		private void SelectAllText()
		{
			Dispatcher.BeginInvoke(new Action(() => AssociatedObject.SelectAll()));
		}

		/// <summary>
		/// Fires when the behavior detaches from a control
		/// </summary>
		protected override void OnDetaching()
		{
			base.OnDetaching();
			AssociatedObject.PreviewMouseLeftButtonDown -= PreviewMouseLeftButtonDown;
			AssociatedObject.MouseDoubleClick -= OnMousDoubleClick;
			AssociatedObject.GotKeyboardFocus -= OnGotKeyBoardFocus;
		}

		private void PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var textEditPartOfEditTemplateUsedInAGrid = AssociatedObject.EditTemplate != null
											 && (AssociatedObject.DataContext as EditGridCellData) != null;

			if (textEditPartOfEditTemplateUsedInAGrid)
				return; //don't block mouse click if textedit is used in a gridcolumn where an edittemplate is defined for (e.g. in case of ration parameters) -> otherwise it causes strange behavior (multiple clicking for checkbox or date control)

			if (_keyboardFocusReceivedByClickingTheMouse)
			{
				e.Handled = true; //block mouse click, otherwise the click will set the caret and undo the text selection
				_keyboardFocusReceivedByClickingTheMouse = false;
			}
		}

	}
}
