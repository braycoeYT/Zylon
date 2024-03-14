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
			var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers() {
				CustomTexturePath = "Zylon/NPCs/WindyDay/WindElemental_Bestiary",
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
			NPCID.Sets.ImmuneToRegularBuffs[Type] = true;
        }
        public override void SetDefaults() {
            NPC.width = 26;
			NPC.height = 26;
			NPC.damage = 18;
			NPC.defense = 4;
			NPC.lifeMax = 61;
			NPC.HitSound = SoundID.NPCHit44;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 1, 50);
			NPC.aiStyle = 44;
			NPC.knockBackResist = 0.8f;
			NPC.noGravity = true;
            NPC.noTileCollide = true;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.WindElementalBanner>();
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 101;
			NPC.damage = 36;
			NPC.knockBackResist = 0.7f;
			NPC.value = Item.buyPrice(0, 0, 2, 75);
			if (Main.hardMode) {
				NPC.lifeMax = 332;
				NPC.damage = 92;
				NPC.value = Item.buyPrice(0, 0, 4);
            }
			if (NPC.downedPlantBoss) {
				NPC.lifeMax = 401;
				NPC.damage = 105;
				NPC.value = Item.buyPrice(0, 0, 4, 40);
            }
			if (Main.masterMode) {
				NPC.lifeMax = (int)(NPC.lifeMax*1.5f);
				NPC.damage = (int)(NPC.damage*1.5f);
				NPC.knockBackResist = 0.6f;
            }
        }
		public override void HitEffect(NPC.HitInfo hit) {
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
			}
		}
		int Timer;
        public override void AI() {
			Timer++;
			if (Timer % 240 == 119) {
				ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(), ModContent.ProjectileType<Projectiles.Enemies.WindElemental_Protect>(), (int)(NPC.damage*0.3f), 0f, Main.myPlayer, NPC.whoAmI, BasicNetType: 2);
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
			NPCLoot.Add(new CommonDrop(ModContent.ItemType<Items.Food.CottonCandy>(), 100));
		}
    }
}