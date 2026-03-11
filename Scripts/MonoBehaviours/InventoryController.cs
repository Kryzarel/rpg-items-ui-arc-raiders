using Kryz.RPG.Items.UGUI;
using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class InventoryController : MonoBehaviour
	{
		[Header("Inventory Views")]
		[SerializeField] ItemContainerView? containerOrStash;
		[SerializeField] ItemContainerView? equipment;
		[SerializeField] ItemContainerView? backpack;
		[SerializeField] ItemContainerView? quickUse;
		[SerializeField] ItemContainerView? augmentSlots;
		[SerializeField] ItemContainerView? safePocket;

		public Player Player { get; private set; } = null!;

		public void SetPlayer(Player player)
		{
			Player = player;
			equipment!.SetItemContainer(player.Equipment);
			backpack!.SetItemContainer(player.Backpack);
			quickUse!.SetItemContainer(player.QuickUse);
			augmentSlots!.SetItemContainer(player.AugmentSlots);
			safePocket!.SetItemContainer(player.SafePocket);
		}

		public void SetContainer(IItemContainer container)
		{
			containerOrStash!.SetItemContainer(container);
		}
	}
}