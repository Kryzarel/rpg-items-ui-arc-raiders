using System;
using System.Buffers;
using System.Collections.Generic;
using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public sealed class EquipmentPanel : ItemContainer, IRestrictedInventoryVisuals
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
				IItem? shield = this[1].Item;

				if (shield != null && !CanReceive(1, shield) && TryRemoveSlot(1, out _, out ItemStack removed))
				{
					OnShieldEjected?.Invoke(removed);
				}
			}
		}

		public override bool CanReceive(int index, IItem item)
		{
			if (lockedSlots.Contains(index) || item is not BaseItem baseItem)
			{
				return false;
			}

			if (index >= SlotRestrictions.Count)
			{
				return SlotRestrictions[^1].IsItemAllowed(baseItem);
			}

			if (index == 1 && this[0].Item is AugmentItem augment)
			{
				return augment.Definition.ShieldCompatibility.IsItemAllowed(baseItem);
			}

			return SlotRestrictions[index].IsItemAllowed(baseItem);
		}

		public override bool CanRemove(int index)
		{
			return !lockedSlots.Contains(index) && base.CanRemove(index);
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

		public Sprite? GetSprite(int index)
		{
			if (index < 0 || index >= Size)
			{
				return null;
			}

			if (index >= SlotRestrictions.Count)
			{
				return SlotRestrictions[^1].Icon;
			}

			if (index == 1 && this[0].Item is AugmentItem augment)
			{
				return augment.Definition.ShieldCompatibility.Icon;
			}

			return SlotRestrictions[index].Icon;
		}
	}
}