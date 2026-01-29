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
	}
}