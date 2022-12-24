using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Whips
{
	public class MeteslapDebuff : ModBuff
	{
		public override void SetStaticDefaults() {
			BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
		}
		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<SlimewhipperDebuffNPC>().markedByThisWhip = true;
		}
	}
	public class MeteslapDebuffNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		public bool markedByThisWhip;
		public override void ResetEffects(NPC npc) {
			markedByThisWhip = false;
		}
		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
			if (markedByThisWhip && !projectile.npcProj && !projectile.trap && (projectile.minion || ProjectileID.Sets.MinionShot[projectile.type])) {
				damage += 6;
			}
		}
	}
}