namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class CraftingMaterialCreator : ItemCreatorSingleton<CraftingMaterialDefinition, CraftingMaterial, ItemSaveDataSingleton>
	{
		public override IItem Create(CraftingMaterialDefinition definition)
		{
			return new CraftingMaterial(definition);
		}

		public override ItemSaveDataSingleton ToSaveData(CraftingMaterial item)
		{
			return new ItemSaveDataSingleton(item.Definition.Id);
		}
	}
}