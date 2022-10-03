using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Enemies
{
	public class DesertDiskiteGore : ModGore
	{
		public override string Texture => "Zylon/Gores/Enemies/DesertDiskiteGore";

		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}