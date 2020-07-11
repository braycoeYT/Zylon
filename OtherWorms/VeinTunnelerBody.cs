using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon;

namespace Zylon.NPCs.OtherWorms
{
	public class VeinTunnelerBody : VeinTunnelerPart
	{
		const int MaxCooldown = 240;
		public float ShootCooldown
		{
			get { return npc.ai[0]; }
			set { npc.ai[0] = value; }
		}
		public override void SetDefaults()
		{
			base.SetDefaults();
			npc.width = 18;
			npc.height = 28;
			if (Main.expertMode)
			npc.damage = 34;
			else
			npc.damage = 17;
			npc.defense = 6;
		}
		public override void AI()
		{
			if (JustSpawned)
			{
				ShootCooldown = MaxCooldown;
				JustSpawned = false;
			}
			CheckSegments();
			DustFX();
		}
		private void DustFX()
		{
			if (Main.rand.NextBool(10))
			{
				for (int i = 0; i < 2; i++)
				{
					Dust dust = Dust.NewDustPerfect(npc.position, 183, Alpha: 200);
					dust.noGravity = false;
				}
			}
		}
		public override bool CheckActive()
		{
			return false;
		}
		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return false;
		}
	}
}