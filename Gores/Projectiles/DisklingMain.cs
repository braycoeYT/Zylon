using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Projectiles
{
	public class DisklingMain : ModGore
	{
		public override string Texture => "Zylon/Gores/Projectiles/DisklingMain";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}