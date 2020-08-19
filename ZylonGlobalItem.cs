using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles
{
	public class ZylonGlobalItem : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.PoisonDart)
				item.damage = 4;
			if (item.type == ItemID.Blowpipe)
				item.damage = 10;
			if (item.type == ItemID.Blowgun)
				item.damage = 34;
		}
	}
}