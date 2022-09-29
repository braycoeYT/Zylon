using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.ADD
{
	public class ADDCenterDeath : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/ADD/ADDCenterDeath";

		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}