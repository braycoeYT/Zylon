using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Chat;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;

namespace Zylon.NPCs.Bosses.SusEye
{
	[AutoloadBossHead]
	internal class SupremeLookingEyeHead : WormHead
	{
		public override int BodyType => ModContent.NPCType<SupremeLookingEyeBody>();
		public override int TailType => ModContent.NPCType<SupremeLookingEyeTail>();
		public override void SetStaticDefaults() {
			NPCID.Sets.MPAllowedEnemies[Type] = true;

			// DisplayName.SetDefault("Suspicious Looking Eye");
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DiggerBody);
			NPC.aiStyle = -1;
			NPC.lifeMax = 500000;
			NPC.damage = 250;
			NPC.defense = 40;
			NPC.value = 69;
			NPC.noGravity = true;
			NPC.width = 60;
			NPC.height = 60;
			NPC.netAlways = true;
			NPC.scale = 1f;
		}
		public override void Init() {
			MinSegmentLength = 60;
			MaxSegmentLength = 60;

			CommonWormInit(this);
		}
		int Timer;
		int flee;
        public override void AI() { //fix npc immune plz and despawn in both worms
			Timer++;
            NPC.boss = true;

			NPC.TargetClosest(true);

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

			if (Main.player[NPC.target].statLife < 1) {
				NPC.TargetClosest(true);
				if (Main.player[NPC.target].statLife < 1) {
					//if (flee == 0)
					flee++;
				}
				else
				flee = 0;
				if (flee > 0) {
					if (flee > 300) NPC.active = false;
					return;
				}
			}
        }
		static int max = 18;
		int d = Main.rand.Next(max);
        public override void PostAI() {
            if (Timer % 60 == 0) {
				d = Main.rand.Next(max);
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
			string a = "Zylon/NPCs/Bosses/SusEye/Supreme/" + d;
			Texture2D me = (Texture2D)ModContent.Request<Texture2D>(a);
			Vector2 drawOrigin = new Vector2(me.Width * 0.5f, me.Height * 0.5f);
			Vector2 drawPos = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY);
			Color color = Color.White;
			spriteBatch.Draw(me, drawPos, null, color, 0f, drawOrigin, NPC.scale, SpriteEffects.None, 0);
			return false;
        }
        internal static void CommonWormInit(Worm worm) {
			worm.MoveSpeed = 34f;
			worm.Acceleration = 0.3f;
		}
		private int attackCounter;
		public override void SendExtraAI(BinaryWriter writer) {
			writer.Write(attackCounter);
		}
		public override void ReceiveExtraAI(BinaryReader reader) {
			attackCounter = reader.ReadInt32();
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Lens, 1, 69, 420));
			npcLoot.Add(new CommonDrop(ItemID.SuspiciousLookingEye, 1));
		}
	}
	//[AutoloadBossHead]
	internal class SupremeLookingEyeBody : WormBody
	{
		public override void SetStaticDefaults() {
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
			NPC.defense = 50;
			NPC.noGravity = true;
			NPC.width = 60;
			NPC.height = 60;
			NPC.netAlways = true;
			NPC.scale = 1f;
		}
		int Timer;
		int rand = Main.rand.Next(600);
        public override void AI() {
			Timer++;
			NPC.dontTakeDamage = Timer < 900;
			if (Timer % 600 == rand) {
				int temp = 0;
				for (int x = 0; x < Main.maxNPCs; x++) {
					if (Main.npc[x].type == ModContent.NPCType<SupremeLookingEyeHead>()) temp = Main.npc[x].target;
                }
				Vector2 speed = NPC.Center - Main.player[temp].Center;
				ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, -8f*speed, ModContent.ProjectileType<Projectiles.Bosses.SusEye.PoopHostile>(), NPC.damage/3, 0f, 255, 0, 0, 2);
            }
        }
		static int max = 18;
		int d = Main.rand.Next(max);
        public override void PostAI() {
            if (Timer % 60 == 0) {
				d = Main.rand.Next(max);
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
			string a = "Zylon/NPCs/Bosses/SusEye/Supreme/" + d;
			Texture2D me = (Texture2D)ModContent.Request<Texture2D>(a);
			Vector2 drawOrigin = new Vector2(me.Width * 0.5f, me.Height * 0.5f);
			Vector2 drawPos = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY);
			Color color = Color.White;
			spriteBatch.Draw(me, drawPos, null, color, 0f, drawOrigin, NPC.scale, SpriteEffects.None, 0);
			return false;
        }
		public override void Init() {
			SupremeLookingEyeHead.CommonWormInit(this);
		}
	}
	//[AutoloadBossHead]
	internal class SupremeLookingEyeTail : WormTail
	{
		public override void SetStaticDefaults() {
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
			
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.TheDestroyerBody);
			NPC.aiStyle = -1;
			NPC.damage = 500;
			NPC.defense = 999999;
			NPC.noGravity = false;
			NPC.width = 60;
			NPC.height = 60;
			NPC.netAlways = true;
			NPC.scale = 1f;
		}
		int Timer;
		int flee;
        public override void AI() {
			Timer++;
        }
		static int max = 18;
		int d = Main.rand.Next(max);
        public override void PostAI() {
            if (Timer % 60 == 0) {
				d = Main.rand.Next(max);
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
			string a = "Zylon/NPCs/Bosses/SusEye/Supreme/" + d;
			Texture2D me = (Texture2D)ModContent.Request<Texture2D>(a);
			Vector2 drawOrigin = new Vector2(me.Width * 0.5f, me.Height * 0.5f);
			Vector2 drawPos = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY);
			Color color = Color.White;
			spriteBatch.Draw(me, drawPos, null, color, 0f, drawOrigin, NPC.scale, SpriteEffects.None, 0);
			return false;
        }
		public override void Init() {
			SupremeLookingEyeHead.CommonWormInit(this);
		}
	}
}