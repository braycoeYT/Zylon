using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Projectiles
{
	public class DirtBlockExp_1 : ModGore
	{
		public override string Texture => "Zylon/Gores/Projectiles/DirtBlockExp_1";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}