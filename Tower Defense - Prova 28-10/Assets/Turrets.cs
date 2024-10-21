using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    [SerializeField] private Transform pontoDeRotacaoDaTorre;//Provavelmente o ponto ao redor do qual a torre gira
    [SerializeField] private GameObject balaPrefab;//Prefab da bala (projetil) que a torre dispara
    [SerializeField] private Transform firePoint;//O local onde o proj�til � instanciado, provavelmente o ponto na ponta da torre

    [SerializeField] private float tamanhoMira; // O alcance da torre, definindo o raio em que ela pode detectar inimigos
    [SerializeField] private float tps; // Tiros por segundo, controlando a frequ�ncia de disparo da torre
    [SerializeField] private float velocidadeDeRotacao = 5f;//Velocidade com que a torre gira para mirar no alvo

    private float tempoAteDisparo;//Usado para controlar o intervalo entre os tiros, contando o tempo desde o �ltimo disparo
    private Transform alvo;//Armazena a refer�ncia ao inimigo mais pr�ximo, que ser� o alvo da torre
    ITorreDano Dano;//Interface que define o comportamento de dano da torre, permitindo a aplica��o de dano ao inimigo

    // Configura��es da torreta
    public ITorreDano tipoTorreta; // Inst�ncia da interface ITorreDano, que especifica o comportamento de ataque da torre
    public string tipoTorreAlvo; // Define o tipo de inimigo que a torre pode atacar (Arqueira, Pesada, M�gica)
    public string[] tipoInimigosPodeAtacar;

    private void Start()//Inicializa a torre com base no tipo definido em tipoTorreAlvo. Dependendo do tipo da torre, ela instancia um dos tr�s tipos de torre (TorreArqueira, TorreGuerreira, ou TorreMagica)
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
        // Chama uma fun��o para encontrar o inimigo mais pr�ximo dentro do alcance da torre
        EncontrarAlvo();

        // Se n�o houver um alvo, n�o realiza mais a��es
        if (alvo == null)
        {
            return;
        }

        // Gira a torreta na dire��o do alvo
        GirarEmDirecaoAlvo();

        // Incrementa o tempo at� o pr�ximo disparo
        tempoAteDisparo += Time.deltaTime;

        // Quando o tempo for maior que o intervalo dos tiros, atira
        if (tempoAteDisparo >= tps)
        {
            Atirar();
            tempoAteDisparo = 0f; // Reseta o tempo at� o pr�ximo tiro
        }
    }

    private void Atirar()
    {
        // Instancia o proj�til e define seu alvo
        GameObject municaoObj = Instantiate(balaPrefab, firePoint.position, Quaternion.identity);
        Muni��o muni��oScript = municaoObj.GetComponent<Muni��o>();

        if (muni��oScript != null)
        {
            muni��oScript.DefinirAlvo(alvo);  // Atribui o alvo atual para a muni��o seguir
            muni��oScript.DefinirDano(tipoTorreta.Dano);  // Define o dano da muni��o com base na torre
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
            Transform alvoMaisProximo = null; // Guarda a refer�ncia do inimigo mais pr�ximo
            float menorDistancia = Mathf.Infinity; // Come�a com uma dist�ncia infinita para comparar

            // Loop por todos os alvos detectados para encontrar o mais pr�ximo
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform != null && hit.transform.gameObject.activeInHierarchy) // Certifica que o alvo est� ativo
                {
                    Monster monstro = hit.transform.GetComponent<Monster>();
                    ITipoInimigo tipoInimigo = hit.transform.GetComponent<ITipoInimigo>();

                    if (monstro != null && tipoInimigo != null) // Certifica que o inimigo implementa a interface ITipoInimigo
                    {
                        // Verifica se o inimigo � do tipo que a torre pode atacar
                        if (PodeAtacar(tipoInimigo))
                        {
                            float distancia = Vector2.Distance(transform.position, hit.transform.position); // Calcula a dist�ncia at� o inimigo

                            // Se o alvo estiver mais pr�ximo que o anterior, ele � selecionado
                            if (distancia < menorDistancia)
                            {
                                menorDistancia = distancia;
                                alvoMaisProximo = hit.transform; // Define esse alvo como o mais pr�ximo
                            }
                        }
                    }
                }
            }

            // Sempre define o novo alvo mais pr�ximo
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

    // Fun��o para girar a torreta na dire��o do alvo
    private void GirarEmDirecaoAlvo()
    {
        if (alvo == null) // Se n�o houver alvo, n�o faz nada
            return;

        // Calcula a dire��o at� o alvo
        Vector3 direcao = alvo.position - transform.position;
        // Calcula o �ngulo necess�rio para a torreta se alinhar ao alvo
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg - 90f;

        // Converte o �ngulo em uma rota��o e suaviza a rota��o usando Slerp
        Quaternion rota��oDoAlvo = Quaternion.Euler(new Vector3(0f, 0f, angulo));
        transform.rotation = Quaternion.Slerp(transform.rotation, rota��oDoAlvo, Time.deltaTime * velocidadeDeRotacao);
    }


}
