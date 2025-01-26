using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Items.Materials;

namespace Zylon.Items.Guns
{
	public class Gunball : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 35);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 8;
			Item.useTime = 4;
			Item.damage = 179;
			Item.width = 86;
			Item.height = 32;
			Item.knockBack = 4f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 17f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = true;
			Item.rare = ModContent.RarityType<SkymanisbtmanDev>();
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            Vector2 temp = Vector2.Normalize(velocity.RotatedBy(MathHelper.PiOver2));
			position += temp*Main.rand.NextFloat(-10f, 10f);

			if (type == ProjectileID.Bullet) type = ModContent.ProjectileType<Projectiles.Guns.Gunball_Proj>();
			if (Main.rand.NextBool(10)) type = ModContent.ProjectileType<Projectiles.Guns.Gunball_Jawbreaker>();
        }
        public override void ModifyTooltips(List<TooltipLine> list) {
			TooltipLine xline = new TooltipLine(Mod, "Tooltip0", "~Developer Item (Skymanisbtman)~");
			xline.OverrideColor = new Color(0, 255, 0);
			list.Add(xline);
        }
        public override bool CanConsumeAmmo(Item ammo, Player player) {
            return Main.rand.NextBool();
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(-72, -4);
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddIngredient(ItemID.HellstoneBar, 4);
			recipe.AddIngredient(ModContent.ItemType<FantasticalFinality>(), 13);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}