using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint GreenTurret;
    public TurretBlueprint RedTurret;

    //Getting access to build manager
    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    //Setting the turret to build to green turret
    public void SelectedGreenTurret ()
    {
        Debug.Log("Green Turret Selected");
        buildManager.SelectTurretToBuild(GreenTurret);
    }

    public void SelectedRedTurret()
    {
        //Setting the turret to build to red turret

        Debug.Log("Red Turret Selected");
        buildManager.SelectTurretToBuild(RedTurret);
    }
}
