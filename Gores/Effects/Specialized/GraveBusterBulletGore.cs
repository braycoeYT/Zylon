using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Effects.Specialized
{
	public class GraveBusterBulletGore : ModGore
	{
		public override string Texture => "Zylon/Gores/Effects/Specialized/GraveBusterBulletGore";

		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}