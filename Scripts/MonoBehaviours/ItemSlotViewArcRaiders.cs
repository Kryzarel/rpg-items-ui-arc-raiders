using Kryz.RPG.Items.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class ItemSlotViewArcRaiders : ItemSlotView
	{
		[Header("ARC Raiders References")]
		[SerializeField] protected Image? border;
		[SerializeField] protected GameObject? footer;
		[SerializeField] protected Image? footerLeftIcon;
		[SerializeField] protected Image? footerMiddleIcon;
		[SerializeField] protected Image? footerRightIcon;
		[Header("ARC Raiders Settings")]
		[SerializeField] protected Color borderColor;

		protected override void RefreshBound()
		{
			if (inventory is IRestrictedInventoryVisuals restricted)
			{
				emptySprite = restricted.GetSprite(slotIndex);
				emptyColor = borderColor;
			}
			else
			{
				emptySprite = null;
				emptyColor = Color.clear;
			}

			base.RefreshBound();

			if (itemStack.Item is BaseItem baseItem)
			{
				if (border != null)
				{
					border.color = baseItem.Definition.Rarity.Color;
				}

				if (footerLeftIcon != null)
				{
					footerLeftIcon.sprite = baseItem.Definition.ItemType.Icon;
					footerLeftIcon.enabled = true;
				}

				if (footer != null && !footer.activeSelf)
				{
					footer.SetActive(true);
				}
			}
			else
			{
				if (border != null) border.color = borderColor;
				if (footerLeftIcon != null) footerLeftIcon.enabled = false;
				if (footerMiddleIcon != null) footerMiddleIcon.enabled = false;
				if (footerRightIcon != null) footerRightIcon.enabled = false;

				if (footer != null && footer.activeSelf)
				{
					footer.SetActive(false);
				}

				if (itemStack.Item != null)
				{
					Debug.LogError($"{GetType().Name} does not support items of type {itemStack.Item?.GetType().Name ?? "null"}. Items must extend {nameof(BaseItem)}.");
				}
			}
		}

		protected override void RefreshUnbound()
		{
			base.RefreshUnbound();

			if (border != null) border.color = borderColor;
			if (footer != null && footer.activeSelf) footer.SetActive(false);
		}
	}
}