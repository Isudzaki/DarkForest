using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public static float damage = 5f;
    private NavMeshAgent agent;
    private Coroutine dmg;
    private Animator anim;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(agent.enabled)
            agent.SetDestination(other.transform.parent.gameObject.transform.position);
        }

        if(other.CompareTag("Attack"))
        {
            if (dmg == null)
                dmg = StartCoroutine(setDamage(other));
            anim.SetBool("isAttack", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GetComponent<moveAgents>().SetNewPath();
        }

        if(other.CompareTag("Attack"))
        {
            StopCoroutine(dmg);
            dmg = null;
            anim.SetBool("isAttack", false);
        }
    }

    IEnumerator setDamage(Collider other)
    {
        while (true)
        {
            if(agent.enabled)
            other.transform.parent.GetComponent<playerHealth>().takeDamage(damage);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
