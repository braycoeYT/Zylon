using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Sky
{
	public class StarpackSlime : ModNPC
	{
		public override void SetStaticDefaults()  {
			// DisplayName.SetDefault("Starpack Slime");
			Main.npcFrameCount[NPC.type] = 2;
		}
        public override void SetDefaults() {
			NPC.width = 40;
			NPC.height = 40;
			NPC.damage = 17;
			NPC.defense = 6;
			NPC.lifeMax = 83;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath3;
			NPC.value = Item.buyPrice(0, 0, 3);
			NPC.aiStyle = 14;
			NPC.knockBackResist = 0.67f;
			AnimationType = 1;
			NPC.noGravity = true;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.StarpackSlimeBanner>();
        }
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 176;
			NPC.damage = 34;
			NPC.knockBackResist = 0.5f;
			NPC.value = Item.buyPrice(0, 0, 6);
			if (Main.hardMode) {
				NPC.lifeMax = 319;
				NPC.damage = 83;
				NPC.value = Item.buyPrice(0, 0, 7, 50);
            }
			if (NPC.downedPlantBoss) {
				NPC.lifeMax = 402;
				NPC.damage = 101;
				NPC.value = Item.buyPrice(0, 0, 8);
            }
			if (Main.masterMode) {
				NPC.lifeMax = (int)(NPC.lifeMax*1.5f);
				NPC.damage = (int)(NPC.damage*1.5f);
				NPC.knockBackResist = 0.35f;
            }
        }
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,
				new FlavorTextBestiaryInfoElement("A heavenly slime attached to a jetpack, allowing it to float across the sky.")
			});
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.Sky.Chance * 0.05f;
        }
	    public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Gel, 1, 1, 3));
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.SpeckledStardust>(), 1, 1, 3));
			npcLoot.Add(ItemDropRule.ByCondition(new ElemGelCondition(), ModContent.ItemType<Items.Materials.ElementalGoop>(), 2, 1, 3));
		}
	}
}