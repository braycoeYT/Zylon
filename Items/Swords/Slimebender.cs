using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Items.Materials;

namespace Zylon.Items.Swords
{
	public class Slimebender : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 298;
			Item.DamageType = DamageClass.Melee;
			Item.width = 92;
			Item.height = 92;
			Item.useTime = 7;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5.5f;
			Item.value = Item.sellPrice(0, 35);
			Item.rare = ModContent.RarityType<BraycoeDev>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.SlimebenderSlash>();
			Item.shootSpeed = 5f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float slashRot = Main.rand.NextFloat(-180, 180f);

			float dist = Vector2.Distance(player.Center, Main.MouseWorld);
			if (dist > 350f) dist = 350f; //Don't go too far - this is melee, after all.

			Vector2 offset = player.Center.DirectionTo(Main.MouseWorld)*dist; //Where the slash spawns.
			Vector2 offset2 = new Vector2(Main.rand.Next(-8, 9), -150).RotatedBy(MathHelper.ToRadians(slashRot)); //Fixes slash positioning + randomizing it.
			
			Projectile.NewProjectile(source, player.Center+offset+offset2+player.velocity, new Vector2(0, velocity.Length()).RotatedBy(MathHelper.ToRadians(slashRot)), type, damage/3, knockback/2, Main.myPlayer);
			return false;
        }
        public override void ModifyTooltips(List<TooltipLine> list) {
			TooltipLine xline = new TooltipLine(Mod, "Tooltip0", "~Developer Item (Braycoe)~");
			xline.OverrideColor = new Color(116, 179, 237);
			list.Add(xline);
        }
		/*public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Item.position, Item.width, Item.height, DustID.Ice);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
		}*/
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Slimecutter>());
			recipe.AddIngredient(ItemID.Gel, 100);
			recipe.AddIngredient(ModContent.ItemType<ElementalGoop>(), 25);
			recipe.AddIngredient(ModContent.ItemType<FantasticalFinality>(), 13);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}