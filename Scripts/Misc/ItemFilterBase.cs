using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public abstract class ItemFilterBase : ScriptableObject
	{
		[field: SerializeField]
		public Sprite Icon { get; private set; } = null!;

		public abstract bool IsItemAllowed(BaseItem item);
	}
}