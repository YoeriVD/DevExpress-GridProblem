namespace GridControlSample
{
	/// <summary>
	/// Inheriting from the SampleRow allows us to still serialize json updates to the row, but add some client side logic of ourselves
	/// </summary>
	public class ClientSampleRow : SampleRow
	{
		public SampleItemEdit ItemEdit { get; set; }
	}
}