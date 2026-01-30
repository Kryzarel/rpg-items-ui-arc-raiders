namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class AugmentItem : BaseItem
	{
		public new readonly AugmentItemDefinition Definition;

		public int Durability;

		public AugmentItem(AugmentItemDefinition definition) : base(definition)
		{
			Definition = definition;
			Durability = 100;
		}

		public AugmentItem(AugmentItemDefinition definition, ItemSaveDataWithDurability saveData) : base(definition)
		{
			Definition = definition;
			Durability = saveData.Durability;
		}
	}
}