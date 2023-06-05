using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public PauseMenu PauseMenu;

    public GameObject iconSquirrelSelected;
    public GameObject iconBeaverlSelected;
    public GameObject iconBoarSelected;
    public GameObject[] characters;

    public SquirrelMovement Squirrel;
    public BeaverMovement Beaver;
    public BoarMovement Boar;

    public int currentIndex;

    private void Start()
    {
        StartLevel();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !PauseMenu.isPaused)
        {
            Squirrel.enabled = true;
            Squirrel.rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Beaver.DisableMovementAnimation();
            Squirrel.ResetParent();
            Boar.DisableMovementAnimation();
            Beaver.enabled = false;
            Boar.enabled = false;
            currentIndex = 0;
            iconSquirrelSelected.SetActive(true);
            iconBeaverlSelected.SetActive(false);
            iconBoarSelected.SetActive(false);

            Squirrel.rigidBody.simulated = true;

            Beaver.rigidBody.simulated = true;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && !PauseMenu.isPaused)
        {
            Beaver.enabled = true;
            Beaver.rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Squirrel.DisableMovementAnimation();
            Beaver.ResetParent();
            Boar.DisableMovementAnimation();
            Squirrel.enabled = false;
            Boar.enabled = false;
            currentIndex = 1;
            iconSquirrelSelected.SetActive(false);
            iconBeaverlSelected.SetActive(true);
            iconBoarSelected.SetActive(false);

            if (Squirrel.isOnBeaver)
            {
                Squirrel.rigidBody.simulated = false;
            }
            else
            {
                Squirrel.rigidBody.simulated = true;
            }

            Beaver.rigidBody.simulated = true;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && !PauseMenu.isPaused)
        {
            Boar.enabled = true;
            Boar.rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Squirrel.DisableMovementAnimation();
            Beaver.DisableMovementAnimation();
            Beaver.enabled = false;
            Squirrel.enabled = false;
            currentIndex = 2;
            iconSquirrelSelected.SetActive(false);
            iconBeaverlSelected.SetActive(false);
            iconBoarSelected.SetActive(true);

            if (Squirrel.isOnBeaver)
            {
                Squirrel.rigidBody.simulated = false;
            }
            else
            {
                Squirrel.rigidBody.simulated = true;
            }

            if (Beaver.isOnBoar)
            {
                Beaver.rigidBody.simulated = false;
            }
            else
            {
                Beaver.rigidBody.simulated = true;
            }
        }

        if (!Squirrel.enabled && Squirrel.IsGrounded())
        {
            Squirrel.rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (!Beaver.enabled && Beaver.IsGrounded())
        {
            Beaver.rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (!Boar.enabled && Boar.IsGrounded())
        {
            Boar.rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    public void StartLevel()
    {
        currentIndex = 0;

        Squirrel.enabled = true;
        Squirrel.rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        Beaver.enabled = false;
        Beaver.rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        Boar.enabled = false;
        Boar.rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;

        iconSquirrelSelected.SetActive(true);
        iconBeaverlSelected.SetActive(false);
        iconBoarSelected.SetActive(false);
    }
}