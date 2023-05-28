using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public PauseMenu PauseMenu;

    public SquirrelMovement Squirrel;
    public BeaverMovement Beaver;
    public BoarMovement Boar;
        
    public GameObject[] characters;

    public int currentIndex;

    private void Start()
    {
        Squirrel.enabled = true;
        Squirrel._rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        Beaver.enabled = false;
        Beaver._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        Boar.enabled = false;
        Boar._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !PauseMenu.isPaused)
        {
            Squirrel.enabled = true;
            Squirrel._rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Beaver.DisableMovementAnimation();
            Squirrel.ResetParent();
            Boar.DisableMovementAnimation();
            Beaver.enabled = false;
            Boar.enabled = false;
            currentIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && !PauseMenu.isPaused)
        {
            Beaver.enabled = true;
            Beaver._rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Squirrel.DisableMovementAnimation();
            Beaver.ResetParent();
            Boar.DisableMovementAnimation();
            Squirrel.enabled = false;
            Boar.enabled = false;
            currentIndex = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && !PauseMenu.isPaused)
        {
            Boar.enabled = true;
            Boar._rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Squirrel.DisableMovementAnimation();
            Beaver.DisableMovementAnimation();
            Beaver.enabled = false;
            Squirrel.enabled = false;
            currentIndex = 2;
        }

        if (!Squirrel.enabled && Squirrel.IsGrounded())
        {
            Squirrel._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (!Beaver.enabled && Beaver.IsGrounded())
        {
            Beaver._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (!Boar.enabled && Boar.IsGrounded())
        {
            Boar._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}