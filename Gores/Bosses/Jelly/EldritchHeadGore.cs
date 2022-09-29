using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Jelly
{
	public class EldritchHeadGore : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Jelly/EldritchHeadGore";

		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}