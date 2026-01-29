using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class CraftingMaterialDefinition : BaseItemDefinition
	{
		[field: SerializeField]
		public int MaxStacks { get; private set; }
	}
}