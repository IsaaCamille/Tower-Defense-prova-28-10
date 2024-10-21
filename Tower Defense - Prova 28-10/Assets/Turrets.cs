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









}
