using System.Buffers;
using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class RestrictedInventory : ItemContainer, IRestrictedInventoryVisuals
	{
		public ItemFilter? ItemFilter;

		public RestrictedInventory(int numSlots, ArrayPool<ItemStack>? pool = null) : base(numSlots, pool) { }

		public RestrictedInventory(ItemFilter itemFilter, int numSlots, ArrayPool<ItemStack>? pool = null) : base(numSlots, pool)
		{
			ItemFilter = itemFilter;
		}

		public override bool CanReceive(int index, IItem item)
		{
			return ItemFilter == null || item == null || item is BaseItem baseItem && ItemFilter.IsItemAllowed(baseItem);
		}

		public Sprite? GetSprite(int index)
		{
			return ItemFilter != null ? ItemFilter.Icon : null;
		}
	}
}