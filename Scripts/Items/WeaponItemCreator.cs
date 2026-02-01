namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class WeaponItemCreator : SingletonItemCreator<WeaponItemDefinition, WeaponItem>
	{
		public override WeaponItem Create(WeaponItemDefinition definition)
		{
			return new WeaponItem(definition);
		}
	}
}