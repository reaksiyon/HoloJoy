using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MoveSpeed = 10f;

    public float RotateSpeed = 10f;

    protected Joystick joystick;

    //

    [SerializeField]
    private Transform player;

    private new Rigidbody rigidbody;

	private Animator animator;

    void Start()
	{
		rigidbody = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

        joystick = FindObjectOfType<Joystick>();
    }
 
    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");

        var vertical = Input.GetAxis("Vertical");

        var direction = new Vector3(joystick.Horizontal + horizontal, 0, joystick.Vertical + vertical);

        rigidbody.velocity = direction.normalized * MoveSpeed;

        if (rigidbody.velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rigidbody.velocity), RotateSpeed * Time.deltaTime);
        }

        animator.SetFloat("speed", rigidbody.velocity.magnitude);
    }

}

