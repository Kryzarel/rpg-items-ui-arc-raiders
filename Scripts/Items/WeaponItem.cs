namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class WeaponItem : BaseItem
	{
		public new readonly WeaponItemDefinition Definition;

		public WeaponItem(WeaponItemDefinition definition) : base(definition)
		{
			Definition = definition;
		}
	}
}