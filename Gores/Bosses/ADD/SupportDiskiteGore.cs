using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.ADD
{
	public class SupportDiskiteGore : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/ADD/SupportDiskiteGore";

		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}