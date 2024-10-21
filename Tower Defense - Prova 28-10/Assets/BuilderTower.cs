using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderTower : MonoBehaviour
{
    public GameObject turretPrefab; // Prefab �nico da torre
    public LayerMask plotLayerMask; // M�scara para detectar apenas os plots
    private ITorreDano selectedTowerType; // Tipo da torre selecionado pelo bot�o
    private GameObject selectedTurretPrefab; // Prefab da torre selecionado pelo bot�o

    private Dictionary<Transform, GameObject> plotTowers = new Dictionary<Transform, GameObject>(); // Refer�ncia para verificar se j� h� uma torre no plot




}
