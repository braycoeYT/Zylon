using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Jelly
{
	public class EldritchTentacleGore : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Jelly/EldritchTentacleGore";

		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}