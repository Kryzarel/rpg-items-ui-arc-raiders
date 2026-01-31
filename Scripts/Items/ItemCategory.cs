using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	[CreateAssetMenu(fileName = nameof(ItemCategory), menuName = "Kryz/RPG Items UI - ARC Raiders/" + nameof(ItemCategory))]
	public class ItemCategory : ScriptableObject
	{
		[field: SerializeField]
		public string Name { get; private set; } = string.Empty;
		[field: SerializeField]
		public Sprite Icon { get; private set; } = null!;
	}
}