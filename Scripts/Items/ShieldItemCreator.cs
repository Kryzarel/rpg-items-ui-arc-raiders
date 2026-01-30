namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public sealed class ShieldItemCreator : ItemCreatorBase<ShieldItemDefinition, ShieldItem, ItemSaveDataWithDurability>
	{
		public override ShieldItem Create(ShieldItemDefinition definition)
		{
			return new ShieldItem(definition);
		}

		public override ShieldItem Create(ShieldItemDefinition definition, ItemSaveDataWithDurability saveData)
		{
			return new ShieldItem(definition, saveData);
		}

		public override ItemSaveDataWithDurability ToSaveData(ShieldItem item)
		{
			return new ItemSaveDataWithDurability(item.Definition.Id, item.Durability);
		}
	}
}