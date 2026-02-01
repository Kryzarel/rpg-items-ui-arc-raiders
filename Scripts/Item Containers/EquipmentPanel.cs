using System;
using System.Buffers;
using System.Collections.Generic;
using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public sealed class EquipmentPanel : Inventory, IRestrictedInventory, IRestrictedInventoryVisuals
	{
		private readonly HashSet<int> lockedSlots = new();
		private readonly int[] ints = { 0, 1, 2, 3, 4 };

		public Sprite[] SlotSprites = Array.Empty<Sprite>();

		public EquipmentPanel(ArrayPool<ItemStack>? pool = null) : base(4, pool) { }

		public bool IsSlotLocked(int index)
		{
			return index >= 0 && index < Size && lockedSlots.Contains(index);
		}

		public void LockSlot(int index)
		{
			if (index >= 0 && index < Size)
			{
				lockedSlots.Add(index);
			}
		}

		public void UnlockSlot(int index)
		{
			if (index >= 0 && index < Size)
			{
				lockedSlots.Remove(index);
			}
		}

		public override bool CanSwap(int index, in ItemStack stack, out ItemStack removed)
		{
			removed = default;
			return CanReceiveItem(index, stack) && !IsSlotLocked(index) && base.CanSwap(index, stack, out removed);
		}

		// public override bool CanAdd(in ItemStack stack, out ItemStack remainder, bool allowPartial = false)
		// {
		// }

		public override bool CanAdd(int index, in ItemStack stack, out ItemStack result, out ItemStack remainder, bool allowPartial = false)
		{
			result = default;
			remainder = stack;
			return CanReceiveItem(index, stack) && !IsSlotLocked(index) && base.CanAdd(index, stack, out result, out remainder, allowPartial);
		}

		// public override bool CanRemove(in ItemStack stack)
		// {
		// }

		public override bool CanRemove(int index, out ItemStack result, out ItemStack removed)
		{
			result = default;
			removed = default;
			return !IsSlotLocked(index) && base.CanRemove(index, out result, out removed);
		}

		public override bool CanRemove(int index, int count, out ItemStack result, out ItemStack removed)
		{
			result = default;
			removed = default;
			return !IsSlotLocked(index) && base.CanRemove(index, count, out result, out removed);
		}

		public override bool TrySwap(int index, in ItemStack stack, out ItemStack removed, bool forceSwap = false)
		{
			removed = default;
			return CanReceiveItem(index, stack) && !IsSlotLocked(index) && base.TrySwap(index, stack, out removed, forceSwap);
		}

		// public override bool TryAdd(in ItemStack stack, out ItemStack remainder, bool allowPartial = false)
		// {
		// }

		public override bool TryAdd(int index, in ItemStack stack, out ItemStack result, out ItemStack remainder, bool allowPartial = false)
		{
			result = default;
			remainder = stack;
			return CanReceiveItem(index, stack) && !IsSlotLocked(index) && base.TryAdd(index, stack, out result, out remainder, allowPartial);
		}

		// public override bool TryRemove(in ItemStack stack)
		// {
		// }

		public override bool TryRemove(int index, out ItemStack result, out ItemStack removed)
		{
			result = default;
			removed = default;
			return !IsSlotLocked(index) && base.TryRemove(index, out result, out removed);
		}

		public override bool TryRemove(int index, int count, out ItemStack result, out ItemStack removed)
		{
			result = default;
			removed = default;
			return !IsSlotLocked(index) && base.TryRemove(index, count, out result, out removed);
		}

		private ReadOnlySpan<int> GetSlotIndexes(in ItemStack stack)
		{
			return stack.Item switch
			{
				AugmentItem => new ReadOnlySpan<int>(ints, 1, 1),
				ShieldItem => new ReadOnlySpan<int>(ints, 1, 1),
				WeaponItem => new ReadOnlySpan<int>(ints, 2, 2),
				_ => ReadOnlySpan<int>.Empty,
			};
		}

		public bool CanReceiveItem(int index, in ItemStack stack)
		{
			if (IsSlotLocked(index)) return false;

			return stack.Item == null || index switch
			{
				0 => stack.Item is AugmentItem,
				1 => stack.Item is ShieldItem,
				2 => stack.Item is WeaponItem,
				3 => stack.Item is WeaponItem,
				_ => false,
			};
		}

		public bool CanRemoveItem(int index)
		{
			return !IsSlotLocked(index);
		}

		public Sprite? GetSprite(int index)
		{
			return index < 0 || index >= size ? null : SlotSprites[index];
		}
	}
}