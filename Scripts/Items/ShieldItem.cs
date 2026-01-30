namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class ShieldItem : BaseItem
	{
		public new readonly ShieldItemDefinition Definition;

		public int Durability;

		public ShieldItem(ShieldItemDefinition definition) : base(definition)
		{
			Definition = definition;
			Durability = 100;
		}

		public ShieldItem(ShieldItemDefinition definition, ItemSaveDataWithDurability saveData) : base(definition)
		{
			Definition = definition;
			Durability = saveData.Durability;
		}
	}
}