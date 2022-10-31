using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Dirtball
{
	public class DirtboiDie : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Dirtball/DirtboiDie";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}