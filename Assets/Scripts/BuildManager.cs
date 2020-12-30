﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    
    void Awake(){
        if(instance == null)
            instance = this;
    }

 
    public GameObject standardTurretPrefab;
    public GameObject missileLaucherPrefab;
    public GameObject buildEffect;
    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

   public bool CanBuild{ get { return turretToBuild != null; } }

public bool HasMoney{ get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret){
        turretToBuild = turret;
         DeselectNode();
    }

    public void SelectNode(Node node){
        if(selectedNode == node){
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(selectedNode);
    }

    public void DeselectNode(){
        
        selectedNode = null;
          nodeUI.Hide(); 
    }

    public TurretBlueprint GetBlueprint(){
        return turretToBuild;
    }   
}