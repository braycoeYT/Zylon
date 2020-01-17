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
	public class AncientDesertDiscus : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ancient Desert Discus");
		}

        public override void SetDefaults()
		{
			npc.width = 87;
			npc.height = 87;
			npc.damage = 44;
			npc.defense = 8;
			npc.lifeMax = 1100;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath7;
			npc.value = 2000f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 56;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.boss = true;
			npc.scale = 2;
			npc.lavaImmune = true;
			music = MusicID.Boss2;
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
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 2000;
            npc.damage = 100;
			npc.defense = 6;
        }
		
        public float Timer
		{
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }

        public override void AI()
		{
	        Timer++;
			if  (Timer % 450 == 0)
			{
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.SandGrainDiscus>(), 0, npc.whoAmI);
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