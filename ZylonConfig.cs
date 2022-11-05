using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Zylon
{
	public class ZylonConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Header("General (reload may be required)")]

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
	}
}