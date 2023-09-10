using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Effects.Specialized
{
	public class SilverFauxBulletGore : ModGore
	{
		public override string Texture => "Zylon/Gores/Effects/Specialized/SilverFauxBulletGore";

		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}