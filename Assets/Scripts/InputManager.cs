using UnityEngine;

public class InputManager : MonoBehaviour{   
    private PlayerInput _playerInput;
    private PlayerInput.OnFootActions _onFootMap;
    private PlayerMovement _playerMovement;
    private PlayerLook _look;
    void Awake(){
        _playerInput = new PlayerInput();
        _onFootMap = _playerInput.OnFoot;
        _playerMovement = GetComponent<PlayerMovement>();
        _look = GetComponent<PlayerLook>();
        _onFootMap.Jump.performed += ctx => _playerMovement.Jump();
    }
    void FixedUpdate(){
        _playerMovement.MovementProcessor(_onFootMap.Movement.ReadValue<Vector2>());
    }
    void LateUpdate(){
         _look.LookAround(_onFootMap.Look.ReadValue<Vector2>());
    }
    void OnEnable(){
        _onFootMap.Enable();
    }
    void OnDisable(){
        _onFootMap.Disable();
    }
}
