using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Whips
{
	public class SlimewhipperDebuff : ModBuff
	{
		public override void SetStaticDefaults() {
			BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
		}
		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<WhipDebuffNPC>().markedByThisWhip = true;
		}
	}
	public class WhipDebuffNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		public bool markedByThisWhip;
		public override void ResetEffects(NPC npc) {
			markedByThisWhip = false;
		}
		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
			if (markedByThisWhip && !projectile.npcProj && !projectile.trap && (projectile.minion || ProjectileID.Sets.MinionShot[projectile.type])) {
				damage += 5;
			}
		}
	}
}