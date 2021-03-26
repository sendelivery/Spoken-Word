using UnityEngine;

namespace SpokenWord
{
	public class Snapshot
	{
		public float forceSliderValue;

		public Snapshot ()
		{
			float comp = GameManager.osc.GetValue();

			Debug.Log("snapshot temp = " + comp);

			if (comp <= 0.1f) comp = 0.05f;
			if (0.45f <= comp && comp <= 0.75f) comp = 0.25f;
			if (comp >= 0.75f) comp = 0.55f;


			Debug.Log("snapshot temp after compensation = " + comp);

			forceSliderValue = GameManager.osc.GetMaxValue() - comp;
		}
	}
}