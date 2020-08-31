using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.Bosses
{
	[AutoloadBossHead]
	public class ZylonianMineralExtractor : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Zylonian Mineral Extractor");
			Main.npcFrameCount[npc.type] = 4;
		}

        public override void SetDefaults()
		{
			npc.width = 322;
			npc.height = 480;
			npc.damage = 157;
			npc.defense = 45;
			npc.lifeMax = 198000;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 400000f;
			npc.knockBackResist = 0f;
			npc.aiStyle = -1; //51 original
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.boss = true;
			npc.scale = 1;
			npc.lavaImmune = true;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/ZME");
			npc.netAlways = true;
			for (int k = 0; k < npc.buffImmune.Length; k++) {
				npc.buffImmune[k] = true;
			}
			animationType = 244;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 311000;
            npc.damage = 229;
			npc.defense = 60;
        }
        public float Timer
		{
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.expertMode)
			{
				target.AddBuff(mod.BuffType("Crystalizing"), 15, false);
				target.AddBuff(mod.BuffType("XenicAcid"), 600, false);
				target.AddBuff(BuffID.Slow, 200, false);
				target.AddBuff(BuffID.Bleeding, 200, false);
				target.AddBuff(BuffID.Venom, 200, false);
				target.AddBuff(BuffID.Frostburn, 200, false);
			}
			else
			{
				target.AddBuff(mod.BuffType("Crystalizing"), 10, false);
				target.AddBuff(mod.BuffType("XenicAcid"), 480, false);
				target.AddBuff(BuffID.Poisoned, 100, false);
				target.AddBuff(BuffID.Frostburn, 45, false);
			}
		}
		int flee = 0;
		int dashInt = 0;
		int nukeTimer = 0;
		int nukeTimer2 = 0;
		int uberTimer = 0;
		bool dash = false;
		bool nuke = true;
		bool nukeChat = true;
		bool nuke2 = true;
		bool nukeChat2 = true;
		bool uber = true;
		bool uberChat = true;
		bool playerBadChat = true;
		bool safe = true;
		bool bg = true;
        public override void AI()
		{
			npc.TargetClosest(true);
	        Timer++;
			if (Main.player[npc.target].statLife < 1)
			{
				npc.TargetClosest(true);
				if (Main.player[npc.target].statLife < 1)
				{
					if (flee == 0)
					flee++;
				}
				else
				flee = 0;
			}
			if (flee >= 1)
            {
                flee++;
                npc.noTileCollide = true;
                npc.velocity.Y = 7f;
                if (flee >= 450)
                    npc.active = false;
				if (flee >= 100 && playerBadChat)
				{
					Color messageColor = Color.Pink;
					string chat = "<XOM> Beginning Mass Mineral Extraction on Terraria...";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					playerBadChat = false;
				}
            }
			if (Main.dayTime)
			{
				npc.life = npc.lifeMax;
				npc.active = false;
				Color messageColor = Color.Pink;
				string chat = "<XOM> This is a waste of time... leaving...";
				if (Main.netMode == NetmodeID.Server)
				{
					NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
				}
				else if (Main.netMode == NetmodeID.SinglePlayer)
				{
					Main.NewText(Language.GetTextValue(chat), messageColor);
				}
			}
			if (Timer < 100)
			npc.TargetClosest(true);
			Player target = Main.player[npc.target];
				if (target.position.X > npc.Center.X)
				{
						if (npc.velocity.X < 0)
							npc.velocity.X = 2;

					if (Timer % 40 == 0)
					if (npc.life < npc.lifeMax * 0.33f && Timer % 2 == 0)
						npc.velocity.X += 2;
					else
						npc.velocity.X += 1;
				}
				if (target.position.X < npc.Center.X)
				{
						if (npc.velocity.X > 0)
							npc.velocity.X = -2;

					if (Timer % 40 == 0)
						if (npc.life < npc.lifeMax * 0.33f && Timer % 2 == 0)
						npc.velocity.X -= 2;
					else
						npc.velocity.X -= 1;
				}
				if (target.position.Y + 300 < npc.Center.Y)
				{
					npc.velocity.Y = -30;
					Main.PlaySound(SoundID.Tink, npc.position, 0);
				}
				else if (target.position.Y + 300 > npc.Center.Y)
				{
					if (Main.expertMode)
					{
						if (Timer % 5 == 0)
							npc.velocity.Y += 2;
					}
					else
					{
						if (npc.lifeMax / 2 > npc.life)
						{
							if (Timer % 6 == 0)
								npc.velocity.Y += 2;
						}
						else
						{
							if (Timer % 5 == 0)
								npc.velocity.Y += 2;
						}
					}
				}
				else
					npc.velocity.Y = 1;
			//}
		
			if (Main.expertMode)
			{
				if  (Timer % 400 == 0)
				{
					if (NPC.CountNPCS(ModContent.NPCType<Minions.AquaSapphire>()) < 8)
						NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.AquaSapphire>(), 0, npc.whoAmI);
					if (NPC.CountNPCS(ModContent.NPCType<Minions.FlameGarnet>()) < 8)
						NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.FlameGarnet>(), 0, npc.whoAmI);
					if (NPC.CountNPCS(ModContent.NPCType<Minions.SproutingEmerald>()) < 8)
						NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.SproutingEmerald>(), 0, npc.whoAmI);
				}
			}
			else if  (Timer % 440 == 0)
			{
				if (NPC.CountNPCS(ModContent.NPCType<Minions.AquaSapphire>()) < 6)
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.AquaSapphire>(), 0, npc.whoAmI);
				if (NPC.CountNPCS(ModContent.NPCType<Minions.FlameGarnet>()) < 6)
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.FlameGarnet>(), 0, npc.whoAmI);
				if (NPC.CountNPCS(ModContent.NPCType<Minions.SproutingEmerald>()) < 6)
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.SproutingEmerald>(), 0, npc.whoAmI);
			}

			/*if (Main.expertMode && npc.life < npc.lifeMax / 1.4)
			{
				int dashSpeed;
				if (npc.life < npc.lifeMax / 2)
					dashSpeed = 800;
				else if (npc.life < npc.lifeMax / 3.5)
					dashSpeed = 700;
				else if (npc.life < npc.lifeMax / 5.7)
					dashSpeed = 600;
				else
					dashSpeed = 900;
				if (Timer % dashSpeed == 0)
				{
					dash = true;
					dashInt = 0;
				}
			}*/
			if ((Timer % 829 == 0 && !Main.expertMode) || (Timer % 787 == 0 && Main.expertMode))
			{
				NPC.NewNPC((int)target.position.X, (int)target.position.Y, NPCType<Minions.Mineral.TargetMegaLaser>(), 0, npc.whoAmI);
			}
			if ((Timer % 480 == 95 && !Main.expertMode) || (Timer % 420 == 247 && Main.expertMode))
			{
				NPC.NewNPC((int)target.position.X, (int)target.position.Y, NPCType<Minions.Mineral.TargetMegaRandom>(), 0, npc.whoAmI);
			}
			if (Main.expertMode && Timer % 1000 == 0)
			{
				NPC.NewNPC((int)target.position.X, (int)target.position.Y, NPCType<Minions.Mineral.TargetMineralBeam>(), 0, npc.whoAmI);
			}
			if (npc.life < npc.lifeMax * 0.5f && uber)
			{
				uberTimer++;
				if (uberTimer > 90 || (uberTimer > 60 && !Main.expertMode))
				{
					uber = false;
				}
				if (uberTimer % 5 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Ubercabochon>(), 0, npc.whoAmI);
				}
			}
			if (npc.life < npc.lifeMax * 0.33f && uberChat)
			{
					uberChat = false;
					Color messageColor = Color.Pink;
					string chat = "<XOM> Must...fulfill...commands...";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					uberChat = false;
			}
			if (npc.life < npc.lifeMax * 0.33f && Timer % 5 == 0)
			{
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("ZMEGhost"), 0, 0, Main.myPlayer);
				if (Timer % 60 == 0 && Main.expertMode)
				{
					Projectile.NewProjectile(npc.Center, new Vector2(0, 10).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("PinkGemblast"), 50, 2, Main.myPlayer);
				}
			}
		}
		public override void BossLoot(ref string name, ref int potionType)
		{
			name = "The " + name;
			potionType = ItemID.SuperHealingPotion;
		}

		public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("MineralBag"));
			}
			else
			{
				Item.NewItem(npc.getRect(), mod.ItemType("GalacticDiamondium"), Main.rand.Next(15, 30));
				Item.NewItem(npc.getRect(), ItemID.Amethyst, Main.rand.Next(10, 26));
			}
			ZylonWorld.downedMineral = true;
		}
	}
}