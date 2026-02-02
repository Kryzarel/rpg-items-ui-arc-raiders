using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	[CreateAssetMenu(fileName = nameof(ItemFilterUse), menuName = "Kryz/RPG Items UI - ARC Raiders/Item Filters/" + nameof(ItemFilterUse))]
	public class ItemFilterUse : ItemFilter
	{
		public override bool IsItemAllowed(BaseItem item)
		{
			return item.Definition is IUsable usable && usable.UseAction != null;
		}
	}
}