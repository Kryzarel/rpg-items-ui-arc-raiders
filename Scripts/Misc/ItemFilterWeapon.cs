using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	[CreateAssetMenu(fileName = nameof(ItemFilterWeapon), menuName = "Kryz/RPG Items UI - ARC Raiders/Item Filters/" + nameof(ItemFilterWeapon))]
	public class ItemFilterWeapon : ItemFilter
	{
		public override bool IsItemAllowed(BaseItem item)
		{
			return item is WeaponItem;
		}
	}
}