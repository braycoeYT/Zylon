using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Items.Bags;

namespace Zylon.NPCs.Bosses.Scavenger
{
	[AutoloadBossHead]
    public class MatrixScavenger : ModNPC
	{
        public override void SetStaticDefaults() {
			NPCID.Sets.BossBestiaryPriority.Add(Type);
			NPCID.Sets.MPAllowedEnemies[Type] = true;

			Main.npcFrameCount[NPC.type] = 4;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Chilled] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Frozen] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Burning] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Frostburn] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.CursedInferno] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Shimmer] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Ichor] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Venom] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire3] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Daybreak] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<Buffs.Debuffs.Shroomed>()] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<Buffs.Debuffs.LoberaSoulslash>()] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<Buffs.Debuffs.ElementalDegeneration>()] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<Buffs.Debuffs.Timestop>()] = true;
		}
        public override void SetDefaults() {
            NPC.width = 130;
			NPC.height = 164;
			NPC.damage = 58;
			NPC.defense = 20;
			NPC.lifeMax = (int)(35000*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.value = Item.buyPrice(0, 13);
			NPC.aiStyle = -1; //14
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.boss = true;
			NPC.netAlways = true;
			NPC.lavaImmune = true;
			Music = MusicID.Boss3;
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = (int)(52500*balance*bossAdjustment*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 97;
			NPC.value = 0;
			if (Main.masterMode) {
				NPC.lifeMax = (int)(70000*balance*bossAdjustment*ModContent.GetInstance<ZylonConfig>().bossHpMult);
				NPC.damage = 136;
            }
        }
		Player target;
		bool attackDone;
		int attackTimer;
		int nextAttack = -1;
        public override void AI() { //exp hit dirtblock = penetrate -, -1 = 3
			NPC.netUpdate = true;
			NPC.TargetClosest(true);
			ZylonGlobalNPC.scavengerBoss = NPC.whoAmI;
			target = Main.player[NPC.target];

			if (attackDone) {
				//First attack
				if (nextAttack == -1) NPC.ai[0] = Main.rand.Next(2);
				else NPC.ai[0] = nextAttack;

				nextAttack = Main.rand.Next(2);
				while ((int)NPC.ai[0] == nextAttack) nextAttack = Main.rand.Next(2);

				attackDone = false;
				attackTimer = 0;

				NPC.ai[0] = 0f;
            }

			if (nextAttack == -1) NPC.ai[0] = -1f;

			//Main.NewText((int)NPC.ai[0] + " | " + nextAttack + " | " + attackTimer);

			switch (NPC.ai[0]) {
				case -1:
					IntroAttack();
					break;
				case 0:
					QuarterDash();
					break;
			}
		}
		private void IntroAttack() {
			attackTimer++;
			if (attackTimer >= 60) attackDone = true;
		}
		private void QuarterDash() {
			NPC.Center = target.Center - new Vector2(0, 320).RotatedBy(MathHelper.ToRadians(attackTimer));

			
			attackTimer++;
			if (attackTimer % 30 == 0 && Main.netMode != NetmodeID.MultiplayerClient) {
				Vector2 speed = Vector2.Normalize(NPC.Center - target.Center);
				Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, speed*-13f, ModContent.ProjectileType<Projectiles.Bosses.Scavenger.BinaryBlast4x4>(), NPC.damage/3, 0f);
			}
		}
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
				new FlavorTextBestiaryInfoElement("???")
			});
		}
    }
}