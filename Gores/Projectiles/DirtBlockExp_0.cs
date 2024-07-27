using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Projectiles
{
	public class DirtBlockExp_0 : ModGore
	{
		public override string Texture => "Zylon/Gores/Projectiles/DirtBlockExp_0";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}