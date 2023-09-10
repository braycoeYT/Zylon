using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class TestBlowpipe2 : ZylonBlowpipe
	{
		public TestBlowpipe2() : base(200, 2f, new Color(0, 0, 0)) { } //int maxChargeI, float chargeRateI, Color textColorI, float chargeRetainI = 0f, float minshootspeedI = 0f, bool maxReplaceI = false
		public override void SetStaticDefaults() {
<<<<<<< HEAD
			Tooltip.SetDefault("Truly the blowpipe of all time");
=======
			// Tooltip.SetDefault("Truly the blowpipe of all time");
>>>>>>> ProjectClash
		}
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 15;
			Item.knockBack = 2.5f;
			Item.shootSpeed = 8f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.value = Item.sellPrice(0, 5);
			Item.rare = ItemRarityID.Pink;
			Item.autoReuse = true;
        }
    }
}