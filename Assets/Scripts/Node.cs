using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{

    public GameObject turret;
    public TurretBlueprint turretBlueprint;
    public bool isUpgraded = false;
    public Vector3 positionOffeset;
    public Color hoverColor;
    private Color startColor;
    private Renderer rend;
    private BuildManager buildManager;

 
    void Start() 
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public Vector3 GetBuildPosition(){
        return transform.position + positionOffeset;
    }

    void OnMouseEnter(){
        
        if(EventSystem.current.IsPointerOverGameObject())
            return;

        if(!buildManager.CanBuild)
            return;

        if(buildManager.HasMoney){
            rend.material.color = hoverColor;
        }else{
            rend.material.color = Color.red;
        }
        
    }

    void OnMouseExit(){
        rend.material.color = startColor;
    }

    void OnMouseDown(){
        if(EventSystem.current.IsPointerOverGameObject())
            return;

        

        if(turret != null){
            buildManager.SelectNode(this);
            return;
        }

        if(!buildManager.CanBuild)
            return;
        BuildTurret(buildManager.GetBlueprint());
    }
    public void UpgradeTurret(){
        if(PlayerStats.Money < turretBlueprint.upgradeCost){
            Debug.Log("NOT ENOUGH MONEY TO UPGRADE");
            return;
        }
        
        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret);
        GameObject _turret = (GameObject) Instantiate(turretBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        
        
       

        GameObject effect = (GameObject) Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
        
    }

    public void SellTurret(){

        PlayerStats.Money += turretBlueprint.sellCost;
        Destroy(turret);
        GameObject effect = (GameObject) Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = false;
        turretBlueprint = null;
        
    }
    void BuildTurret(TurretBlueprint blueprint)
    {
        if(PlayerStats.Money < blueprint.cost){
            Debug.Log("NOT ENOUGH MONEY TO BUILD");
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        GameObject _turret = (GameObject) Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
         turretBlueprint  = blueprint;
        GameObject effect = (GameObject) Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
