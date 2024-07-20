using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Bosses.Jelly
{
	public class BeamEerieJellyfish : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[NPC.type] = 3;
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers() {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}
        public override void SetDefaults() {
			NPC.width = 30;
			NPC.height = 30;
			NPC.damage = 35;
			NPC.lifeMax = 1;
			NPC.aiStyle = -1;
			NPC.dontTakeDamage = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.alpha = 255;
        }
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.damage = 70;
        }
		int Timer;
		int attackCount;
		public override void AI() {
			NPC.netUpdate = true;
			if (Timer % 5 == 0)
				NPC.frameCounter++;
			if (NPC.frameCounter > 2)
				NPC.frameCounter = 0;
			NPC.frame.Y = (int)(NPC.frameCounter * 72);

			if (NPC.ai[1] == 1)
				NPC.rotation = MathHelper.ToRadians(270);
			NPC.TargetClosest();
			Timer++;
			if (Timer < 60)
				NPC.color = Color.Transparent;
			else if (Timer % 5 == 0 && Timer < 120) {
				if (NPC.color == Color.Blue)
					NPC.color = Color.Transparent;
				else
					NPC.color = Color.Blue;
			}
			else if (Timer > 119)
				NPC.color = Color.Blue;
			else
				NPC.velocity *= 0.98f;
			if (Timer == 120) {
				SoundEngine.PlaySound(SoundID.Item124);
				int beamDamage = (int)(25 + NPC.ai[0]);
				if (Main.expertMode) beamDamage = (int)(35 + NPC.ai[0]);
				if (NPC.ai[1] == 0) ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.position - new Vector2(2, 8), new Vector2(), ModContent.ProjectileType<Projectiles.Bosses.Jelly.JellyBeamBody>(), beamDamage, 0f, Main.myPlayer, 30, 2f, BasicNetType: 2);
				else ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(-6, -32), new Vector2(), ModContent.ProjectileType<Projectiles.Bosses.Jelly.JellyBeamBody>(), beamDamage, 0f, Main.myPlayer, 30, 1f, BasicNetType: 2);
				attackCount++;
			}
			if (Timer >= 120)
			if (Timer > 180) {
				Timer = 0;
			}
			if (attackCount < 2 && NPC.alpha > 0)
				NPC.alpha -= 17;
			if (attackCount > 2)
				NPC.alpha += 17;
			if (NPC.alpha >= 255)
				NPC.life = 0;

			if (NPC.ai[1] == 0) {
				if (Timer % 5 == 0)
				if (NPC.Center.X < Main.player[NPC.target].Center.X) NPC.velocity.X += 1;
				else NPC.velocity.X -= 1;
				if (NPC.velocity.X > 16)
					NPC.velocity.X = 16;
				if (NPC.velocity.X < -16)
					NPC.velocity.X = -16;
				if (Timer >= 120)
					NPC.velocity.X = 0;
				else
					NPC.position.Y = Main.player[NPC.target].position.Y - 320;
			}
			else { 
				if (Timer % 5 == 0)
				if (NPC.Center.Y < Main.player[NPC.target].Center.Y) NPC.velocity.Y += 1;
				else NPC.velocity.Y -= 1;
				if (NPC.velocity.Y > 16)
					NPC.velocity.Y = 16;
				if (NPC.velocity.Y < -16)
					NPC.velocity.Y = -16;
				if (Timer >= 120)
					NPC.velocity.Y = 0;
				else
					NPC.position.X = Main.player[NPC.target].position.X - 700;
			}
		}
	}
}