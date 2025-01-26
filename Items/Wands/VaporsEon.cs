using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Items.Materials;

namespace Zylon.Items.Wands
{
	public class VaporsEon : ModItem //This reference was inevitable, Vaporeon is literally my PC background rn
	{
		public override void SetStaticDefaults() {
			Item.staff[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 726;
			Item.width = 68;
			Item.height = 68;
			Item.DamageType = DamageClass.Magic;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5.1f;
			Item.value = Item.sellPrice(0, 35);
			Item.rare = ModContent.RarityType<BraycoeDev>();
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.VaporsEonBlast>();
			Item.shootSpeed = 20f;
			Item.noMelee = true;
			Item.mana = 10;
			Item.UseSound = SoundID.Item21;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            int chance = 0, chance2 = 0;
			if (Main.rand.NextBool(5)) chance = 1;
			if (Main.rand.NextBool(10)) chance2 = 1;

			for (int i = 0; i < (chance*Main.rand.Next(4, 6)+1); i++) {
				Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(25)), ModContent.ProjectileType<Projectiles.Wands.VaporsEonShower>(), (int)(damage*0.75f), knockback/2, Main.myPlayer);
            }

			Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, chance2);

			return false;
        }
		public override void ModifyTooltips(List<TooltipLine> list) {
			TooltipLine xline = new TooltipLine(Mod, "Tooltip0", "~Developer Item (Braycoe)~");
			xline.OverrideColor = new Color(116, 179, 237);
			list.Add(xline);
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.WaterBucket, 2);
			recipe.AddIngredient(ModContent.ItemType<FantasticalFinality>(), 13);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
    }
}