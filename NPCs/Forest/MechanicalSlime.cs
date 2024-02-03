using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Forest
{
	public class MechanicalSlime : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[NPC.type] = 7;
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				SpecificallyImmuneTo = new int[] {
					BuffID.Poisoned,
					BuffID.Confused,
					BuffID.OnFire,
					BuffID.Chilled,
					BuffID.Frozen,
					BuffID.Burning,
					BuffID.Frostburn,
					BuffID.CursedInferno
				}
			};
		}
        public override void SetDefaults() {
			NPC.width = 38;
			NPC.height = 18;
			NPC.damage = 67;
			NPC.defense = 25;
			NPC.lifeMax = 293;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 4, 50);
			NPC.aiStyle = 1;
			NPC.knockBackResist = 0.6f;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.MechanicalSlimeBanner>();
		}
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 542;
            NPC.damage = 129;
        }
		int Timer;
		int animationTimer;
		public override void AI() {
			if (Main.player[NPC.target].statLife < 1)
				NPC.TargetClosest(true);
			Player target = Main.player[NPC.target];
			Vector2 target2 = target.position;
			target2.X += Main.rand.Next(-60, 61);
			target2.Y += Main.rand.Next(-60, 61);
			Timer++;
			if (Timer % 180 == 0)
				ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, (NPC.DirectionTo(target2)) * 8, ProjectileID.PinkLaser, (int)(NPC.damage * 0.3f), 0f, Main.myPlayer, BasicNetType: 2);
			if (Timer % 10 == 0)
				animationTimer++;
			if (animationTimer > 6)
				animationTimer = 0;
			NPC.frame.Y = animationTimer * 26;
			NPC.spriteDirection = NPC.direction;
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
				new FlavorTextBestiaryInfoElement("A slime constructed in a similar manner to the mechanical bosses.")
			});
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (NPC.downedMechBossAny)
				return SpawnCondition.OverworldNightMonster.Chance * 0.1f;
			return 0f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Gel, 1, 1, 3));
			npcLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(3, ItemID.IronBar, ItemID.LeadBar, ModContent.ItemType<Items.Bars.ZincBar>()));
			npcLoot.Add(ItemDropRule.ByCondition(new ElemGelCondition(), ModContent.ItemType<Items.Materials.ElementalGoop>(), 2, 1, 3));
		}
	}
}