using UnityEngine;
using TMPro;

public class Nodes : MonoBehaviour
{
    public Color hoverColor;
    
    public GameObject turret;

    private SpriteRenderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        //Whenever you click on a node tile it will be highlighted
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.color;

        buildManager = BuildManager.instance;
    }
    //Pressing on a tile will build a turret
    private void OnMouseDown()
    {
        //If no turret is selected then don't build anything
        if(!buildManager.CanBuild())
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("Can't build here! - TODO: Display on screen.");
            return;
        }
        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        if (!buildManager.CanBuild())
        {
            return;
        }

        rend.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.color = startColor;
    }
}
