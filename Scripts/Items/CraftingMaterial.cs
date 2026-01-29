namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class CraftingMaterial : BaseItem
	{
		public new readonly CraftingMaterialDefinition Definition;

		public override int MaxStacks => Definition.MaxStacks;

		public CraftingMaterial(CraftingMaterialDefinition definition) : base(definition)
		{
			Definition = definition;
		}
	}
}