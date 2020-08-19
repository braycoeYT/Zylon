using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Silvervoid
{
	public class SilvervoidSlime : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults()
		{
			npc.width = 38;
			npc.height = 31;
			npc.damage = 108;
			npc.defense = 41;
			npc.lifeMax = 1958;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 500f;
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
            npc.lifeMax = 3841;
            npc.damage = 217;
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 5; i++)
			{
				int dustType = 37;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
			if (npc.life <= 0)
			{
				if ((Main.rand.Next(0, 7) == 0 && Main.expertMode) || (Main.rand.Next(0, 8) == 0 && !Main.expertMode))
					NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("SilvervoidSpirit"));
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
			if (Timer % 300 == 0)
				Projectile.NewProjectile(npc.Center, (npc.DirectionTo(target2)) * 7.5f, mod.ProjectileType("SilvervoidPelletHostile"), 60, 1f, Main.myPlayer);
			for (int i = 0; i < 2; i++)
			{
				int dustType = 37;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (NPC.downedMoonlord)
					return (SpawnCondition.Crimson.Chance + SpawnCondition.Corruption.Chance) * 0.06f;
			return 0f;
        }
		public override void NPCLoot()
		{
			if (Main.rand.Next(10) == 0)
				Item.NewItem(npc.getRect(), mod.ItemType("ElementamaxSludge"));
		}
	}
}