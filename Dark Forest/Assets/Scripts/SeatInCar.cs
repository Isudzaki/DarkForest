using UnityEngine;

public class SeatInCar : MonoBehaviour {

    public GameObject car;
    public static bool isSeating;
    private void Start()
    {
        car.GetComponent<MoveCar>().enabled = false;
    }

    private void OnTriggerStay(Collider other) {
        if(Input.GetKeyDown(KeyCode.E) && other.CompareTag("Car") && !isSeating) {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(false);

            car.GetComponent<MoveCar>().enabled = true;

            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<CapsuleCollider>().enabled = false;

            car.transform.GetChild(5).gameObject.SetActive(true);

            Invoke("playerSeated", 0.5f);
        }

    }

    void playerSeated() {
        isSeating = true;
    }

}
