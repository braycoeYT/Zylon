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
using Zylon.Items;

namespace Zylon.NPCs.Bosses
{
	[AutoloadBossHead]
	public class ComputerVirusBoss : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Computer Virus.exe");
		}

        public override void SetDefaults()
		{
			npc.width = 360;
			npc.height = 300;
			npc.damage = 43;
			npc.defense = 5;
			npc.lifeMax = 4950;
			npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath7;
			npc.value = 7000f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 74;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.boss = true;
			npc.scale = 0.6f;
			npc.lavaImmune = true;
			music = MusicID.Boss3;
			npc.netAlways = true;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Cursed] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Slow] = true;
			npc.buffImmune[BuffID.Weak] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
			npc.buffImmune[BuffID.Frostburn] = true;
			npc.buffImmune[BuffID.Chilled] = true;
			npc.buffImmune[BuffID.Frozen] = true;
			npc.buffImmune[BuffID.Burning] = true;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.buffImmune[BuffID.Venom] = true;
			bossBag = ItemType<DiscusBag>();
			aiType = NPCID.SolarCorite;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 8900;
            npc.damage = 90;
			npc.defense = 7;
        }
		
		public float Timer
		{
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }

        public override void AI()
		{
			npc.aiStyle = 74;
	        Timer++;
			if (Main.expertMode)
			{
			    if  (Timer % 200 == 0)
			    {
				    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.TheEmbeded>(), 0, npc.whoAmI);
			    }
				if  (Timer % 60 == 0)
			    {
				    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 6f, 6f, ProjectileType<Projectiles.HostileErrorShot>(), -25, Main.myPlayer);
			    }
			}
			else
			{
				if  (Timer % 420 == 0)
			    {
				    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.TheEmbeded>(), 0, npc.whoAmI);
			    }
			}
        }
		
	    public override void NPCLoot()
        {
			if(Main.expertMode)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("DiscusBag"));
			}
		    else
			{
			    Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(1));
	            Item.NewItem(npc.getRect(), ItemID.Amber, 1 + Main.rand.Next(1));
			    Item.NewItem(npc.getRect(), ItemID.GoldBar, 1 + Main.rand.Next(1));
				Item.NewItem(npc.getRect(), mod.ItemType("ZylonianDesertCore"), Main.rand.Next(5, 9));
			}
        }
	}
}