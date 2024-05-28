﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Whips
{
	public class LivingWhipDebuff : ModBuff
	{
		public static readonly int TagDamage = 1;
		public override void SetStaticDefaults() {
			BuffID.Sets.IsATagBuff[Type] = true;
		}
	}
	public class LivingWhipAdvancedDebuff : ModBuff
	{
		public static readonly int TagDamagePercent = 30;
		public static readonly float TagDamageMultiplier = TagDamagePercent / 100f;
		public override void SetStaticDefaults() {
			BuffID.Sets.IsATagBuff[Type] = true;
		}
	}
	public class LivingWhipDebuffNPC : GlobalNPC
	{
		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers) {
			if (projectile.npcProj || projectile.trap || !projectile.IsMinionOrSentryRelated)
				return;

			var projTagMultiplier = ProjectileID.Sets.SummonTagDamageMultiplier[projectile.type];
			if (npc.HasBuff<LivingWhipDebuff>()) {
				modifiers.FlatBonusDamage += LivingWhipDebuff.TagDamage * projTagMultiplier;
			}

			if (npc.HasBuff<LivingWhipAdvancedDebuff>()) {
				modifiers.ScalingBonusDamage += LivingWhipAdvancedDebuff.TagDamageMultiplier * projTagMultiplier;
				npc.RequestBuffRemoval(ModContent.BuffType<LivingWhipAdvancedDebuff>());
			}
		}
	}
}