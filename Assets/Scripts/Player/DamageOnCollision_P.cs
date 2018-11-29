using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision_P : MonoBehaviour {

    public int damage = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<EnemyHealth>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<EnemyHealth>();
        if (health != null)
        {
            health.TakeDamage(1);
        }
    }
}
