using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Adeneb
{
	public class AdenebDead3 : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Adeneb/AdenebDead3";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}