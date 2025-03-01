using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.TownNPCs
{
	public class Hitman_GoreHead : ModGore
	{
		public override string Texture => "Zylon/NPCs/TownNPCs/Hitman_Head";

		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}