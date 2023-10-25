using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private CharacterController characterController;


    [SerializeField] float speed, jumpHeight, mSensitivity;
    [SerializeField] bool isGrounded;
    float movex, movez, movey;
    float gravityPull = -9.82f;
    float rayDistance = 0.01f;
    string floorTag = "Walkable";
    Vector3 movement, dwnd = Vector3.down, upwrd = Vector3.up;

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
        PlayerMovement();
        CameraControls();
    }

    void CameraControls() {
        Vector3 rotation = new Vector3(0, Input.GetAxisRaw("Mouse X") * mSensitivity * Time.deltaTime ,0);
        transform.Rotate(rotation);
    }

    void PlayerMovement() {
        movex = Input.GetAxisRaw("Horizontal"); movez = Input.GetAxisRaw("Vertical"); movey = Input.GetAxisRaw("Jump");
        movement = new Vector3(movex, 0, movez);
        characterController.Move(movement * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && CheckGrounded(isGrounded)) {
            upwrd.y = Mathf.Sqrt(jumpHeight * -3 * gravityPull);
        }

        upwrd.y = gravityPull * Time.deltaTime;
        characterController.Move(upwrd * Time.deltaTime);
        isGrounded = CheckGrounded(isGrounded);
    }
    bool CheckGrounded(bool isGrounded) {

        if (Physics.Raycast(transform.position, dwnd, out hitInfo, rayDistance)) {
            if (hitInfo.collider != null) {
                if (hitInfo.collider.CompareTag(floorTag)){
                    isGrounded = true;
                }
            }
        }
        else {
            isGrounded = false;
        }
        return isGrounded;
    }
}
