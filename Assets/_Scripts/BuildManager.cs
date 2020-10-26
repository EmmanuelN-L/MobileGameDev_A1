using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //Creating a refernece to the build manager
    public static BuildManager instance;

    //Singleton (I think I did it right)
    private void Awake()
    {
        if (instance!=null)
        {
            Debug.LogError("More than one buildmanager in scene");
            return;
        }
        instance = this;

    }

    public int Cost = 0;
    public GameObject GreenTurretPrefab;
    public GameObject RedTurretPrefab;

    private TurretBlueprint turretToBuild;
    //Checks if theres a turret alright there
    public bool CanBuild()
    {
        if (turretToBuild != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //Building the turret on the 2D node
    public void BuildTurretOn (Nodes node)
    {
        //Checks user money
        if(PlayerStats.userMoney - turretToBuild.cost < 0 )
        {
            Debug.Log("Insufficient Funds to build");
            return;

        }
        PlayerStats.userMoney -= turretToBuild.cost;
        
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position, node.transform.rotation);
        node.turret = turret;
    }
    //This sets the user selected turret
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
