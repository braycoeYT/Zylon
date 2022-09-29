using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.ADD
{
	public class SideTopDeath : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/ADD/SideTopDeath";

		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}