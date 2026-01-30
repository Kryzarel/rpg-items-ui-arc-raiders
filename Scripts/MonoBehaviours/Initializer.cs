using System;
using Kryz.RPG.Items.Views;
using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class Initializer : MonoBehaviour
	{
		private readonly ItemFactory itemFactory = new(new ItemDefinitionDatabaseResources());
		private readonly Inventory cursorInventory = new(1);
		private readonly Player player = new();

		[SerializeField]
		private InventoryController? inventoryController;
		[SerializeField]
		private InventoryView? cursorInventoryView;
		[SerializeField]
		private BaseItemDefinition[] itemDefinitions = Array.Empty<BaseItemDefinition>();
		[SerializeField]
		private int[] itemCounts = Array.Empty<int>();

		private void OnValidate()
		{
			Array.Resize(ref itemCounts, itemDefinitions.Length);
			for (int i = 0; i < itemCounts.Length; i++)
			{
				ref int count = ref itemCounts[i];
				if (count <= 0) count = 1;
			}
		}

		private void Awake()
		{
			itemFactory.Register(new BasicItemCreator());
		}

		private void Start()
		{
			inventoryController!.SetPlayer(player);
			cursorInventoryView!.SetInventory(cursorInventory);

			for (int i = 0; i < itemDefinitions.Length; i++)
			{
				player.Stash.TrySwap(i, new ItemStack(itemFactory.Create(itemDefinitions[i]), itemCounts[i]), out _);
			}

			inventoryController.SetContainer(player.Stash);
		}
	}
}