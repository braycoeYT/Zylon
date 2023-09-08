using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Desert
{
	public class DesertDiskite_LaserEye : ModNPC
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Desert Diskite");
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
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
        NPC.lifeMax = 69;
			NPC.damage = 0;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
            Texture2D texture = ModContent.Request<Texture2D>("Zylon/NPCs/Desert/DesertDiskite_LaserEyeGlow").Value;
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
		Vector2 target;
        public override void AI() {
			Timer++;
			if (Timer > 2) {
				main = Main.npc[(int)NPC.ai[0]];
			target = main.Center - Main.player[main.target].Center;
			target.Normalize();

			Vector2 look = Main.player[main.target].Center - main.Center;
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

			NPC.Center = main.Center - new Vector2(0, 8).RotatedBy(MathHelper.ToRadians(degrees)); //16 for normal
			//NPC.rotation = MathHelper.ToRadians(degrees);

				if (main.life < 1 || !main.active)
					NPC.active = false;
            }
        }
    }
}