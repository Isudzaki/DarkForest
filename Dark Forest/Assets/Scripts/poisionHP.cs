using UnityEngine;
using UnityEngine.UI;

public class poisionAttack : MonoBehaviour
{
    private bool notAttack = false;
    public void SetInfinityHealth()
    {
        if (notAttack)
        return;
        notAttack = true;
        EnemyAttack.damage = 0f;
        Invoke("RemoveInfinityHealth", 2f);
    }

    void RemoveInfinityHealth()
    {
        notAttack = false;
        EnemyAttack.damage = 5f;
        Destroy(gameObject);
    }
}
