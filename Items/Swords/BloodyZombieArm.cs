using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class BloodyZombieArm : ModItem
	{
        public override void SetStaticDefaults() {
            // Tooltip.SetDefault("'Bloodier than ever!'\nInflicts Zombie Rot upon hitting enemies, which can be spread to other nearby enemies");
        }
        public override void SetDefaults() {
			Item.damage = 16;
			Item.DamageType = DamageClass.Melee;
			Item.width = 34;
			Item.height = 34;
			Item.useTime = 31;
			Item.useAnimation = 31;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6.25f;
			Item.value = Item.sellPrice(0, 0, 40);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = false;
		}
<<<<<<< HEAD
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.ZombieRot>(), Main.rand.Next(5, 9)*60);
=======
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.ZombieRot>(), Main.rand.Next(5, 9)*60);
>>>>>>> ProjectClash
        }
        /*public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.ZombieRot>(), Main.rand.Next(5, 9)*60);
        }*/
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ZombieArm);
			recipe.AddIngredient(ModContent.ItemType<Materials.BloodDroplet>(), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}