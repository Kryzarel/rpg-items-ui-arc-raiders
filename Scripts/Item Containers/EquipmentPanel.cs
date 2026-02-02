using System;
using System.Buffers;
using System.Collections.Generic;
using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public sealed class EquipmentPanel : Inventory, IRestrictedInventory, IRestrictedInventoryVisuals
	{
		private readonly HashSet<int> lockedSlots = new();

		public event Action<ItemStack> OnShieldEjected = delegate { };

		public IReadOnlyList<ItemFilter> SlotRestrictions = Array.Empty<ItemFilter>();

		public EquipmentPanel(int size, ArrayPool<ItemStack>? pool = null) : base(size, pool)
		{
			OnSlotChanged += UpdateShieldSlot;
		}

		private void UpdateShieldSlot(int index, ItemStack previousStack, ItemStack newStack)
		{
			if (index == 0)
			{
				ref ItemStack slot = ref slots[1];

				if (CanReceiveItem(1, slot))
				{
					SetSlot(ref slot, 1, slot);
				}
				else
				{
					ItemStack old = slot;
					SetSlot(ref slot, 1, default);
					OnShieldEjected(old);
				}
			}
		}

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

		public override bool CanAdd(in ItemStack stack, out ItemStack remainder, bool allowPartial = false)
		{
			if (stack.Item != null)
			{
				for (int i = 0; i < size; i++)
				{
					if (CanSwap(i, stack, out remainder))
					{
						return true;
					}
				}
			}

			remainder = stack;
			return false;
		}

		public override bool CanAdd(int index, in ItemStack stack, out ItemStack result, out ItemStack remainder, bool allowPartial = false)
		{
			result = default;
			remainder = stack;
			return CanReceiveItem(index, stack) && !IsSlotLocked(index) && base.CanAdd(index, stack, out result, out remainder, allowPartial);
		}

		public override bool CanRemove(in ItemStack stack)
		{
			if (stack.Item == null)
			{
				return false;
			}

			for (int i = 0, required = stack.Count; i < size; i++)
			{
				if (IsSlotLocked(i)) continue;

				ItemStack slot = slots[i];

				if (slot.Item == stack.Item && (required -= slot.Count) <= 0)
				{
					return true;
				}
			}

			return false;
		}

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

		public override bool TryAdd(in ItemStack stack, out ItemStack remainder, bool allowPartial = false)
		{
			if (stack.Item == null)
			{
				remainder = stack;
				return false;
			}

			for (int i = 0; i < size; i++)
			{
				if (TrySwap(i, stack, out remainder))
				{
					return true;
				}
			}

			remainder = stack;
			return false;
		}

		public override bool TryAdd(int index, in ItemStack stack, out ItemStack result, out ItemStack remainder, bool allowPartial = false)
		{
			result = default;
			remainder = stack;
			return CanReceiveItem(index, stack) && !IsSlotLocked(index) && base.TryAdd(index, stack, out result, out remainder, allowPartial);
		}

		public override bool TryRemove(in ItemStack stack)
		{
			if (!CanRemove(stack))
			{
				return false;
			}

			for (int i = 0, required = stack.Count; i < size && required > 0; i++)
			{
				if (IsSlotLocked(i)) continue;

				ref ItemStack slot = ref slots[i];

				if (slot.Item == stack.Item && slot.TryRemove(Math.Min(required, slot.Count), out ItemStack result, out ItemStack removed))
				{
					SetSlot(ref slot, i, result);
					required -= removed.Count;
				}
			}

			return true;
		}

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

		public bool CanReceiveItem(int index, in ItemStack stack)
		{
			if (index < 0 || index >= size || IsSlotLocked(index))
			{
				return false;
			}

			if (stack.Item == null)
			{
				return true;
			}

			if (stack.Item is not BaseItem baseItem)
			{
				return false;
			}

			if (index >= SlotRestrictions.Count)
			{
				return SlotRestrictions[^1].IsItemAllowed(baseItem);
			}

			if (index == 1 && slots[0].Item is AugmentItem augment)
			{
				return augment.Definition.ShieldCompatibility.IsItemAllowed(baseItem);
			}

			return SlotRestrictions[index].IsItemAllowed(baseItem);
		}

		public bool CanRemoveItem(int index)
		{
			return !IsSlotLocked(index);
		}

		public Sprite? GetSprite(int index)
		{
			if (index < 0 || index >= size)
			{
				return null;
			}

			if (index >= SlotRestrictions.Count)
			{
				return SlotRestrictions[^1].Icon;
			}

			if (index == 1 && slots[0].Item is AugmentItem augment)
			{
				return augment.Definition.ShieldCompatibility.Icon;
			}

			return SlotRestrictions[index].Icon;
		}
	}
}