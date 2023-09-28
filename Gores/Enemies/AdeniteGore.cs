using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Enemies
{
	public class AdeniteGore : ModGore
	{
		public override string Texture => "Zylon/Gores/Enemies/AdeniteGore";

		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}