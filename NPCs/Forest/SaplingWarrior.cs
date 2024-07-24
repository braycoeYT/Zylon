using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace Zylon.NPCs.Forest
{
	public class SaplingWarrior : ModNPC
	{
        public override void SetStaticDefaults() {
            Main.npcFrameCount[NPC.type] = 5;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.DryadsWardDebuff] = true;
        }
        public override void SetDefaults() {
            NPC.width = 36;
			NPC.height = 56;
			NPC.damage = 8;
			NPC.defense = 5;
			NPC.lifeMax = 23;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 75);
			NPC.aiStyle = 3;
			AIType = NPCID.GiantWalkingAntlion;
			NPC.knockBackResist = 0.75f;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.SaplingWarriorBanner>();
        }
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment) {
			NPC.lifeMax = 47;
			NPC.damage = 15;
			NPC.knockBackResist = 0.55f;
			NPC.value = Item.buyPrice(0, 0, 1, 50);
			if (Main.hardMode) {
				NPC.lifeMax = 157;
				NPC.damage = 96;
				NPC.value = Item.buyPrice(0, 0, 5);
            }
			if (NPC.downedPlantBoss) {
				NPC.lifeMax = 243;
				NPC.damage = 112;
				NPC.value = Item.buyPrice(0, 0, 5, 75);
            }
			if (Main.masterMode) {
				NPC.lifeMax = (int)(NPC.lifeMax*1.5f);
				NPC.damage = (int)(NPC.damage*1.5f);
				NPC.knockBackResist = 0.35f;
            }
		}
        public override bool CanHitNPC(NPC target) {
            return target.type != NPCID.Dryad;
        }
        int frameID;
		float frameCounter;
        public override void AI() {
			NPC.spriteDirection = NPC.direction;
            frameCounter += Math.Abs(NPC.velocity.X);
			if (frameCounter > 10) {
				frameID++;
				frameCounter = 0;
            }
			NPC.frame.Y = (frameID % 4)*60;
			if (NPC.velocity.X == 0) NPC.frame.Y = 0;
			if (NPC.velocity.Y != 0) NPC.frame.Y = 240;
        }
		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
			Texture2D texture = TextureAssets.Npc[Type].Value;
			if (WorldGen.currentWorldSeed.ToLower() == "autumn") texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Forest/SaplingWarrior_Autumn");

			Vector2 drawPos = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY);
			Color color = NPC.GetAlpha(drawColor);
			var effects = SpriteEffects.None;
			if (NPC.direction == 1) effects = SpriteEffects.FlipHorizontally;
			Vector2 drawOrigin = new Vector2(texture.Width*0.5f, texture.Height*0.1f);

			spriteBatch.Draw(texture, drawPos, NPC.frame, color, 0f, drawOrigin, NPC.scale, effects, 0);
			return false;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("A strange creature born from the roots of giant trees, created to protect the forests.")
			});
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo) { //I wanna make them only spawn if a block of living wood is near the player but idk how to do that (NOT spawn on the living wood, just nearby)
			if (!Main.dayTime) return 0f;
			if ((SpawnCondition.Ocean.Chance + SpawnCondition.OverworldDayDesert.Chance + SpawnCondition.Corruption.Chance + SpawnCondition.Crimson.Chance + SpawnCondition.SurfaceJungle.Chance + SpawnCondition.OverworldDaySnowCritter.Chance) > 0) return 0f;
            return SpawnCondition.OverworldDay.Chance * 0.1f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Wood, 1, 1, 3));
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.LivingBranch>(), 1, 2, 3));
			npcLoot.Add(new CommonDrop(ItemID.Acorn, 2, 1));
			npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ModContent.ItemType<Items.Bags.BagofFruits>(), 30), new CommonDrop(ModContent.ItemType<Items.Bags.BagofFruits>(), 25)));
		}
    }
}