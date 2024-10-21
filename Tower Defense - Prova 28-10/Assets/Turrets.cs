using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    [SerializeField] private Transform pontoDeRotacaoDaTorre;//Provavelmente o ponto ao redor do qual a torre gira
    [SerializeField] private GameObject balaPrefab;//Prefab da bala (projetil) que a torre dispara
    [SerializeField] private Transform firePoint;//O local onde o projétil é instanciado, provavelmente o ponto na ponta da torre

    [SerializeField] private float tamanhoMira; // O alcance da torre, definindo o raio em que ela pode detectar inimigos
    [SerializeField] private float tps; // Tiros por segundo, controlando a frequência de disparo da torre
    [SerializeField] private float velocidadeDeRotacao = 5f;//Velocidade com que a torre gira para mirar no alvo

    private float tempoAteDisparo;//Usado para controlar o intervalo entre os tiros, contando o tempo desde o último disparo
    private Transform alvo;//Armazena a referência ao inimigo mais próximo, que será o alvo da torre
    ITorreDano Dano;//Interface que define o comportamento de dano da torre, permitindo a aplicação de dano ao inimigo

    // Configurações da torreta
    public ITorreDano tipoTorreta; // Instância da interface ITorreDano, que especifica o comportamento de ataque da torre
    public string tipoTorreAlvo; // Define o tipo de inimigo que a torre pode atacar (Arqueira, Pesada, Mágica)
    public string[] tipoInimigosPodeAtacar;

    private void Start()//Inicializa a torre com base no tipo definido em tipoTorreAlvo. Dependendo do tipo da torre, ela instancia um dos três tipos de torre (TorreArqueira, TorreGuerreira, ou TorreMagica)
    {
        switch (tipoTorreAlvo)
        {
            case "Arqueira":
                tipoTorreta = new TorreArqueira();
                break;
            case "Pesada":
                tipoTorreta = new TorreGuerreira();
                break;
            case "Magica":
                tipoTorreta = new TorreMagica();
                break;
        }
    }

    private void Update()
    {
        // Chama uma função para encontrar o inimigo mais próximo dentro do alcance da torre
        EncontrarAlvo();

        // Se não houver um alvo, não realiza mais ações
        if (alvo == null)
        {
            return;
        }

        // Gira a torreta na direção do alvo
        GirarEmDirecaoAlvo();

        // Incrementa o tempo até o próximo disparo
        tempoAteDisparo += Time.deltaTime;

        // Quando o tempo for maior que o intervalo dos tiros, atira
        if (tempoAteDisparo >= tps)
        {
            Atirar();
            tempoAteDisparo = 0f; // Reseta o tempo até o próximo tiro
        }
    }

    private void Atirar()
    {
        // Instancia o projétil e define seu alvo
        GameObject municaoObj = Instantiate(balaPrefab, firePoint.position, Quaternion.identity);
        Munição muniçãoScript = municaoObj.GetComponent<Munição>();

        if (muniçãoScript != null)
        {
            muniçãoScript.DefinirAlvo(alvo);  // Atribui o alvo atual para a munição seguir
            muniçãoScript.DefinirDano(tipoTorreta.Dano);  // Define o dano da munição com base na torre
        }
    }

    private void OnDrawGizmos()
    {
        // Desenha uma esfera visual no editor para representar o raio de alcance da torreta
        Gizmos.DrawWireSphere(transform.position, tamanhoMira);
    }

    private void EncontrarAlvo()
    {
        // Faz um CircleCast para detectar todos os inimigos no raio de alcance
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, tamanhoMira, Vector2.zero, 0f, LayerMask.GetMask("Enemy"));

        if (hits.Length > 0)
        {
            Transform alvoMaisProximo = null; // Guarda a referência do inimigo mais próximo
            float menorDistancia = Mathf.Infinity; // Começa com uma distância infinita para comparar

            // Loop por todos os alvos detectados para encontrar o mais próximo
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform != null && hit.transform.gameObject.activeInHierarchy) // Certifica que o alvo está ativo
                {
                    Monster monstro = hit.transform.GetComponent<Monster>();
                    ITipoInimigo tipoInimigo = hit.transform.GetComponent<ITipoInimigo>();

                    if (monstro != null && tipoInimigo != null) // Certifica que o inimigo implementa a interface ITipoInimigo
                    {
                        // Verifica se o inimigo é do tipo que a torre pode atacar
                        if (PodeAtacar(tipoInimigo))
                        {
                            float distancia = Vector2.Distance(transform.position, hit.transform.position); // Calcula a distância até o inimigo

                            // Se o alvo estiver mais próximo que o anterior, ele é selecionado
                            if (distancia < menorDistancia)
                            {
                                menorDistancia = distancia;
                                alvoMaisProximo = hit.transform; // Define esse alvo como o mais próximo
                            }
                        }
                    }
                }
            }

            // Sempre define o novo alvo mais próximo
            if (alvoMaisProximo != null)
            {
                alvo = alvoMaisProximo;
            }
        }
        else
        {
            // Se nenhum alvo for encontrado, reseta o alvo
            alvo = null;
        }
    }

    // Verifica se a torre pode atacar o inimigo baseado no tipo
    private bool PodeAtacar(ITipoInimigo tipoInimigo)
    {
        foreach (string indexer in tipoInimigosPodeAtacar)
        {
            if (tipoInimigo.Nome == indexer) return true;
        }
        return false;

    }

    // Função para girar a torreta na direção do alvo
    private void GirarEmDirecaoAlvo()
    {
        if (alvo == null) // Se não houver alvo, não faz nada
            return;

        // Calcula a direção até o alvo
        Vector3 direcao = alvo.position - transform.position;
        // Calcula o ângulo necessário para a torreta se alinhar ao alvo
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg - 90f;

        // Converte o ângulo em uma rotação e suaviza a rotação usando Slerp
        Quaternion rotaçãoDoAlvo = Quaternion.Euler(new Vector3(0f, 0f, angulo));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotaçãoDoAlvo, Time.deltaTime * velocidadeDeRotacao);
    }


}
