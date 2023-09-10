using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Zylon.Items.Banners;

namespace Zylon.Tiles.Banners
{
	public class MonsterBanner : ModTile
	{
		public override void SetStaticDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.StyleWrapLimit = 111;
			TileObjectData.addTile(Type);
			DustType = -1;
			//DisableSmartCursor = true;
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Banner");
			AddMapEntry(new Color(13, 88, 130), name);
		}
		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (closer)
			{
				Player player = Main.LocalPlayer;
				int style = Main.tile[i, j].TileFrameX / 18;
				int npcType;
				switch (style)
				{
					case 0:
						npcType = ModContent.NPCType<NPCs.Forest.OrangeSlime>();
						break;
					case 1:
						npcType = 0; //npcType = ModContent.NPCType<NPCs.Ocean.CyanSlime>();
						break;
					case 2:
						npcType = ModContent.NPCType<NPCs.Forest.DirtSlime>();
						break;
					case 3:
						npcType = 0; //npcType = ModContent.NPCType<NPCs.Forest.VerdureGigaslime>();
						break;
					case 4:
						npcType = 0; //npcType = ModContent.NPCType<NPCs.Ocean.LittoralGigaslime>();
						break;
					case 5:
						npcType = ModContent.NPCType<NPCs.Crimson.VeinTunnelerHead>();
						break;
					case 6:
						npcType = ModContent.NPCType<NPCs.Crimson.ArteryCloggerHead>();
						break;
					case 7:
						npcType = ModContent.NPCType<NPCs.Dungeon.BoneSlime>();
						break;
					case 8:
						npcType = ModContent.NPCType<NPCs.Forest.MechanicalSlime>();
						break;
					case 9:
						npcType = 0; //npcType = ModContent.NPCType<NPCs.Sky.StarpackSlime>();
						break;
					case 10:
						npcType = ModContent.NPCType<NPCs.Snow.LivingMarshmallow>();
						break;
					case 11:
						npcType = ModContent.NPCType<NPCs.Snow.RoastedLivingMarshmallow>();
						break;
					case 12:
						npcType = ModContent.NPCType<NPCs.Ocean.EerieJellyfish>();
						break;
					case 13:
						npcType = ModContent.NPCType<NPCs.Desert.DesertDiskite_Center>();
						break;
					case 14:
						npcType = 0; //npcType = ModContent.NPCType<NPCs.Desert.DustbowlGigaslime>();
						break;
					case 15:
						npcType = ModContent.NPCType<NPCs.Jungle.LiveObelisk>();
						break;
					case 16:
						npcType = ModContent.NPCType<NPCs.WindyDay.WindElemental>();
						break;
					case 17:
						npcType = 0; //npcType = ModContent.NPCType<NPCs.BloodMoon.BigDrip>();
						break;
					case 18:
						npcType = ModContent.NPCType<NPCs.ElemSlime>();
						break;
					case 19:
						npcType = ModContent.NPCType<NPCs.Meteorite.MeteorTail>();
						break;
					case 20:
						npcType = 0; //npcType = ModContent.NPCType<NPCs.Snow.BlizzardSeer>();
						break;
					default:
						return;
				}
				Main.SceneMetrics.NPCBannerBuff[npcType] = true;
				Main.SceneMetrics.hasBanner = true;
			}
		}
		public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects) {
			if (i % 2 == 1) {
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}
	}
}