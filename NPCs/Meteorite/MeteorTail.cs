using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Meteorite
{
	public class MeteorTail : ModNPC
	{
        public override void SetDefaults() {
			NPC.width = 40;
			NPC.height = 40;
			NPC.damage = 34;
			NPC.defense = 12;
			NPC.lifeMax = 24;
			NPC.HitSound = SoundID.NPCHit3;
			NPC.DeathSound = SoundID.NPCDeath3;
			NPC.value = Item.buyPrice(0, 0, 2);
			NPC.aiStyle = 10;
			NPC.knockBackResist = 0.1f;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.MeteorTailBanner>();
			AIType = NPCID.CursedSkull;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
        }
<<<<<<< HEAD
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
        NPC.lifeMax = 48;
            NPC.damage = 74;
			NPC.knockBackResist = 0.02f;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(6, 8));
=======
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 48;
            NPC.damage = 74;
			NPC.knockBackResist = 0.02f;
        }
		public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo) {
            target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(6, 8));
>>>>>>> ProjectClash
        }
		int Timer;
		int timeMax = 300;
		public override void AI() {
			Timer++;
			if (Main.expertMode) timeMax = 240;
			if (Timer % timeMax == 0) {
				NPC.TargetClosest(true);
				Vector2 speed = NPC.velocity;//NPC.Center - Main.player[NPC.target].Center;
				speed.Normalize();
				ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, speed*6f, ModContent.ProjectileType<Projectiles.Enemies.MeteorTailFireBlast>(), (int)(NPC.damage*0.2f), 0f, BasicNetType: 2);
            }
		}
        public override void PostAI() {
            NPC.rotation = NPC.velocity.ToRotation() - MathHelper.PiOver2;
			NPC.spriteDirection = 0;
			for (int i = 0; i < 2; i++) {
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity = new Vector2();
				dust.noGravity = true;
				dust.scale *= 1.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Meteor,
				new FlavorTextBestiaryInfoElement("After a meteorite strikes, some of the uneven and misshapen pieces form into Meteor Tails.")
			});
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.Meteor.Chance * 0.5f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			ItemDropRule.ByCondition(new Conditions.IsPreHardmode(), ItemID.Meteorite, 50); 
		}
	}
}