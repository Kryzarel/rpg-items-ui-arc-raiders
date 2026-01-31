using System.Buffers;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class RestrictedInventory : Inventory
	{
		public ItemCategory? CategoryRestriction;

		public RestrictedInventory(int numSlots, ArrayPool<ItemStack>? pool = null) : base(numSlots, pool) { }

		public RestrictedInventory(ItemCategory restriction, int numSlots, ArrayPool<ItemStack>? pool = null) : base(numSlots, pool)
		{
			CategoryRestriction = restriction;
		}

		public override bool CanSwap(int index, in ItemStack stack, out ItemStack removed)
		{
			removed = default;
			return IsItemAllowed(stack) && base.CanSwap(index, stack, out removed);
		}

		public override bool CanAdd(in ItemStack stack, out ItemStack remainder, bool allowPartial = false)
		{
			remainder = stack;
			return IsItemAllowed(stack) && base.CanAdd(stack, out remainder, allowPartial);
		}

		public override bool CanAdd(int index, in ItemStack stack, out ItemStack result, out ItemStack remainder, bool allowPartial = false)
		{
			result = default;
			remainder = stack;
			return IsItemAllowed(stack) && base.CanAdd(index, stack, out result, out remainder, allowPartial);
		}

		public override bool TrySwap(int index, in ItemStack stack, out ItemStack removed, bool forceSwap = false)
		{
			removed = default;
			return IsItemAllowed(stack) && base.TrySwap(index, stack, out removed);
		}

		public override bool TryAdd(in ItemStack stack, out ItemStack remainder, bool allowPartial = false)
		{
			remainder = stack;
			return IsItemAllowed(stack) && base.TryAdd(stack, out remainder, allowPartial);
		}

		public override bool TryAdd(int index, in ItemStack stack, out ItemStack result, out ItemStack remainder, bool allowPartial = false)
		{
			result = default;
			remainder = stack;
			return IsItemAllowed(stack) && base.TryAdd(index, stack, out result, out remainder, allowPartial);
		}

		protected bool IsItemAllowed(in ItemStack stack)
		{
			return CategoryRestriction == null || stack.Item == null || stack.Item is BaseItem baseItem && baseItem.Definition.Category == CategoryRestriction;
		}
	}
}