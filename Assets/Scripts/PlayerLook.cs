using UnityEngine;

public class PlayerLook : MonoBehaviour{
    public Camera cam;
    float xRotation = 0f;
    [SerializeField]float xSensitivity = 20f;
    [SerializeField]float ySensitivity = 20f;
    public void LookAround(Vector2 input){
        float xMouse = input.x;
        float yMouse = input.y;

        //Calculate vertical rotation
        xRotation -= (yMouse * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        //Apply calculation to camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        
        //Rotate camera horizontaly
        transform.Rotate(Vector3.up * (xMouse * Time.deltaTime) * xSensitivity);
    }
}
