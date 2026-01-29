namespace Kryz.RPG.Items.UI.ARCRaiders
{
	public abstract class SingletonItemCreator<TDefinition, TItem> : ItemCreatorSingleton<TDefinition, TItem, ItemSaveDataSingleton> where TDefinition : BaseItemDefinition where TItem : BaseItem
	{
		public override ItemSaveDataSingleton ToSaveData(TItem item)
		{
			return new ItemSaveDataSingleton(item.Definition.Id);
		}
	}
}