using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Dirtball
{
	public class DS17GoreLeft : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Dirtball/DS17GoreLeft";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}