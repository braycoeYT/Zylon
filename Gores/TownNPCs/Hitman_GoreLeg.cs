using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.TownNPCs
{
	public class Hitman_GoreLeg : ModGore
	{
		public override string Texture => "Zylon/Gores/TownNPCs/Hitman_GoreLeg";

		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}