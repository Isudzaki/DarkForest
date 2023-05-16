using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPause = false;
    public GameObject pauseMenu;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!isPause)
            {
                pauseMenu.SetActive(true); 
                Time.timeScale = 0;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
            isPause = !isPause;
        }
    }
}

