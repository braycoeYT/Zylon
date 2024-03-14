using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.Wings
{
	[AutoloadEquip(EquipType.Wings)]
	public class ArchangelWings : ModItem
	{
		public override void SetStaticDefaults() {
			ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(170, 6.5f, 1.5f);
		}
		public override void SetDefaults() {
			Item.width = 36;
			Item.height = 42;
			Item.value = Item.sellPrice(0, 8);
			Item.rare = ItemRarityID.Lime;
			Item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.wingTimeMax = 170;
			if (player.controlJump && player.velocity.Y > 0 && player.wingTime <= 0) player.velocity.Y *= 0.9f; //I sure hope this doesn't break anything important
		
			if (player.controlJump && Main.rand.NextBool(2)) {
				Dust dust = Dust.NewDustDirect(player.position - new Microsoft.Xna.Framework.Vector2(16+16*player.direction, 0), Item.width, Item.height, DustID.IceTorch);
				dust.noGravity = true;
				dust.scale = 0.75f;
            }	
		}
		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.4f;
			ascentWhenRising = 0.2f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 1.5f;
			constantAscend = 0.15f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FairyWings);
			recipe.AddIngredient(ItemType<Materials.SpectralFairyDust>(), 7);
			recipe.AddIngredient(ItemID.Ectoplasm, 7);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}