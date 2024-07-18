using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon
{
	public class BraycoeDev : ModRarity
	{
		//For my dev items and eventually vanity when I learn how to sprite.
		public override Color RarityColor => new Color(116, 179, 237);
		public override int GetPrefixedRarity(int offset, float valueMult) => offset switch {
			_ => Type,
		};
	}
	public class HBDeusDev : ModRarity
	{
		//For HBDeus's sword and the other swords I haven't added yet.
		public override Color RarityColor => new Color(224, 153, 0);
		public override int GetPrefixedRarity(int offset, float valueMult) => offset switch {
			_ => Type,
		};
	}
	public class ExcalipoorRarity : ModRarity
	{
		//Epic sword.
		public override Color RarityColor => new Color(Main.DiscoG, Main.DiscoG, Main.DiscoG);
		public override int GetPrefixedRarity(int offset, float valueMult) => offset switch {
			_ => Type,
		};
	}
	public class RedModded : ModRarity
	{
		//Modified version of vanilla's red rarity so that it goes into modded pml rarities.
		public override Color RarityColor => new Color(225, 6, 67);
		public override int GetPrefixedRarity(int offset, float valueMult) => offset switch {
			-2 => ItemRarityID.Yellow,
			-1 => ItemRarityID.Cyan,
			1 => ItemRarityID.Purple,
			2 => ModContent.RarityType<Magenta>(),
			_ => Type,
		};
	}
	public class PurpleModded : ModRarity
	{
		//Modified version of vanilla's purple rarity so that it goes into modded pml rarities.
		public override Color RarityColor => new Color(178, 39, 253);
		public override int GetPrefixedRarity(int offset, float valueMult) => offset switch {
			-2 => ItemRarityID.Cyan,
			-1 => ItemRarityID.Red,
			1 => ModContent.RarityType<Magenta>(),
			2 => ModContent.RarityType<Emerald>(),
			_ => Type,
		};
	}
	public class Magenta : ModRarity
	{
		//Tier 12 - All PML banners, masks, and trophies. All items that are post PML miniboss, Sabur, and Mineral.
		//Powerful/tedious items obtained after Moonlord but before any PML bosses. Summons for tier 13 bosses.
		//Color is based on ZME.
		public override Color RarityColor => new Color(255, 200*ModContent.GetInstance<ZylonConfig>().nightLightRarities.ToInt(), 255-(55*ModContent.GetInstance<ZylonConfig>().nightLightRarities.ToInt()));
		public override int GetPrefixedRarity(int offset, float valueMult) => offset switch {
			-2 => ItemRarityID.Red,
			-1 => ItemRarityID.Purple,
			1 => ModContent.RarityType<Emerald>(),
			2 => ModContent.RarityType<Emerald>(),
			_ => Type,
		};
	}
	public class Emerald : ModRarity
	{
		//Tier 13 - All items post ToC, Quet, Loc, and ???. All items obtained in the Cellspawn after ToC has been defeated.
		//Materals from the AB are this rarity despite being obtainable before ZME.
		//Color used to be based on ToC, but is now based on Loc and Quet.
		public override Color RarityColor => new Color(19, 191, 64); //16, 145, 50
		public override int GetPrefixedRarity(int offset, float valueMult) => offset switch {
			-2 => ItemRarityID.Purple,
			-1 => ModContent.RarityType<Magenta>(),
			1 => ModContent.RarityType<Emerald>(),
			2 => ModContent.RarityType<Emerald>(),
			_ => Type,
		};
	}
}