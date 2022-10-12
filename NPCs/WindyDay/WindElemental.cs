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

namespace Zylon.NPCs.WindyDay
{
    public class WindElemental : ModNPC
	{
        public override void SetStaticDefaults() {
            //Main.npcFrameCount[NPC.type] = 2;
			var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				CustomTexturePath = "Zylon/NPCs/WindyDay/WindElemental_Bestiary",
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				ImmuneToAllBuffsThatAreNotWhips = true,
				ImmuneToWhips = true
			};
			NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
        }
        public override void SetDefaults() {
            NPC.width = 26;
			NPC.height = 26;
			NPC.damage = 18;
			NPC.defense = 4;
			NPC.lifeMax = 61;
			NPC.HitSound = SoundID.NPCHit44;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 75;
			NPC.aiStyle = 44;
			NPC.knockBackResist = 0.8f;
			NPC.noGravity = true;
            NPC.noTileCollide = true;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.WindElementalBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            NPC.lifeMax = 101;
			NPC.damage = 36;
			NPC.value = 150;
			NPC.knockBackResist = 0.5f;
			if (Main.hardMode) {
				NPC.lifeMax = 268;
				NPC.damage = 54;
				NPC.value = 250;
            }
        }
		public override void HitEffect(int hitDirection, double damage) {
			if (NPC.life > 0) {
				for (int i = 0; i < 4; i++) {
					Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.RainCloud, Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2), 0, default, 2f);
					dust.noGravity = true;
				}
			}
			else {
				for (int i = 0; i < 10; i++) {
					Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.RainCloud, Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2), 0, default, 2f);
					dust.noGravity = true;
				}
				//for (int j = 0; j < 6; j++) Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-6, 6)), ModContent.GoreType<Gores.Bosses.ADD.SpikeRingDeath>());
				//Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-2, 2), 0), ModContent.GoreType<Gores.Enemies.DesertDiskiteGore>());
			}
		}
		int Timer;
        public override void AI() {
			Timer++;
			if (Timer % 240 == 119) {
				Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(), ModContent.ProjectileType<Projectiles.Enemies.WindElemental_Protect>(), (int)(NPC.damage*0.3f), 0f, Main.myPlayer, NPC.whoAmI);
				//Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(), ModContent.ProjectileType<Projectiles.Enemies.WindElemental_ProtectDeco>(), (int)(NPC.damage*0.3f), 0f, Main.myPlayer, NPC.whoAmI);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (Math.Abs(Main.windSpeedCurrent) > 20) return SpawnCondition.OverworldDay.Chance * 0.15f;
			return 0f;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.WindyDay,
				new FlavorTextBestiaryInfoElement("A nasty ethereal being that is blown together during high winds.")
			});
		}
		public override void ModifyNPCLoot(NPCLoot NPCLoot) {
			NPCLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ModContent.ItemType<Items.Materials.WindEssence>(), 3), new CommonDrop(ModContent.ItemType<Items.Materials.WindEssence>(), 2)));
		}
    }
}