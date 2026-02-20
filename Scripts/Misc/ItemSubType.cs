using System;
using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	[CreateAssetMenu(fileName = nameof(ItemSubType), menuName = "Kryz/RPG Items UI - ARC Raiders/" + nameof(ItemSubType))]
	public class ItemSubType : ScriptableObject, IComparable<ItemSubType>
	{
		[field: SerializeField]
		public string Name { get; private set; } = string.Empty;

		public int CompareTo(ItemSubType other) => string.Compare(name, other.name, StringComparison.OrdinalIgnoreCase);
	}
}