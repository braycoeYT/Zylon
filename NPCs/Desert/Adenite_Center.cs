using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent;

namespace Zylon.NPCs.Desert
{
    public class Adenite_Center : ModNPC
	{
        public override void SetStaticDefaults() {
			var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers() {
				CustomTexturePath = "Zylon/NPCs/Desert/Adenite_Bestiary",
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
			NPCID.Sets.ImmuneToRegularBuffs[Type] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Chilled] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Frozen] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Burning] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Frostburn] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.CursedInferno] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Ichor] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.ShadowFlame] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<Buffs.Debuffs.DeadlyToxins>()] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<Buffs.Debuffs.Shroomed>()] = true;
        }
        public override void SetDefaults() {
            NPC.width = 34;
			NPC.height = 34;
			NPC.damage = 16;
			NPC.defense = 4;
			NPC.lifeMax = 45;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.value = Item.buyPrice(0, 0, 2);
			NPC.aiStyle = 44;
			NPC.knockBackResist = 0.5f;
			NPC.noGravity = true;
            NPC.noTileCollide = false;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.AdeniteBanner>();
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.value = Item.buyPrice(0, 0, 5);
			NPC.knockBackResist = 0.3f;
			if (Main.hardMode) {
				NPC.lifeMax = 219;
				NPC.damage = 44;
				NPC.value = Item.buyPrice(0, 0, 8);
            }
			if (NPC.downedPlantBoss) {
				NPC.lifeMax = 282;
				NPC.damage = 51;
				NPC.value = Item.buyPrice(0, 0, 9);
            }
			if (Main.masterMode) {
				NPC.lifeMax = (int)(NPC.lifeMax*1.5f);
				NPC.damage = (int)(NPC.damage*1.5f);
				NPC.knockBackResist = 0.2f;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) { //Adapted from Adeneb code
			Texture2D spikeTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Desert/Adenite_SpikeRing");
			Texture2D texture = TextureAssets.Npc[Type].Value;
			Texture2D eyeTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Desert/Adenite_LaserEye");

			Vector2 drawPos = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY);
			Color color = NPC.GetAlpha(drawColor);
			var effects = SpriteEffects.None;
			Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
			Vector2 spikeOrigin = new Vector2(spikeTexture.Width * 0.5f, spikeTexture.Height * 0.5f);
			Vector2 eyeOrigin = new Vector2(eyeTexture.Width * 0.5f, eyeTexture.Height * 0.5f);

			Vector2 eyePos = drawPos + - new Vector2(0, 8).RotatedBy(MathHelper.ToRadians(degrees));

			spriteBatch.Draw(spikeTexture, drawPos, null, color, spikeRot, spikeOrigin, NPC.scale, effects, 0); //Draw spike ring
            spriteBatch.Draw(texture, drawPos, null, color, 0f, drawOrigin, NPC.scale, effects, 0); //Draw main orb
			spriteBatch.Draw(eyeTexture, eyePos, null, Color.White, 0f, eyeOrigin, NPC.scale, effects, 0); //Draw laser eye
			return false;
        }
        public override void HitEffect(NPC.HitInfo hit) {
			if (NPC.life > 0) {
				for (int i = 0; i < 2; i++) {
					Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<Dusts.AdeniteDust>(), Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
					dust.noGravity = true;
				}
			}
			else {
				for (int i = 0; i < 12; i++) {
					Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<Dusts.AdeniteDust>(), Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
					dust.noGravity = true;
				}
				for (int j = 0; j < 6; j++) Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-6, 6)), ModContent.GoreType<Gores.Enemies.SpikeRingDeath>());
				Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, new Vector2(Main.rand.NextFloat(-2, 2), 0), ModContent.GoreType<Gores.Enemies.AdeniteGore>());
			}
		}
		NPC main;
		int Timer;
		float degrees;
		float targetRot;
		float degTemp;
		float targTemp;
		float count1;
		float count2;
		float degSpeed;
		bool whatDir;
		Vector2 target;
        float spikeRot;
		//Vector2 newVel;
		//bool hit;
        public override void AI() {
			Timer++;

			//At some point I'm gonna add an expert mode dash attack but not rn.

			//Spike ring code
			spikeRot += MathHelper.ToRadians(5);

			//Laser eye code
			if (Timer > 2) {
				target = NPC.Center - Main.player[NPC.target].Center;
				target.Normalize();

				Vector2 look = Main.player[NPC.target].Center - NPC.Center;
				float angle = 0.5f * (float)Math.PI;
				if (look.X != 0f) {
					angle = (float)Math.Atan(look.Y / look.X);
				}
				else if (look.Y < 0f) {
					angle += (float)Math.PI;
				}
				if (look.X < 0f) {
					angle += (float)Math.PI;
			}

			targetRot = angle;
			//targetRot += MathHelper.ToRadians(90);

			targetRot += MathHelper.ToRadians(90);
			//if (look.X > 0) targetRot += MathHelper.ToRadians(90);
			//else targetRot += MathHelper.ToRadians(270);

			degTemp = degrees;
			targTemp = MathHelper.ToDegrees(targetRot);
			if (degTemp < targTemp) degTemp += 360;
			count1 = degTemp - targTemp;

			degTemp = degrees;
			targTemp = MathHelper.ToDegrees(targetRot);
			if (targTemp < degTemp) targTemp += 360;
			count2 = targTemp - degTemp;

			whatDir = count1 >= count2;

			//if (whatDir) degrees += 1.5f;
			//else degrees -= 1.5f;
			
			if (whatDir) degSpeed += 0.5f;
			else degSpeed -= 0.5f;

			if (degSpeed > 2.5f && !Main.expertMode) degSpeed = 3f;
			else if (degSpeed > 3.5f && Main.expertMode) degSpeed = 4f;
			if (degSpeed < -2.5f && !Main.expertMode) degSpeed = -3f;
			else if (degSpeed < -3.5f && Main.expertMode) degSpeed = -4f;

			//if (Math.Abs(degrees - MathHelper.ToDegrees(targetRot)) < 1f)
			//	degSpeed = Math.Abs(degrees - MathHelper.ToDegrees(targetRot));

			degrees += degSpeed;

			if (Math.Abs(degrees - MathHelper.ToDegrees(targetRot)) < 2f && degSpeed <= 2f) {
				degrees = MathHelper.ToDegrees(targetRot);
				degSpeed = 0;
            }

			if (degrees < 0) degrees = 360;
			if (degrees > 360) degrees = 0;

			//NPC.Center = main.Center - new Vector2(0, 8).RotatedBy(MathHelper.ToRadians(degrees)); //16 for normal
            }
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            return (SpawnCondition.OverworldDayDesert.Chance * 2.8f) + (SpawnCondition.DesertCave.Chance * 0.08f);
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
				new FlavorTextBestiaryInfoElement("An ancient machine constructed for the analysis of faraway planets, repurposed to defend a long-lost desert civilization.")
			});
		}
		public override void ModifyNPCLoot(NPCLoot NPCLoot) {
			NPCLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ModContent.ItemType<Items.Materials.AdeniteCrumbles>(), 3, 1, 2, 2), new CommonDrop(ModContent.ItemType<Items.Materials.AdeniteCrumbles>(), 1, 1, 2)));
			NPCLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Amber, 12), new CommonDrop(ItemID.Amber, 10)));
		}
    }
}