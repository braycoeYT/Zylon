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

namespace Zylon.NPCs.Desert
{
    public class DesertDiskite_Center : ModNPC
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Desert Diskite");
            //Main.npcFrameCount[NPC.type] = 2;
			var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				CustomTexturePath = "Zylon/NPCs/Desert/DesertDiskite_Bestiary",
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				ImmuneToAllBuffsThatAreNotWhips = true,
				ImmuneToWhips = true
			};
			NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
        }
        public override void SetDefaults() {
            NPC.width = 34;
			NPC.height = 34;
			NPC.damage = 16;
			NPC.defense = 4;
			NPC.lifeMax = 45;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.value = 100;
			NPC.aiStyle = 44;
			NPC.knockBackResist = 0.5f;
			NPC.noGravity = true;
            NPC.noTileCollide = false;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.DesertDiskiteBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
        NPC.lifeMax = 90;
			NPC.damage = 32;
			NPC.value = 200;
			NPC.knockBackResist = 0.3f;
        }
        public override void HitEffect(int hitDirection, double damage) {
			if (NPC.life > 0) {
				for (int i = 0; i < 2; i++) {
					Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<Dusts.DiskiteDust>(), Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
					dust.noGravity = true;
				}
			}
			else {
				for (int i = 0; i < 12; i++) {
					Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<Dusts.DiskiteDust>(), Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
					dust.noGravity = true;
				}
				for (int j = 0; j < 6; j++) Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-6, 6)), ModContent.GoreType<Gores.Bosses.ADD.SpikeRingDeath>());
				Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-2, 2), 0), ModContent.GoreType<Gores.Enemies.DesertDiskiteGore>());
			}
		}
		int Timer;
		float yeah;
		bool init;
		bool test = true;
		Vector2 randVector;
        public override void AI() {
			/*Timer++;
			if (Timer % 60 == 1) randVector = new Vector2(Main.rand.Next(-60, 61), Main.rand.Next(-60, 61));
			NPC.TargetClosest(true);
			if (Vector2.Distance(NPC.Center, Main.player[NPC.target].Center) < (Math.Abs(randVector.X) + Math.Abs(randVector.Y))) {
				randVector = Vector2.Zero;
				yeah = 1f;
				if (Vector2.Distance(NPC.Center, Main.player[NPC.target].Center) < 30)
					yeah = 2f;
			}
			else yeah = 0;*/
			if (!init) {
				//Projectile.NewProjectile(NPC.GetSource_FromNPC(), NPC.Center, new Vector2(), ModContent.ProjectileType<Projectiles.Enemies.DesertDiskite_LaserEye>(), 0, 0, 255, NPC.whoAmI);
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<DesertDiskite_LaserEye>(), 0, NPC.whoAmI, NPC.ai[0]);
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<DesertDiskite_CenterDeco>(), 0, NPC.whoAmI);
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<DesertDiskite_SpikeRing>(), 0, NPC.whoAmI);
				init = true;
			}
			/*if (help == 1f) {
				Timer++;
				if (Timer % 240 == 0)
					Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, Vector2.Normalize(NPC.Center - Main.player[NPC.target].Center) * -12f, ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser>(), (int)(NPC.damage * 0.3f), 0f);
            }*/
			/*Vector2 speed = NPC.Center - Main.player[NPC.target].Center + randVector;
				speed.Normalize();
				if (Main.expertMode) speed *= -3.5f + yeah;
				else speed *= -3f + yeah;
				NPC.velocity += speed;
				NPC.velocity /= 2;*/
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            return (SpawnCondition.OverworldDayDesert.Chance * 0.9f) + (SpawnCondition.DesertCave.Chance * 0.08f);
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
				new FlavorTextBestiaryInfoElement("An ancient machine constructed for the analysis of faraway planets.")
			});
		}
		public override void ModifyNPCLoot(NPCLoot NPCLoot) {
			NPCLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ModContent.ItemType<Items.Materials.DiskiteCrumbles>(), 3, 1, 2, 2), new CommonDrop(ModContent.ItemType<Items.Materials.DiskiteCrumbles>(), 1, 1, 2)));
			NPCLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Amber, 20), new CommonDrop(ItemID.Amber, 18)));
		}
    }
}