using System.Buffers;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class Stash : ItemContainer
	{
		public Stash(int size, ArrayPool<ItemStack>? pool = null) : base(size, pool)
		{
		}

		public override void FinalizeTransaction<T>(T transaction)
		{
			Sort(transaction);
		}
	}
}