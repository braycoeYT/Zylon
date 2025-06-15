using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Jungle
{
    public class LiveObelisk : ModNPC
	{
        public override void SetStaticDefaults() {
			Main.npcFrameCount[NPC.type] = 7;
			NPCID.Sets.ImmuneToRegularBuffs[Type] = true;
        }
        public override void SetDefaults() {
            NPC.width = 50;
			NPC.height = 106;
			NPC.damage = 24;
			NPC.defense = 18;
			NPC.lifeMax = 78;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.value = Item.buyPrice(0, 0, 3);
			NPC.aiStyle = 44;
			NPC.knockBackResist = 0.3f;
			NPC.noGravity = true;
            //NPC.noTileCollide = true;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.LiveObeliskBanner>();
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 151;
			NPC.damage = 45;
			NPC.knockBackResist = 0.2f;
			NPC.value = Item.buyPrice(0, 0, 4, 50);
			if (Main.hardMode) {
				NPC.lifeMax = 619;
				NPC.damage = 110;
				NPC.value = Item.buyPrice(0, 0, 6);
            }
			if (NPC.downedPlantBoss) {
				NPC.lifeMax = 752;
				NPC.damage = 156;
				NPC.value = Item.buyPrice(0, 0, 7);
            }
			if (Main.masterMode) {
				NPC.lifeMax = (int)(NPC.lifeMax*1.5f);
				NPC.damage = (int)(NPC.damage*1.5f);
				NPC.knockBackResist = 0.1f;
            }
        }
		public override void HitEffect(NPC.HitInfo hit) {
			if (NPC.life > 0) {
				for (int i = 0; i < 5; i++) {
					Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.Stone, Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2), 0, default, 2f);
					dust.noGravity = true;
				}
			}
			else for (int i = 0; i < 18; i++) {
				Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.Stone, Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2), 0, default, 2f);
				dust.noGravity = true;
			}
		}
		int Timer;
        public override void AI() {
			Timer++;
			NPC.spriteDirection = NPC.direction*-1;
			NPC.velocity *= 0.98f;
			NPC.rotation = MathHelper.ToRadians(NPC.velocity.X*2);
			if (Timer % 7 == 0)
				NPC.frameCounter++;
			if (NPC.frameCounter > 6)
				NPC.frameCounter = 0;
			NPC.frame.Y = (int)NPC.frameCounter * 120;
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            return (SpawnCondition.SurfaceJungle.Chance * 0.3f) + (SpawnCondition.UndergroundJungle.Chance * 0.1f);
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle,
				new FlavorTextBestiaryInfoElement("A living marker of the dead that still has flora attached to itself. Its heavy weight slows it down greatly.")
			});
		}
		public override void ModifyNPCLoot(NPCLoot NPCLoot) {
			NPCLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ModContent.ItemType<Items.Materials.ObeliskShard>(), 1, 1, 4), new CommonDrop(ModContent.ItemType<Items.Materials.ObeliskShard>(), 1, 2, 5)));
			NPCLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Vine, 3), new CommonDrop(ItemID.Vine, 2)));
			NPCLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(150, ItemID.AncientCobaltHelmet, ItemID.AncientCobaltBreastplate, ItemID.AncientCobaltLeggings));
		}
    }
}