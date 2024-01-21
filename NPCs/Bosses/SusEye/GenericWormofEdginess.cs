using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Chat;
using Microsoft.Xna.Framework.Graphics;

namespace Zylon.NPCs.Bosses.SusEye
{
	[AutoloadBossHead]
	internal class GenericWormofEdginessHead : WormHead
	{
		public override int BodyType => ModContent.NPCType<GenericWormofEdginessBody>();
		public override int TailType => ModContent.NPCType<GenericWormofEdginessTail>();
		public override void SetStaticDefaults() {
			NPCID.Sets.MPAllowedEnemies[Type] = true;

			// DisplayName.SetDefault("Suspicious Looking Eye");
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.TheDestroyerBody);
			NPC.aiStyle = -1;
			NPC.lifeMax = 250000;
			NPC.damage = 250;
			NPC.defense = 0;
			NPC.value = 69;
			NPC.noGravity = true;
			NPC.width = 110;
			NPC.height = 113;
			NPC.netAlways = true;
			NPC.scale = 1f;
		}
		public override void Init() {
			MinSegmentLength = 45;
			MaxSegmentLength = 45;

			CommonWormInit(this);
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
			string a = "Zylon/NPCs/Bosses/SusEye/GenericWormofEdginessHead";
			Texture2D me = (Texture2D)ModContent.Request<Texture2D>(a);
			Vector2 drawOrigin = new Vector2(me.Width * 0.5f, me.Height * 0.5f);
			Vector2 drawPos = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY);
			Color color = Color.White;
			spriteBatch.Draw(me, drawPos, null, color, 0f, drawOrigin, NPC.scale, SpriteEffects.None, 0);
			return false;
        }
        public override void AI() {
            NPC.boss = true;

			NPC.TargetClosest(true);

			if (Vector2.Distance(NPC.Center, Main.player[NPC.target].Center) > 2500) {
				NPC.velocity = Vector2.Normalize(NPC.Center - Main.player[NPC.target].Center)*-30f;
			}

            if (!Main.zenithWorld) { 
				Color messageColor = Color.DarkRed;
					string chat = "GET FIXED BOI!!!!!!!!!!!!!!!";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
				NPC.active = false;
			}
        }
        internal static void CommonWormInit(Worm worm) {
			worm.MoveSpeed = 22f;
			worm.Acceleration = 0.15f;
		}
		private int attackCounter;
		public override void SendExtraAI(BinaryWriter writer) {
			writer.Write(attackCounter);
		}
		public override void ReceiveExtraAI(BinaryReader reader) {
			attackCounter = reader.ReadInt32();
		}
	}
	//[AutoloadBossHead]
	internal class GenericWormofEdginessBody : WormBody
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Vein Tunneler");

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
			
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.TheDestroyerBody);
			NPC.aiStyle = -1;
			NPC.damage = 240;
			NPC.defense = 30;
			NPC.noGravity = false;
			NPC.width = 110;
			NPC.height = 113;
			NPC.netAlways = true;
			NPC.scale = 1f;
		}
		public override void Init() {
			GenericWormofEdginessHead.CommonWormInit(this);
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
			string a = "Zylon/NPCs/Bosses/SusEye/GenericWormofEdginessBody";
			Texture2D me = (Texture2D)ModContent.Request<Texture2D>(a);
			Vector2 drawOrigin = new Vector2(me.Width * 0.5f, me.Height * 0.5f);
			Vector2 drawPos = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY);
			Color color = Color.White;
			spriteBatch.Draw(me, drawPos, null, color, 0f, drawOrigin, NPC.scale, SpriteEffects.None, 0);
			return false;
        }
	}
	//[AutoloadBossHead]
	internal class GenericWormofEdginessTail : WormTail
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Vein Tunneler");

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
			
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.TheDestroyerTail);
			NPC.aiStyle = -1;
			NPC.damage = 500;
			NPC.defense = 999999;
			NPC.noGravity = false;
			NPC.width = 110;
			NPC.height = 113;
			NPC.netAlways = true;
			NPC.scale = 1f;
		}
		public override void Init() {
			GenericWormofEdginessHead.CommonWormInit(this);
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
			string a = "Zylon/NPCs/Bosses/SusEye/GenericWormofEdginessTail";
			Texture2D me = (Texture2D)ModContent.Request<Texture2D>(a);
			Vector2 drawOrigin = new Vector2(me.Width * 0.5f, me.Height * 0.5f);
			Vector2 drawPos = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY);
			Color color = Color.White;
			spriteBatch.Draw(me, drawPos, null, color, 0f, drawOrigin, NPC.scale, SpriteEffects.None, 0);
			return false;
        }
	}
}