using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Projectiles
{
	public class DisklingSpike : ModGore
	{
		public override string Texture => "Zylon/Gores/Projectiles/DisklingSpike";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}