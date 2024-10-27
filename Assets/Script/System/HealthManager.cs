using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float maxHealth = 100.0f;
    private float currentHealth = 0.1f;

    private CapsuleCollider capsuleCollider;
    public GameObject DeathParticle;

    void Start()
    {
        currentHealth = maxHealth;
        capsuleCollider = GetComponent<CapsuleCollider>();

        if(capsuleCollider)
        {
            capsuleCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        DamageCauser damageCauser = other.GetComponentInChildren<DamageCauser>();
        if(damageCauser)
        {
            float attackedDamage = damageCauser.Damage;
            currentHealth -= attackedDamage;

            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            if(currentHealth <= 0)
            {
                if(DeathParticle)
                {
                    GameObject clone = Instantiate(DeathParticle);
                    clone.transform.position = transform.position;
                    clone.transform.rotation = transform.rotation;
                }

                GamePlayManager.instance.EnemyDeathEvent.Invoke();
                
                if(transform.parent)
                {
                    Destroy(transform.parent.gameObject);
                }else
                {
                    Destroy(transform.gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
