using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Adeneb
{
	public class Adeneb_Ankh : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Adeneb/Adeneb_Ankh";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}