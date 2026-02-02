using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public abstract class ItemFilter : ScriptableObject
	{
		[field: SerializeField]
		public Sprite Icon { get; private set; } = null!;

		public abstract bool IsItemAllowed(BaseItem item);
	}
}