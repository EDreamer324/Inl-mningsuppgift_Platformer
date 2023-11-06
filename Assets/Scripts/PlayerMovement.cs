using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _Controller;
    Vector3 movement;
    [SerializeField]float speed = 5f;
    float gravity = -9.82f;
    float jumpHeight = 3f;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        _Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = _Controller.isGrounded;
    }
    /// <summary>
    /// Translates the input from hardware into movement
    /// </summary>
    /// <param name="input"></param>
    public void MovementProcessor(Vector2 input){
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        _Controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        movement.y += gravity * Time.deltaTime;

        if(isGrounded && movement.y < 0){
                movement.y = -2f;
        }
        _Controller.Move(movement * Time.deltaTime);
    }
    public void Jump(){
        if(isGrounded){
            movement.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
    }
}
