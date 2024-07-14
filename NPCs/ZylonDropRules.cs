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
	public class DownedDirtballCondition : IItemDropRuleCondition
	{
		private static LocalizedText Description;

		public DownedDirtballCondition() {
			Description ??= Language.GetOrRegister("Mods.Zylon.DropConditions.DownedDirtballCondition");
		}

		public bool CanDrop(DropAttemptInfo info) {
			return ZylonWorldCheckSystem.downedDirtball;
		}

		public bool CanShowItemDropInUI() {
			return true;
		}

		public string GetConditionDescription() {
			return Description.Value;
		}
	}
	public class AutumnCondition : IItemDropRuleCondition
	{
		private static LocalizedText Description;

		public AutumnCondition() {
			Description ??= Language.GetOrRegister("Mods.Zylon.DropConditions.AutumnCondition");
		}

		public bool CanDrop(DropAttemptInfo info) {
			return ZylonWorldCheckSystem.downedDirtball;
		}

		public bool CanShowItemDropInUI() {
			return true;
		}

		public string GetConditionDescription() {
			return Description.Value;
		}
	}
}