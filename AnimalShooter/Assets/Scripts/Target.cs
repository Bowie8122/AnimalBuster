using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public float health = 50f;
    float Maxhealth;
    bool DB = false;
    void Start()
    {
        Maxhealth = health;
        GameManager.Instance.Animals += 1;
        GameManager.Instance.UpdateText();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (DB == false)
        {
            DB = true;
            GameManager.Instance.Animals -= 1;
            GameManager.Instance.UpdateText();
            Destroy(gameObject);
        }
    }
}
