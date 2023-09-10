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
		[Tooltip("Rebalances a lot of the vanilla content.")]
		public bool zylonianBalancing;

		[DefaultValue(true)]
		[Label("Band Buffs")]
		[Tooltip("Bands (such as the Band of Regeneration) now buff certain potions.")]
		public bool bandBuffs;

		[Label("Dirt Ammo Compatibility Fixer")]
		[Tooltip("Keep this disabled unless a mod uses dirt blocks as ammo and is having major issues. Enabling this will disable the Dirtthrower.")]
		public bool dirtAmmoFix;

		//[DefaultValue(true)]
		//[Label("Infinite Boss Summons")]
		//[Tooltip("Makes the mod's boss summons infinite.")]
		//public bool infBossSum;

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

		[Header("config.accessibility")]

		[Range(0, 100)]
		[Increment(1)]
		[DefaultValue(100)]
		[Slider]
		[Label("Screenshake Amount")]
		[Tooltip("Changes the amount of all screenshake in the mod. Reccomended for people who have trouble with it.")]
		public int ScreenshakeAccessibilityMulti;
	}
}