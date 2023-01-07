using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Bosses.Jelly
{
	public class ExplosiveEerieJellyfish : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[NPC.type] = 3;
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}
        public override void SetDefaults() {
			NPC.width = 40;
			NPC.height = 68;
			NPC.damage = 35;
			NPC.lifeMax = 1;
			NPC.aiStyle = -1;
			NPC.dontTakeDamage = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            NPC.damage = 70;
        }
		int Timer;
		public override void AI() {
			NPC.TargetClosest();
			Timer++;

			if (Timer % 5 == 0) {
				if (NPC.color == Color.Red)
					NPC.color = Color.Transparent;
				else
					NPC.color = Color.Red;
			}

			if (Timer == 1)
				NPC.velocity = (NPC.Center - Main.player[NPC.target].Center) * (-0.025f);
			else
				NPC.velocity *= 0.98f;
			if (Timer == 90) {
				NPC.life = 0;
				SoundEngine.PlaySound(SoundID.Item62);
				int beamDamage = (int)(25 + NPC.ai[0]);
				if (Main.expertMode) beamDamage = (int)(30 + NPC.ai[0]);
					ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(), ModContent.ProjectileType<Projectiles.Bosses.Jelly.JellyBeamCenter>(), beamDamage, 0f, Main.myPlayer, NPC.ai[0] + 5, BasicNetType: 2);
			}
			NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X) + MathHelper.ToRadians(90);

			if (Timer % 5 == 0)
				NPC.frameCounter++;
			if (NPC.frameCounter > 2)
				NPC.frameCounter = 0;
			NPC.frame.Y = (int)(NPC.frameCounter * 72);
		}
	}
}