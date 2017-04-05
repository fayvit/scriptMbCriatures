using UnityEngine;
using System.Collections;

public class movimentoBasico : comandos
{
    //private float velocidade = 3.0f;

    public bool podeAndar = true;

    public caracteristicasBasicas Y;

    private heroi H;
    private movimentoBasico mB;
    private HUDCriatures hud = null;
    private HUDItens hudI = null;
    private HUDRecarga hudRecarga;

    private umCriature criature;


    private Vector3 direcaoMovimento = Vector3.zero;

    private static bool zerado2 = true;
    private static bool zerado = true;
    private cameraPrincipal cam;






    // Use this for initialization
    void Start()
    {
        controle = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        H = GameObject.FindGameObjectWithTag("Player").GetComponent<heroi>();

        Y = new caracteristicasBasicas();
        if (!GameObject.Find("CriatureAtivo") && !variaveisChave.shift["adiciona O Criature"])
            adicionaOCriature();

        cam = GetComponent<cameraPrincipal>();

        textos = bancoDeTextos.falacoes[heroi.lingua]["movimentoBasico"].ToArray();
    }

    public void adicionaOCriature()
    {


        string nomeCriature = H.criaturesAtivos[0].nomeID.ToString();

        GameObject CA = GameObject.Find("elementosDoJogo").GetComponent<elementosDoJogo>().criature(nomeCriature);
        CA = Instantiate(CA, transform.position - 3 * transform.forward, Quaternion.identity)
            as GameObject;
        CA.name = "CriatureAtivo";

        //H.criaturesAtivos[0].colocaStatus(CA);


        if (!CA.GetComponent<UnityEngine.AI.NavMeshAgent>())
        {

            UnityEngine.AI.NavMeshAgent N = CA.AddComponent<UnityEngine.AI.NavMeshAgent>();
            N.stoppingDistance = N.radius < 1 ? 7 : 5 * N.radius;
            N.baseOffset = 0;
            N.speed = N.radius < 1 ? 9 : 0;

        }

        if (!CA.GetComponent<sigaOLider>())
            CA.AddComponent<sigaOLider>();

        if (!CA.GetComponent<alternancia>())
            CA.AddComponent<alternancia>();
    }

    void Update()
    {
        //		print(mostradorDeTempo(Time.time));
        if (!pausaJogo.pause)
        {
            if (transform.tag == "Player" && podeAndar)
                andaCorean();
            else
            {
                if (podeAndar)
                    andaCriature4();
                if (mB == null)
                    mB = GameObject.FindGameObjectWithTag("Player").
                        GetComponent<movimentoBasico>();
                mB.pararOHeroi();

            }
        }
    }

    public static void pararFluxoCriature(bool daCam = true, bool doMB = true, bool parar = true)
    {
        GameObject G = GameObject.Find("CriatureAtivo");
        if (!G)
            return;

        if (doMB)
        {
            movimentoBasico mB = G.GetComponent<movimentoBasico>();
            mB.enabled = false;
            if (parar)
                alternanciaEmLuta.pararOCriature(G.transform);
        }

        if (daCam)
        {
            cameraPrincipal cam = G.GetComponent<cameraPrincipal>();
            cam.enabled = false;
        }


    }

    public static void retornaFluxoCriature(bool daCam = true, bool doMB = true)
    {
        GameObject G = GameObject.Find("CriatureAtivo");
        if (!G)
            return;

        if (doMB)
        {
            movimentoBasico mB = G.GetComponent<movimentoBasico>();
            mB.enabled = true;
        }

        if (daCam)
        {
            cameraPrincipal cam = G.GetComponent<cameraPrincipal>();
            cam.enabled = true;
        }


    }

    public static void pararFluxoHeroi(bool mit = true, bool daCam = true, bool doMB = true, bool parar = true)
    {
        GameObject G = GameObject.FindWithTag("Player");
        if (doMB)
        {
            movimentoBasico mB = G.GetComponent<movimentoBasico>();
            mB.enabled = false;
            if (parar)
                mB.pararOHeroi();
        }

        if (daCam)
        {
            cameraPrincipal cam = G.GetComponent<cameraPrincipal>();
            cam.enabled = false;
        }

        if (mit)
        {
            menuInTravel2 mIT2 = Camera.main.gameObject.GetComponent<menuInTravel2>();
            mIT2.enabled = false;
        }


    }

