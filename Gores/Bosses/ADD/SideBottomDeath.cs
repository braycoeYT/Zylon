using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.ADD
{
	public class SideBottomDeath : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/ADD/SideBottomDeath";

		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}