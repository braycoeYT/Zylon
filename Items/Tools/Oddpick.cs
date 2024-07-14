using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tools
{
	public class Oddpick : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 43;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(0, 3, 75);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.pick = 169;
			//Item.shoot = ProjectileID.WoodenArrowFriendly;
			//Item.shootSpeed = 15f;
		}
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			int myBuff = 0;
			switch (Main.rand.Next(8)) {
				case 0:
					myBuff = BuffID.OnFire;
					break;
				case 1:
					myBuff = BuffID.Confused;
					break;
				case 2:
					myBuff = BuffID.ShadowFlame;
					break;
				case 3:
					myBuff = BuffID.CursedInferno;
					break;
				case 4:
					myBuff = BuffID.Frostburn;
					break;
				case 5:
					myBuff = ModContent.BuffType<Buffs.Debuffs.Shroomed>();
					break;
				case 6:
					myBuff = ModContent.BuffType<Buffs.Debuffs.ZombieRot>();
					break;
				case 7:
					myBuff = ModContent.BuffType<Buffs.Debuffs.BrainFreeze>();
					break;
			}
			target.AddBuff(myBuff, Main.rand.Next(600));
		}
        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo) {
			int myBuff = 0;
			switch (Main.rand.Next(8)) {
				case 0:
					myBuff = BuffID.OnFire;
					break;
				case 1:
					myBuff = BuffID.Confused;
					break;
				case 2:
					myBuff = BuffID.ShadowFlame;
					break;
				case 3:
					myBuff = BuffID.CursedInferno;
					break;
				case 4:
					myBuff = BuffID.Frostburn;
					break;
				case 5:
					myBuff = ModContent.BuffType<Buffs.Debuffs.Shroomed>();
					break;
				case 6:
					myBuff = ModContent.BuffType<Buffs.Debuffs.Timestop>();
					break;
				case 7:
					myBuff = ModContent.BuffType<Buffs.Debuffs.BrainFreeze>();
					break;
			}
			target.AddBuff(myBuff, Main.rand.Next(600));
		}
        public override void UseAnimation(Player player) {
            int num = Main.rand.Next(2, 30);
			Item.useAnimation = num;
			Item.useTime = num;
        }
        /*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            int num = Main.rand.Next(2, 50);
			//Item.useAnimation = num;
			//Item.useTime = num;

			switch (Main.rand.Next(10)) {
				case 0:
					type = ProjectileID.WoodenArrowFriendly;
					break;
				case 1:
					type = ProjectileID.WaterGun;
					break;
				case 2:
					type = ProjectileID.Fireball;
					break;
				case 3:
					type = ProjectileID.ChlorophyteBullet;
					break;
				case 4:
					type = ProjectileID.Grenade;
					break;
				case 5:
					type = ProjectileID.BouncyGrenade;
					break;
				case 6:
					type = ProjectileID.StickyGrenade;
					break;
				case 7:
					type = ProjectileID.ZapinatorLaser;
					break;
				case 8:
					type = ProjectileID.Gungnir;
					break;
				case 9:
					type = ProjectileID.RottenEgg;
					break;
			}
			if (Main.rand.NextBool(10)) Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
			return false;
        }*/
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Obsidian, 8);
			recipe.AddIngredient(ItemID.RainbowBrick, 17);
			recipe.AddIngredient(ModContent.ItemType<Materials.TabooEssence>(), 11);
			recipe.AddIngredient(ItemID.Ectoplasm, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}