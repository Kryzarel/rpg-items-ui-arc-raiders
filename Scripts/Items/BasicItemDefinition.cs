using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	[CreateAssetMenu(fileName = nameof(BasicItemDefinition), menuName = "Kryz/RPG Items UI - ARC Raiders/" + nameof(BasicItemDefinition))]
	public class BasicItemDefinition : BaseItemDefinition
	{
		[field: SerializeField]
		public ItemCategory Category { get; private set; } = null!;
		[field: SerializeField]
		public ItemRarity Rarity { get; private set; } = null!;
		[field: SerializeField]
		public Sprite TypeIcon { get; private set; } = null!;
		[field: SerializeField]
		public int SellPrice { get; private set; } = 10;
		[field: SerializeField, Range(1, 99)]
		public int MaxStacks { get; private set; } = 1;
	}
}