    public static void retornarFluxoHeroi(bool mit = true, bool daCam = true, bool doMB = true)
    {
        GameObject G = GameObject.FindWithTag("Player");
        if (doMB)
        {
            movimentoBasico mB = G.GetComponent<movimentoBasico>();
            mB.enabled = true;
            mB.pararOHeroi();
            mB.podeAndar = true;
        }

        if (daCam)
        {
            cameraPrincipal cam = G.GetComponent<cameraPrincipal>();
            cam.enabled = true;
        }

        if (mit)
        {
            menuInTravel2 mIT2 = Camera.main.gameObject.GetComponent<menuInTravel2>();
            mIT2.enabled = true;
        }

    }

    public void pararOHeroi()
    {
        if (transform.tag == "Player")
        {
            animator.SetFloat("velocidade", 0f);
            animator.SetFloat("direcao", 0f);
            animator.SetBool("girando", false);
        }
    }

    public void desabilitaCamera()
    {
        cam.enabled = false;
    }

    public void habilitaCamera()
    {
        cam.enabled = true;
    }

    public void criatureVerificaTrocaGolpe()//Criado para ser usado no Tutotial !!(exclamaçoes)!!!!
    {
        criatureVerificaTrocaGolpe(H.criaturesAtivos[0]);
    }

    void criatureVerificaTrocaGolpe(Criature X)
    {


        if (Input.GetButtonDown("trocaGolpe") && !variaveisChave.shift["TrocaGolpes"])
        {

            int aux = X.golpeEscolhido;
            if (aux < X.Golpes.Length - 1)
                X.golpeEscolhido++;
            else
                X.golpeEscolhido = 0;

            if (!Camera.main.GetComponent<HUDGolpes>())
            {

                HUDGolpes HUD = GameObject.FindGameObjectWithTag("MainCamera").AddComponent<HUDGolpes>();
                HUD.zeraTempo();
            }
            else
                Camera.main.GetComponent<HUDGolpes>().zeraTempo();

        }
    }

    public static float alternador2()
    {
        float retorno = 0;
        if (zerado)
        {
            if (Input.GetAxis("alternador2") != 0)
            {
                zerado = false;
            }

            if (Input.GetAxis("alternador2") > 0)
                retorno = 1;
            else if (Input.GetAxis("alternador2") < 0)
                retorno = -1;

        }
        else
        {
            retorno = 0;
            if (Input.GetButtonUp("alternador2"))
                zerado = true;

        }

        return retorno;

    }

    public static float alternador3()
    {
        float v = Input.GetAxisRaw("alternador3");
        //		print(v);
        if (zerado2)
        {
            if (v < -0.1f)
                zerado2 = false;
            else
                if (v > 0.1f)
                zerado2 = false;
        }
        else
        {
            if (v > -0.1f && v < 0.1f)
                zerado2 = true;

            v = 0;
        }


        return (zerado2) ? 0 : v;
    }

