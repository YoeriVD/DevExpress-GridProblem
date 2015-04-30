using System;

namespace GridControlSample
{
	public class SampleItemEdit
	{
		private readonly Func<SampleItem> _getItemFunc;
		private readonly Action<string> _doSomeAction;

		public string SourceValue
		{
			get { return _getItemFunc().Item; }
			set { _doSomeAction(value); }
		}

		public SampleItemEdit(Func<SampleItem> getItemFunc, Action<string> doSomeAction)
		{
			_getItemFunc = getItemFunc;
			_doSomeAction = doSomeAction;
		}
	}
}