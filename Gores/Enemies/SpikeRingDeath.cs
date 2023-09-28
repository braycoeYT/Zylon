using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Enemies
{
	public class SpikeRingDeath : ModGore
	{
		public override string Texture => "Zylon/Gores/Enemies/SpikeRingDeath";

		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}