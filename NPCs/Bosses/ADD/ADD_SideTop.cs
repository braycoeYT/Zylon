using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Bosses.ADD
{
	public class ADD_SideTop : ModNPC
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ancient Diskite Director");
            //Main.npcFrameCount[NPC.type] = 2;
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				ImmuneToAllBuffsThatAreNotWhips = true,
				ImmuneToWhips = true
			};
			NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
        }
        public override void SetDefaults() {
            NPC.width = 56;
			NPC.height = 70;
			NPC.damage = 30;
			NPC.defense = 14;
			NPC.lifeMax = (int)(800*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.aiStyle = -1;
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.dontCountMe = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            NPC.lifeMax = (int)((950 + ((numPlayers - 1) * 400))*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 43;
		}
		NPC main;
		int Timer;
		float degrees;
		float targetRot;
		float degTemp;
		float targTemp;
		float count1;
		float count2;
		float degSpeed;
		bool whatDir;
		Vector2 target;
        public override void AI() {
			Timer++;
            main = Main.npc[ZylonGlobalNPC.diskiteBoss];
			target = main.Center - Main.player[main.target].Center;
			target.Normalize();

			if (Timer % 90 < 45 && Main.expertMode && NPC.CountNPCS(ModContent.NPCType<ADD_SideBottom>()) > 0) NPC.dontTakeDamage = true;
			else NPC.dontTakeDamage = false;

			Vector2 look = Main.player[main.target].Center - main.Center;
			float angle = 0.5f * (float)Math.PI;
			if (look.X != 0f) {
				angle = (float)Math.Atan(look.Y / look.X);
			}
			else if (look.Y < 0f) {
				angle += (float)Math.PI;
			}
			if (look.X < 0f) {
				angle += (float)Math.PI;
			}

			targetRot = angle;
			//targetRot += MathHelper.ToRadians(90);

			targetRot += MathHelper.ToRadians(90);
			//if (look.X > 0) targetRot += MathHelper.ToRadians(90);
			//else targetRot += MathHelper.ToRadians(270);

			degTemp = degrees;
			targTemp = MathHelper.ToDegrees(targetRot);
			if (degTemp < targTemp) degTemp += 360;
			count1 = degTemp - targTemp;

			degTemp = degrees;
			targTemp = MathHelper.ToDegrees(targetRot);
			if (targTemp < degTemp) targTemp += 360;
			count2 = targTemp - degTemp;

			whatDir = count1 >= count2;

			//if (whatDir) degrees += 1.5f;
			//else degrees -= 1.5f;
			
			if (whatDir) degSpeed += 0.25f;
			else degSpeed -= 0.25f;

			if (degSpeed > 1.5f && !Main.expertMode) degSpeed = 1.5f;
			else if (degSpeed > 2f && Main.expertMode) degSpeed = 2f;
			if (degSpeed < -1.5f && !Main.expertMode) degSpeed = -1.5f;
			else if (degSpeed < -2f && Main.expertMode) degSpeed = -2f;

			//if (Math.Abs(degrees - MathHelper.ToDegrees(targetRot)) < 1f)
			//	degSpeed = Math.Abs(degrees - MathHelper.ToDegrees(targetRot));

			degrees += degSpeed;

			if (Math.Abs(degrees - MathHelper.ToDegrees(targetRot)) < 1f && degSpeed <= 1f) {
				degrees = MathHelper.ToDegrees(targetRot);
				degSpeed = 0;
            }

			if (degrees < 0) degrees = 360;
			if (degrees > 360) degrees = 0;

			NPC.Center = main.Center - new Vector2(0, 66).RotatedBy(MathHelper.ToRadians(degrees));
			NPC.rotation = MathHelper.ToRadians(degrees);

			if (Main.expertMode) {
				if (Timer % 480 == 60) {//if (Timer % (300 + (180*(NPC.life/NPC.lifeMax))) == 0) {
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f);
				}
				if (Timer % 480 == 70 && NPC.life <= NPC.lifeMax * 0.75f) {
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f);
				}
				if (Timer % 480 == 80 && NPC.life <= NPC.lifeMax * 0.5f) {
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f);
				}
				if (Timer % 480 == 90 && NPC.life <= NPC.lifeMax * 0.25f) {
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f);
				}
				if (Timer % 480 == 100 && NPC.life <= NPC.lifeMax * 0.125f) {
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f);
				}
            }
			else {
				if (Timer % 480 == 60) {
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -8).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f);
				}
				if (Timer % 480 == 75 && NPC.life <= NPC.lifeMax * 0.66f) {
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -8).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f);
				}
				if (Timer % 480 == 90 && NPC.life <= NPC.lifeMax * 0.33f) {
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -8).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f);
				}
				if (Timer % 480 == 105 && NPC.life <= NPC.lifeMax * 0.16f) {
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -8).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f);
				}
            }
			if (main.life < 1 || !main.active) NPC.life = 0;
        }
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
				new FlavorTextBestiaryInfoElement("A laser-shooting piece of the Ancient Diskite Director.")
			});
		}
        public override void HitEffect(int hitDirection, double damage) {
            if (NPC.life < 0) Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-3, 3), -6), ModContent.GoreType<Gores.Bosses.ADD.SideTopDeath>());
        }
    }
}