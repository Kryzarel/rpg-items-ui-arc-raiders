using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	[CreateAssetMenu(fileName = nameof(ItemFilterAugment), menuName = "Kryz/RPG Items UI - ARC Raiders/Item Filters/" + nameof(ItemFilterAugment))]
	public class ItemFilterAugment : ItemFilter
	{
		public override bool IsItemAllowed(BaseItem item)
		{
			return item is AugmentItem;
		}
	}
}