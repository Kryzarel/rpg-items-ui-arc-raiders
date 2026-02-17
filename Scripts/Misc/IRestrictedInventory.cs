using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public interface IRestrictedInventoryVisuals
	{
		Sprite? GetSprite(int index);
	}
}