using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public float heal = 20f;
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            enemyHealth enemyHealth = other.GetComponent<enemyHealth>();
            if(enemyHealth.canHeal && enemyHealth.death && Input.GetKeyUp(KeyCode.E))
            {
                enemyHealth.canHeal = false;
                enemyHealth.setNewColor(Color.green);

                playerHealth playerHealth = transform.parent.GetComponent<playerHealth>();

                playerHealth.health += heal;
                if (playerHealth.health > 100f)
                    playerHealth.health = 100f;

                playerHealth.setHealthBar();
            }
        }
    }
}
