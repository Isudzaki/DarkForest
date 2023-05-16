using UnityEngine;

public class EnemyName : MonoBehaviour
{
    public GameObject[] enemy;
    private int countEnemys;
    //public RewordAds rAd;


    private void Start()
    {
        //rAd.LoadAd();
        enemy[0].name = "Enemy " + ++countEnemys;
        enemy[1].name = "Enemy " + ++countEnemys;
        enemy[2].name = "Enemy " + ++countEnemys;
    }
}
