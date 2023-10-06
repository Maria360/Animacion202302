using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public CharacterController characterController;

    private void OnTriggerStay(Collider other)
    {
        characterController.canJump = true;
    }
    private void OnTriggerExit(Collider other)
    {
        characterController.canJump = false;
    }
}
