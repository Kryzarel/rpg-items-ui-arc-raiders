using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public class ItemSaveDataWithDurability : ItemSaveDataBase
	{
		[field: SerializeField, Range(0, 100)]
		public int Durability { get; private set; }

		public ItemSaveDataWithDurability(string definitionId, int durability) : base(definitionId)
		{
			Durability = durability;
		}
	}
}