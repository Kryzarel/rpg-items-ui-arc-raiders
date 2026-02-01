using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	[CreateAssetMenu(fileName = nameof(ItemType), menuName = "Kryz/RPG Items UI - ARC Raiders/" + nameof(ItemType))]
	public class ItemType : ScriptableObject
	{
		[field: SerializeField]
		public Sprite Icon { get; private set; } = null!;
		[field: SerializeField]
		public ItemSubType SubType { get; private set; } = null!;
	}
}