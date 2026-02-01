using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public abstract class BaseItemDefinition : ScriptableObject, IItemDefinition
	{
		[field: SerializeField]
		public string Id { get; private set; } = string.Empty;
		[field: SerializeField]
		public Sprite? Icon { get; private set; }
		[field: SerializeField]
		public string Name { get; private set; } = string.Empty;
		[field: SerializeField, TextArea]
		public string Description { get; private set; } = string.Empty;

		[field: Header("ARC Raiders")]
		[field: SerializeField]
		public ItemType ItemType { get; private set; } = null!;
		[field: SerializeField]
		public ItemRarity Rarity { get; private set; } = null!;
		[field: SerializeField]
		public float Weight { get; private set; } = 1;
		[field: SerializeField]
		public int SellPrice { get; private set; } = 10;

		protected virtual void OnValidate()
		{
			Id = name;
		}
	}
}