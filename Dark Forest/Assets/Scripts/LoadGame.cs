using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public GameObject player;
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.loadPlayer();

        Vector3 pos = new Vector3(data.position[0], data.position[01], data.position[2]);

        player.transform.position = pos;

        player.GetComponent<playerHealth>().health = data.health;
        player.GetComponent<playerHealth>().setHealthBar();
    }
}
