using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] int moveSpeed;
    [SerializeField] int jumpHeight;
    private Rigidbody rb;
    private Animator anim;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /* isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); 

        Vector3 moveChar = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.A))
            //rb.AddForce(Vector3.left);
            moveChar = Vector3.left;
        if (Input.GetKey(KeyCode.D))
            //rb.AddForce(Vector3.right);
            moveChar = Vector3.right;
        if (Input.GetKey(KeyCode.W))
            //rb.AddForce(Vector3.up);
            moveChar = Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            //rb.AddForce(Vector3.down);
            moveChar = Vector3.back;

        transform.position += moveChar * Time.deltaTime * moveSpeed;

        if (moveChar != Vector3.zero)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        */

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            //transform.Translate(Vector3.up * 100 * Time.deltaTime, Space.World);
            audioSource.PlayOneShot(AudioManager.Instance.Jump);
        } 

        // Punch 
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Punch");
            ModifyTerrain.Instance.DestroyBlock(10f, (byte)TextureType.air.GetHashCode());
            audioSource.PlayOneShot(AudioManager.Instance.Hit);
        }

        // Build
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("Punch");
            ModifyTerrain.Instance.AddBlock(10f, (byte)TextureType.rock.GetHashCode());
            audioSource.PlayOneShot(AudioManager.Instance.Build);
        }
    }
}
