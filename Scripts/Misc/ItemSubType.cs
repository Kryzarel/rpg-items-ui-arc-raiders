using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	[CreateAssetMenu(fileName = nameof(ItemSubType), menuName = "Kryz/RPG Items UI - ARC Raiders/" + nameof(ItemSubType))]
	public class ItemSubType : ScriptableObject
	{
		[field: SerializeField]
		public string Name { get; private set; } = string.Empty;
	}
}