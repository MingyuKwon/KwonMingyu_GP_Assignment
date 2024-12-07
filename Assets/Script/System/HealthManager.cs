using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float maxHealth = 100.0f;
    private float currentHealth = 0.1f;
    public bool bPlayerHealth = false;
    public bool bNexusHealth = false;

    private CapsuleCollider capsuleCollider;
    public GameObject DeathParticle;

    private Animator animator;

    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();

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

            if(bNexusHealth)
            {
                GamePlayManager.instance.NexusHealthUpdateEvent.Invoke(currentHealth / maxHealth);
            }else
            {
                if(bPlayerHealth)
                {
                    GamePlayManager.instance.PlayerHealthUpdateEvent.Invoke(currentHealth / maxHealth);
                }
            }

            if(currentHealth <= 0)
            {
                AudioManager.instance.PlaySound(AudioManager.EAudioType.EAT_EnemyDeath, 1, Camera.main.transform.position);

                if(DeathParticle)
                {
                    GameObject clone = Instantiate(DeathParticle);
                    clone.transform.position = transform.position;
                    clone.transform.rotation = transform.rotation;
                }


                if(bPlayerHealth)
                {
                    GamePlayManager.instance.GameOverEvent.Invoke();
                }else{
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
    }
}
