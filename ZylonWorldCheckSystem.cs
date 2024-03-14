using Microsoft.Xna.Framework;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;

namespace Zylon
{
	public class ZylonWorldCheckSystem : ModSystem
	{
		public static bool carnalliteMessage = false;
		public static bool downedJelly = false;
		public static bool downedAdeneb = false;
		public static bool downedDirtball = false;
		public static bool downedMetelord = false;
		public override void OnWorldLoad() {
			carnalliteMessage = false;
			downedJelly = false;
			downedAdeneb = false;
			downedDirtball = false;
			downedMetelord = false;
		}
		public override void OnWorldUnload() {
			carnalliteMessage = false;
			downedJelly = false;
			downedAdeneb = false;
			downedDirtball = false;
			downedMetelord = false;
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
		}
		public override void LoadWorldData(TagCompound tag) {
			carnalliteMessage = tag.ContainsKey("carnalliteMessage");
			downedJelly = tag.ContainsKey("downedJelly");
			downedAdeneb = tag.ContainsKey("downedAdeneb");
			downedDirtball = tag.ContainsKey("downedDirtball");
			downedMetelord = tag.ContainsKey("downedMetelord");
		}
		public override void NetSend(BinaryWriter writer) {
			bool[] flags = new bool[] {
				carnalliteMessage,
				downedJelly,
				downedAdeneb,
				downedDirtball,
				downedMetelord
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
    }
}