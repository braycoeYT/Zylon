using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Zylon
{
	public class ZylonConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Header("config.general")]

		[Label("Advanced Blowpipe Display")]
		[Tooltip("Replaces the usage instructions in blowpipe tooltips with even more stats!")]
		public bool advBlowpipe;

		[DefaultValue(true)]
		[Label("Zylonian Prefixes")]
		[Tooltip("Allows for custom prefixes.")]
		public bool zylonianPrefixes;

		[DefaultValue(true)]
		[Label("Zylonian Balancing")]
		[Tooltip("Rebalances a lot of vanilla content.")]
		public bool zylonianBalancing;

		[DefaultValue(true)]
		[Label("Band Buffs")]
		[Tooltip("Bands (such as the Band of Regeneration) now buff certain potions.")]
		public bool bandBuffs;

		[Label("Dirt Ammo Compatibility Fixer")]
		[Tooltip("Keep this disabled unless a mod uses dirt blocks as ammo and is having major issues. Enabling this will disable the Dirtthrower.")]
		public bool dirtAmmoFix;

		[Range(1f, 10f)]
		[DefaultValue(1f)]
		[Slider]
		[Label("Boss HP Multiplier")]
		[Tooltip("Allows you to multiply the health of the mod's bosses for increased difficulty. To be used with the similar config from Calamity.")]
		public float bossHpMult;

		[DefaultValue(true)]
		[Label("April Fools Day Changes")]
		[Tooltip("Allows the mod to go absolutely wacky on that fateful day.")]
		public bool aprilFoolsChanges;

		[DefaultValue(true)]
		[Label("Blowpipe Max Charge Noise")]
		[Tooltip("Plays a short noise when blowpipes reach max charge.")]
		public bool blowpipeNoise;

		[Label("Experimental Boomerangs")]
		[Tooltip("Allows some boomerangs to have special AI.")]
		public bool experimentalBoomerangs;

		[DefaultValue(true)]
		[Label("Boomerang Custom Camera Movement")]
		[Tooltip("Allows certain boomerangs to move the camera when used (for experimental boomerangs).")]
		public bool boomerangCamera;

		[DefaultValue(true)]
		[Label("Summon Natural Crits")]
		[Tooltip("Summons now have a 4% default crit chance, and are affected by generic crit boosts.")]
		public bool summonNaturalCrit;

		[Label("Experimental World Gen")]
		[Tooltip("You probably should leave this off.")]
		public bool experimentalWorldgen;

		[Header("config.accessories")]

		[Range(0f, 1f)]
		[Increment(0.025f)]
		[DefaultValue(0.15f)]
		[Slider]
		[Label("[i:Zylon/CosmicDie]Cosmic Die: Damage Variation")]
		[Tooltip("Controls the player's damage variation while holding the Cosmic Die.")]
		public float cosmicDieVariation;

		[Label("[i:Zylon/IllusoryBulletPolish]Illusory Bullet Polish: Enemy Bounce")]
		[Tooltip("Prevents bullets from bouncing on enemies, which may be more optimal for some weapons.")]
		public bool illusoryPolishNoEnemy;

		[Header("config.accessibility")]

		[Range(0, 100)]
		[Increment(1)]
		[DefaultValue(100)]
		[Slider]
		[Label("Screenshake Amount")]
		[Tooltip("Changes the amount of all screenshake in the mod. Reccomended for people who have trouble with it.")]
		public int ScreenshakeAccessibilityMulti;

		[Label("Night Light / Tritanopic Rarity Support")]
		[Tooltip("Changes the color of modded rarities so that tritanopics or users of night light can differentiate them easier.")]
		public bool nightLightRarities;
	}
}