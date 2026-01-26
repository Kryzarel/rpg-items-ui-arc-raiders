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

		protected virtual void OnValidate()
		{
			Id = name;
		}
	}
}