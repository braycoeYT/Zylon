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

namespace Zylon
{
	public class ZylonWorldCheckSystem : ModSystem
	{
		public static bool carnallItemessage = false;
		public static bool downedJelly = false;
		public static bool downedADD = false;
		public override void OnWorldLoad() {
			carnallItemessage = false;
			downedJelly = false;
			downedADD = false;
		}
		public override void OnWorldUnload() {
			carnallItemessage = false;
			downedJelly = false;
			downedADD = false;
		}
		public override void SaveWorldData(TagCompound tag) {
			if (carnallItemessage) {
				tag["carnallItemessage"] = true;
			}
			if (downedJelly) {
				tag["downedJelly"] = true;
            }
			if (downedADD) {
				tag["downedADD"] = true;
			}
		}
		public override void LoadWorldData(TagCompound tag) {
			carnallItemessage = tag.ContainsKey("carnallItemessage");
			downedJelly = tag.ContainsKey("downedJelly");
			downedADD = tag.ContainsKey("downedADD");
		}
		public override void NetSend(BinaryWriter writer) {
			bool[] flags = new bool[] {
				carnallItemessage,
				downedJelly,
				downedADD
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
			carnallItemessage = bitArray[0];
			downedJelly = bitArray[1];
			downedADD = bitArray[2];
		}
        public override void PostUpdateNPCs() {
            if (NPC.downedBoss3 && !carnallItemessage) {
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
				carnallItemessage = true;
            }
        }
    }
}