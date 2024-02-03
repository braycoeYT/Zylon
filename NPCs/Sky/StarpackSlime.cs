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
			NPC.lifeMax = 49;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath3;
			NPC.value = Item.buyPrice(0, 0, 0, 75);
			NPC.aiStyle = 14;
			NPC.knockBackResist = 0.67f;
			AnimationType = 1;
			NPC.noGravity = true;
        }
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 98;
            NPC.damage = 34;
			NPC.knockBackResist = 0.5f;
        }
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,
				new FlavorTextBestiaryInfoElement("A heavenly slime attached to a jetpack, allowing it to float across the sky.")
			});
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.Sky.Chance * 0.16f;
        }
	    public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Gel, 1, 1, 3));
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.SpeckledStardust>(), 1, 1, 3));
			npcLoot.Add(ItemDropRule.ByCondition(new ElemGelCondition(), ModContent.ItemType<Items.Materials.ElementalGoop>(), 2, 1, 3));
		}
	}
}