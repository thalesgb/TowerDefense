using UnityEngine;


public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLaucher;
    
    void Start(){
        buildManager =  BuildManager.instance;
    }
    public void SelectStandardTurret(){
        Debug.Log("ESCOLHEU STANDARD");
        buildManager.SelectTurretToBuild(standardTurret);
    }

     public void SelectMissileLaucher(){
        Debug.Log("ESCOLHEU ANOTHER");
        buildManager.SelectTurretToBuild(missileLaucher);
    }
}
