using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Bosses.ADD
{
	public class ADD_LaserEye2 : ModNPC
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ancient Diskite Director");
            //Main.npcFrameCount[NPC.type] = 2;
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }
        public override void SetDefaults() {
            NPC.width = 8;
			NPC.height = 8;
			NPC.damage = 0;
			NPC.defense = 9999;
			NPC.lifeMax = 69;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.aiStyle = -1;
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.dontCountMe = true;
			NPC.dontTakeDamage = true;
			NPC.alpha = 255;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            NPC.lifeMax = 69;
			NPC.damage = 0;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
            Texture2D texture = ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/ADD/ADD_LaserEye2_Glow").Value;
			if (NPC.alpha < 1)
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					NPC.position.X - Main.screenPosition.X + NPC.width * 0.5f,
					NPC.position.Y - Main.screenPosition.Y + NPC.height - texture.Height * 0.5f + 2f
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
		float degrees;
		float targetRot;
		float degTemp;
		float targTemp;
		float count1;
		float count2;
		float degSpeed;
		bool whatDir;
		int atkProj;
		Vector2 target;
        public override void AI() {
			Timer++;

			if (Timer == 60) {
				if (NPC.Center.X < Main.player[main.target].Center.X) whatDir = false;
				else whatDir = true;
            }

			if (Timer > 2) {
				main = Main.npc[ZylonGlobalNPC.diskiteBoss];
			if (Timer == 3) {
				if (main.life < main.lifeMax && Main.rand.NextBool(2)) atkProj = ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser4>();
				else atkProj = ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser3>();
            }
			if (Timer < 60) degrees = 0;
			else { 
				float mult;
				if (whatDir) mult = -1.75f;
				else mult = 1.75f;
				degrees += mult;
			}
			
			if (degrees < -360) degrees = -360;
			if (degrees > 360) degrees = 360;
			NPC.Center = main.Center - new Vector2(0, 16).RotatedBy(MathHelper.ToRadians(degrees)); //16 for normal
			//NPC.rotation = MathHelper.ToRadians(degrees);
				if (NPC.alpha > 0 && Timer < 283 && Timer > 30) {
					NPC.alpha -= 15;
				}
				else NPC.alpha += 15;
				if (NPC.alpha < 0) NPC.alpha = 0;
			if (NPC.alpha > 255) NPC.alpha = 255;

			int damage = (int)(main.damage*(0.4f - (0.1f*main.life/main.lifeMax)));
			int range = 10;
			if (Main.expertMode) range = 8;
			if (Timer >= 60 && degrees != 360 && degrees != -360 && Timer % range == 0) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -8).RotatedBy(MathHelper.ToRadians(degrees)), atkProj, damage, 0f);

			if (main.life < 1 || !main.active || Timer > 300) NPC.active = false;
            }
        }
    }
}