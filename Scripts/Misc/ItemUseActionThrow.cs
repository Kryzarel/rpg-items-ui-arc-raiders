using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	[CreateAssetMenu(fileName = nameof(ItemUseActionThrow), menuName = "Kryz/RPG Items UI - ARC Raiders/Item Use Actions/" + nameof(ItemUseActionThrow))]
	public class ItemUseActionThrow : ItemUseAction
	{
		// Placeholder. I have no clue what properties throwable items actually have.
		[field: SerializeField]
		public float Distance { get; private set; }
	}
}