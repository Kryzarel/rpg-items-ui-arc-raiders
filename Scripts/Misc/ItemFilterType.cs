using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	[CreateAssetMenu(fileName = nameof(ItemFilterType), menuName = "Kryz/RPG Items UI - ARC Raiders/Item Filters/" + nameof(ItemFilterType))]
	public sealed class ItemFilterType : ItemFilterBase, ISerializationCallbackReceiver
	{
		[SerializeField]
		private ItemType[] types = Array.Empty<ItemType>();
		[SerializeField]
		private ItemSubType[] subTypes = Array.Empty<ItemSubType>();

		private readonly HashSet<ItemType> typesSet = new();
		private readonly HashSet<ItemSubType> subTypesSet = new();

		public override bool IsItemAllowed(BaseItem item)
		{
			return typesSet.Contains(item.Definition.ItemType) || subTypesSet.Contains(item.Definition.ItemType.SubType);
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			typesSet.Clear();
			typesSet.UnionWith(types);

			subTypesSet.Clear();
			subTypesSet.UnionWith(subTypes);
		}
	}
}