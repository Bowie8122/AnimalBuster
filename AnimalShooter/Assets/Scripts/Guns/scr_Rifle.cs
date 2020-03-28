using UnityEngine;

public class scr_Rifle : scr_DefaultGun
{
    private void Start()
    {
        damage = 35f;
        range = 100f;
        MaxAmmo = 5f;
        Ammo = MaxAmmo;
        DisplayAmmo();
    }
    public override void Shoot()
    {
        base.Shoot();
        Vector3 Spread = new Vector3(0, 0, 0);
        ShootBullet(Spread);
    }
    public override void ShootBullet(Vector3 Spread)
    {
        base.ShootBullet(Spread);
    }
}
