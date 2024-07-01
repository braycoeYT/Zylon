using System.Runtime.CompilerServices;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Items.Bows;
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
			damageMult *= 1.13f;
            knockbackMult *= 1.1f;
			useTimeMult *= 0.9f;
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
			damageMult *= 0.96f;
			useTimeMult *= 0.95f;
			shootSpeedMult *= 1.4f;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Relaxed : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.Ranged;
		public override float RollChance(Item item) {
			return 2f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult *= 1.08f;
			useTimeMult *= 0.95f;
			shootSpeedMult *= 0.7f;
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
	public class Exalted : ModPrefix //Best summoner prefix
	{
		public override PrefixCategory Category => PrefixCategory.AnyWeapon;
		public override float RollChance(Item item) {
			return 1.5f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes && item.DamageType == DamageClass.Summon;
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
	public class Fabled : ModPrefix //Legendary prefix but for weapons unable to get size modifier
	{
		public override PrefixCategory Category => PrefixCategory.AnyWeapon;
		public override float RollChance(Item item) {
			return 1.5f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes && (item.DamageType == DamageClass.Melee || item.DamageType == DamageClass.MeleeNoSpeed) && item.noUseGraphic;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult *= 1.15f;
			useTimeMult *= 0.9f;
			critBonus += 5;
			knockbackMult *= 1.15f;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Pushy : ModPrefix
	{
		public override PrefixCategory Category => PrefixCategory.AnyWeapon;
		public override float RollChance(Item item) {
			return 1.5f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			knockbackMult = 1.23f;
		}
        public override void Apply(Item item) {
			
		}
	}
	public class Aerobic : ModPrefix //Blowpipes can't receive Unreal, so here is an equivalent.
	{
		public override PrefixCategory Category => PrefixCategory.Ranged;
		public override float RollChance(Item item) {
			return 1.5f;
		}
		public override bool CanRoll(Item item) {
			return GetInstance<ZylonConfig>().zylonianPrefixes && item.useAmmo == AmmoID.Dart;
		}
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult = 1.16f;
			knockbackMult = 1.15f;
			shootSpeedMult = 1.12f;
			critBonus = 7;
		}
        public override void Apply(Item item) {
			
		}
	}
}