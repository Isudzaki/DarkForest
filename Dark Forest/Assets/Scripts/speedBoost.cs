using UnityEngine;
using UnityEngine.UI;
public class speedBoost : MonoBehaviour
{
    private bool notSpeed = false;
    public void SetSuperSpeed()
    {
        if (notSpeed)
            return;
        notSpeed = true;
        Player.speed = 20f;
        Invoke("RemoveSpeed", 6f);
    }

    void RemoveSpeed()
    {
        notSpeed = false;
        Player.speed = 7f;
        Destroy(gameObject);
    }
}
