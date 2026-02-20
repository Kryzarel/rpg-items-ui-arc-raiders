using System;
using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	[CreateAssetMenu(fileName = nameof(ItemType), menuName = "Kryz/RPG Items UI - ARC Raiders/" + nameof(ItemType))]
	public class ItemType : ScriptableObject, IComparable<ItemType>
	{
		[field: SerializeField]
		public Sprite Icon { get; private set; } = null!;
		[field: SerializeField]
		public ItemSubType SubType { get; private set; } = null!;

		public int CompareTo(ItemType other)
		{
			int result = string.Compare(name, other.name, StringComparison.OrdinalIgnoreCase);
			if (result != 0) return result;
			return SubType.CompareTo(other.SubType);
		}
	}
}