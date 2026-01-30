using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	[CreateAssetMenu(fileName = nameof(ShieldItemDefinition), menuName = "Kryz/RPG Items UI - ARC Raiders/" + nameof(ShieldItemDefinition))]
	public class ShieldItemDefinition : BaseItemDefinition
	{
		[field: Header("Shield")]
		[field: SerializeField]
		public int ShieldCharge { get; private set; } = 40;
		[field: SerializeField]
		public float DamageMitigation { get; private set; } = 40;
		[field: SerializeField]
		public float MovementPenalty { get; private set; } = 0;
	}
}