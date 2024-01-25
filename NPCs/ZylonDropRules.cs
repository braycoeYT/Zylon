﻿using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;

namespace Zylon.NPCs
{
    public class ElemGelCondition : IItemDropRuleCondition
	{
		private static LocalizedText Description;

		public ElemGelCondition() {
			Description ??= Language.GetOrRegister("Mods.Zylon.DropConditions.ElemGelCondition");
		}

		public bool CanDrop(DropAttemptInfo info) {
			return NPC.downedPlantBoss;
		}

		public bool CanShowItemDropInUI() {
			return true;
		}

		public string GetConditionDescription() {
			return Description.Value;
		}
	}
}