using UnityEngine;
using UnityEngine.UI;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class ToggleColor : MonoBehaviour
	{
		[SerializeField] Graphic targetGraphic;
		[SerializeField] Color colorWhenOn = Color.white;
		[SerializeField] Color colorWhenOff = Color.cornflowerBlue;

		public void SetColor(bool isOn)
		{
			targetGraphic.color = isOn ? colorWhenOn : colorWhenOff;
		}
	}
}