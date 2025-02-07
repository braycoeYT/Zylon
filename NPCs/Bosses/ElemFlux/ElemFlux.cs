using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Buffs.Debuffs;
using Zylon.Items.Bags;

namespace Zylon.NPCs.Bosses.ElemFlux
{
	[AutoloadBossHead]
    public class ElemFlux : ModNPC
	{
        public override void SetStaticDefaults() {
			NPCID.Sets.BossBestiaryPriority.Add(Type);
			NPCID.Sets.MPAllowedEnemies[Type] = true;

			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Chilled] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Frozen] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Burning] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Frostburn] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.CursedInferno] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Shimmer] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Ichor] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire3] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<ElementalDegeneration>()] = true;
		}
        public override void SetDefaults() {
            NPC.width = 98;
			NPC.height = 94;
			NPC.damage = 74;
			NPC.defense = 40;
			NPC.lifeMax = (int)(18000*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 20);
			NPC.aiStyle = -1;
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.boss = true;
			NPC.netAlways = true;
			NPC.lavaImmune = true;
			//Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/DirtStep");
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = (int)(24500*balance*bossAdjustment*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 148;
			NPC.value = Item.buyPrice(0, 40);
			if (Main.masterMode) {
				NPC.lifeMax = (int)(33300*balance*bossAdjustment*ModContent.GetInstance<ZylonConfig>().bossHpMult);
				NPC.damage = 222;
            }
			if (Main.getGoodWorld) NPC.scale = 0.75f;
        }
		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
			Texture2D texture = TextureAssets.Npc[Type].Value;
			Texture2D altTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/ElemFlux/ElemFlux_2");
			Texture2D midTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/ElemFlux/ElemFlux_Mid");
			Texture2D mid2Texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/ElemFlux/ElemFlux_Mid2");
			Texture2D eyeShader = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/ElemFlux/ElemFlux_EyeShader");
			Texture2D eyeTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/ElemFlux/ElemFlux_Eye");
			Texture2D pupilTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/ElemFlux/ElemFlux_Pupil");
			Texture2D pupilColorTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/ElemFlux/ElemFlux_PupilColor");

			Vector2 drawPos = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY);
			Color color = NPC.GetAlpha(drawColor);
			var effects = SpriteEffects.None;
			Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
			Vector2 eyeOrigin = new Vector2(eyeTexture.Width * 0.5f, eyeTexture.Height * 0.5f);
			Vector2 pupilOrigin = new Vector2(pupilTexture.Width * 0.5f, pupilTexture.Height * 0.5f);
			Vector2 eyeShaderOrigin = new Vector2(eyeShader.Width * 0.5f, eyeShader.Height * 0.5f);

			Vector2 pupilOffset = Vector2.Normalize(NPC.Center - Main.player[NPC.target].Center) * 10f;
			/*if (eyeOffset.Length() > 5f) {
				eyeOffset = Vector2.Normalize(eyeOffset)*5f;
			}*/
			pupilOffset.Y *= 0.28f;
			Vector2 pupilPos = drawPos - pupilOffset;

			Color realMain = new Color(
				(int)(ZylonGlobalNPC.elemFluxMain.R*(1f-colorPercent) + newMain.R*colorPercent),
				(int)(ZylonGlobalNPC.elemFluxMain.G*(1f-colorPercent) + newMain.G*colorPercent),
				(int)(ZylonGlobalNPC.elemFluxMain.B*(1f-colorPercent) + newMain.B*colorPercent));
			Color realSecond = new Color(
				(int)(ZylonGlobalNPC.elemFluxSecond.R*(1f-colorPercent) + newSecond.R*colorPercent),
				(int)(ZylonGlobalNPC.elemFluxSecond.G*(1f-colorPercent) + newSecond.G*colorPercent),
				(int)(ZylonGlobalNPC.elemFluxSecond.B*(1f-colorPercent) + newSecond.B*colorPercent));
			Color realTransition = new Color(
				(int)(realMain.R*0.33f + realSecond.R*0.67f),
				(int)(realMain.G*0.33f + realSecond.G*0.67f),
				(int)(realMain.B*0.33f + realSecond.B*0.67f));
			Color realTransition2 = new Color(
				(int)(realMain.R*0.67f + realSecond.R*0.33f),
				(int)(realMain.G*0.67f + realSecond.G*0.33f),
				(int)(realMain.B*0.67f + realSecond.B*0.33f));

            spriteBatch.Draw(texture, drawPos, null, realMain, NPC.rotation, drawOrigin, NPC.scale*1.2f, effects, 0); //Draw main boss
			spriteBatch.Draw(altTexture, drawPos, null, realSecond, NPC.rotation, drawOrigin, NPC.scale*1.2f, effects, 0); //Draw secondary color
			spriteBatch.Draw(midTexture, drawPos, null, realTransition, NPC.rotation, drawOrigin, NPC.scale*1.2f, effects, 0); //Draw smooth transition
			spriteBatch.Draw(mid2Texture, drawPos, null, realTransition2, NPC.rotation, drawOrigin, NPC.scale*1.2f, effects, 0); //Draw smooth transition 2
			spriteBatch.Draw(eyeShader, drawPos, null, Color.White*0.33f, 0f, eyeShaderOrigin, NPC.scale*0.65f, effects, 0); //Make eye look more natural.
			spriteBatch.Draw(eyeTexture, drawPos, null, Color.White, 0f, eyeOrigin, NPC.scale, effects, 0); //Draw boss eye
			spriteBatch.Draw(pupilColorTexture, pupilPos, null, realSecond, 0f, pupilOrigin, NPC.scale, effects, 0); //Draw boss pupil color
			spriteBatch.Draw(pupilTexture, pupilPos, null, Color.White, 0f, pupilOrigin, NPC.scale, effects, 0); //Draw boss pupil

			return false;
        }
		bool init;
        public override void AI() {
			if (!init) {
				init = true;
				ZylonGlobalNPC.elemFluxMain = new Color(18, 222, 123);
				ZylonGlobalNPC.elemFluxSecond = new Color(250, 184, 135);
			}
			ZylonGlobalNPC.elemFluxBoss = NPC.whoAmI;
            NPC.rotation += MathHelper.ToRadians(NPC.velocity.X/1.5f);

			if (Main.GameUpdateCount % 60 == 0) {
				newMain = new Color(Main.rand.Next(256), Main.rand.Next(256), Main.rand.Next(256));
				newSecond = new Color(Main.rand.Next(256), Main.rand.Next(256), Main.rand.Next(256));
			}

			//NPC.velocity = Vector2.Normalize(NPC.Center - Main.player[NPC.target].Center) * -7f;

			NPC.TargetClosest(true);
        }
		float colorPercent;
		Color newMain;
		Color newSecond;
        public override void PostAI() {

			//Handles transitions, which last 20 frames
			if (!newMain.Equals(ZylonGlobalNPC.elemFluxMain) || !newSecond.Equals(ZylonGlobalNPC.elemFluxSecond)) {
				colorPercent += 0.05f;
				if (colorPercent >= 1f) { //Reset
					colorPercent = 0f;
					ZylonGlobalNPC.elemFluxMain = newMain;
					ZylonGlobalNPC.elemFluxSecond = newSecond;
				}
			}
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("A disgusting amalgamate of elemental goo.")
			});
		}
		public override void BossLoot(ref string name, ref int potionType) {
			//ZylonWorldCheckSystem.downedDirtball = true;
			potionType = ItemID.GreaterHealingPotion;
        }
    }
}