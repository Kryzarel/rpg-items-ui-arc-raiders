namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public sealed class AugmentItemCreator : ItemCreator<AugmentItemDefinition, AugmentItem, ItemSaveDataWithDurability>
	{
		public override AugmentItem Create(AugmentItemDefinition definition)
		{
			return new AugmentItem(definition);
		}

		public override AugmentItem Create(AugmentItemDefinition definition, ItemSaveDataWithDurability saveData)
		{
			return new AugmentItem(definition, saveData);
		}

		public override ItemSaveDataWithDurability ToSaveData(AugmentItem item)
		{
			return new ItemSaveDataWithDurability(item.Definition.Id, item.Durability);
		}
	}
}