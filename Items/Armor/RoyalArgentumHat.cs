using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RoyalArgentumHat : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 15);
			Item.rare = ModContent.RarityType<Magenta>();
			Item.defense = 12;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<RoyalArgentumChestpiece>() && legs.type == ModContent.ItemType<RoyalArgentumBoots>();
		}
        public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.GetDamage(DamageClass.Magic) += 0.21f;
			player.GetCritChance(DamageClass.Magic) += 21;
			player.manaCost -= 0.08f;
			if (player.statLife < player.statLifeMax2/4) player.manaRegen += 2;
        }
        public override void UpdateArmorSet(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.setBonus = "Increases magic damage by 11%\nSummons four Argentum Orbs to defend you\nArgentum Orbs fire short beams at nearby enemies";
			player.GetDamage(DamageClass.Magic) += 0.11f;
			p.argentumSetBonus = true;
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.ArgentumOrb>()] < 4 && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Minions.ArgentumOrb>(), 200, 4f, Main.myPlayer, player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.ArgentumOrb>()]);
			}
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SilverHelmet);
			recipe.AddIngredient(ModContent.ItemType<Materials.FantasticalFinality>(), 4);
			recipe.AddIngredient(ItemID.FragmentNebula, 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TungstenHelmet);
			recipe.AddIngredient(ModContent.ItemType<Materials.FantasticalFinality>(), 4);
			recipe.AddIngredient(ItemID.FragmentNebula, 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}