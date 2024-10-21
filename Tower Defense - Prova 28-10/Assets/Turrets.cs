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








}
