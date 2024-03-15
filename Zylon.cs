using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon
{
	public class Zylon : Mod
	{
		//Future rarities for PML use. Ignore this since most of this doesn't exist yet. Use this as reference for item rarities when we start PML.

		//Tier 12 - All PML banners and trophies. All items that are post PML miniboss, Sabur, and Mineral.
		//Powerful/tedious items obtained after Moonlord but before any PML bosses. Summons for tier 13 bosses.
		public static readonly Color Magenta = new Color(255, 0, 255);

		//Tier 13 - All items post ToC, Quetzalcoatl, ???, and ???. All items obtained in the Cellspawn after ToC has been defeated.
        public static readonly Color ForestGreen = new Color(11, 102, 35);

		public static bool hasFoughtSabur;
    }
}