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
			2 => ModContent.RarityType<ForestGreen>(),
			_ => Type,
		};
	}
	public class Magenta : ModRarity
	{
		//Tier 12 - All PML banners and trophies. All items that are post PML miniboss, Sabur, and Mineral.
		//Powerful/tedious items obtained after Moonlord but before any PML bosses. Summons for tier 13 bosses.
		public override Color RarityColor => new Color(255, 0, 255);
		public override int GetPrefixedRarity(int offset, float valueMult) => offset switch {
			-2 => ItemRarityID.Red,
			-1 => ItemRarityID.Purple,
			1 => ModContent.RarityType<ForestGreen>(),
			2 => ModContent.RarityType<ForestGreen>(),
			_ => Type,
		};
	}
	public class ForestGreen : ModRarity
	{
		//Tier 13 - All items post ToC, Quetzalcoatl, ???, and ???. All items obtained in the Cellspawn after ToC has been defeated.
		public override Color RarityColor => new Color(16, 145, 50);
		public override int GetPrefixedRarity(int offset, float valueMult) => offset switch {
			-2 => ItemRarityID.Purple,
			-1 => ModContent.RarityType<Magenta>(),
			1 => ModContent.RarityType<ForestGreen>(),
			2 => ModContent.RarityType<ForestGreen>(),
			_ => Type,
		};
	}
}