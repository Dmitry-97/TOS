using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Scripts / FPCInput")]

public class FPCInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    private CharacterController _charController;    //переменная для ссылки на компонент CharacterController

    private void Start()
    {
        _charController = GetComponent<CharacterController>();  //доступ к другим компонентам, присоединённым к этому же объекту  
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        movement = Vector3.ClampMagnitude(movement, speed);     //движение по диагонали - с той же скоростью, что и по осям
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);      //преобразование вектора движения от локальных координат к глобальным
        _charController.Move(movement);     //вектор движение перемещает компонент CharacterController
    }
}