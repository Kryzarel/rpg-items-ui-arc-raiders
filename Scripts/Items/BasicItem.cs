namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class BasicItem : BaseItem
	{
		public new readonly BasicItemDefinition Definition;

		public override int MaxStacks => Definition.MaxStacks;

		public BasicItem(BasicItemDefinition definition) : base(definition)
		{
			Definition = definition;
		}
	}
}