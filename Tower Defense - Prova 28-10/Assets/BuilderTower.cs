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

            if (hit.collider != null)
            {
                Debug.Log("Raycast 2D bateu em: " + hit.collider.name);
            }

            // Verifica se o raycast acerta algum objeto com a máscara de plots
            RaycastHit2D hitWithMask = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, plotLayerMask);

            if (hitWithMask.collider != null)
            {
                // Chama o método para construir a torre no plot clicado
                Debug.Log("Raycast 2D bateu em: " + hitWithMask.collider.name + " que é um objeto da layerMask selecionada");
                BuildTower(hitWithMask.transform);
            }

        }

    }

    // Método para instanciar a torre no plot
    void BuildTower(Transform plotTransform)
    {
        // Verifica se já há uma torre no plot
        if (plotTowers.ContainsKey(plotTransform))
        {
            Debug.Log("Já há uma torre neste plot.");
            return;
        }

        // Verifica se algum prefab de torre foi selecionado
        if (selectedTurretPrefab == null)
        {
            Debug.LogWarning("Nenhum prefab de torre selecionado.");
            return;
        }

        // Instancia o prefab da torre na posição do plot
        GameObject newTower = Instantiate(selectedTurretPrefab, plotTransform.position, Quaternion.identity);

        // Associa a torre ao plot para que não seja construída outra na mesma posição
        plotTowers.Add(plotTransform, newTower);

        Debug.Log("Torre construída com sucesso.");
    }

    // Método chamado ao clicar nos botões de seleção de torreta
    public void SelectTurretType(GameObject turretPrefab)
    {
        selectedTurretPrefab = turretPrefab; // Atualiza o prefab da torreta selecionado
        Debug.Log("Prefab da torre selecionado: " + turretPrefab.name);
    }

    public void OnAtiradoraButtonPressed(GameObject atiradoraPrefab)
    {
        FindObjectOfType<BuilderTower>().SelectTurretType(atiradoraPrefab); // Seleciona o prefab da torreta Atiradora
    }

    public void OnPesadaButtonPressed(GameObject pesadaPrefab)
    {
        FindObjectOfType<BuilderTower>().SelectTurretType(pesadaPrefab); // Seleciona o prefab da torreta Pesada
    }

    public void OnMisticaButtonPressed(GameObject misticaPrefab)
    {
        FindObjectOfType<BuilderTower>().SelectTurretType(misticaPrefab); // Seleciona o prefab da torreta Mística
    }



}