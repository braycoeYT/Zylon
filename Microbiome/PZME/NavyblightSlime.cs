using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Microbiome.PZME
{
	public class NavyblightSlime : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Navyblight Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults()
		{
			npc.width = 38;
			npc.height = 18;
			npc.damage = 183;
			npc.defense = 31;
			npc.lifeMax = 1293;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 5f;
			npc.aiStyle = 1;
			npc.knockBackResist = 0.1f;
			animationType = 1;
			npc.alpha = 50;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Slow] = true;
			npc.buffImmune[BuffID.Weak] = true;
			npc.buffImmune[BuffID.Chilled] = true;
			npc.buffImmune[BuffID.Frozen] = true;
			npc.buffImmune[BuffID.Burning] = true;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.buffImmune[mod.BuffType("Sick")] = true;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 2501;
            npc.damage = 243;
        }
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool(3))
			{
				player.AddBuff(mod.BuffType("Sick"), 500, true);
			}
		}
		int Timer;
		public override void AI()
		{
			npc.TargetClosest(true);
			Player target = Main.player[npc.target];
			Vector2 target2 = target.position;
			target2.X += Main.rand.Next(-60, 60);
			target2.Y += Main.rand.Next(-60, 60);
			Timer++;
			if (Timer % 120 == 0)
				Projectile.NewProjectile(npc.Center, (npc.DirectionTo(target2)) * 4, 83, 59, 1f, Main.myPlayer);
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (ZylonWorld.downedMineral)
			{
				return spawnInfo.player.GetModPlayer<ZylonPlayer>().ZoneMicrobiome ? 0.22f : 0f;
			}
			return 0f;
        }

		public override void NPCLoot()
		{
			if (Main.rand.Next(20) == 0)
				Item.NewItem(npc.getRect(), mod.ItemType("InfectedOnyx"));
			if (Main.rand.Next(30) == 0)
				Item.NewItem(npc.getRect(), mod.ItemType("SilvervoidCore"));
		}
	}
}