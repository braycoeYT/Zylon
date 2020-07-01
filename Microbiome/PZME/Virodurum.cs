using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Microbiome.PZME
{
	public class Virodurum : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Virodurum");
		}

        public override void SetDefaults()
		{
			npc.width = 88;
			npc.height = 69;
			npc.damage = 172;
			npc.defense = 79;
			npc.lifeMax = 13294;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 900f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 24993;
            npc.damage = 289;
			npc.defense = 91;
        }
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool(2))
			{
				player.AddBuff(mod.BuffType("Sick"), 700, true);
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
			Timer++;
			if (Timer % 120 == 0)
			{
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 0, 257, 59, 1f, Main.myPlayer);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 0, 257, 59, 1f, Main.myPlayer);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, 257, 59, 1f, Main.myPlayer);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -8, 257, 59, 1f, Main.myPlayer);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (ZylonWorld.downedMineral)
			{
				return spawnInfo.player.GetModPlayer<ZylonPlayer>().ZoneMicrobiome ? 0.2f : 0f;
			}
			return 0f;
		}
		public override void NPCLoot()
		{
			if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), mod.ItemType("SilvervoidCore"));
			if (Main.rand.Next(3) == 0)
				Item.NewItem(npc.getRect(), mod.ItemType("SilvervoidCore"));
		}
	}
}