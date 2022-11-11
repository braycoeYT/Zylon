using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Effects
{
	public class ShotgunBulletGore : ModGore
	{
		public override string Texture => "Zylon/Gores/Effects/ShotgunBulletGore";

		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}