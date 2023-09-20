using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Boomerangs
{
	public class Mephiles : ModItem
	{
		public override void SetDefaults() { //Reference to Sonic '06
			Item.damage = 63;
			Item.DamageType = DamageClass.Melee;
			Item.width = 78;
			Item.height = 62;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6.2f;
			Item.value = Item.sellPrice(0, 4, 65);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item74;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.Mephiles>();
			Item.shootSpeed = 12f;
			Item.noUseGraphic = true;
			Item.scale = 0.75f;
		}
        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            TooltipLine line = new TooltipLine(Mod, "Tooltip#0", "'WELCOME TO TILTED TOWERS' -Memphis, Tennessee");
			int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
			if (month == 4 && day == 1 && ModContent.GetInstance<ZylonConfig>().aprilFoolsChanges) tooltips.Add(line);
        }
        public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot) {
                    return false;
                }
            }
            return true;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.TabooEssence>(), 18);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}