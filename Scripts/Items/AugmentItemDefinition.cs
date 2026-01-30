using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kryz.RPG.Items.UI.ARCRaiders
{
	[CreateAssetMenu(fileName = nameof(AugmentItemDefinition), menuName = "Kryz/RPG Items UI - ARC Raiders/" + nameof(AugmentItemDefinition))]
	public class AugmentItemDefinition : BaseItemDefinition
	{
		[field: Header("Augment")]
		[field: SerializeField]
		public int BackpackSlots { get; private set; } = 14;
		[field: SerializeField]
		public int QuickUseSlots { get; private set; } = 4;
		[field: SerializeField]
		public int AugmentedSlots { get; private set; } = 0;
		[field: SerializeField]
		public int SafePocketSlots { get; private set; } = 0;
		[field: SerializeField]
		public int WeightLimit { get; private set; } = 0;
		[SerializeField]
		private ShieldItemDefinition[] shieldCompatibility = Array.Empty<ShieldItemDefinition>();

		public IReadOnlyList<ShieldItemDefinition> ShieldCompatibility => shieldCompatibility;
	}
}