using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Prefixes
{
	public class Balanced : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Accessory;
		public override float RollChance(Item item) {
			return 0.8f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void ApplyAccessoryEffects(Player player) {
            player.GetDamage(DamageClass.Generic) += 0.02f;
			player.statDefense += 2;
        }
        public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
            yield return new TooltipLine(Mod, "PrefixDamage", "+2% damage") {
				IsModifier = true,
			};
			yield return new TooltipLine(Mod, "PrefixDefense", "+2 defense") {
				IsModifier = true,
			};
        }
		public override void ModifyValue(ref float valueMult) {
            valueMult *= 1.2f;
        }
        public override void Apply(Item item) {
			
		}
	}
	public class Costly : ModPrefix //They better not be using luiafk
	{
		public override PrefixCategory Category => PrefixCategory.Accessory;
		public override float RollChance(Item item) {
			return 0.8f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void ApplyAccessoryEffects(Player player) {
            player.GetDamage(DamageClass.Magic) += 0.06f;
			player.manaCost += 0.09f;
        }
        public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
            yield return new TooltipLine(Mod, "PrefixDamage", "+6% magic damage") {
				IsModifier = true,
			};
			yield return new TooltipLine(Mod, "PrefixManaCost", "+9% mana cost") {
				IsModifier = true,
				IsModifierBad = true,
			};
        }
        public override void ModifyValue(ref float valueMult) {
            valueMult *= 1.13f;
        }
        public override void Apply(Item item) {
			
		}
	}
	public class Safe : ModPrefix //I wanted to put Absolutely Safe :(
	{
		public override PrefixCategory Category => PrefixCategory.Accessory;
		public override float RollChance(Item item) {
			return 0.6f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void ApplyAccessoryEffects(Player player) {
            player.GetDamage(DamageClass.Generic) -= 0.02f;
			player.statDefense += 6;
        }
        public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
            yield return new TooltipLine(Mod, "PrefixDefense", "+6 defense") {
				IsModifier = true,
			};
			yield return new TooltipLine(Mod, "PrefixDamage", "-2% damage") {
				IsModifier = true,
				IsModifierBad = true,
			};
        }
		public override void ModifyValue(ref float valueMult) {
            valueMult *= 1.1f;
        }
        public override void Apply(Item item) {
			
		}
	}
	public class Plentiful : ModPrefix //Please don't be broken
	{
		public override PrefixCategory Category => PrefixCategory.Accessory;
		public override float RollChance(Item item) {
			return 0.5f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void ApplyAccessoryEffects(Player player) {
            player.GetDamage(DamageClass.Generic) -= 0.15f;
			player.maxMinions += 1;
        }
        public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
            yield return new TooltipLine(Mod, "PrefixMaxMinions", "+1 max minions") {
				IsModifier = true,
			};
			yield return new TooltipLine(Mod, "PrefixDamage", "-15% damage") {
				IsModifier = true,
				IsModifierBad = true,
			};
        }
		public override void ModifyValue(ref float valueMult) {
            valueMult *= 1.115f;
        }
        public override void Apply(Item item) {
			
		}
	}
	public class Awakened : ModPrefix //How long is too long?
	{
		public override PrefixCategory Category => PrefixCategory.Accessory;
		public override float RollChance(Item item) {
			return 0.5f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void ApplyAccessoryEffects(Player player) {
            player.GetDamage(DamageClass.Generic) += 0.01f;
			player.GetCritChance(DamageClass.Generic) += 1;
			player.statLifeMax2 += 5;
			player.statDefense += 1;
        }
        public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
			yield return new TooltipLine(Mod, "PrefixDamage", "+1% damage") {
				IsModifier = true,
			};
			yield return new TooltipLine(Mod, "PrefixDefense", "+1 defense") {
				IsModifier = true,
			};
			yield return new TooltipLine(Mod, "PrefixCrit", "+1% critical strike chance") {
				IsModifier = true,
			};
			yield return new TooltipLine(Mod, "PrefixLife", "+5 max life") {
				IsModifier = true,
			};
        }
		public override void ModifyValue(ref float valueMult) {
            valueMult *= 1.225f;
        }
        public override void Apply(Item item) {
			
		}
	}
	public class Animated : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Accessory;
		public override float RollChance(Item item) {
			return 0.9f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void ApplyAccessoryEffects(Player player) {
            player.statLifeMax2 += 5;
        }
        public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
			yield return new TooltipLine(Mod, "PrefixLife", "+5 max life") {
				IsModifier = true,
			};
        }
		public override void ModifyValue(ref float valueMult) {
            valueMult *= 1.05f;
        }
        public override void Apply(Item item) {
			
		}
	}
	public class Lively : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Accessory;
		public override float RollChance(Item item) {
			return 0.8f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void ApplyAccessoryEffects(Player player) {
            player.statLifeMax2 += 10;
        }
        public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
			yield return new TooltipLine(Mod, "PrefixLife", "+10 max life") {
				IsModifier = true,
			};
        }
		public override void ModifyValue(ref float valueMult) {
            valueMult *= 1.1f;
        }
        public override void Apply(Item item) {
			
		}
	}
	public class Healthy : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Accessory;
		public override float RollChance(Item item) {
			return 0.7f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void ApplyAccessoryEffects(Player player) {
            player.statLifeMax2 += 15;
        }
        public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
			yield return new TooltipLine(Mod, "PrefixLife", "+15 max life") {
				IsModifier = true,
			};
        }
		public override void ModifyValue(ref float valueMult) {
            valueMult *= 1.15f;
        }
        public override void Apply(Item item) {
			
		}
	}
	public class Robust : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Accessory;
		public override float RollChance(Item item) {
			return 0.6f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void ApplyAccessoryEffects(Player player) {
            player.statLifeMax2 += 20;
        }
        public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
			yield return new TooltipLine(Mod, "PrefixLife", "+20 max life") {
				IsModifier = true,
			};
        }
		public override void ModifyValue(ref float valueMult) {
            valueMult *= 1.2f;
        }
        public override void Apply(Item item) {
			
		}
	}
	public class Preservative : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Accessory;
		public override float RollChance(Item item) {
			return 0.75f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void ApplyAccessoryEffects(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
            p.numof10ammo += 1;
        }
        public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
			yield return new TooltipLine(Mod, "PrefixAmmo", "+10% chance not to consume ammo") {
				IsModifier = true,
			};
        }
		public override void ModifyValue(ref float valueMult) {
            valueMult *= 1.125f;
        }
        public override void Apply(Item item) {
			
		}
	}
	public class Risky : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Accessory;
		public override float RollChance(Item item) {
			return 0.6f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void ApplyAccessoryEffects(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
            p.damageVariation += 0.2f;
        }
        public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
			yield return new TooltipLine(Mod, "PrefixDamageVariation", "+20% damage variation") {
				IsModifier = true,
			};
        }
		public override void ModifyValue(ref float valueMult) {
            valueMult *= 1.0875f;
        }
        public override void Apply(Item item) {
			
		}
	}
	public class Heavy : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Accessory;
		public override float RollChance(Item item) {
			return 0.65f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void ApplyAccessoryEffects(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
            p.critExtraDmg += 0.05f;
        }
        public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
			yield return new TooltipLine(Mod, "PrefixCritDamage", "+5% critical strike damage") {
				IsModifier = true,
			};
        }
		public override void ModifyValue(ref float valueMult) {
            valueMult *= 1.125f;
        }
        public override void Apply(Item item) {
			
		}
	}
}