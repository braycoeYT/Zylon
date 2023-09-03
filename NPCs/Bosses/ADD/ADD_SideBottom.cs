using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Bosses.ADD
{
	public class ADD_SideBottom : ModNPC
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Ancient Diskite Director");
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
			NPC.damage = 33;
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
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = (int)((950 + ((numPlayers - 1) * 400))*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 48;
        }
		NPC main;
		int Timer;
		float degrees = 180;
		float targetRot;
		float degTemp;
		float targTemp;
		float count1;
		float count2;
		float degSpeed;
		bool whatDir;
		bool dirrand;
		Vector2 target;
        public override void AI() {
			Timer++;

			if (Timer % 60 == 0)
				dirrand = !dirrand;

            main = Main.npc[ZylonGlobalNPC.diskiteBoss];
			target = main.Center - Main.player[main.target].Center;
			target.Normalize();

			if (Timer % 90 >= 45 && Main.expertMode && NPC.CountNPCS(ModContent.NPCType<ADD_SideTop>()) > 0) NPC.dontTakeDamage = true;
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

			if (dirrand) targetRot += MathHelper.ToRadians(20);
			else targetRot += MathHelper.ToRadians(-20);
			if (!Main.expertMode) {
				if (dirrand) targetRot += MathHelper.ToRadians(10);
				else targetRot += MathHelper.ToRadians(-10);
            }

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
				if (Timer % 480 == 120) {//if (Timer % (300 + (180*(NPC.life/NPC.lifeMax))) == 90) {
					ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f, BasicNetType: 2);
				}
				if (Timer % 480 == 130 && NPC.life <= NPC.lifeMax * 0.75f) {
					ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f, BasicNetType: 2);
				}
				if (Timer % 480 == 140 && NPC.life <= NPC.lifeMax * 0.5f) {
					ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f, BasicNetType: 2);
				}
				if (Timer % 480 == 150 && NPC.life <= NPC.lifeMax * 0.25f) {
					ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f, BasicNetType: 2);
				}
				if (Timer % 480 == 160 && NPC.life <= NPC.lifeMax * 0.125f) {
					ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f, BasicNetType: 2);
				}
            }
			else {
				if (Timer % 480 == 120) {
					ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -8).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f, BasicNetType: 2);
				}
				if (Timer % 480 == 135 && NPC.life <= NPC.lifeMax * 0.66f) {
					ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -8).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f, BasicNetType: 2);
				}
				if (Timer % 480 == 150 && NPC.life <= NPC.lifeMax * 0.33f) {
					ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -8).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f, BasicNetType: 2);
				}
				if (Timer % 480 == 165 && NPC.life <= NPC.lifeMax * 0.16f) {
					ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -8).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f, BasicNetType: 2);
				}
            }
			if (main.life < 1 || !main.active) NPC.active = false;
        }
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
				new FlavorTextBestiaryInfoElement("A laser-shooting piece of the Ancient Diskite Director.")
			});
		}
		public override void HitEffect(NPC.HitInfo hit) {
            if (NPC.life < 0) Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-3, 3), -6), ModContent.GoreType<Gores.Bosses.ADD.SideBottomDeath>());
        }
    }
}