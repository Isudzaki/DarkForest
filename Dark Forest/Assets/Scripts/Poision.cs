using UnityEngine;
using UnityEngine.UI;

public class Poision : MonoBehaviour
{

    public void SetSlowTime()
    {
        if (Time.timeScale == 0.5f)
            return;

        Time.timeScale = 0.5f;
        Invoke("RemoveSlowTime", 5f);
    }

    void RemoveSlowTime()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
