using UnityEngine;
using UnityEngine.UI;

public abstract class scr_DefaultGun : MonoBehaviour
{
    public Camera fpsCam;
    public ParticleSystem particle;
    public GameObject inpactEffect;
    public Text textObject;
    public LayerMask mask;
    bool invertMask = false;
    protected float damage;
    protected float range;
    protected float MaxAmmo;
    protected float Ammo;

    RaycastHit hit;
    LayerMask newMask;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Ammo > 0)
                Shoot();
            else
            {
                Ammo = MaxAmmo;
                DisplayAmmo();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Ammo = MaxAmmo;
            DisplayAmmo();
        }
    }
    public virtual void Shoot()
    {
        particle.Play();
        newMask = ~(invertMask ? ~mask.value : mask.value);
        Ammo--;
        DisplayAmmo();
    }

    //Damage Target
    void GiveDamage(Target s_target)
    {
        s_target.TakeDamage(damage);
    }
    public virtual void ShootBullet(Vector3 Extra)
    {
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward + Extra, out hit, range, newMask))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                GiveDamage(target);
            }

            GameObject ParticleObject = (GameObject)Instantiate(inpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ParticleObject, 0.25f);
        }
    }
    private void OnEnable()
    {
        DisplayAmmo();
    }
    public void DisplayAmmo()
    {
        textObject.text = Ammo.ToString();
    }
}
