using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using Terraria.Localization;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class HaxoniteHelmet : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 80);
			Item.rare = ItemRarityID.Green;
			Item.defense = 9;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<HaxoniteBreastplate>() && legs.type == ModContent.ItemType<HaxoniteLeggings>();
		}
        public override void UpdateEquip(Player player) {
			player.GetArmorPenetration(DamageClass.Generic) += 2;
			player.GetCritChance(DamageClass.Generic) += 2;
			Timer++;
        }
		int Timer;
        public override void UpdateArmorSet(Player player) {
			player.setBonus = Language.GetTextValue("Mods.Zylon.Items.HaxoniteHelmet.SetBonus");
			if (player.velocity.Length() > 0f && (Timer % 20 == 0) && player.whoAmI == Main.myPlayer)
				Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, new Microsoft.Xna.Framework.Vector2(), ModContent.ProjectileType<Projectiles.HaxoniteTrail>(), 15, 0.1f, Main.myPlayer);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.HaxoniteBar>(), 10);
			recipe.AddIngredient(ItemID.MeteoriteBar, 4);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}