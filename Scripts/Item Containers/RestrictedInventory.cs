using System.Buffers;
using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class RestrictedInventory : Inventory, IRestrictedInventory, IRestrictedInventoryVisuals
	{
		public ItemFilterBase? ItemFilter;

		public RestrictedInventory(int numSlots, ArrayPool<ItemStack>? pool = null) : base(numSlots, pool) { }

		public RestrictedInventory(ItemFilterBase itemFilter, int numSlots, ArrayPool<ItemStack>? pool = null) : base(numSlots, pool)
		{
			ItemFilter = itemFilter;
		}

		public override bool CanSwap(int index, in ItemStack stack, out ItemStack removed)
		{
			removed = default;
			return CanReceiveItem(index, stack) && base.CanSwap(index, stack, out removed);
		}

		public override bool CanAdd(in ItemStack stack, out ItemStack remainder, bool allowPartial = false)
		{
			remainder = stack;
			return CanReceiveItem(0, stack) && base.CanAdd(stack, out remainder, allowPartial);
		}

		public override bool CanAdd(int index, in ItemStack stack, out ItemStack result, out ItemStack remainder, bool allowPartial = false)
		{
			result = default;
			remainder = stack;
			return CanReceiveItem(index, stack) && base.CanAdd(index, stack, out result, out remainder, allowPartial);
		}

		public override bool TrySwap(int index, in ItemStack stack, out ItemStack removed, bool forceSwap = false)
		{
			removed = default;
			return CanReceiveItem(index, stack) && base.TrySwap(index, stack, out removed);
		}

		public override bool TryAdd(in ItemStack stack, out ItemStack remainder, bool allowPartial = false)
		{
			remainder = stack;
			return CanReceiveItem(0, stack) && base.TryAdd(stack, out remainder, allowPartial);
		}

		public override bool TryAdd(int index, in ItemStack stack, out ItemStack result, out ItemStack remainder, bool allowPartial = false)
		{
			result = default;
			remainder = stack;
			return CanReceiveItem(index, stack) && base.TryAdd(index, stack, out result, out remainder, allowPartial);
		}

		public bool CanReceiveItem(int index, in ItemStack stack)
		{
			return ItemFilter == null || stack.Item == null || stack.Item is BaseItem baseItem && ItemFilter.IsItemAllowed(baseItem);
		}

		public bool CanRemoveItem(int index) => true;

		public Sprite? GetSprite(int index)
		{
			return ItemFilter != null ? ItemFilter.Icon : null;
		}
	}
}