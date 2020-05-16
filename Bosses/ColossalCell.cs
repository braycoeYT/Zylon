using Zylon;
using Zylon.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.Bosses
{
	[AutoloadBossHead]
	public class ColossalCell : ModNPC
	{
		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Colossal Cell");
		}

        public override void SetDefaults()
		{
			npc.width = 115;
			npc.height = 115;
			npc.damage = 34;
			npc.defense = 0;
			npc.lifeMax = 3600;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 9000f;
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.boss = true;
			npc.lavaImmune = true;
			music = MusicID.Boss1;
			npc.netAlways = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Slow] = true;
			npc.buffImmune[BuffID.Weak] = true;
			npc.buffImmune[BuffID.Chilled] = true;
			npc.buffImmune[BuffID.Frozen] = true;
			npc.buffImmune[BuffID.Burning] = true;
			npc.buffImmune[BuffID.Ichor] = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 7200 + numPlayers * 800;
			npc.damage = 68;
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = 80;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		
        public float Timer
		{
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }
		int flee = 0;
		int attack = 0;
		int attackMax = 0;
		int attackNum = 0;
		bool attackDone = true;
		Vector2 targetPos;
		public override void AI()
		{
			if (Main.player[npc.target].statLife < 1)
			{
				npc.TargetClosest(true);
				if (Main.player[npc.target].statLife < 1)
				{
					if (flee == 0)
						flee++;
				}
			}
			if (flee >= 1)
			{
				flee++;
				npc.noTileCollide = true;
				npc.velocity.Y = 7f;
				if (flee >= 450)
					npc.active = false;
			}
			targetPos = Main.player[npc.target].Center;
			if (Main.expertMode)
			{

			}
			else
			{

			}
			if (Timer % 10 == 0)
			npc.rotation += 0.01f;
		}
	    public override void NPCLoot()
        {
			if (!WorldEdit.downedDiscus)
			{
				Color messageColor = Color.Orange;
				string chat = "As the Ancient Desert Discus dies, the other discuses flee into all of the other biomes...";
				if (Main.netMode == 2)
				{
					NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
				}
				else if (Main.netMode == 0)
				{
					Main.NewText(Language.GetTextValue(chat), messageColor);
				}
			}
			
			if (Main.expertMode)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("DiscusBag"));
				if (!WorldEdit.downedDiscus)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("DiscusStory"));
				}
			}
		    else
			{
			    Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 4 + Main.rand.Next(2));
	            Item.NewItem(npc.getRect(), ItemID.Amber, 1 + Main.rand.Next(1));
			    Item.NewItem(npc.getRect(), ItemID.GoldBar, 1 + Main.rand.Next(1));
				Item.NewItem(npc.getRect(), mod.ItemType("ZylonianDesertCore"), Main.rand.Next(5, 9));
				if (Main.rand.NextFloat() < .5f)
				Item.NewItem(npc.getRect(), mod.ItemType("BandOfInfection"));
			}
			WorldEdit.downedDiscus = true;
        }
	}
}