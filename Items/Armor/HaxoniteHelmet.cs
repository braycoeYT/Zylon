using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class HaxoniteHelmet : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases armor penetration and critical strike chance by 2");
		}
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
			player.setBonus = "Gives the player a short flame orb trail when moving";
			if (player.velocity.Length() > 0f && (Timer % 20 == 0))
				Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, new Microsoft.Xna.Framework.Vector2(), ModContent.ProjectileType<Projectiles.HaxoniteTrail>(), 15, 0.1f, Main.myPlayer);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.HaxoniteBar>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}