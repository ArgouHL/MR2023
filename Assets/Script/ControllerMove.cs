using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class ControllerMove : MonoBehaviour
{
    [SerializeField] private Transform org;
    [SerializeField] private float speed = 0.5f;
    Coroutine MoveCoro;
    Vector2 _movementInput;
    [SerializeField] private TMP_Text t;
    [SerializeField] private GameObject _camera;



    private void OnEnable()
    {
        PlayerInputManager.instance.input.Player.Move.canceled += StopMove;
        PlayerInputManager.instance.input.Player.Move.performed += StartMove;
    }

    private void OnDisable()
    {
        PlayerInputManager.instance.input.Player.Move.canceled -= StopMove;
        PlayerInputManager.instance.input.Player.Move.performed -= StartMove;
    }

    private void Update()
    {
       // t.text = PlayerInputManager.instance.input.Player.Move.ReadValue<Vector2>().ToString() ;
        float XValue = PlayerInputManager.instance.input.Player.Look.ReadValue<Vector2>().x;
        float YValue = -PlayerInputManager.instance.input.Player.Look.ReadValue<Vector2>().y;
        //_camera.transform.rotation = Quaternion.Euler(YValue * rotationSpeed + _camera.transform.rotation.eulerAngles.x, XValue * rotationSpeed + _camera.transform.rotation.eulerAngles.y, 0f);

        var v2 = _movementInput;
        Move(new Vector3(v2.x, 0, v2.y));
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

    public void Move(Vector3 dirction)
    {
       float rotateAngle = _camera.transform.rotation.eulerAngles.y;
       var way = Quaternion.Euler(new Vector3(0, rotateAngle, 0)) * dirction;

       org.position += way.normalized * speed * Time.deltaTime;
    }

}
