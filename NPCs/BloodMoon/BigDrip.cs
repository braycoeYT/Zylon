using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.BloodMoon
{
	public class BigDrip : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[NPC.type] = 8;
		}
        public override void SetDefaults() {
			NPC.width = 74;
			NPC.height = 110;
			NPC.damage = 45;
			NPC.defense = 9;
			NPC.lifeMax = 750;
			NPC.HitSound = SoundID.NPCHit19;
			NPC.DeathSound = SoundID.NPCDeath22;
			NPC.value = 600;
			NPC.aiStyle = 22;
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			AnimationType = NPCID.Drippler;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.BigDripBanner>();
			AIType = NPCID.Drippler;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			NPC.knockBackResist = 0f;
        }
        public override void HitEffect(int hitDirection, double damage) {
            if (NPC.life < 1) {
				for (int i = 0; i < 3; i++)
					Gore.NewGore(NPC.GetSource_FromThis(), NPC.Center, new Vector2(Main.rand.NextFloat(-4, 4), 0), GoreID.DripplerChunk, 2f);
				for (int i = 0; i < 3; i++)
					Gore.NewGore(NPC.GetSource_FromThis(), NPC.Center, new Vector2(Main.rand.NextFloat(-4, 4), 0), GoreID.DripplerChunk2, 2f);
				for (int i = 0; i < 3; i++)
					Gore.NewGore(NPC.GetSource_FromThis(), NPC.Center, new Vector2(Main.rand.NextFloat(-4, 4), 0), GoreID.DripplerChunk3, 2f);
			}
		}
        int Timer;
		public override void AI() {
			Timer++;
			NPC.TargetClosest(true);
			Vector2 speed = NPC.Center - Main.player[NPC.target].Center;
			speed.Normalize();
			if (Timer % 180 == 0) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, speed*-9, ProjectileID.DeathLaser, (int)(NPC.damage*0.3f), 0f);
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon,
				new FlavorTextBestiaryInfoElement("Ancient spirits from within the Wall of Flesh fused with dripplers to cause them to clump together even further, creating this monstrocity.")
			});
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (Main.bloodMoon && Main.hardMode) return 0.1f;
			return 0f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.BloodDroplet>(), 1, 1, 3));
			npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.MoneyTrough, 100), new CommonDrop(ItemID.MoneyTrough, 75)));
			npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.SharkToothNecklace, 115), new CommonDrop(ItemID.SharkToothNecklace, 87)));
		}
	}
}