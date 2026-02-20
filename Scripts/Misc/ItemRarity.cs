using System;
using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	[CreateAssetMenu(fileName = nameof(ItemRarity), menuName = "Kryz/RPG Items UI - ARC Raiders/" + nameof(ItemRarity))]
	public class ItemRarity : ScriptableObject, IComparable<ItemRarity>
	{
		[field: SerializeField]
		public string Name { get; private set; } = string.Empty;
		[field: SerializeField]
		public Color Color { get; private set; } = Color.white;

		public int CompareTo(ItemRarity other) => string.Compare(name, other.name, StringComparison.OrdinalIgnoreCase);
	}
}