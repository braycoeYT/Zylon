using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon;
using Zylon.NPCs.OtherWorms;

namespace Zylon.NPCs.OtherWorms
{
	public class VeinTunnelerTail : VeinTunnelerPart
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			npc.width = 18;
			npc.height = 36;
			if (Main.expertMode)
			npc.damage = 26;
			else
			npc.damage = 14;
			npc.defense = 10;
		}

		public override void AI()
		{
			CheckSegments();
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