using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PainelDeGolpe : MonoBehaviour
{
    [SerializeField]private RawImage imgGolpe;
    [SerializeField]private Text txtNomeGolpe;
    [SerializeField]private Text numCusto;
    [SerializeField]private Text txtTipo;
    [SerializeField]private Text numPoder;
    [SerializeField]private Text tempoReg;

    public void Aciona(GolpeBase g)
    {
        gameObject.SetActive(true);
        imgGolpe.texture = elementosDoJogo.el.RetornaMini(g.Nome);
        txtNomeGolpe.text = golpe.nomeEmLinguas(g.Nome);
        numCusto.text = g.CustoPE.ToString();
        txtTipo.text = tipos.NomeEmLinguas(g.Tipo);
        numPoder.text = g.PotenciaCorrente.ToString();
        tempoReg.text = g.TempoDeReuso.ToString()+"s";
    }
}
