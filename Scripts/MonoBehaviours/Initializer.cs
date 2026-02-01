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

		[Header("References")]
		[SerializeField] InventoryController? inventoryController;
		[SerializeField] InventoryView? cursorInventoryView;
		[SerializeField] BaseItemDefinition[] itemDefinitions = Array.Empty<BaseItemDefinition>();
		[SerializeField] int[] itemCounts = Array.Empty<int>();
		[Header("Other")]
		[SerializeField] ItemFilterBase? quickUseFilter;
		[SerializeField] ItemFilterBase? safePocketFilter;

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
			itemFactory.Register(new AugmentItemCreator());
			itemFactory.Register(new ShieldItemCreator());
			itemFactory.Register(new WeaponItemCreator());
		}

		private void Start()
		{
			player.QuickUse.ItemFilter = quickUseFilter;
			player.SafePocket.ItemFilter = safePocketFilter;

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