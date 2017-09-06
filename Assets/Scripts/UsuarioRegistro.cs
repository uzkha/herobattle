using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsuarioRegistro : MonoBehaviour {

    [SerializeField]
    private InputField inputNome, inputIdade;

    public void Enviar()
    {
        UsuarioManager.instance.setUsuarioNome(inputNome.text);
        UsuarioManager.instance.setUsuarioIdade(int.Parse(inputIdade.text));
    }
   
}
