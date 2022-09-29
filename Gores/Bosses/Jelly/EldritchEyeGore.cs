using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Jelly
{
	public class EldritchEyeGore : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Jelly/EldritchEyeGore";

		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}