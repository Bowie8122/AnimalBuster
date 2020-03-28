using UnityEngine;

public class scr_Shotgun : scr_DefaultGun
{
    private int ShotCount = 28;
    private void Start()
    {
        damage = 2.5f;
        range = 35f;
        MaxAmmo = 10f;
        Ammo = MaxAmmo;
        DisplayAmmo();
    }
    public override void Shoot()
    {
        base.Shoot();
        for (int i = 0; i < ShotCount; i++)
        {
            Vector3 Spread = (fpsCam.transform.right * Random.Range(-0.45f, 0.45f)) + (fpsCam.transform.up * Random.Range(-0.45f, 0.45f));
            ShootBullet(Spread);
        }
    }
    public override void ShootBullet(Vector3 Spread)
    {
        base.ShootBullet(Spread);
    }
}
