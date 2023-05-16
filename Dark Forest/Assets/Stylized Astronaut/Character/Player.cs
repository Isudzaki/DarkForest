using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public AudioSource jumpAudio;
	public LayerMask onGround;
	public Transform groundedTransform;
	public float jumpForse = 450f, turnSpeed = 400.0f;
	public static float speed = 7f;

	private Animator anim;
	private Rigidbody rb;
    private float moveDirection;
	private AudioSource audio;

		void Start () {
			rb = GetComponent<Rigidbody>();
			anim = gameObject.GetComponentInChildren<Animator>();
		    audio = GetComponent<AudioSource>();
		}

	void Update ()
	{
		if (!playerHealth.death)
		{
			if (Input.GetKey("w"))
			{
				anim.SetInteger("AnimationPar", 1);
				if(!audio.isPlaying)
				audio.Play();
			}
			else
			{
				anim.SetInteger("AnimationPar", 0);
				if (audio.isPlaying)
					audio.Pause();
			}

			if (Physics.Raycast(groundedTransform.position, Vector3.down, 0.05f, onGround))
				anim.SetBool("isJump", false);

			if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(groundedTransform.position, Vector3.down, 0.05f, onGround))
			{
				rb.AddForce(Vector3.up * jumpForse);
				anim.SetTrigger("jumping");
				anim.SetBool("isJump", true);
				jumpAudio.Play();
			}

			moveDirection = Input.GetAxis("Vertical") * speed * Time.deltaTime;

			rb.MovePosition(transform.position + transform.forward * moveDirection);

			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		}
	}
}
