using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Dirtball
{
	public class DS17Gore : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Dirtball/DS17Gore";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}