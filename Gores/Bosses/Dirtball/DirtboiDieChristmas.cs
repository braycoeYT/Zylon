using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Dirtball
{
	public class DirtboiDieChristmas : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Dirtball/DirtboiDieChristmas";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}