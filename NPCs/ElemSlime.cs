using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs
{
	public class ElemSlime : ModNPC
	{
        public override void SetStaticDefaults() {
            Main.npcFrameCount[NPC.type] = 2;
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				ImmuneToAllBuffsThatAreNotWhips = true
			};
			NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
        }
        public override void SetDefaults() {
            NPC.width = 32;
			NPC.height = 26;
			NPC.damage = 45;
			NPC.defense = 20;
			NPC.lifeMax = 723;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 750;
			NPC.aiStyle = 1;
			NPC.knockBackResist = 0.1f;
			//AnimationType = 1;
			NPC.alpha = 50;
			NPC.scale = 1.5f;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.ElemSlimeBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            NPC.lifeMax = 1446;
			NPC.damage = 90;
			NPC.value = 1300;
			NPC.defense = 20;
        }
		public override void HitEffect(int hitDirection, double damage) {
			if (NPC.life > 0) {
				for (int i = 0; i < 2; i++) {
					Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<Dusts.ElemDust>(), Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
					dust.noGravity = true;
				}
			}
			else for (int i = 0; i < 12; i++) {
				Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<Dusts.ElemDust>(), Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
				dust.noGravity = true;
			}
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.ElementalDegeneration>(), 60*Main.rand.Next(5, 11));
        }
		int Timer;
		int animationTimer;
		int attack;
		int attackTimer;
		bool attackDone = true;
        public override void AI() {
            Timer++;
			NPC.TargetClosest(true);

			if (Timer % 10 == 0)
				animationTimer++;
			if (animationTimer > 1)
				animationTimer = 0;
			NPC.frame.Y = animationTimer * 26;
			NPC.spriteDirection = NPC.direction;

			if (attackDone == true) {
				attack = Main.rand.Next(3);
				attackTimer = 0;
				attackDone = false;
            }
			if (attack == 0) {
				attackTimer++;
				if (attackTimer < 120) return;
				Vector2 speed = NPC.Center - Main.player[NPC.target].Center;
				speed.Normalize();
				ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, speed*-8.5f, ModContent.ProjectileType<Projectiles.Enemies.ElemSlimeBlob>(), (int)(NPC.damage*0.3f), 0f, BasicNetType: 2);
				attackDone = true;
			}
			else if (attack == 1) {
				attackTimer++;
				if (attackTimer == 120) {
					for (int i = 0; i < 6; i++)
						ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(Main.rand.NextFloat(-6, 6), Main.rand.NextFloat(-9, -5)), ModContent.ProjectileType<Projectiles.Enemies.ElemSlimeSpike>(), (int)(NPC.damage*0.2f), 0f, BasicNetType: 2);
					attackDone = true;
                }
            }
			else if (attack == 2) {
				attackTimer++;
				if (attackTimer < 120) return;
				Vector2 speed = NPC.Center - Main.player[NPC.target].Center;
				speed.Normalize();
				ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, speed*-12f, ModContent.ProjectileType<Projectiles.Enemies.ElemSlimeOrb>(), (int)(NPC.damage*0.3f), 0f, BasicNetType: 2);
				for (int i = 0; i < 4; i++)
					ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, 12).RotatedBy(Main.rand.NextFloat(MathHelper.TwoPi)), ModContent.ProjectileType<Projectiles.Enemies.ElemSlimeOrb>(), (int)(NPC.damage*0.3f), 0f, BasicNetType: 2);
				attackDone = true;
			}
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("What used to be a common slime has absorbed a piece of elemental goop and become another factory for the creation of more goop.")
			});
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (!NPC.downedPlantBoss) return 0f;
			if (SpawnCondition.OverworldDaySlime.Chance > 0) return 0.075f;
            else return 0.01f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Gel, 1, 2, 5));
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.ElementalGoop>(), 2));
			npcLoot.Add(ItemDropRule.NormalvsExpert(ItemID.SlimeStaff, 7500, 5000));
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Food.GalacticBrownie>(), 25));
			npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ModContent.ItemType<Items.Accessories.SlimePendant>(), 125), new CommonDrop(ModContent.ItemType<Items.Accessories.SlimePendant>(), 100)));
		}
    }
}