using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Adeneb
{
	public class Adeneb_SpikeUpper : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Adeneb/Adeneb_SpikeUpper";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}