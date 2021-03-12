namespace SpokenWord
{
	public class Snapshot
	{
		public float forceSliderValue;

		public Snapshot ()
		{
			float temp = GameManager.osc.GetValue();
			forceSliderValue = GameManager.osc.GetMaxValue() - temp;
		}
	}
}