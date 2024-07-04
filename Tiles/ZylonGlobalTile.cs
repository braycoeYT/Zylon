using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles
{
	public class ZylonGlobalTile : GlobalTile
	{
        public override void PlaceInWorld(int i, int j, int type, Item item) {
            if (WorldGen.currentWorldSeed.ToLower() == "autumn") if (type == TileID.Grass || type == TileID.Trees || (type >= 583 && type <= 590) || type == TileID.AshGrass || type == TileID.CorruptGrass || type == TileID.CorruptJungleGrass || type == TileID.CrimsonGrass || type == TileID.CrimsonGrass || type == TileID.CrimsonJungleGrass || type == TileID.JungleGrass || type == TileID.MushroomGrass || type == TileID.JunglePlants || type == TileID.JunglePlants2 || type == TileID.JungleThorns || type == TileID.JungleVines || type == TileID.VineFlowers || type == TileID.Vines || type == TileID.AshVines || type == TileID.CorruptVines || type == TileID.CrimsonVines || type == TileID.HallowedVines || type == TileID.MushroomVines || type == TileID.MushroomPlants || type == TileID.MushroomTrees || type == TileID.BlueDungeonBrick || type == TileID.CrackedBlueDungeonBrick || type == TileID.CrackedGreenDungeonBrick || type == TileID.CrackedPinkDungeonBrick || type == TileID.GreenDungeonBrick || type == TileID.PinkDungeonBrick || type == TileID.LivingMahoganyLeaves || type == 192 || type == TileID.VanityTreeSakura || type == TileID.VanityTreeSakuraSaplings || type == TileID.VanityTreeWillowSaplings || type == TileID.VanityTreeYellowWillow || type == 3 || type == 20 || type == 23 || type == 24 || type == 27 || type == 32 || type == TileID.Plants || type == TileID.Plants2 || type == TileID.HallowedPlants2 || type == TileID.JunglePlants2 || type == TileID.BloomingHerbs || type == TileID.ImmatureHerbs || type == TileID.MatureHerbs || type == TileID.PineTree || type == TileID.ChristmasTree || type == 185 || type == 187 || type == 227 || type == 233 || type == 236 || type == 238 || type == 304 || type == TileID.VineRope || type == TileID.VineFlowers || type == TileID.GolfGrass || type == TileID.GolfGrassHallowed || type == TileID.FallenLog || type == TileID.LilyPad || type == TileID.Cattail || type == TileID.SeaOats || type == TileID.OasisPlants || type == TileID.PottedPlants1 || type == TileID.PottedPlants2 || type == 590 || type == 591 || type == 597 || type == TileID.LargePiles2Echo || type == TileID.SmallPiles2x1Echo || type == TileID.SmallPiles1x1Echo || type == TileID.PlantDetritus2x2Echo || type == TileID.PlantDetritus3x2Echo) {
                Tile tile = Main.tile[i, j];
                tile.TileColor = PaintID.DeepOrangePaint;
            }
        }
    }
    public class ZylonGlobalWall : GlobalWall
    {
        public override void PlaceInWorld(int i, int j, int type, Item item) {
            if (WorldGen.currentWorldSeed.ToLower() == "autumn") if (type == WallID.LivingLeaf || type == WallID.BlueDungeon || type == WallID.BlueDungeonSlab || type == WallID.BlueDungeonSlabUnsafe || type == WallID.BlueDungeonTile || type == WallID.BlueDungeonTileUnsafe || type == WallID.BlueDungeonUnsafe || type == WallID.GreenDungeon || type == WallID.GreenDungeonSlab || type == WallID.GreenDungeonSlabUnsafe || type == WallID.GreenDungeonTile || type == WallID.GreenDungeonTileUnsafe || type == WallID.GreenDungeonUnsafe || type == WallID.PinkDungeon || type == WallID.PinkDungeonSlab || type == WallID.PinkDungeonSlabUnsafe || type == WallID.PinkDungeonTile || type == WallID.PinkDungeonTileUnsafe || type == WallID.PinkDungeonUnsafe || type == WallID.GrassUnsafe || type == WallID.JungleUnsafe || type == WallID.FlowerUnsafe || type == WallID.Grass || type == WallID.Jungle || type == WallID.Flower || type == WallID.CorruptGrassUnsafe || type == WallID.HallowedGrassUnsafe || type == WallID.MushroomUnsafe || type == WallID.JungleUnsafe1 || type == WallID.JungleUnsafe2 || type == WallID.JungleUnsafe3 || type == WallID.JungleUnsafe4 || type == WallID.CorruptGrassEcho || type == WallID.HallowedGrassEcho || type == WallID.CrimsonGrassEcho || type == WallID.Jungle1Echo || type == WallID.Jungle2Echo || type == WallID.Jungle3Echo || type == WallID.Jungle4Echo) {
                Tile tile = Main.tile[i, j];
                tile.WallColor = PaintID.DeepOrangePaint;
            }
        }
    }
}