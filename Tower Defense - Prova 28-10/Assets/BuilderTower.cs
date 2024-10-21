using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderTower : MonoBehaviour
{
    public GameObject turretPrefab; // Prefab único da torre
    public LayerMask plotLayerMask; // Máscara para detectar apenas os plots
    private ITorreDano selectedTowerType; // Tipo da torre selecionado pelo botão
    private GameObject selectedTurretPrefab; // Prefab da torre selecionado pelo botão

    private Dictionary<Transform, GameObject> plotTowers = new Dictionary<Transform, GameObject>(); // Referência para verificar se já há uma torre no plot

    private void Start()
    {
        plotTowers = new Dictionary<Transform, GameObject>();
    }

    void Update()
    {
        // Verifica se o botão esquerdo do mouse foi clicado
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicou");

            // Pega a posição do mouse em coordenadas do mundo
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Realiza o Raycast 2D
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        }
    }
}