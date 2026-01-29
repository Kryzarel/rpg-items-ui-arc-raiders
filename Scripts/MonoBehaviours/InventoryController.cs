using Kryz.RPG.Items.Views;
using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class InventoryController : MonoBehaviour
	{
		[Header("Inventory Views")]
		[SerializeField] InventoryView? containerOrStash;
		[SerializeField] InventoryView? equipment;
		[SerializeField] InventoryView? backpack;
		[SerializeField] InventoryView? quickUse;
		[SerializeField] InventoryView? augmentSlots;
		[SerializeField] InventoryView? safePocket;

		public Player Player { get; private set; } = null!;

		public void SetPlayer(Player player)
		{
			Player = player;
			equipment!.SetInventory(player.Equipment);
			backpack!.SetInventory(player.Backpack);
			quickUse!.SetInventory(player.QuickUse);
			augmentSlots!.SetInventory(player.AugmentSlots);
			safePocket!.SetInventory(player.SafePocket);
		}

		public void SetContainer(IInventory container)
		{
			containerOrStash!.SetInventory(container);
		}
	}
}