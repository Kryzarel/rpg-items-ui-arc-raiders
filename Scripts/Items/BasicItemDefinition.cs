using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	[CreateAssetMenu(fileName = nameof(BasicItemDefinition), menuName = "Kryz/RPG Items UI - ARC Raiders/" + nameof(BasicItemDefinition))]
	public class BasicItemDefinition : BaseItemDefinition
	{
		[Header("Basic Item")]
		[field: SerializeField, Range(1, 99)]
		public int MaxStacks { get; private set; } = 1;
	}
}