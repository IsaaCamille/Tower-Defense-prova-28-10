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

    private void Start()
    {
        plotTowers = new Dictionary<Transform, GameObject>();
    }

    void Update()
    {
        // Verifica se o bot�o esquerdo do mouse foi clicado
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicou");

            // Pega a posi��o do mouse em coordenadas do mundo
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Realiza o Raycast 2D
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        }
    }
}