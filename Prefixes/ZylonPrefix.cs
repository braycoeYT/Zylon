using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Prefixes
{
	public class Critical : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.AnyWeapon;
		public override float RollChance(Item item) {
			return 2.25f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			critBonus += 10;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Ultimate : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.AnyWeapon;
		public override float RollChance(Item item) {
			return 1f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult *= 1.16f;
            knockbackMult *= 1.08f;
			useTimeMult *= 0.90f;
            critBonus += 8;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Atomic : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Melee;
		public override float RollChance(Item item) {
			return 2f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			scaleMult *= 0.75f;
			useTimeMult *= 0.8f;
			knockbackMult *= 0.8f;
			damageMult *= 0.85f;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Unhesitating : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Ranged;
		public override float RollChance(Item item) {
			return 2.5f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult *= 0.92f;
			useTimeMult *= 0.95f;
			shootSpeedMult *= 1.4f;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Cheap : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Magic;
		public override float RollChance(Item item) {
			return 2f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes && item.DamageType != DamageClass.Summon;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			manaMult *= 0.7f;
			damageMult *= 0.75f;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Supernatural : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Magic;
		public override float RollChance(Item item) {
			return 2f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes && item.DamageType != DamageClass.Summon;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			manaMult *= 1.4f;
			damageMult *= 1.3f;
			useTimeMult *= 1.08f;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Gigantic : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Melee;
		public override float RollChance(Item item) {
			return 2f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			scaleMult *= 1.35f;
			useTimeMult *= 1.3f;
			damageMult *= 1.15f;
			knockbackMult *= 1.1f;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Exalted : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.AnyWeapon;
		public override float RollChance(Item item) {
			return 1.5f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes && item.DamageType == DamageClass.Summon; //Is this how summon-only prefixes work?
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult *= 1.19f;
			knockbackMult *= 1.25f;
			useTimeMult *= 0.5f;
			shootSpeedMult *= 0.9f;
		}
        public override void Apply(Item item) {
			
		}
	}
}