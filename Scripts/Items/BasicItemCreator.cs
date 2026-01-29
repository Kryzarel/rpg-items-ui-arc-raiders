namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public sealed class BasicItemCreator : SingletonItemCreator<BasicItemDefinition, BasicItem>
	{
		public override IItem Create(BasicItemDefinition definition)
		{
			return new BasicItem(definition);
		}
	}
}