using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Adeneb
{
	public class Adeneb_SpikeLower : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Adeneb/Adeneb_SpikeLower";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}