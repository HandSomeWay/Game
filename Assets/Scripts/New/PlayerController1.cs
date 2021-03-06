using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody rb1;
    private Animator Amt;
    public bool Crouch;

    public Collider capsule;
    public GameObject Model_A;
    public float speed;//移动速度
    public float jumpForce;//跳跃的力
    public bool isGround;//是否在地面

    void Awake() 
   {
        //获取组件
        rb1=GetComponent<Rigidbody>();
        Amt = Model_A.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        Crouch = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Crouch)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 90f));
            speed = 2.5f;
        }
        else 
            speed = 5f;
        if (Input.GetKeyDown(KeyCode.C))
        {
            Crouch = !Crouch;
        }
        capsule.isTrigger = Crouch;
        Amt.SetBool("Crouch", Crouch);
        if (Input.GetKeyDown(KeyCode.J))
            Jump();
        AnimationChg();
    }
    void FixedUpdate()
    {
        rb1.AddForce(new Vector3(0f, 0f, -9f));
        if (!ModeController.GameOver)
        {
            GroundMovement();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trap")
        {
            Amt.SetTrigger("Dead");
            ModeController.GameOver = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Finish")
            ModeController.Victory = true;
        if (other.tag == "Ground")
            isGround = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
            isGround = false;
    }
    void GroundMovement()
    {
        int dirHor = 0;
        if (Input.GetKey(KeyCode.A)) dirHor = -1;
        else if (Input.GetKey(KeyCode.D)) dirHor = 1;
        if (dirHor == 1) transform.rotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
        if (dirHor == -1) transform.rotation = Quaternion.Euler(new Vector3(-90f, 180f, 0f));
        if (dirHor != 0) Amt.SetBool("Move", true);
        else Amt.SetBool("Move", false);
        rb1.velocity = new Vector3(dirHor * speed, 0f, rb1.velocity.z);//移动
    }
    void Jump()
    {
        if(isGround)
            rb1.velocity= new Vector3(rb1.velocity.x, 0f, jumpForce);//跳跃
        isGround = false;
    }
    void AnimationChg()
    {
        Amt.SetBool("isGround", isGround);
        Amt.SetFloat("Speed", Mathf.Abs(rb1.velocity.x));
        Amt.SetFloat("Jump", rb1.velocity.z);
    }
}
