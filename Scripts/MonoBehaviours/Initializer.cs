using System;
using Kryz.RPG.Items.Views;
using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class Initializer : MonoBehaviour
	{
		private readonly ItemFactory itemFactory = new(new ItemDefinitionDatabaseResources());
		private readonly Inventory inventory = new(12);
		private readonly Inventory cursorInventory = new(1);

		[SerializeField]
		private InventoryView? inventoryView;
		[SerializeField]
		private InventoryView? cursorInventoryView;
		[SerializeField]
		private BaseItemDefinition[] itemDefinitions = Array.Empty<BaseItemDefinition>();
		[SerializeField]
		private int[] itemCounts = Array.Empty<int>();
		[SerializeField]
		private InventorySaveData inventorySaveData = new();
		[SerializeField]
		private string saveDataJson = string.Empty;

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
			itemFactory.Register(new CraftingMaterialCreator());
			// itemFactory.Register(new EquipableItemCreator());
		}

		private void Start()
		{
			inventoryView!.SetInventory(inventory);
			cursorInventoryView!.SetInventory(cursorInventory);

			if (string.IsNullOrEmpty(saveDataJson))
			{
				for (int i = 0; i < itemDefinitions.Length; i++)
				{
					inventory.TrySwap(i, new ItemStack(itemFactory.Create(itemDefinitions[i]), itemCounts[i]), out _);
				}
			}
			else
			{
				JsonUtility.FromJsonOverwrite(saveDataJson, inventorySaveData);
				inventorySaveData.ToInventory(itemFactory, inventory);
			}
		}

		private void OnDisable()
		{
			inventorySaveData.FromItems(itemFactory, inventory.AsSpan());
			Debug.Log(JsonUtility.ToJson(inventorySaveData));
		}
	}
}