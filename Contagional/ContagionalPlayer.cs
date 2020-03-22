using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Items.Contagional
{
	public class ContagionalPlayer : ModPlayer
	{
		public static ContagionalPlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<ContagionalPlayer>();
		}

		public int ContagionalDamageAdd;
		public float ContagionalDamageMult = 1f;
		public float ContagionalKnockback;
		public int ContagionalCrit;
		public int ContagionalResourceCurrent;
		public const int DefaultContagionalResourceMax = 600;
		public int ContagionalResourceMax;
		public int ContagionalResourceMax2;
		public float ContagionalResourceRegenRate;
		public bool ContagionalCanRegen = true;
		internal int ContagionalResourceRegenTimer = 0;
		public int ContagionalRegenAmount = 6;
		public static readonly Color HealContagionalResource = new Color(75, 161, 91);

		public override void Initialize() {
			ContagionalResourceMax = DefaultContagionalResourceMax;
		}

		public override void ResetEffects() {
			ResetVariables();
		}

		public override void UpdateDead() {
			ResetVariables();
		}

		private void ResetVariables() {
			ContagionalDamageAdd = 0;
			ContagionalDamageMult = 1f;
			ContagionalKnockback = 0f;
			ContagionalCrit = 0;
			ContagionalResourceRegenRate = 1f;
			ContagionalResourceMax2 = ContagionalResourceMax;
		}

		public override void PostUpdateMiscEffects()
		{
			UpdateResource();
		}

		private void UpdateResource()
		{
			ContagionalResourceRegenTimer++;
			if (ContagionalResourceRegenTimer > 60 * ContagionalResourceRegenRate)
			{
				ContagionalResourceCurrent += ContagionalRegenAmount;
				ContagionalResourceRegenTimer = 0;
			}
			ContagionalResourceCurrent = Utils.Clamp(ContagionalResourceCurrent, 0, ContagionalResourceMax2);
		}
	}
}