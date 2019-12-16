using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float Speed = 4f;

    [SerializeField]
    float RotationSpeed = 10f;

    Rigidbody Rb;
    Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Rb.velocity = new Vector3(h * Speed, Rb.velocity.y, v * Speed);

        if (h != 0f || v != 0) {
            Anim.SetInteger("state", 1);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(new Vector3(h, 0f, v)),
                Time.deltaTime * RotationSpeed
            );
        }
        else {
            Anim.SetInteger("state", 0);
        }
    }
}
