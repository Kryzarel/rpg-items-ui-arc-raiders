using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class Initializer : MonoBehaviour
	{
		private readonly ItemFactory itemFactory = new(new ItemDefinitionDatabaseResources());
		private readonly Player player = new();

		[Header("References")]
		[SerializeField] InventoryController? inventoryController;
		[SerializeField] BaseItemDefinition[] itemDefinitions = Array.Empty<BaseItemDefinition>();
		[SerializeField] int[] itemCounts = Array.Empty<int>();
		[Header("Other")]
		[SerializeField] ItemFilter? quickUseFilter;
		[SerializeField] ItemFilter? safePocketFilter;
		[SerializeField] ItemFilter[] equipmentRestrictions = Array.Empty<ItemFilter>();
		[SerializeField] BaseItemDefinition? duck;

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
			player.Equipment.SlotRestrictions = equipmentRestrictions;

			inventoryController!.SetPlayer(player);

			using ItemTransaction transaction = new(player.Stash);
			for (int i = 0; i < itemDefinitions.Length; i++)
			{
				player.Stash.SetSlot(transaction, i, new ItemStack(itemFactory.Create(itemDefinitions[i]), itemCounts[i]));
			}
			transaction.SetResult(true);

			inventoryController.SetContainer(player.Stash);
		}

		private void Update()
		{
			if (Keyboard.current.spaceKey.wasPressedThisFrame)
			{
				player.Stash.TryAdd(new ItemStack(itemFactory.Create(duck!)), out _);
			}
		}
	}
}