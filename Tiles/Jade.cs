using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles
{
	public class Jade : ModTile
	{
        public override void SetStaticDefaults()
        {
			TileID.Sets.Ore[Type] = false;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileStone[Type] = true;
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Jade");
			AddMapEntry(new Color(123, 209, 88), name);
			DustType = DustType<Dusts.JadeOreDust>();
			RegisterItemDrop(ItemType<Items.Materials.Jade>());
			HitSound = SoundID.Tink;
			MineResist = 1f;
			MinPick = 0;
		}
		public override bool CanExplode(int i, int j) {
			return true;
		}

		

	}
	public class JadeGenSystem : ModSystem
	{
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight) {
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1) {
				tasks.Insert(ShiniesIndex + 1, new JadeGenPass("Sprinkling in Zylonian Gems", 237.4298f));
			}
		}
	}

	public class JadeGenPass : GenPass
	{
		public JadeGenPass(string name, float loadWeight) : base(name, loadWeight) {
		}

		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration) {
			progress.Message = "Sprinkling in Zylonian Gems";

			for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 0.000125); k++) {
				int x = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
				int y = WorldGen.genRand.Next((int)GenVars.rockLayer, Main.maxTilesY - 300);
				Tile tile = Framing.GetTileSafely(x, y);
				if (tile.TileType == TileID.Stone)
					WorldGen.TileRunner(x, y, WorldGen.genRand.Next(2, 5), WorldGen.genRand.Next(2, 5), TileType<Jade>());
			}
		}
	}
}