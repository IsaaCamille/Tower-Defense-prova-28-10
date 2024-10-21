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








}
