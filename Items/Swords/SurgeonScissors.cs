using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class SurgeonScissors : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 74;
			Item.DamageType = DamageClass.Melee;
			Item.width = 52;
			Item.height = 52;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4.5f;
			Item.value = Item.sellPrice(0, 3);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.SurgeonScissorsProj>();
			Item.shootSpeed = 3f;
		}
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
            charge += 5;
			if (charge > 20) charge = 20;

			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BleedingEnemy>(), Main.rand.Next(8, 13)*60);
        }
        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo) {
            charge += 5;
			if (charge > 20) charge = 20;

			target.AddBuff(BuffID.Bleeding, Main.rand.Next(8, 13)*60);
        }
        int charge;
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			if (charge > 0) {
				charge--;

				float slashRot = Main.rand.NextFloat(-180, 180f);

				Vector2 offset = player.Center.DirectionTo(Main.MouseWorld)*90f; //Where the slash spawns.
				Vector2 offset2 = new Vector2(0, -90).RotatedBy(MathHelper.ToRadians(slashRot)); //Fixes slash positioning + randomizing it.
			
				Projectile.NewProjectile(source, player.Center+offset+offset2+player.velocity, new Vector2(0, 3).RotatedBy(MathHelper.ToRadians(slashRot)), type, damage, knockback*1.5f, Main.myPlayer, player.direction);
			}
			return false;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StylistKilLaKillScissorsIWish);
			recipe.AddRecipeGroup("Zylon:AnyAdamantiteBar", 10);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}