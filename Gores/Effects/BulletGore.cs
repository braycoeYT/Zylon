using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Effects
{
	public class BulletGore : ModGore
	{
		public override string Texture => "Zylon/Gores/Effects/BulletGore";

		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}