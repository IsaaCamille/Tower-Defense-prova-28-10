using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageble //Esta interface declara o m�todo TakeDamage(int dano)
{
    void TakeDamage(int dano);//O objetivo deste m�todo � que ele seja implementado por outras classes para que essas classes possam receber danos


}
