using UnityEngine;
using System.Collections;

public class AtivadorDoBotaoConversaComCartaLuva : AtivadorDoBotaoConversa
{
    [SerializeField]private NPCdasCartaLuva npcCarta;
    // Use this for initialization
    new void Start()
    {
        npc = npcCarta;
        base.Start();
    }
}
