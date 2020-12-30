using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;
    public Node target;
    public Text upgradeCost;
    public Button upgradeButton;
    public Text sellCost;
    
    public void SetTarget(Node _target){
        target = _target;
        transform.position = target.GetBuildPosition();
        if(!target.isUpgraded){
            upgradeCost.text = "$"+target.turretBlueprint.upgradeCost.ToString();
            upgradeButton.interactable = true;
        }else{
            upgradeCost.text = "NAX";
            upgradeButton.interactable = false;
        }
        sellCost.text = "$"+target.turretBlueprint.sellCost.ToString();

        
        ui.SetActive(true);
    }

    public void Hide(){
        ui.SetActive(false);
    }

    public void Upgrade(){
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell(){
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
