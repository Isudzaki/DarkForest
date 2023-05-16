using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public bool canHeal = true;
    public LayerMask EnenemyLayer;
    public Color meterialColor;
    public GameObject[] mummyParts;
    public GameObject healthBar;
    public float health = 100f, force = 150f, forceTorque = 100f;
    public bool death;
    private Rigidbody rb;
    private AudioSource audio;
    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, EnenemyLayer))
        {
            string carName = hit.transform.gameObject.name;
            if (Input.GetMouseButtonDown(0) && gameObject.name == carName)
            {
                takeDamage(20f);
            }
        }
    }
    public  void takeDamage(float dameg)
    {
        health -= dameg;
        if(healthBar != null)
          healthBar.transform.localScale = new Vector3(health / 100f, 0.1f, 0.1f);
        if (health <= 0 && !death)
        {
            death = true;
            audio.Play();
            setNewColor(meterialColor);

            foreach (GameObject obj in mummyParts)
                obj.GetComponent<SkinnedMeshRenderer>().material.color = meterialColor;

            Destroy(healthBar);
            GetComponent<Animator>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;

            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.up * force);
            rb.AddTorque(Vector3.back * forceTorque);
        }
    }

    public void setNewColor(Color color)
    {
        foreach (GameObject obj in mummyParts)
            obj.GetComponent<SkinnedMeshRenderer>().material.color = color;
    }
}
