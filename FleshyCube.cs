using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs
{
	public class FleshyCube : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Fleshy Cube");
			Main.npcFrameCount[npc.type] = 4;
		}

        public override void SetDefaults()
		{
			npc.width = 85;
			npc.height = 85;
			npc.damage = 204;
			npc.defense = 44;
			npc.lifeMax = 10000;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = 1259f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 14;
			npc.noGravity = true;
			animationType = 82;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 17000;
            npc.damage = 339;
			npc.defense = 55;
        }
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool(3))
			{
				player.AddBuff(BuffID.Ichor, 300, true);
			}
		}
		int Timer;
		public override void AI()
		{
			if (Main.player[npc.target].statLife < 1)
			{
				npc.TargetClosest(true);
			}
			Player target = Main.player[npc.target];
			Vector2 target2 = target.position;
			target2.X += Main.rand.Next(-60, 60);
			target2.Y += Main.rand.Next(-60, 60);
			Timer++;
			if (Timer % 120 == 0)
				Projectile.NewProjectile(npc.Center, (npc.DirectionTo(target2)) * 8, 288, 59, 1f, Main.myPlayer);
		}
		/*public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (NPC.downedMoonlord)
			{
			    return SpawnCondition.Crimson.Chance * 0.04f;
			}
			return 0f;
        }*/
		
	    public override void NPCLoot()
        {
	        Item.NewItem(npc.getRect(), mod.ItemType("SilvervoidCore"), 1 + Main.rand.Next(3));
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.rand.Next(10) == 0)
			NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<FleshyCubling>(), 0, npc.whoAmI);
		}
	}
}