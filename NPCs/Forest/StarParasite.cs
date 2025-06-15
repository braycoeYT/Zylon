using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Microsoft.Xna.Framework;
using Steamworks;
using Humanizer.DateTimeHumanizeStrategy;

namespace Zylon.NPCs.Forest
{
	public class StarParasite : ModNPC
	{
        public override void SetStaticDefaults() {
            Main.npcFrameCount[NPC.type] = 2;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Venom] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Frostburn] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.CursedInferno] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Daybreak] = true;
        }
        public override void SetDefaults() {
            NPC.width = 36;
			NPC.height = 30;
			NPC.damage = 20;
			NPC.defense = 0;
			NPC.lifeMax = 70;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath7;
			NPC.value = Item.buyPrice(0, 0, 0, 75);
			NPC.aiStyle = 2;
			NPC.knockBackResist = 0.8f;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.StarParasiteBanner>();
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 136;
			NPC.damage = 40;
			NPC.knockBackResist = 0.7f;
			NPC.value = Item.buyPrice(0, 0, 1, 50);
			if (Main.hardMode) {
				NPC.lifeMax = 318;
				NPC.damage = 80;
				NPC.value = Item.buyPrice(0, 0, 3);
            }
			if (Main.masterMode) {
				NPC.lifeMax = (int)(NPC.lifeMax*1.5f);
				NPC.damage = (int)(NPC.damage*1.5f);
				NPC.knockBackResist = 0.6f;
            }
        }
        public override void ModifyIncomingHit(ref NPC.HitModifiers modifiers) {
			//Increases knockback dealt while dashing at the player. Not sure if this actually works or not.
			float boost = modifiers.Knockback.Base;
			if (boost > 6f) boost = 6f;
            if (dash) modifiers.Knockback.Flat += boost;
        }
        public override void OnHitByItem(Player player, Item item, NPC.HitInfo hit, int damageDone) {
            for (int i = 0; i < 3; i++) {
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.YellowStarDust);
				Dust dust = Main.dust[dustIndex];
				dust.scale *= 1f + Main.rand.Next(-50, 51) * 0.01f;
			}
        }
        public override void OnHitByProjectile(Projectile projectile, NPC.HitInfo hit, int damageDone) {
            for (int i = 0; i < 3; i++) {
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.YellowStarDust);
				Dust dust = Main.dust[dustIndex];
				dust.scale *= 1f + Main.rand.Next(-50, 51) * 0.01f;
			}
        }
		bool init;
		bool dash;
		int dashTimer = 0;
		int dashWait = Main.rand.Next(120, 181);
		Player target;
		int frame;
        public override bool PreAI() {
			if (target == null || !target.active) NPC.TargetClosest();
			target = Main.player[NPC.target];

			//Dash behaviour with cool white dust effect.
			if (dash) {
				dashTimer++;
				if (dashTimer < 60) { 
					NPC.velocity *= 0.98f;

					if (Main.GameUpdateCount % 2 == 0) {
						int dustIndex = Dust.NewDust(NPC.Center, 0, 0, ModContent.DustType<Dusts.StarParasiteDashDust>());
						Dust dust = Main.dust[dustIndex];
						dust.scale = 0.5f;
						dust.velocity = new	Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi);
					}
				}
				else if (dashTimer == 60) {
					NPC.velocity = new Vector2(0, -9 - 2*Main.expertMode.ToInt()).RotatedBy(NPC.Center.DirectionTo(target.Center).ToRotation() + MathHelper.PiOver2);

					//How often will this even come up?
					if (NPC.confused) NPC.velocity = new Vector2(0, -9 - 2*Main.expertMode.ToInt()).RotatedByRandom(MathHelper.TwoPi);
				}
				else {
					NPC.velocity *= 0.99f;
					if (dashTimer > 180 || NPC.velocity.Length() < 2f) {
						dash = false;
						dashTimer = 0;
					}
					//Spawns cool dust.
					if (Main.GameUpdateCount % 4 == 0) {
						int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<Dusts.StarParasiteDashDust>());
						Dust dust = Main.dust[dustIndex];
						dust.scale = 1f;
						dust.velocity = Vector2.Normalize(NPC.velocity.RotatedBy(MathHelper.Pi))*8f;
					}
				}
			}
            return !dash;
        }
        public override void AI() {
			//Charges dash.
			dashTimer++;
			if (dashTimer > dashWait) {
				dashTimer = 0;
				dashWait = Main.rand.Next(180, 301);
				dash = true;
			}

			//Spawn is like a dash with no charge.
			if (!init) {
				NPC.velocity = new Vector2(0, (-9 - 2*Main.expertMode.ToInt())*Main.rand.NextFloat(-0.9f, 1.1f)).RotatedByRandom(MathHelper.TwoPi);
				init = true;

				dash = true;
				dashTimer = 60;
			}

			NPC.velocity = NPC.velocity*0.99f + new Vector2(0, -1).RotatedBy(NPC.Center.DirectionTo(target.Center).ToRotation())*(NPC.velocity.Length()*0.01f);
        }
        public override void PostAI() {
            NPC.rotation = NPC.velocity.ToRotation();

			//Disappear when it is daytime
			if (Main.dayTime) {
				NPC.active = false;
				for (int i = 0; i < 12; i++) {
					int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.YellowStarDust);
					Dust dust = Main.dust[dustIndex];
					dust.scale *= 1.25f + Main.rand.Next(-50, 51) * 0.01f;
				}
			}

			//Animation
			NPC.frameCounter++;
			if (NPC.frameCounter > 3) { NPC.frameCounter = 0; frame++; }
			if (frame > 1) frame = 0;
			NPC.frame.Y = frame*30;

			Lighting.AddLight(NPC.Center, 0.8f, 0.8f, 0.2f);

			if (Main.rand.NextBool()) {
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.YellowStarDust);
				Dust dust = Main.dust[dustIndex];
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
        }
        public override void OnKill() {
            for (int i = 0; i < 12; i++) {
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.YellowStarDust);
				Dust dust = Main.dust[dustIndex];
				dust.scale *= 1.25f + Main.rand.Next(-50, 51) * 0.01f;
			}
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("An interstellar parasite that dwells within fallen stars, feeding on stardust.")
			});
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return 0f; //Solely spawns from fallen stars
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.FallenStar, 8));
			npcLoot.Add(ItemDropRule.NormalvsExpert(ModContent.ItemType<Items.Accessories.MysticComet>(), 25, 20));
		}
    }
}