    public void criatureScroll()
    {

        float alt2 = alternador2();

        if (alt2 == 0)
        {
            alt2 = alternador3();
        }



        if (!Input.GetButton("Correr"))
        {
            if (Input.GetButtonDown("gatilho") && !variaveisChave.shift["HUDItens"])
                if (Time.time - H.tempoDoUltimoUsoDeItem > H.intervaloParaUsarItem || !heroi.emLuta)
                {
                    GameObject.FindGameObjectWithTag("Player").AddComponent<usaItemEmLuta>();

                }
                else
                    usaItemEmLuta.mensagemDuranteALuta(
                    string.Format(textos[0],
                              comandos.mostradorDeTempo(
                    H.tempoDoUltimoUsoDeItem - (Time.time - H.intervaloParaUsarItem))
                              ));


            if ((Input.GetAxis("alternador") != 0 || alt2 != 0) && !variaveisChave.shift["HUDItens"])
            {
                if (!hudI)
                    hudI = GameObject.FindGameObjectWithTag("MainCamera").AddComponent<HUDItens>();

                hudI.zeraTempo();

                if (Input.GetAxis("alternador") < 0 || alt2 < 0)
                {
                    if (!H)
                        H = GameObject.FindWithTag("Player").GetComponent<heroi>();

                    if (H.itemAoUso < H.itens.Count - 1)
                        H.itemAoUso++;
                    else if (H.itens.Count > 0)
                        H.itemAoUso = 0;
                }
                else if (Input.GetAxis("alternador") > 0 || alt2 > 0)
                    if (H.itemAoUso > 0)
                        H.itemAoUso--;
                    else if (H.itens.Count > 0)
                        H.itemAoUso = H.itens.Count - 1;

            }
        }
        else
        {

            if ((Input.GetAxis("alternador") != 0 || alt2 != 0) && !variaveisChave.shift["HUDCriatures"])
            {
                if (!hud)
                    hud = GameObject.FindGameObjectWithTag("MainCamera").AddComponent<HUDCriatures>();

                hud.zeraTempo();

                if (Input.GetAxis("alternador") < 0 || alt2 < 0)
                {
                    if (H.criatureSai < H.criaturesAtivos.Count - 1)
                        H.criatureSai++;
                    else if (H.criaturesAtivos.Count > 1)
                        H.criatureSai = 1;
                }
                else if (Input.GetAxis("alternador") > 0 || alt2 > 0)
                    if (H.criatureSai > 1)
                        H.criatureSai--;
                    else if (H.criaturesAtivos.Count > 1)
                        H.criatureSai = H.criaturesAtivos.Count - 1;

                if (H.criaturesAtivos.Count < 2)
                    H.criatureSai = 0;
            }

            if (Input.GetButtonDown("gatilho") && H.criaturesAtivos.Count > 1 && !variaveisChave.shift["HUDCriatures"])
            {
                if (H.criaturesAtivos[H.criatureSai].cAtributos[0].Corrente > 0)
                    GameObject.FindGameObjectWithTag("Player").AddComponent<alternanciaEmLuta>();
                else if (!variaveisChave.shift["HUDCriatures"])
                {
                    GameObject maeCamera = GameObject.Find("Main Camera");
                    if (maeCamera.GetComponent<mensagemEmLuta>())
                        maeCamera.GetComponent<mensagemEmLuta>().fechador();
                    mensagemEmLuta mL = maeCamera.AddComponent<mensagemEmLuta>();
                    mL.mensagem = string.Format(textos[2], H.criaturesAtivos[H.criatureSai].Nome);
                }
            }

        }

    }

    void maisUmAtualizaSuavemente(float v, float h, caracteristicasBasicas X, Vector3 direcaoAlvo)
    {

        // moveDirection is always normalized, and we only update it if there is user input.
        if (direcaoAlvo != Vector3.zero)
        {
            // If we are really slow, just snap to the target direction
            if (controle.velocity.magnitude < X.velocidadeCorrendo * 0.9f && noChao(X.distanciaFundamentadora))
            {
                direcaoMovimento = direcaoAlvo.normalized;
            }
            // Otherwise smoothly turn towards it
            else
            {
                direcaoMovimento = Vector3.RotateTowards(direcaoMovimento, direcaoAlvo, 500 * Mathf.Deg2Rad * Time.deltaTime, 1000);

                direcaoMovimento = direcaoMovimento.normalized;
            }
        }

    }

    bool focoPraMove = false;
    bool focoEra = false;
    Vector3 direcaoGuardada;
    float guardeH;
    float guardeV;



    Vector3 direcaoInduzida(float h, float v)
    {
        Transform cameraTransform = Camera.main.transform;
        Vector3 retorno = cameraTransform.TransformDirection(Vector3.forward);
        if (!focoPraMove)
        {
            focoPraMove = cam.Focar;
            if (focoEra != focoPraMove)
            {
                direcaoGuardada = cameraTransform.TransformDirection(Vector3.forward);
                guardeH = h;
                guardeV = v;

            }
            retorno = direcaoGuardada;
        }
        else
        {
            direcaoGuardada = Vector3.Lerp(direcaoGuardada, cameraTransform.TransformDirection(Vector3.forward), 0.05f * Time.deltaTime);
            retorno = direcaoGuardada;
        }

        if (focoPraMove)
        {
            if (h == 0 && v == 0)
            {
                focoPraMove = false;
                retorno = cameraTransform.TransformDirection(Vector3.forward);
            }
            else if (Mathf.Abs(guardeH - h) > 0.3f && Mathf.Abs(guardeV - v) > 0.3f)
            {
                focoPraMove = false;
                retorno = cameraTransform.TransformDirection(Vector3.forward);
            }
        }
        else
        {

            retorno = cameraTransform.TransformDirection(Vector3.forward);
        }



        focoEra = focoPraMove;
        //		print("focoPraMove: "+focoPraMove+" focoEra: "+focoEra+" retorno: "+retorno+" dir Camera "+cameraTransform.TransformDirection(Vector3.forward));
        //		print("dirGuardada: "+direcaoGuardada+"focar: "+cam.Focar);
        return retorno;
    }

