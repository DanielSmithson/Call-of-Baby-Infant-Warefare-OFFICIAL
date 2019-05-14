using UnityEngine;
public class Walking2 : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 98.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    private float turner;
    private float looker;
    public float sensitivity;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        turner = Input.GetAxis("mouse X")* sensitivity;
        looker = -Input.GetAxis("Mouse Y") * sensitivity;
        if (turner != 0)
        {
            transform.eulerAngles += new Vector3(looker,0,0);
        }
        if (looker != 0)
        {
            transform.eulerAngles += new Vector3(0,turner,0);
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}