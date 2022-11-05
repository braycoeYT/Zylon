using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class Eternia2000 : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Eternia 2000");
			Tooltip.SetDefault("UNOBTAINABLE: Will probably be obtainable when I make PML content.\n'Not to be confused with the Eternia 995'\nReleases Vinyl Discs, LP Rockets, and World-Ending Meteors\nDamaging enemies has a chance to inflict Broken Karta (a shatter sound plays and '!!!' appear above the enemy each time this happens)\nPure melee has a much higher chance of inflicting Broken Karta than projectiles.\nInflicting Broken Karta three times will replace the debuff with Severe Bleeding.\nThis debuff lasts until you don't damage the enemy for a bit.\nSevere Bleeding has lower effect on bosses"); //I yiiked my pants creating this weapon
		}
		public override void SetDefaults()
		{
			Item.damage = 129;
			Item.DamageType = DamageClass.Melee;
			Item.width = 66;
			Item.height = 66;
			Item.useTime = 19;
			Item.useAnimation = 19;
			Item.useStyle = 1;
			Item.knockBack = 6.3f;
			Item.value = 200000;
			Item.rare = 10;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.VinylDisc>();
			Item.shootSpeed = 22f;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			if (target.HasBuff(ModContent.BuffType<Buffs.SevereBleeding>())) {
				target.AddBuff(ModContent.BuffType<Buffs.SevereBleeding>(), 90);
			}
			else if (Main.rand.NextBool(5)) {
				SoundEngine.PlaySound(SoundID.Shatter, target.position);
				if (target.HasBuff(ModContent.BuffType<Buffs.BrokenKarta2>()))
					target.AddBuff(ModContent.BuffType<Buffs.SevereBleeding>(), 120);
				else if (target.HasBuff(ModContent.BuffType<Buffs.BrokenKarta1>()))
					target.AddBuff(ModContent.BuffType<Buffs.BrokenKarta2>(), 3600);
				else
					target.AddBuff(ModContent.BuffType<Buffs.BrokenKarta1>(), 3600);
				CombatText.NewText(target.getRect(), Color.Crimson, "!!!");
			}
		}
        public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
			if (target.HasBuff(ModContent.BuffType<Buffs.SevereBleeding>())) {
				target.AddBuff(ModContent.BuffType<Buffs.SevereBleeding>(), 90);
			}
			else if (Main.rand.NextBool(5)) {
				SoundEngine.PlaySound(SoundID.Shatter, target.position);
				if (target.HasBuff(ModContent.BuffType<Buffs.BrokenKarta2>()))
					target.AddBuff(ModContent.BuffType<Buffs.SevereBleeding>(), 120);
				else if (target.HasBuff(ModContent.BuffType<Buffs.BrokenKarta1>()))
					target.AddBuff(ModContent.BuffType<Buffs.BrokenKarta2>(), 3600);
				else
					target.AddBuff(ModContent.BuffType<Buffs.BrokenKarta1>(), 3600);
				CombatText.NewText(target.getRect(), Color.Crimson, "!!!");
			}
		}
        int shootCount;
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			shootCount++;
			damage = (int)(damage * 0.5f);
			knockback = 1f;
			int numberProjectiles = 7 + Main.rand.Next(4);
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(velocity.X * (Main.rand.NextFloat() + 0.1f), velocity.Y * (Main.rand.NextFloat() + 0.5f)).RotatedByRandom(MathHelper.ToRadians(20));
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}

			float rotation;
			for (float j = 0; j < 4; j++) {
				numberProjectiles = 2;
				rotation = MathHelper.ToRadians((float)(12f + (6*j)));
				position += Vector2.Normalize(velocity) * (float)(12f + (6 * j));
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .6f;
					Projectile.NewProjectile(source, position, perturbedSpeed, ModContent.ProjectileType<Projectiles.Swords.LPRocket>(), damage, knockback, player.whoAmI);
				}
			}
			if (shootCount % 5 == 4)
				Projectile.NewProjectile(source, new Vector2(Main.MouseWorld.X, position.Y - 400), new Vector2(Main.rand.NextFloat(-1.5f, 1.5f), 12), ModContent.ProjectileType<Projectiles.Swords.WorldEndingMeteor>(), damage * 2, knockback * 1.5f, player.whoAmI);
			return false;
		}
		/*public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddIngredient(ItemID.LunarBar, 20);
			recipe.AddIngredient(ItemID.FragmentSolar, 25);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}*/
	}
}