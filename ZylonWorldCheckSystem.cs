using Microsoft.Xna.Framework;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Zylon
{
	public class ZylonWorldCheckSystem : ModSystem
	{
		public static bool carnalliteMessage = false;
		public static bool downedJelly = false;
		public static bool downedAdeneb = false;
		public static bool downedDirtball = false;
		public static bool downedMetelord = false;
		public static bool downedSabur = false;
		public override void OnWorldLoad() {
			carnalliteMessage = false;
			downedJelly = false;
			downedAdeneb = false;
			downedDirtball = false;
			downedMetelord = false;
			downedSabur = false;
		}
		public override void OnWorldUnload() {
			carnalliteMessage = false;
			downedJelly = false;
			downedAdeneb = false;
			downedDirtball = false;
			downedMetelord = false;
			downedSabur = false;
		}
		public override void SaveWorldData(TagCompound tag) {
			if (carnalliteMessage) {
				tag["carnalliteMessage"] = true;
			}
			if (downedJelly) {
				tag["downedJelly"] = true;
            }
			if (downedAdeneb) {
				tag["downedAdeneb"] = true;
			}
			if (downedDirtball) {
				tag["downedDirtball"] = true;
			}
			if (downedMetelord) {
				tag["downedMetelord"] = true;
			}
			if (downedSabur) {
				tag["downedSabur"] = true;
			}
		}
		public override void LoadWorldData(TagCompound tag) {
			carnalliteMessage = tag.ContainsKey("carnalliteMessage");
			downedJelly = tag.ContainsKey("downedJelly");
			downedAdeneb = tag.ContainsKey("downedAdeneb");
			downedDirtball = tag.ContainsKey("downedDirtball");
			downedMetelord = tag.ContainsKey("downedMetelord");
			downedSabur = tag.ContainsKey("downedSabur");
		}
		public override void NetSend(BinaryWriter writer) {
			bool[] flags = new bool[] {
				carnalliteMessage,
				downedJelly,
				downedAdeneb,
				downedDirtball,
				downedMetelord,
				downedSabur
			};
			BitArray bitArray = new BitArray(flags);
			byte[] bytes = new byte[(bitArray.Length - 1) / 8 + 1];
			bitArray.CopyTo(bytes, 0);
			writer.Write(bytes.Length);
			writer.Write(bytes);
		}
		public override void NetReceive(BinaryReader reader) {
			int length = reader.ReadInt32();
			byte[] bytes = reader.ReadBytes(length);
			BitArray bitArray = new BitArray(bytes);
			carnalliteMessage = bitArray[0];
			downedJelly = bitArray[1];
			downedAdeneb = bitArray[2];
			downedDirtball = bitArray[3];
			downedMetelord = bitArray[4];
			downedSabur = bitArray[5];
		}
        public override void PostUpdateNPCs() {
            if (NPC.downedQueenBee && !carnalliteMessage) {
				Color messageColor = Color.MediumSpringGreen;
					string chat = "A green light shimmers from the muds of this world!";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
				carnalliteMessage = true;

				for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 0.0004); k++) { //0.0005
					int x = WorldGen.genRand.Next(0, Main.maxTilesX);
					int y = WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, Main.maxTilesY);
					Tile tile = Framing.GetTileSafely(x, y);
					if (tile.TileType == TileID.Mud)
						WorldGen.TileRunner(x, y, WorldGen.genRand.Next(7, 11), WorldGen.genRand.Next(3, 6), ModContent.TileType<Tiles.Ores.CarnalliteOre>());
				}
            }
        }
		public static LocalizedText AbyssworldSpikesPassMessage { get; private set; }
		public static LocalizedText AbyssworldPaintPassMessage { get; private set; }
		public static LocalizedText AutumnPaintPassMessage { get; private set; }
		public override void SetStaticDefaults() {
			AbyssworldSpikesPassMessage = Language.GetOrRegister(Mod.GetLocalizationKey($"WorldGen.{nameof(AbyssworldSpikesPassMessage)}"));
			AbyssworldPaintPassMessage = Language.GetOrRegister(Mod.GetLocalizationKey($"WorldGen.{nameof(AbyssworldPaintPassMessage)}"));
			AutumnPaintPassMessage = Language.GetOrRegister(Mod.GetLocalizationKey($"WorldGen.{nameof(AutumnPaintPassMessage)}"));
		}

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight) {
			int RandomGemsIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Random Gems"));
			if (RandomGemsIndex != -1 && (WorldGen.currentWorldSeed.ToLower() == "abyssworld" || WorldGen.currentWorldSeed.ToLower() == "flopside pit")) {
				tasks.Insert(RandomGemsIndex + 1, new AbyssworldSpikesPass("AbyssworldSpikes", 100f));
			}

			int FinalCleanupIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
			if (FinalCleanupIndex != -1 && (WorldGen.currentWorldSeed.ToLower() == "abyssworld" || WorldGen.currentWorldSeed.ToLower() == "flopside pit")) {
				tasks.Insert(FinalCleanupIndex + 1, new AbyssworldPaintPass("AbyssworldPaint", 100f));
			}
			if (FinalCleanupIndex != -1 && WorldGen.currentWorldSeed.ToLower() == "autumn") {
				tasks.Insert(FinalCleanupIndex + 1, new AutumnPaintPass("AutumnPaint", 100f));
			}
		}
    }
	public class AbyssworldSpikesPass : GenPass
	{
		public AbyssworldSpikesPass(string name, float loadWeight) : base(name, loadWeight) {
		}
		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration) {
			progress.Message = ZylonWorldCheckSystem.AbyssworldSpikesPassMessage.Value;

			//Place spikes around the world
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00003); k++) {
				int x = WorldGen.genRand.Next(0, Main.maxTilesX/2-100);
				int y = WorldGen.genRand.Next((int)0, (int)(Main.worldSurface*0.4f));

				if (Main.tile[x, y].WallType != 0) break;

				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(1, 10), WorldGen.genRand.Next(1, 5), TileID.Spikes, true);
			}
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00003); k++) {
				int x = WorldGen.genRand.Next(Main.maxTilesX/2+100, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)0, (int)(Main.worldSurface*0.4f));

				if (Main.tile[x, y].WallType != 0) break;

				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(1, 10), WorldGen.genRand.Next(1, 5), TileID.Spikes, true);
			}
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 0.0002); k++) {
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)Main.rockLayer, (int)(Main.rockLayer*1.5f));

				if (Main.tile[x, y].TileType == TileID.LihzahrdBrick || Main.tile[x, y].TileType == WallID.LihzahrdBrick || Main.tile[x, y].TileType == WallID.LihzahrdBrickUnsafe) break;

				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(1, 10), WorldGen.genRand.Next(1, 5), TileID.Spikes, true);
			}
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00015); k++) {
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)(Main.rockLayer*1.5f), (int)(Main.rockLayer*2));

				if (Main.tile[x, y].TileType == TileID.LihzahrdBrick || Main.tile[x, y].TileType == WallID.LihzahrdBrick || Main.tile[x, y].TileType == WallID.LihzahrdBrickUnsafe) break;

				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 13), WorldGen.genRand.Next(1, 5), TileID.Spikes, true);
			}
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 0.0001); k++) {
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)(Main.rockLayer*2), Main.maxTilesY-200);

				if (Main.tile[x, y].TileType == TileID.LihzahrdBrick || Main.tile[x, y].TileType == WallID.LihzahrdBrick || Main.tile[x, y].TileType == WallID.LihzahrdBrickUnsafe) break;

				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(7, 15), WorldGen.genRand.Next(1, 5), TileID.Spikes, true);
			}

			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 0.000025); k++) {
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next(Main.maxTilesY-200, Main.maxTilesY);

				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(9, 20), WorldGen.genRand.Next(1, 5), TileID.WoodenSpikes, true);
			}
		}
	}
	public class AbyssworldPaintPass : GenPass
	{
		public AbyssworldPaintPass(string name, float loadWeight) : base(name, loadWeight) {
		}
		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration) {
			progress.Message = ZylonWorldCheckSystem.AbyssworldPaintPassMessage.Value;
			//Paint the tiles to be black
			for (int k = 0; k < 200; k++) {
				for (int j = 0; j < Main.maxTilesX; j++) {
					Tile tile = Main.tile[j, Main.maxTilesY-k];
					if (tile.HasTile) {
						tile.TileColor = 25;
					}
					if (tile.WallType != 0) {
						tile.WallColor = 25;
					}
				}
			}
			//Gradient plz work TwT
			int range = Main.maxTilesY-(int)(Main.rockLayer*1.5f);
			for (int k = 0; k < range; k++) {
				float chance = (float)k/range;
				for (int j = 0; j < Main.maxTilesX; j++) {
					if (Main.rand.NextFloat() > chance) {
						Tile tile = Main.tile[j, Main.maxTilesY-200-k];
						if (tile.HasTile) {
							tile.TileColor = 25;
						}
						if (tile.WallType != 0) {
							tile.WallColor = 25;
						}
					}
				}
			}
		}
	}
	public class AutumnPaintPass : GenPass
	{
		public AutumnPaintPass(string name, float loadWeight) : base(name, loadWeight) {
		}
		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration) {
			progress.Message = ZylonWorldCheckSystem.AutumnPaintPassMessage.Value;
			//Paint the tiles to be autumn
			for (int k = 0; k < Main.maxTilesY; k++) {
				for (int j = 0; j < Main.maxTilesX; j++) { //2 is autumn power
					Tile tile = Main.tile[j, Main.maxTilesY-k];

					if (tile.HasTile) {
						if (tile.TileType == TileID.Grass || tile.TileType == TileID.Trees || (tile.TileType >= 583 && tile.TileType <= 590) || tile.TileType == TileID.AshGrass || tile.TileType == TileID.CorruptGrass || tile.TileType == TileID.CorruptJungleGrass || tile.TileType == TileID.CrimsonGrass || tile.TileType == TileID.CrimsonGrass || tile.TileType == TileID.CrimsonJungleGrass || tile.TileType == TileID.JungleGrass || tile.TileType == TileID.MushroomGrass || tile.TileType == TileID.JunglePlants || tile.TileType == TileID.JunglePlants2 || tile.TileType == TileID.JungleThorns || tile.TileType == TileID.JungleVines || tile.TileType == TileID.VineFlowers || tile.TileType == TileID.Vines || tile.TileType == TileID.AshVines || tile.TileType == TileID.CorruptVines || tile.TileType == TileID.CrimsonVines || tile.TileType == TileID.HallowedVines || tile.TileType == TileID.MushroomVines || tile.TileType == TileID.MushroomPlants || tile.TileType == TileID.MushroomTrees || tile.TileType == TileID.BlueDungeonBrick || tile.TileType == TileID.CrackedBlueDungeonBrick || tile.TileType == TileID.CrackedGreenDungeonBrick || tile.TileType == TileID.CrackedPinkDungeonBrick || tile.TileType == TileID.GreenDungeonBrick || tile.TileType == TileID.PinkDungeonBrick || tile.TileType == TileID.LivingMahoganyLeaves || tile.TileType == 192 || tile.TileType == TileID.VanityTreeSakura || tile.TileType == TileID.VanityTreeSakuraSaplings || tile.TileType == TileID.VanityTreeWillowSaplings || tile.TileType == TileID.VanityTreeYellowWillow || tile.TileType == 3 || tile.TileType == 20 || tile.TileType == 23 || tile.TileType == 24 || tile.TileType == 27 || tile.TileType == 32 || tile.TileType == TileID.Plants || tile.TileType == TileID.Plants2 || tile.TileType == TileID.HallowedPlants2 || tile.TileType == TileID.JunglePlants2 || tile.TileType == TileID.BloomingHerbs || tile.TileType == TileID.ImmatureHerbs || tile.TileType == TileID.MatureHerbs || tile.TileType == TileID.PineTree || tile.TileType == TileID.ChristmasTree || tile.TileType == 185 || tile.TileType == 187 || tile.TileType == 227 || tile.TileType == 233 || tile.TileType == 236 || tile.TileType == 238 || tile.TileType == 304 || tile.TileType == TileID.VineRope || tile.TileType == TileID.VineFlowers || tile.TileType == TileID.GolfGrass || tile.TileType == TileID.GolfGrassHallowed || tile.TileType == TileID.FallenLog || tile.TileType == TileID.LilyPad || tile.TileType == TileID.Cattail || tile.TileType == TileID.SeaOats || tile.TileType == TileID.OasisPlants || tile.TileType == TileID.PottedPlants1 || tile.TileType == TileID.PottedPlants2 || tile.TileType == 590 || tile.TileType == 591 || tile.TileType == 597 || tile.TileType == TileID.LargePiles2Echo || tile.TileType == TileID.SmallPiles2x1Echo || tile.TileType == TileID.SmallPiles1x1Echo || tile.TileType == TileID.PlantDetritus2x2Echo || tile.TileType == TileID.PlantDetritus3x2Echo || tile.TileType == TileID.LivingWood || tile.TileType == TileID.LivingMahogany || tile.TileType == TileID.LivingLoom)
						tile.TileColor = PaintID.DeepOrangePaint;
					}
					if (tile.WallType != 0) {
						if (tile.WallType == WallID.LivingLeaf || tile.WallType == WallID.BlueDungeon || tile.WallType == WallID.BlueDungeonSlab || tile.WallType == WallID.BlueDungeonSlabUnsafe || tile.WallType == WallID.BlueDungeonTile || tile.WallType == WallID.BlueDungeonTileUnsafe || tile.WallType == WallID.BlueDungeonUnsafe || tile.WallType == WallID.GreenDungeon || tile.WallType == WallID.GreenDungeonSlab || tile.WallType == WallID.GreenDungeonSlabUnsafe || tile.WallType == WallID.GreenDungeonTile || tile.WallType == WallID.GreenDungeonTileUnsafe || tile.WallType == WallID.GreenDungeonUnsafe || tile.WallType == WallID.PinkDungeon || tile.WallType == WallID.PinkDungeonSlab || tile.WallType == WallID.PinkDungeonSlabUnsafe || tile.WallType == WallID.PinkDungeonTile || tile.WallType == WallID.PinkDungeonTileUnsafe || tile.WallType == WallID.PinkDungeonUnsafe || tile.WallType == WallID.GrassUnsafe || tile.WallType == WallID.JungleUnsafe || tile.WallType == WallID.FlowerUnsafe || tile.WallType == WallID.Grass || tile.WallType == WallID.Jungle || tile.WallType == WallID.Flower || tile.WallType == WallID.CorruptGrassUnsafe || tile.WallType == WallID.HallowedGrassUnsafe || tile.WallType == WallID.MushroomUnsafe || tile.WallType == WallID.JungleUnsafe1 || tile.WallType == WallID.JungleUnsafe2 || tile.WallType == WallID.JungleUnsafe3 || tile.WallType == WallID.JungleUnsafe4 || tile.WallType == WallID.CorruptGrassEcho || tile.WallType == WallID.HallowedGrassEcho || tile.WallType == WallID.CrimsonGrassEcho || tile.WallType == WallID.Jungle1Echo || tile.WallType == WallID.Jungle2Echo || tile.WallType == WallID.Jungle3Echo || tile.WallType == WallID.Jungle4Echo)
						tile.WallColor = PaintID.DeepOrangePaint;
					}
				}
			}
		}
	}
}