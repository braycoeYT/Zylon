using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles
{
	public class ZylonGlobalTile : GlobalTile
	{
		/*public override bool Drop(int i, int j, int type) {
			if (type == TileID.Stalactite)
			{ 
				Vector2 dropPos;
				dropPos.X = i*16;
				dropPos.Y = j*16;
				Framing.GetTileSafely(i, j);
				if (Main.tile[(int)dropPos.X, (int)dropPos.Y].type == TileID.Containers && Main.tile[(int)dropPos.X, (int)dropPos.Y].frameX == 0 * 36)
				Item.NewItem(dropPos, 16, 16, mod.ItemType("IcySeedshot"), 0 + Main.rand.Next(3));
				if (Main.tile[(int)dropPos.X, (int)dropPos.Y].type == TileID.Containers && Main.tile[(int)dropPos.X, (int)dropPos.Y].frameX == 1 * 36)
				Item.NewItem(dropPos, 16, 16, mod.ItemType("IcySeedshot"), 0 + Main.rand.Next(3));
				if (Main.tile[(int)dropPos.X, (int)dropPos.Y].type == TileID.Containers && Main.tile[(int)dropPos.X, (int)dropPos.Y].frameX == 2 * 36)
				Item.NewItem(dropPos, 16, 16, mod.ItemType("IcySeedshot"), 0 + Main.rand.Next(3));
			}
			return true;
		}*/
	}
}