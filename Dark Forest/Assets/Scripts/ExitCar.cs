using UnityEngine;

public class ExitCar : MonoBehaviour {

    public GameObject player;

    private void Start()
    {
        GetComponent<MoveCar>().enabled = true;
    }

    private void Update() {

        if (SeatInCar.isSeating && Input.GetKeyDown(KeyCode.E)) {
            player.transform.position = transform.GetChild(6).gameObject.transform.position;
            player.transform.GetChild(0).gameObject.SetActive(true);
            player.transform.GetChild(1).gameObject.SetActive(true);
            player.transform.GetChild(2).gameObject.SetActive(true);
            player.transform.GetChild(3).gameObject.SetActive(true);
            player.transform.GetChild(4).gameObject.SetActive(true);
            player.transform.GetChild(5).gameObject.SetActive(true);
            GetComponent<MoveCar>().enabled = false;

            player.GetComponent<Rigidbody>().isKinematic = false;
            player.GetComponent<CapsuleCollider>().enabled = true;

            transform.GetChild(5).gameObject.SetActive(false);

            SeatInCar.isSeating = false;
        }
    }

}
