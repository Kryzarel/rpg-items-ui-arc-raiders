namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class Player
	{
		public readonly NewInventory Stash = new(160); // Probably needs to be moved out of here.

		public readonly EquipmentPanel Equipment = new(4);
		public readonly NewInventory Backpack = new(10);
		public readonly RestrictedInventory QuickUse = new(4);
		public readonly RestrictedInventory AugmentSlots = new(1);
		public readonly RestrictedInventory SafePocket = new(1);

		public Player()
		{
			Equipment.OnShieldEjected += stack => Stash.TryAdd(stack, out _);
		}
	}
}