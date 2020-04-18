using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles
{
	public class OblivionTree : ModTree
	{
		private Mod mod => ModLoader.GetMod("Zylon");

		public override int DropWood()
		{
			return ItemType<Items.Blocks.OblivionWood>();
		}

		public override Texture2D GetTexture()
		{
			return mod.GetTexture("Tiles/OblivionTree");
		}

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
		{
			return mod.GetTexture("Tiles/OblivionTree_Tops");
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
		{
			return mod.GetTexture("Tiles/OblivionTree_Branches");
		}
	}
} 