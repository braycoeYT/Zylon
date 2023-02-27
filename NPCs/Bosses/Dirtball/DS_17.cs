using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Bosses.Dirtball
{
    public class DS_17 : ModNPC
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("DS-17");
            //Main.npcFrameCount[NPC.type] = 2;
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				ImmuneToAllBuffsThatAreNotWhips = true,
				ImmuneToWhips = true
			};
			NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
        }
        public override void SetDefaults() {
            NPC.width = 34;
			NPC.height = 34;
			NPC.damage = 15;
			NPC.defense = 4;
			NPC.lifeMax = 41;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.aiStyle = -1; //44
			NPC.knockBackResist = 0.3f;
			NPC.noGravity = true;
            NPC.noTileCollide = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            NPC.lifeMax = 82;
			NPC.damage = 30;
			NPC.knockBackResist = 0f;
			if (Main.masterMode) {
				NPC.lifeMax = 123;
				NPC.damage = 45;
				NPC.knockBackResist = 0f;
            }
        }
		public override void HitEffect(int hitDirection, double damage) {
			if (NPC.life > 0) {
				for (int i = 0; i < 2; i++) {
					Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.Iron, Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
					dust.noGravity = true;
				}
			}
			else {
				for (int i = 0; i < 12; i++) {
					Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.Iron, Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
					dust.noGravity = true;
				}
				Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-2, 2), 0), ModContent.GoreType<Gores.Bosses.Dirtball.DS17Gore>());
				Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-2, 2), 0), ModContent.GoreType<Gores.Bosses.Dirtball.DS17GoreLeft>());
				Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-2, 2), 0), ModContent.GoreType<Gores.Bosses.Dirtball.DS17GoreRight>());
			}
		}
		int Timer;
		float speedBoost;
		int yvel;
        public override void AI() {
			NPC.TargetClosest(true);
			Player target = Main.player[NPC.target];
			Vector2 target2 = target.position;
			target2.X += Main.rand.Next(-64, 65);
			target2.Y += Main.rand.Next(-64, 65);
			Timer++;
			if (Timer % 180 == 0)
				ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, NPC.DirectionTo(target2)*9f, ModContent.ProjectileType<Projectiles.Bosses.Dirtball.DirtballLaser>(), (int)(NPC.damage * 0.25f), 0f, BasicNetType: 2);
			
			speedBoost = 0.75f;
			Vector2 calc = Main.player[NPC.target].Center - NPC.Center;
			float dist = calc.Length();
			if (dist > 800f)
			speedBoost = 1.5f;

			if (NPC.direction == -1 && NPC.velocity.X > -4f*speedBoost)
							{
								NPC.velocity.X = NPC.velocity.X - 0.1f*speedBoost;
								if (NPC.velocity.X > 4f*speedBoost)
								{
									NPC.velocity.X = NPC.velocity.X - 0.1f*speedBoost;
								}
								else if (NPC.velocity.X > 0f)
								{
									NPC.velocity.X = NPC.velocity.X + 0.05f*speedBoost;
								}
								if (NPC.velocity.X < -4f*speedBoost)
								{
									NPC.velocity.X = -4f*speedBoost;
								}
							}
							else if (NPC.direction == 1 && NPC.velocity.X < 4f*speedBoost)
							{
								NPC.velocity.X = NPC.velocity.X + 0.1f*speedBoost;
								if (NPC.velocity.X < -4f*speedBoost)
								{
									NPC.velocity.X = NPC.velocity.X + 0.1f*speedBoost;
								}
								else if (NPC.velocity.X < 0f)
								{
									NPC.velocity.X = NPC.velocity.X - 0.05f*speedBoost;
								}
								if (NPC.velocity.X > 4f*speedBoost)
								{
									NPC.velocity.X = 4f*speedBoost;
								}
							}
			NPC.ai[1] += 1f;
						if (NPC.ai[1] > 200f)
						{
							if (!Main.player[NPC.target].wet && Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
							{
								NPC.ai[1] = 0f;
							}
							float num209 = 0.2f;
							float num210 = 0.1f;
							float num211 = 4f;
							float num212 = 1.5f;
							if (NPC.ai[1] > 1000f)
							{
								NPC.ai[1] = 0f;
							}
							NPC.ai[2] += 1f;
							if (NPC.ai[2] > 0f)
							{
								if (NPC.velocity.Y < num212)
								{
									NPC.velocity.Y = NPC.velocity.Y + num210;
								}
							}
							else if (NPC.velocity.Y > -num212)
							{
								NPC.velocity.Y = NPC.velocity.Y - num210;
							}
							if (NPC.ai[2] < -150f || NPC.ai[2] > 150f)
							{
								if (NPC.velocity.X < num211)
								{
									NPC.velocity.X = NPC.velocity.X + num209;
								}
							}
							else if (NPC.velocity.X > -num211)
							{
								NPC.velocity.X = NPC.velocity.X - num209;
							}
							if (NPC.ai[2] > 300f)
							{
								NPC.ai[2] = -300f;
							}
						}
			if (NPC.Center.Y + 50 > Main.player[NPC.target].Center.Y && Timer % 12 == 0) yvel -= 1;
			if (NPC.Center.Y - 50 < Main.player[NPC.target].Center.Y && Timer % 12 == 0) yvel += 1;
			if (yvel > 8) yvel = 8;
			if (yvel < -8) yvel = -8;
			if (yvel > 0 && NPC.Center.Y > Main.player[NPC.target].Center.Y && Timer % 12 == 0) yvel -= 1;
			if (yvel < 0 && NPC.Center.Y < Main.player[NPC.target].Center.Y && Timer % 12 == 0) yvel += 1;
			if (Main.npc[ZylonGlobalNPC.dirtballBoss].life < 1) NPC.life = 0;
			NPC.velocity.Y = yvel; //if (Math.Abs(NPC.Center.Y - Main.player[NPC.target].Center.Y) > 80) NPC.velocity.Y = yvel;
		}
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("DS-17, or Drone Servant Model 17, is a type of temporary drone created by Dirtball meant for defense. Due to age and subpar design, it often misses its target.")
			});
		}
    }
}