using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;

namespace Zylon.Items.Accessories
{
	public class OverchargedManaCapsule : ModItem
	{
		public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4)); //first is speed, second is amount of frames
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }
		public override void SetDefaults() {
			Item.width = 50;
			Item.height = 72;
			Item.value = Item.sellPrice(0, 3);
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			
            if (player.velocity.X < 0.01f && player.velocity.Y < 0.01f) player.manaRegen += 2;
			if (!player.ZoneUnderworldHeight && !player.ZoneRockLayerHeight && !player.ZoneDirtLayerHeight && Main.dayTime)
				player.statManaMax2 += 40;
			else player.statManaMax2 += 10;

			p.sparkingCore = true;

			if (player.statMana < 20 && !player.HasBuff(ModContent.BuffType<Buffs.Accessories.ManaRechargeCooldown>())) {
				SoundEngine.PlaySound(SoundID.Item27);
				player.ManaEffect(player.statManaMax2-player.statMana);
				player.statMana = player.statManaMax2;
				player.AddBuff(ModContent.BuffType<Buffs.Accessories.ManaRechargeCooldown>(), 30*60);
            }
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ManaPod>());
			recipe.AddIngredient(ModContent.ItemType<SparkingCore>());
			recipe.AddIngredient(ModContent.ItemType<ManaBattery>());
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}