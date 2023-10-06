using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotateSpeed = 200f;
    [SerializeField] float jumpForce = 8f;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject pistol;

    float x, y;
    public bool canJump;

    Animator anim;
    [SerializeField]Rig[] rigs;
  //Rig rig;
    float targetWeight;
    private void Awake()
    {
        foreach(Rig rig in rigs)
        {
            rig.GetComponent<Rig>();
        }
        
   
    }
    private void Start()
    {
        pistol.SetActive(false);
        targetWeight = 0f;
        canJump = false;
        anim = GetComponent<Animator>();

    }
    private void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * rotateSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * moveSpeed);
    }
    private void Update()
    {
        foreach(Rig rig in rigs)
        {
            rig.weight = Mathf.Lerp(rig.weight, targetWeight, Time.deltaTime * 10f);
        }



        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
     
        anim.SetFloat("SpeedX", x);
        anim.SetFloat("SpeedY", y);

        if (Input.GetKey(KeyCode.Tab))
        {
            anim.SetFloat("SpeedX", x / 2);
            anim.SetFloat("SpeedY", y / 2);
        }
        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Jump", true);
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
            anim.SetBool("OnFloor", true);
        }
        else
        {
            Falling();
        }

        
    }
    void Falling()
    {
        anim.SetBool("OnFloor", false);
        anim.SetBool("Jump", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AimZone"))
        {
            pistol.SetActive(true);
            targetWeight = 1f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AimZone"))
        {
            pistol.SetActive(false);
            targetWeight = 0f;
        }
    }
}
