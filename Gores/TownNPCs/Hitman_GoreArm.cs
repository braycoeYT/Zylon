using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.TownNPCs
{
	public class Hitman_GoreArm : ModGore
	{
		public override string Texture => "Zylon/Gores/TownNPCs/Hitman_GoreArm";

		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}