    Vector2 embaralhaDeMedo(Criature C, int indiceDoMedo, float h, float v)
    {
        Vector2 r = new Vector3(h, v);
        switch ((int)C.statusTemporarios[indiceDoMedo].forcaDoDano)
        {
            case 0:
                r.x = -h;
                r.y = -v;
                break;
            case 1:
            case 9:
                r.x = v;
                r.y = h;
                break;
            case 2:
            case 7:
            case 8:
                r.x = -v;
                r.y = h;
                break;
            case 3:
            case 10:
                r.x = v;
                r.y = -h;
                break;
            case 4:
                r.x = -v;
                r.y = -h;
                break;
            case 5:
                r.x = -h;
                r.y = v;
                break;
            case 6:
                r.x = h;
                r.y = -v;
                break;
            default:
                Debug.LogWarning("Nenhuma das opçoes de embaralhamento foram selecionadas");
                break;
        }

        return r;
    }

    bool temGolpeEmRecarga(Criature C)
    {
        bool retorno = false;
        for (int i = 0; i < C.Golpes.Length; i++)//G.UltimoUso < Time.time -  G.TempoReuso
            if (Time.time - C.Golpes[i].UltimoUso < C.Golpes[i].TempoReuso && C.Golpes[i].TempoReuso > 2)
            {
                retorno = true;
                //			print(C.Golpes[i].nomeID);
            }
        return retorno;
    }

    void andaCriature4()
    {
        if (criature == null)
            criature = GetComponent<umCriature>();

        if (
            (Time.time - H.tempoDoUltimoUsoDeItem < H.intervaloParaUsarItem
            ||
            temGolpeEmRecarga(criature.X))
            &&
            !hudRecarga
            )
        {
            hudRecarga = Camera.main.gameObject.AddComponent<HUDRecarga>();
            hudRecarga.H1 = H;
        }


        if (Input.GetButtonDown("paraCriature") && heroi.emLuta == false)
        {
            alternancia a = GetComponent<alternancia>();
            a.retornaAoHeroi();
        }


        criatureVerificaTrocaGolpe(criature.X);

        criatureScroll();


        //bool grounded = noChao(.distanciaFundamentadora );

        // Forward vector relative to the camera along the x-z plane   
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        int temMedo = statusTemporarioBase.contemStatus(tipoStatus.amedrontado, criature.X);
        if (temMedo > -1)
        {
            Vector2 embaralhamento = embaralhaDeMedo(criature.X, temMedo, h, v);
            h = embaralhamento.x;
            v = embaralhamento.y;
        }

        Vector3 forward = direcaoInduzida(h, v);

        forward.y = 0;
        forward = forward.normalized;

        // Right vector relative to the camera
        // Always orthogonal to the forward vector
        Vector3 right = new Vector3(forward.z, 0, -forward.x);


        Vector3 direcaoAlvo = (h * right + v * forward);
        float targetSpeed = Mathf.Min(direcaoAlvo.magnitude, 1.0f);
        targetSpeed *= criature.X.velocidadeAndando;
        if (Input.GetButtonDown("Jump") && noChao(criature.X.distanciaFundamentadora))
        {
            ultimoYFundamentado = transform.position.y;
            pulo = true;
            controle.Move(Vector3.up * (criature.X.distanciaFundamentadora + 0.05f));

        }

        if (noChao(criature.X.distanciaFundamentadora))
        {
            pulo = false;
            if (Input.GetButtonDown("acao")
                ||
                Input.GetButtonDown("acaoAlt")
                )
            {

                Criature daki = criature.X;
                if (daki.Golpes[daki.golpeEscolhido].CustoPE <= daki.cAtributos[1].Corrente)
                {
                    aplicaGolpe(daki);
                }
                else
                {
                    usaItemEmLuta.mensagemDuranteALuta(bancoDeTextos.falacoes[heroi.lingua]["encontros"][4]);
                }
            }
            maisUmAtualizaSuavemente(v, h, criature.X, direcaoAlvo);

            direcaoMovimento = direcaoMovimento * 3 * targetSpeed + Vector3.down * criature.X.gravidade;
            //	+ criature.X.apliqueGravidade(Vector3.zero, direcaoMovimento ); 
            if (statusTemporarioBase.contemStatus(tipoStatus.paralisado, criature.X) > -1)
                direcaoMovimento /= 10;
            controle.Move((direcaoMovimento) * Time.deltaTime);
        }
        else
        {
            if (statusTemporarioBase.contemStatus(tipoStatus.paralisado, criature.X) > -1)
                direcaoAlvo /= 10;
            verificaPulo(direcaoAlvo, criature.X);
        }
        if (noChao(criature.X.distanciaFundamentadora))
        {
            if (Mathf.Abs(v) > 0.3f || Mathf.Abs(h) > 0.3f)
                transform.rotation = Quaternion.LookRotation(new Vector3(direcaoMovimento.x, 0, direcaoMovimento.z));

        }
        else
        {
            Vector3 xzMove = direcaoMovimento * Time.deltaTime;
            xzMove.y = 0;
            if (xzMove.sqrMagnitude > 0.001f)
            {
                transform.rotation = Quaternion.LookRotation(xzMove);

            }
        }

        animator.SetBool("noChao", noChao(criature.X.distanciaFundamentadora));
        animator.SetBool("pulo", pulo);
        animator.SetFloat("velocidade", Mathf.Abs(v) + Mathf.Abs(h));
    }

