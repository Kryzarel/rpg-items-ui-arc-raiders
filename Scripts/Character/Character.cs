namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class Character
	{
		public readonly Inventory Equipment = new(4);
		public readonly Inventory Backpack = new(10);
		public readonly Inventory QuickUse = new(4);
		public readonly Inventory AugmentSlots = new(0);
		public readonly Inventory SafePocket = new(1);
	}
}