using UnityEngine;

public class playerAttack1 : MonoBehaviour
{
    public AudioSource shootSound;
    public ParticleSystem shoot;
    public GameObject gun;
    public float damage = 10f;
    private bool attack;
    private Collider monster;
    private Animator anim;
    private AudioSource audio;

    private void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !attack && !playerHealth.death)
        {
            shoot.Play();
            shootSound.Play();
        }

        if (Input.GetMouseButtonDown(0) && attack && monster != null && !playerHealth.death)
        {
            monster.GetComponent<enemyHealth>().takeDamage(damage);
            anim.SetTrigger("Attack");
            audio.Play();
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gun.SetActive(false);
            attack = true;
            monster = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gun.SetActive(true);
            attack = false;
            monster = null;
        }
     } 
}
