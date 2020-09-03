using Microsoft.Xna.Framework;
using System.Collections.Specialized;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Items.OtherBows;

namespace Zylon.NPCs.Microbiome.PZME
{
	public class MorbusRose : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Morbus Rose");
		}
        public override void SetDefaults()
		{
			npc.width = 45; //28
			npc.height = 43; //27
			npc.damage = 143;
			npc.defense = 24;
			npc.lifeMax = 5928;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 2990f;
			npc.aiStyle = 44;
			npc.knockBackResist = 0f;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Slow] = true;
			npc.buffImmune[BuffID.Weak] = true;
			npc.buffImmune[BuffID.Chilled] = true;
			npc.buffImmune[BuffID.Frozen] = true;
			npc.buffImmune[BuffID.Burning] = true;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Venom] = true;
			npc.buffImmune[mod.BuffType("Sick")] = true;
			npc.noTileCollide = true;
			npc.noGravity = true;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.rand.NextBool(2))
				Projectile.NewProjectile(npc.Center, new Vector2(0, 2).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("MorbusPetal"), 41, 1f, Main.myPlayer);
			int dustType = mod.DustType("MicrobiomeDust");
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 10293;
            npc.damage = 312;
        }
		
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool(2))
				player.AddBuff(mod.BuffType("Sick"), 700, true);
		}
		int Timer;
		public override void AI()
		{
			Timer++;
			if (Main.player[npc.target].statLife < 1)
			{
				npc.TargetClosest(true);
			}
			Player target = Main.player[npc.target];
			if (Timer % 120 == 0)
			{
				if (Main.rand.Next(0, 2) == 0 || (NPC.CountNPCS(ModContent.NPCType<NPCs.Microbiome.PZME.MiniMorbusRose>()) > 6))
					Projectile.NewProjectile(npc.Center, (npc.DirectionTo(target.position)) * 4, ProjectileID.EyeLaser, 59, 1f, Main.myPlayer);
				else
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("MiniMorbusRose"));
			}
			npc.rotation += 0.02f;
			Lighting.AddLight(npc.position, 0.15f, 0.3f, 0.15f);
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (ZylonWorld.downedMineral)
			{
				return spawnInfo.player.GetModPlayer<ZylonPlayer>().ZoneMicrobiome ? 0.1f : 0f;
			}
			return 0f;
        }
		
	    public override void NPCLoot()
        {
            if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), mod.ItemType("InfectedOnyx"));
			if (Main.rand.Next(3) == 0)
				Item.NewItem(npc.getRect(), mod.ItemType("SilvervoidCore"));
			if (Main.rand.Next(4) == 0)
				Item.NewItem(npc.getRect(), mod.ItemType("NucleusShard"));
		}
	}
}