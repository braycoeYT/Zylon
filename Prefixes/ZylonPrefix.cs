using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Prefixes
{
	public class Critical : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.AnyWeapon;
		public override float RollChance(Item item) {
			return 3f;
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
			return 0.5f;
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
			return 2.5f;
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
	public class Beloved : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.AnyWeapon;
		public override float RollChance(Item item) {
			return 3f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			knockbackMult *= 1.15f;
			useTimeMult *= 0.9f;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Crazy : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Ranged;
		public override float RollChance(Item item) {
			return 3f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult *= 0.8f;
			useTimeMult *= 0.8f;
			shootSpeedMult *= 1.25f;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Proud : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.AnyWeapon;
		public override float RollChance(Item item) {
			return 2.5f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult *= 1.15f;
			knockbackMult *= 1.25f;
			useTimeMult *= 1.05f;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Standard : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.AnyWeapon;
		public override float RollChance(Item item) {
			return 4f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult *= 1.03f;
			knockbackMult *= 1.03f;
			useTimeMult *= 0.97f;
			critBonus += 3;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Cheap : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Magic;
		public override float RollChance(Item item) {
			return 3f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			manaMult *= 0.75f;
			damageMult *= 0.75f;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Supernatural : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Magic;
		public override float RollChance(Item item) {
			return 3f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			manaMult *= 0.9f;
			damageMult *= 1.08f;
			useTimeMult *= 0.95f;
			critBonus += 1;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Fatal : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.AnyWeapon;
		public override float RollChance(Item item) {
			return 1.5f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult *= 1.2f;
			knockbackMult *= 1.15f;
			useTimeMult *= 1.15f;
			critBonus += 4;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Charged : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Ranged;
		public override float RollChance(Item item) {
			return 2.5f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult *= 0.95f;
			useTimeMult *= 0.95f;
			shootSpeedMult *= 1.3f;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Gigantic : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Melee;
		public override float RollChance(Item item) {
			return 2.5f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			scaleMult *= 1.3f;
			useTimeMult *= 1.20f;
			damageMult *= 1.15f;
			knockbackMult *= 1.1f;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Irate : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Melee;
		public override float RollChance(Item item) {
			return 2.5f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			scaleMult *= 0.9f;
			damageMult *= 1.15f;
			knockbackMult *= 1.1f;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Epic : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.AnyWeapon;
		public override float RollChance(Item item) {
			return 1.75f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult *= 1.1f;
			knockbackMult *= 1.1f;
			critBonus += 10;
		}
        public override void Apply(Item item) {
			
		}
	}
}