    void andaCorean()
    {

        if (Input.GetButtonDown("paraCriature") && heroi.emLuta == false && !variaveisChave.shift["alternaParaCriature"])
        {
            alternancia a = GameObject.Find("CriatureAtivo").GetComponent<alternancia>();
            a.aoCriature();
        }


        //criatureVerificaTrocaGolpe(criature.X);			

        criatureScroll();


        //bool grounded = noChao(.distanciaFundamentadora );

        // Forward vector relative to the camera along the x-z plane   

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        Vector3 forward = direcaoInduzida(h, v);

        forward.y = 0;
        forward = forward.normalized;

        // Right vector relative to the camera
        // Always orthogonal to the forward vector
        Vector3 right = new Vector3(forward.z, 0, -forward.x);


        Vector3 direcaoAlvo = (h * right + v * forward);
        //		float targetSpeed= Mathf.Min(direcaoAlvo.magnitude, 1.0f);
        //targetSpeed *= criature.X.velocidadeAndando;
        if (Input.GetButtonDown("Jump") && noChao(Y.distanciaFundamentadora))
        {
            ultimoYFundamentado = transform.position.y;
            pulo = true;
            controle.Move(Vector3.up * (Y.distanciaFundamentadora + 0.05f));

        }

        if (noChao(Y.distanciaFundamentadora))
        {
            pulo = false;


            maisUmAtualizaSuavemente(v, h, Y, direcaoAlvo);

            direcaoMovimento = direcaoMovimento// * targetSpeed
                + Y.apliqueGravidade(Vector3.zero, direcaoMovimento); //+ Vector3.down * criature.X.gravidade;
                                                                      //controle.Move ((direcaoMovimento) * Time.deltaTime);
        }
        else
        {
            verificaPulo(direcaoAlvo, Y);
        }
        if (noChao(Y.distanciaFundamentadora))
        {
            if (Mathf.Abs(v) > 0.3f || Mathf.Abs(h) > 0.3f)
                transform.rotation = Quaternion.LookRotation(new Vector3(direcaoMovimento.x, 0, direcaoMovimento.z));

        }
        else
        {
            Vector3 xzMove = direcaoMovimento * Time.deltaTime;
            xzMove.y = 0;
            if (xzMove.sqrMagnitude > 0.001f)
            {
                transform.rotation = Quaternion.LookRotation(xzMove);

            }
        }

        float vel = Mathf.Min(Mathf.Abs(v) + Mathf.Abs(h), 1);
        if (vel < 0.1f)
            vel = 0;

        if (Input.GetButton("Correr"))
            vel *= 3;

        animator.SetBool("noChao", noChao(Y.distanciaFundamentadora));
        animator.SetBool("pulo", pulo);
        animator.SetFloat("velocidade", vel);
    }

}