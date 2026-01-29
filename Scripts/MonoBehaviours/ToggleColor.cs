using UnityEngine;
using UnityEngine.UI;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class ToggleColor : MonoBehaviour
	{
		[SerializeField] Graphic? targetGraphic;
		[SerializeField] Color colorWhenOn = Color.white;
		[SerializeField] Color colorWhenOff = Color.clear;

		public void SetColor(bool isOn)
		{
			if (targetGraphic != null)
			{
				targetGraphic.color = isOn ? colorWhenOn : colorWhenOff;
			}
		}
	}
}