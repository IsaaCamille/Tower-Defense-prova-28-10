using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageble //Esta interface declara o método TakeDamage(int dano)
{
    void TakeDamage(int dano);//O objetivo deste método é que ele seja implementado por outras classes para que essas classes possam receber danos


}
