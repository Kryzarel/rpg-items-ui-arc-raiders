using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public interface IRestrictedInventory
	{
		bool CanReceiveItem(int index, in ItemStack stack);
		bool CanRemoveItem(int index);
	}

	public interface IRestrictedInventoryVisuals
	{
		Sprite? GetSprite(int index);
	}
}