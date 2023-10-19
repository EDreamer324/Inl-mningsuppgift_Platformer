using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private CharacterController characterController;


    [SerializeField] float speed, jumpHeight;
    [SerializeField] bool isGrounded;
    float movex, movez, movey;
    float gravityPull = -9.82f;
    Vector3 movement, dwnd, upwrd;

    Ray r;
    RaycastHit hitInfo;    


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (characterController == null) {
            Debug.LogError("Character controller component missing");
        }
    }

    // Update is called once per frame
    void Update()
    {
        movex = Input.GetAxisRaw("Horizontal");
        movez = Input.GetAxisRaw("Vertical");
        movey = Input.GetAxisRaw("Jump");

        movement = new Vector3(movex, 0, movez);

        characterController.Move(movement * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && CheckGrounded(isGrounded)) {
            upwrd.y += Mathf.Sqrt(jumpHeight * -3 * gravityPull);
        }

        upwrd.y += gravityPull * Time.deltaTime;
        characterController.Move(upwrd * Time.deltaTime);
    }

    bool CheckGrounded(bool isGrounded) {
        dwnd = Vector3.down;

        if (Physics.Raycast(transform.position, dwnd, out hitInfo, 0.1f)) {
            isGrounded = true;
        }
        else {
            isGrounded = false;
        }
        return isGrounded;
    }
}
