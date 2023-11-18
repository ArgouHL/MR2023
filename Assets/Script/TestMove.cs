using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestMove : MonoBehaviour
{
    [SerializeField] private Transform org;
    [SerializeField] private float speed=2;


    [SerializeField] private GameObject _camera;
    [SerializeField] private float rotationSpeed;
    Vector2 _movementInput;
    PlayerInpur input;


    private void Awake()
    {
        input = new PlayerInpur();
        input.UI.Enable();
        input.Player.Enable();
    }

    private void OnEnable()
    {
        input.Player.Move.canceled+=StopMove;
        input.Player.Move.performed += StartMove;
    }

    private void StartMove(InputAction.CallbackContext obj)
    {
        Debug.Log("StartMOve");
        _movementInput = obj.ReadValue<Vector2>();
    }

    private void StopMove(InputAction.CallbackContext obj)
    {
        Debug.Log("StopMove");
        _movementInput = Vector2.zero;
    }

    private void Update()
    {
        float XValue = input.Player.Look.ReadValue<Vector2>().x;
        float YValue = -input.Player.Look.ReadValue<Vector2>().y;
        _camera.transform.rotation = Quaternion.Euler(YValue * rotationSpeed + _camera.transform.rotation.eulerAngles.x, XValue * rotationSpeed + _camera.transform.rotation.eulerAngles.y, 0f);

        var v2 = _movementInput;
        Move(new Vector3(v2.x, 0, v2.y));
    }

    public void Move(Vector3 dirction)
    {
        float rotateAngle = org.rotation.eulerAngles.y;
        var way = Quaternion.Euler(new Vector3(0, rotateAngle, 0)) * dirction;

        org.position += way.normalized * speed * Time.deltaTime;
    }


}
