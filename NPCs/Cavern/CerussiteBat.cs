using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Microsoft.Xna.Framework;

namespace Zylon.NPCs.Cavern
{
	public class CerussiteBat : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[NPC.type] = 4;
		}
        public override void SetDefaults() {
			NPC.width = 38;
			NPC.height = 18;
			NPC.damage = 16;
			NPC.defense = 6;
			NPC.lifeMax = 14;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath4;
			NPC.value = 125;
			NPC.aiStyle = 14;
			NPC.lavaImmune = true;
			AIType = NPCID.CaveBat;
			NPC.knockBackResist = 1.75f;
			AnimationType = NPCID.CaveBat;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.CerussiteBatBanner>();
        }
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment) {
			NPC.knockBackResist = 1.5f;
			NPC.value = 250;
			if (Main.hardMode) {
				NPC.lifeMax = 128;
				NPC.damage = 101;
				NPC.value = 750;
            }
			if (NPC.downedPlantBoss) {
				NPC.lifeMax = 156;
				NPC.damage = 126;
				NPC.value = 800;
            }
			if (Main.masterMode) {
				if (Main.hardMode) {
					NPC.lifeMax = (int)(NPC.lifeMax*1.5f);
					NPC.damage = (int)(NPC.damage*1.5f);
                }
				NPC.knockBackResist = 1.25f;
            }
        }
		int Timer;
		int wait = Main.rand.Next(240, 301);
		int wait2 = Main.rand.Next(30, 61);
		int wait3 = Main.rand.Next(30, 61);
		public override void AI() {
			Timer++;
			if (Timer == wait || Timer == wait + wait2 || Timer == wait + wait2 + wait3) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, 8), ModContent.ProjectileType<Projectiles.Enemies.CerussiteBatProj>(), NPC.damage/3, 0f);
			if (Timer > wait + wait2 + wait3) {
				Timer = 0;
				wait = Main.rand.Next(240, 301);
				wait2 = Main.rand.Next(30, 61);
				wait3 = Main.rand.Next(30, 61);
            }
			NPC.spriteDirection = NPC.direction;
		}
        public override void PostAI() {
            for (int i = 0; i < 3; i++) {
				Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.WhiteTorch);
				dust.noGravity = true;
				dust.scale = 2f;
			}
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,
				new FlavorTextBestiaryInfoElement("A bat formed from the primordial gem magic residing within Cerussite.")
			});
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			//Spawn in bottom half of cavern only
			if(spawnInfo.SpawnTileY <= Main.maxTilesY - 200 && spawnInfo.SpawnTileY > (Main.rockLayer + Main.maxTilesY - 200) / 2) return SpawnCondition.Cavern.Chance*0.08f;
			return 0f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.Cerussite>(), 1, 2, 4));
			npcLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ItemID.Amethyst, ItemID.Topaz, ItemID.Sapphire, ItemID.Emerald, ItemID.Ruby, ItemID.Diamond, ModContent.ItemType<Items.Materials.Jade>()));
			npcLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(2, ItemID.Amethyst, ItemID.Topaz, ItemID.Sapphire, ItemID.Emerald, ItemID.Ruby, ItemID.Diamond, ModContent.ItemType<Items.Materials.Jade>()));
			npcLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(4, ItemID.Amethyst, ItemID.Topaz, ItemID.Sapphire, ItemID.Emerald, ItemID.Ruby, ItemID.Diamond, ModContent.ItemType<Items.Materials.Jade>()));
			npcLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(6, ItemID.Amethyst, ItemID.Topaz, ItemID.Sapphire, ItemID.Emerald, ItemID.Ruby, ItemID.Diamond, ModContent.ItemType<Items.Materials.Jade>()));
		}
	}
}