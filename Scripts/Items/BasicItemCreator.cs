namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public sealed class BasicItemCreator : SingletonItemCreator<BasicItemDefinition, BasicItem>
	{
		public override BasicItem Create(BasicItemDefinition definition)
		{
			return new BasicItem(definition);
		}
	}
}