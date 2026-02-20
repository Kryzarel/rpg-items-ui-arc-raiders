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

		public virtual int CompareTo(IItem other)
		{
			int result = -1;
			if (other is BaseItem baseItem)
			{
				result = Definition.ItemType.CompareTo(baseItem.Definition.ItemType);
				if (result != 0) return result;
				// Compare this one in reverse because we want higher rarities first
				result = baseItem.Definition.Rarity.CompareTo(Definition.Rarity);
				if (result != 0) return result;
				return string.Compare(Name, baseItem.Name, System.StringComparison.Ordinal);
			}
			return result;
		}
	}
}