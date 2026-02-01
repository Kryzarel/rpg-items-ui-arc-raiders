using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	[CreateAssetMenu(fileName = nameof(WeaponItemDefinition), menuName = "Kryz/RPG Items UI - ARC Raiders/Item Definitions/" + nameof(WeaponItemDefinition))]
	public class WeaponItemDefinition : BaseItemDefinition
	{
		[field: Header("Weapon")]
		[field: SerializeField]
		public ItemType AmmoType { get; private set; } = null!;
		[field: SerializeField, Range(0, 3)]
		public int ArcArmorPenetration { get; private set; }
		[field: SerializeField]
		public int MagazineSize { get; private set; }
		[field: SerializeField]
		public float Damage { get; private set; }
		[field: SerializeField]
		public float FireRate { get; private set; }
		[field: SerializeField]
		public float HeadshotMultiplier { get; private set; }
		[field: SerializeField]
		public float Range { get; private set; }
		[field: SerializeField]
		public float Stability { get; private set; }
		[field: SerializeField]
		public float Agility { get; private set; }
		[field: SerializeField]
		public float Stealth { get; private set; }
	}
}