using UnityEngine;
using System.Collections;

public class EliController : MonoBehaviour {
	
	public Vector2 speed = new Vector2(15, 15);
	private Vector2 movement;
	private Animator animator;
	public Vector2 jumpForce = new Vector2(0f, 50f);
	private Transform groundDetector;
	private bool grounded;
	private bool facingRight = true;
	private float radius = 50.0f;  //this is how far it checks for other objects


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		groundDetector = transform.Find("GroundDetector");
	}

	void GetControls() {

		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		if (inputX != 0) {
			if (inputX < 0 && facingRight) {
				facingRight = false;
				transform.Rotate (Vector3.up * -180);
					//Quaternion.LookRotation(new Vector2(-1, 0));
				//transform.localScale = new Vector2(180, transform.localScale.y);
			} else if (inputX > 0){
				if (!facingRight) {
					transform.Rotate (Vector3.up * -180);
					facingRight = true;
				}
			}
			animator.SetBool ("walk", true);
		} else {
			animator.SetBool ("walk", false);
		}

		if (inputY > 0) {
				animator.SetBool ("Jump", true);
				
		} else {
				animator.SetBool ("Jump", false);
		}

		if (inputY < 0) {
			animator.SetBool ("crouch", true);
		} else {
			animator.SetBool ("crouch", false);
		}

		movement = new Vector2(
			speed.x * inputX,
			rigidbody2D.velocity.y);
	}

	private bool IsGrounded(){
		RaycastHit2D[] results = new RaycastHit2D[1];
		int i = Physics2D.LinecastNonAlloc (transform.position, groundDetector.position, results, 1 << LayerMask.NameToLayer ("Terrain"));
		return i > 0;  

	}
	
	// Update is called once per frame
	void Update () {
		this.GetControls ();
		if (!IsGrounded ()) {
			animator.SetBool ("Jump", true);
		}

	}

	void FixedUpdate()
	{	

		if (IsGrounded() && animator.GetBool ("Jump")) {
			this.audio.Play();
			rigidbody2D.AddForce(jumpForce);
		}

		rigidbody2D.velocity = movement;
	}

	void OnGui() {

	}

	void OnCollisionEnter(Collision collision) 
	{
		print( "ground" );
	}
	

}
