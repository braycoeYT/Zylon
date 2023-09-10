using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class Pandemic : ModItem
	{
        public override void SetStaticDefaults() {
            // Tooltip.SetDefault("Inflicts Flash Pandemic upon hitting enemies, which deals extremely high damage and can be spread to other nearby enemies");
        }
        public override void SetDefaults() {
			Item.damage = 67;
			Item.DamageType = DamageClass.Melee;
			Item.width = 46;
			Item.height = 38;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5.5f;
			Item.value = Item.sellPrice(0, 4, 87);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
		}
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.FlashPandemic>(), Main.rand.Next(2, 5)*60);
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<BloodyZombieArm>());
			recipe.AddIngredient(ItemID.JungleSpores, 15);
			recipe.AddIngredient(ModContent.ItemType<Materials.Oozeberry>(), 20);
			recipe.AddIngredient(ItemID.Glass, 8);
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}