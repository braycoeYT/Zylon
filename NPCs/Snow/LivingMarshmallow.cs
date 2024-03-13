using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Snow
{
	public class LivingMarshmallow : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[NPC.type] = 2;
		}
        public override void SetDefaults() {
			NPC.width = 26;
			NPC.height = 26;
			NPC.damage = 14;
			NPC.defense = 4;
			NPC.lifeMax = 41;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath3;
			NPC.value = Item.buyPrice(0, 0, 0, 75);
			NPC.aiStyle = 1;
			NPC.knockBackResist = 0.5f;
			AnimationType = 1;
			NPC.alpha = 50;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.LivingMarshmallowBanner>();
        }
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment) {
            NPC.lifeMax = 82;
            NPC.damage = 28;
			NPC.knockBackResist = 0.35f;
			NPC.value = Item.buyPrice(0, 0, 1, 50);
			if (Main.hardMode) {
				NPC.lifeMax = 211;
				NPC.damage = 79;
				NPC.value = Item.buyPrice(0, 0, 3);
            }
			if (NPC.downedPlantBoss) {
				NPC.lifeMax = 298;
				NPC.damage = 89;
				NPC.value = Item.buyPrice(0, 0, 3, 50);
            }
			if (Main.masterMode) {
				NPC.lifeMax = (int)(NPC.lifeMax*1.5f);
				NPC.damage = (int)(NPC.damage*1.5f);
				NPC.knockBackResist = 0.25f;
            }
        }
		public override void AI() {
			if (NPC.HasBuff(BuffID.OnFire) || NPC.HasBuff(BuffID.CursedInferno) || NPC.HasBuff(BuffID.Frostburn) || NPC.HasBuff(BuffID.ShadowFlame) || NPC.HasBuff(BuffID.Daybreak))
				NPC.Transform(ModContent.NPCType<RoastedLivingMarshmallow>());
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
				new FlavorTextBestiaryInfoElement("An enchanted marshmallow that decided to take refuge in the coldest place it could find.")
			});
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (spawnInfo.Player.ZoneSnow)
				return 0.17f;
			return 0f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Gel, 1, 1, 3));
			npcLoot.Add(new CommonDrop(ItemID.Marshmallow, 4, 1, 1, 3)).OnFailedRoll(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ModContent.ItemType<Items.Food.CocoaBeans>(), ModContent.ItemType<Items.Food.GrahamCracker>()));
			npcLoot.Add(ItemDropRule.ByCondition(new ElemGelCondition(), ModContent.ItemType<Items.Materials.ElementalGoop>(), 2, 1, 3));
		}
	}
}