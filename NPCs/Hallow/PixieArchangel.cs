using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Hallow
{
	public class PixieArchangel : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[NPC.type] = 2;
			var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers() {
				CustomTexturePath = "Zylon/NPCs/Hallow/PixieArchangelBestiary",
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<Buffs.Debuffs.Shroomed>()] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<Buffs.Debuffs.BrainFreeze>()] = true;
        }
        public override void SetDefaults() {
			NPC.width = 68;
			NPC.height = 44;
			NPC.damage = 60;
			NPC.defense = 25;
			NPC.lifeMax = 280;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath39;
			NPC.value = Item.buyPrice(0, 0, 6);
			NPC.aiStyle = -1;
			NPC.knockBackResist = 0.3f;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.PixieArchangelBanner>();
			NPC.noGravity = true;
			NPC.noTileCollide = true;
        }
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 560;
			NPC.damage = 120;
			NPC.knockBackResist = 0.2f;
			NPC.value = Item.buyPrice(0, 0, 12);
			if (NPC.downedQueenSlime) {
				NPC.lifeMax = 700;
				NPC.damage = 150;
				NPC.value = Item.buyPrice(0, 0, 14);
            }
			if (NPC.downedEmpressOfLight) {
				NPC.lifeMax = 1200;
				NPC.damage = 200;
				NPC.value = Item.buyPrice(0, 0, 16);
            }
			if (Main.masterMode) {
				NPC.lifeMax = (int)(NPC.lifeMax*1.5f);
				NPC.damage = (int)(NPC.damage*1.5f);
				NPC.knockBackResist = 0.15f;
            }
        }
		public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo) {
            if (Main.rand.NextBool(7)) target.AddBuff(BuffID.Silenced, 60*8);
			if (Main.rand.NextBool(7)) target.AddBuff(BuffID.Slow, 60*8);
			if (Main.rand.NextBool(7)) target.AddBuff(BuffID.Weak, 60*20);
        }
        int Timer;
		int attack = 0;
		int myFrame;
		public override void AI() {
			if (++NPC.frameCounter >= 3) {
				NPC.frameCounter = 0;
				if (++myFrame >= 2)
					myFrame = 0;
			}
			NPC.frame.Y = myFrame*50;

			if (!Main.player[NPC.target].active) NPC.TargetClosest(true); //Only choose new target if attack transition or current target is dead
			Player target = Main.player[NPC.target];
			if (attack % 2 == 0) { //Ram attack
				NPC.aiStyle = -1; //Yeet pixie mode for now
				if (Timer % 60 == 0 || Timer < 2) NPC.velocity = NPC.DirectionTo(target.Center)*12f; //DASH!!!
				else if (Timer % 60 > 30) NPC.velocity *= 0.94f; //Slow down

				if (Timer >= 240) {
					NPC.velocity = Vector2.Zero;
					Timer = 0;
					attack++;
					NPC.TargetClosest(true);
                }
            }
			else { //Projectile attack
				NPC.aiStyle = 22; //Act like regular pixie, but with new ai below
				if (Timer % 120 == 60) { //Projectile attack
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, NPC.DirectionTo(target.Center)*4f, ModContent.ProjectileType<Projectiles.Enemies.PixieArchangelProj>(), NPC.damage/3, 0f);
                }
				if (Timer % 90 == 45) { //Special horizontal dash
					if (NPC.Center.X < target.Center.X) NPC.velocity.X = 10;
					else NPC.velocity.X = -10;
                }
				if (Timer % 4 == 0 && NPC.Center.Y > target.Center.Y + 40 && NPC.velocity.Y > -6) NPC.velocity.Y -= 1;
				if (Timer >= 480) {
					NPC.velocity = Vector2.Zero;
					Timer = 0;
					attack++;
					NPC.TargetClosest(true);
                }
            }
			Timer++;
			NPC.spriteDirection = NPC.direction;
		}
        public override void PostAI() {
			NPC.rotation = NPC.velocity.X * 0.05f;
			for (int i = 0; i < 2; i++) {
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.IceTorch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity = new Vector2();
				dust.noGravity = true;
				dust.scale *= 1.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
        }
        public override void OnKill() {
            for (int i = 0; i < 5; i++) {
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.IceTorch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow,
				new FlavorTextBestiaryInfoElement("Stronger variants of pixies that were blessed by Radias, who granted them magic and an extra pair of wings.")
			});
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.OverworldHallow.Chance * 0.13f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.SpectralFairyDust>(), 3)).OnFailedRoll(new CommonDrop(ItemID.PixieDust, 1, 2, 5));
			npcLoot.Add(new CommonDrop(ItemID.LightShard, 15));
		}
	}
}