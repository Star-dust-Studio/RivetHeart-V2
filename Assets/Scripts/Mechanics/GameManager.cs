using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Controls
{
    Move,
    Jump,
    Interact,
    Inventory,
    Map,
    Shoot,
    Grapple
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public EnemySpawner enemySpawner;

    public int componentsCollected;
    public bool unlockedEnding = false;
    public bool[] doorOpened;

    [Header("Tutorial")]
    public bool doneMove = false;
    public bool doneJump = false;
    public bool doneInteract = false;
    public bool doneInventory = false;
    public bool doneMap = false;
    public bool doneShoot = false;
    public bool doneGrapple = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void RefEnemySpawner(EnemySpawner script)
    {
        enemySpawner = script;
    }

    public void CollectComponent()
    {
        componentsCollected++;

        if (componentsCollected == 6)
        {
            unlockedEnding = true;
        }
    }

    public bool CheckTutorial(Controls type)
    {
        switch (type)
        {
            case Controls.Move:
                return (doneMove);
            case Controls.Jump:
                return (doneJump);
            case Controls.Interact:
                return (doneInteract);
            case Controls.Inventory:
                return (doneInventory);
            case Controls.Map:
                return (doneMap);
            case Controls.Shoot:
                return (doneShoot);
            case Controls.Grapple:
                return (doneGrapple);
            default:
                return false;
        }
    }
}
