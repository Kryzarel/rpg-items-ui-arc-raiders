using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public abstract class BaseItem : IItem
	{
		public readonly BaseItemDefinition Definition;

		public virtual Sprite Icon => Definition.Icon!;
		public virtual string Name => Definition.Name;
		public virtual string Description => Definition.Description;
		public virtual int MaxStacks => 1;

		IItemDefinition IItem.Definition => Definition;

		public BaseItem(BaseItemDefinition definition)
		{
			Definition = definition;
		}

		public virtual int CompareTo(IItem other) => Name.CompareTo(other.Name);
	}
}