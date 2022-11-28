using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles.Ores
{
	public class CarnalliteOre : ModTile
	{
        public override void SetStaticDefaults()
        {
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileOreFinderPriority[Type] = 320;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 1220;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Carnallite Ore");
			AddMapEntry(new Color(103, 217, 69), name); //110, 150, 98
			DustType = DustType<Dusts.CarnalliteOreDust>();
			ItemDrop = ItemType<Items.Ores.CarnalliteOre>();
			HitSound = SoundID.Tink;
			MineResist = 1f;
			MinPick = 969420;
		}
		public override void PostDraw(int i, int j, SpriteBatch spriteBatch) {
			if (NPC.downedBoss3) MinPick = 40;
			else MinPick = 969420;
		}
		public override bool CanExplode(int i, int j) {
			return NPC.downedBoss3;
		}
	}
	public class CarnalliteOreSystem : ModSystem
	{
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight) {
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1) {
				tasks.Insert(ShiniesIndex + 1, new CarnalliteOrePass("Sprinkling in Zylonian Ores", 237.4298f));
			}
		}
	}

	public class CarnalliteOrePass : GenPass
	{
		public CarnalliteOrePass(string name, float loadWeight) : base(name, loadWeight) {
		}

		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration) {
			progress.Message = "Sprinkling in Zylonian Ores";

			for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 0.0005); k++) {
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY);
				Tile tile = Framing.GetTileSafely(x, y);
				if (tile.TileType == TileID.Mud)
					WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<CarnalliteOre>());
			}
		}
	}
}