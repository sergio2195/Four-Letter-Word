using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;

    [SerializeField]
    private float health;

    [SerializeField]
    private Image lifeBar;

    [SerializeField]
    private GameObject explosion;

    public void TakeDamage(float amount)
    {
        health -= amount;

        lifeBar.fillAmount = health / maxHealth;

        if (health <= 0f)
        {
            Die();
        }

        if (lifeBar.fillAmount <= .5f)
            lifeBar.GetComponent<Image>().color = Color.yellow;

        if(lifeBar.fillAmount <= .25f)
            lifeBar.GetComponent<Image>().color = Color.red;

    }

    private void Die()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
