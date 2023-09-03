using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Bosses.ADD
{
	public class SupportDiskite : ModNPC
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Support Diskite");
            //Main.npcFrameCount[NPC.type] = 2;
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				ImmuneToAllBuffsThatAreNotWhips = true,
				ImmuneToWhips = true
			};
			NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
        }
        public override void SetDefaults() {
            NPC.width = 20;
			NPC.height = 20;
			NPC.damage = 30;
			NPC.defense = 8;
			NPC.lifeMax = 120;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.aiStyle = -1;
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.dontCountMe = true;
			NPC.alpha = 255;
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 180 + ((numPlayers - 1) * 10);
			NPC.damage = 41;
		}
		public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
            Texture2D texture = ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/ADD/SupportDiskite_Glow").Value;
			if (NPC.alpha < 1)
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					NPC.position.X - Main.screenPosition.X + NPC.width * 0.5f,
					NPC.position.Y - Main.screenPosition.Y + NPC.height - texture.Height * 0.5f + 2f + 2
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				NPC.rotation,
				texture.Size() * 0.5f,
				NPC.scale, 
				SpriteEffects.None, 
				0f
			);
        }
		NPC main;
		int Timer;
		Vector2 target;
        public override void AI() {
			Timer++;
			NPC.alpha -= 25;
            main = Main.npc[ZylonGlobalNPC.diskiteBoss];
			NPC.Center = main.Center - new Vector2(0, 100).RotatedBy(MathHelper.ToRadians(Timer));
			target = main.Center - Main.player[main.target].Center;
			target.Normalize();
			if (Timer % 270 == 0) {
				ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, target*-11f, ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser3>(), (int)(NPC.damage * 0.33f), 0f, BasicNetType: 2);
			}
			if (main.life < 1 || !main.active) NPC.life = 0;
        }
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
				new FlavorTextBestiaryInfoElement("A small support drone created in case the Ancient Diskite Director was under attack.")
			});
		}
        public override void HitEffect(NPC.HitInfo hit) {
            if (NPC.life < 0) Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-2, 2), 0), ModContent.GoreType<Gores.Bosses.ADD.SupportDiskiteGore>());
        }
    }
}