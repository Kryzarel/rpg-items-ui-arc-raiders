using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	[CreateAssetMenu(fileName = nameof(BasicItemDefinition), menuName = "Kryz/RPG Items UI - ARC Raiders/Item Definitions/" + nameof(BasicItemDefinition))]
	public class BasicItemDefinition : BaseItemDefinition, IUsable
	{
		[Header("Basic Item")]
		[field: SerializeField]
		public ItemUseAction? UseAction { get; private set; }
		[field: SerializeField, Range(1, 500)]
		public int MaxStacks { get; private set; } = 1;
	}
}