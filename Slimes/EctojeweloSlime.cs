using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Slimes
{
	public class EctojeweloSlime : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ectojewelo Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults()
		{
			npc.width = 28;
			npc.height = 27;
			npc.damage = 118;
			npc.defense = 75;
			npc.lifeMax = 11020;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 500f;
			npc.aiStyle = 1;
			npc.knockBackResist = 0f;
			animationType = 1;
			npc.alpha = 50;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 21485;
            npc.damage = 195;
			npc.defense = 100;
        }
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool(2))
			{
				player.AddBuff(mod.BuffType("Crystalizing"), 25, true);
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
			if (Timer % 250 == 0)
				Projectile.NewProjectile(npc.Center, new Vector2(0, 6).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("PinkGemblast"), 54, 1f, Main.myPlayer);
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if(spawnInfo.player.ZoneRockLayerHeight && ZylonWorld.downedMineral)
			return 0.1f;
			return 0f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("EctojeweloOre"), 0 + Main.rand.Next(4));
        }
	}
}