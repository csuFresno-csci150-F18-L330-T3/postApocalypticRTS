using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public RectTransform healthBar;
   

  
        void OnTriggerEnter2D(Collider2D other)
        {
            //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
            if (other.gameObject.name == "Parts")
            {
            Destroy(other.gameObject);
            //other.gameObject.SetActive(false);
            
            
        }

    }

    


    public void TakeDamage(int amount)
    {

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
            Debug.Log("Dead!");
        }

        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

}