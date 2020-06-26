using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Empress
{
	public class MonarchalGel : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Monarchal Gel");
			Tooltip.SetDefault("You are a slime monarch\nMost slimes are friendly\nWhen you get hurt, you unleash a barrage of empress spikes");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 1500000;
			item.rare = 8;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.npcTypeNoAggro[1] = true;
			player.npcTypeNoAggro[16] = true;
			player.npcTypeNoAggro[59] = true;
			player.npcTypeNoAggro[71] = true;
			player.npcTypeNoAggro[81] = true;
			player.npcTypeNoAggro[138] = true;
			player.npcTypeNoAggro[121] = true;
			player.npcTypeNoAggro[122] = true;
			player.npcTypeNoAggro[141] = true;
			player.npcTypeNoAggro[147] = true;
			player.npcTypeNoAggro[183] = true;
			player.npcTypeNoAggro[184] = true;
			player.npcTypeNoAggro[204] = true;
			player.npcTypeNoAggro[225] = true;
			player.npcTypeNoAggro[244] = true;
			player.npcTypeNoAggro[302] = true;
			player.npcTypeNoAggro[333] = true;
			player.npcTypeNoAggro[335] = true;
			player.npcTypeNoAggro[334] = true;
			player.npcTypeNoAggro[336] = true;
			player.npcTypeNoAggro[537] = true;
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.empressSpikes = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RoyalGel);
			recipe.AddIngredient(mod.ItemType("SpikySac"));
			recipe.AddIngredient(mod.ItemType("EmpressShard"), 3);
			recipe.AddIngredient(mod.ItemType("ElementamaxSludge"), 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}