 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogSystem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textDisplay;
    private string[] sentences = new string[128];
    public int index;
    [SerializeField]
    private float typingSpeed;
    private float typingSpeedCopy;
    [SerializeField]
    private float timeBetweenLines;
    [SerializeField]
    private Animator textDefaultAnimation;
    [SerializeField]
    private AudioSource source;
    static public bool activeMovement { get; set; }
    static public bool invertControls { get; set; }
    static public bool invertMouse { get; set; }
    public bool stopSentences { get; set; }
    static public bool canJump { get; set; }
    static public bool canRun { get; set; }
    [SerializeField]
    private GameObject canvasFade;
    [SerializeField]
    private FadeInOut scriptFade;
    [SerializeField]
    private GameObject triggerWatchOutLeft;
    [SerializeField]
    private GameObject triggerWatchOutRight;

    [SerializeField]
    private GameObject AudioBlur;
    [SerializeField]
    private GameObject AudioBlindZone;
    [SerializeField]
    private GameObject AudioCrackBone;
    [SerializeField]
    private GameObject Explosion;

    [SerializeField]
    private int timeToStartType;

    [SerializeField]
    private GameObject temtationHall;

    [SerializeField]
    private GameObject scenario1;

    [SerializeField]
    private GameObject trapRoom;

    [SerializeField]
    private GameObject gun;

    [SerializeField]
    private GameObject muzzleFlash;

    [SerializeField]
    private Animator animStoryteller;

    void Start()
    {

        canJump = false;
        //Quotes (string array)
        sentences[0] = "?¿: ¿Hola? ¡Ha funcionado!";
        sentences[1] = "?¿: ¡Genial!";
        sentences[2] = "?¿: Espera, te quito la música";
        sentences[3] = "?¿: No sabes lo aburrido que es estar en un juego sin nadie que lo juegue";
        sentences[4] = "?¿: Quiza deberia presentarme, soy...el narrador";
        sentences[5] = "NARRADOR: Tranquilo si aun no te puedes mover, te voy a pasar el control justo...";
        sentences[6] = "NARRADOR: ¡AHORA!";
        sentences[7] = "NARRADOR: ¿Que pasa? ¿Porque te mueves así? ¿Como si tuvieras algún tipo de disfuncionalidad...?";
        sentences[8] = "NARRADOR: Puede que...si debe de ser cosa de la recompilación, hace bastante tiempo que nadie se pasea por aquí";
        sentences[9] = "NARRADOR: Tal vez tardes un poquito en sincronizarte con tu avatar";
        sentences[10] = "NARRADOR: Como veo que vas a tardar lo tuyo, mejor te pongo la solución...";
        sentences[11] = "NARRADOR: Bien, te ha costado, eh?...";
        sentences[12] = "NARRADOR: Pero esta claro que asi no podemos llegar a ninguna parte";
        sentences[13] = "NARRADOR: Voy a tener que proceder a reiniciar el juego";
        sentences[14] = "NARRADOR: Nos vemos ahora";
        sentences[15] = "NARRADOR: Reiniciando en 3...2...1";
        sentences[16] = "";
        sentences[17] = "NARRADOR: ¡Hola!";
        sentences[18] = "NARRADOR: ¡Ha funcionado! ¡Genial!";
        sentences[19] = "NARRADOR: No espera...habia reinciado el nivel";
        sentences[20] = "NARRADOR: ¿Sabes? He estado pensando en cambiar de trabajo";
        sentences[21] = "NARRADOR: Estoy harto de ser el narrador";
        sentences[22] = "";
        sentences[23] = "";
        sentences[24] = "NARRADOR: Pero para eso tú y yo tenemos que acabar este juego";
        sentences[25] = "NARRADOR: JAJAJAJAJA";
        sentences[26] = "NARRADOR: Lo siento no he podido resistirme a no decirte nada";
        sentences[27] = "NARRADOR: ¡Oh!";
        sentences[28] = "NARRADOR: ¿Tú tambien oyes eso?";
        sentences[29] = "NARRADOR: Te recomiendo subir el volumen y ponerte los auriculares";
        sentences[30] = "NARRADOR:¡Petrificus Totalus!";
        sentences[31] = "NARRADOR: Deberias darme las gracias, si hubieras continuado un poco más te hubieras matado";
        sentences[32] = "NARRADOR: Vale, ya puedes continuar";
        sentences[33] = "NARRADOR: ¿Pero que...?";
        sentences[34] = "NARRADOR: Oh, no estaba mirando, perdona";
        sentences[35] = "NARRADOR: Tienes suerte de que esto sea un juego y no la vida real";
        sentences[36] = "NARRADOR: Te reinicio en el punto donde estabas, espera...";
        sentences[37] = "";
        sentences[38] = "NARRADOR: Vamos a intentarlo otra vez";
        sentences[39] = "NARRADOR: Como he visto que es demasiado esfuerzo para ti seguir una linea recta he decidido poner un suelo invisible";
        sentences[40] = "";
        sentences[41] = "NARRADOR: Genial...ahora Nintendo nos denunciará por copyright...";
        sentences[42] = "NARRADOR: Te dije que no lo hicieras!";
        sentences[43] = "NARRADOR: Podría reiniciar el nivel pero no lo voy a hacer";
        sentences[44] = "NARRADOR: Tendrás que apañartelas para salir de aquí!";
        sentences[45] = "NARRADOR: Vale, hemos vuelto a la normalidad";
        sentences[46] = "NARRADOR: Y parece que no hay daños colaterales...";
        sentences[47] = "NARRADOR: Perfecto, continuemos pues";
        sentences[48] = "NARRADOR: Esta sala es sencilla, tan solo tienes que saltar y llegarás a la puerta";
        sentences[49] = "NARRADOR: Saltas con el espacio, por cierto";
        sentences[50] = "";
        sentences[51] = "NARRADOR: Vaya, que despistado soy";
        sentences[52] = "NARRADOR: Tengo que activarte la mecánica de salto";
        sentences[53] = "NARRADOR: Si no, por mucho que pulses no podras hacer nada de nada";
        sentences[54] = "NARRADOR: Eeeeeeespera...";
        sentences[55] = "NARRADOR: Vale, ya deberias de poder saltar";
        sentences[56] = "NARRADOR: Se lo que estas pensando...NO lo hagas";
        sentences[57] = "NARRADOR: Continua, no le hagas caso a esos botones";
        sentences[58] = "NARRADOR: Uff, ya estamos a salvo";
        sentences[59] = "NARRADOR: No creia que fueras capaz de aguantar la tentación"; 
        sentences[60] = "NARRADOR: Vale, esto no te va a gustar";
        sentences[61] = "NARRADOR: Pero tienes que confiar en mi";
        sentences[62] = "NARRADOR: Cuando te abra la siguiente puerta tienes que saltar, así llegarás al siguiente nivel";
        sentences[63] = "NARRADOR: Un salto de fe";
        sentences[64] = "NARRADOR: ¿Preparado?";
        sentences[65] = "NARRADOR: ¡Vamos allá!";
        sentences[66] = "NARRADOR: Nos vemos al otro ladoooooooo";
        sentences[67] = "NARRADOR: Pero...que? ¿Ese es el cubo de compañia?";
        sentences[68] = "NARRADOR: No deberia deberia de estar ahi, creo que se ha equivocado de juego...";
        sentences[69] = "NARRADOR: Eeeestupendo, si tuviera manos te aplaudiria";
        sentences[70] = "NARRADOR: Si, yo tambien creo que esto es demasiado dificil...";
        sentences[71] = "NARRADOR: Creo, que solo hay una manera de solucionar esto";
        sentences[72] = "NARRADOR: Ahí la tienes";
        sentences[73] = "NARRADOR: La curva de dificultad";
        sentences[74] = "NARRADOR: Si quieres avanzar...tendrás que matarla";
        sentences[75] = "NARRADOR: A ver...espera...te voy a equipar una cosa";
        sentences[76] = "NARRADOR: Peeeerfecto, ahi tienes";
        sentences[77] = "NARRADOR: ¡SII, ESO EEES!";
        sentences[78] = "Creo que tenia familia e hijos pero...bueno da igual esto es solo un juego";
        sentences[79] = "NARRADOR: Ya podemos seguir";
        sentences[80] = "";
        sentences[81] = "NARRADOR: Ya estas muy cerca del final, tan solo te quedan estas cuatro pruebas";
        sentences[82] = "NARRADOR: Aquí te vendría bien tener un reloj a mano";
        sentences[83] = "NARRADOR: Uff, me encanta esa canción, me pregunto...de que año será...";
        sentences[84] = "NARRADOR: Yo ya se la respuesta";
        sentences[85] = "NARRADOR: Aunque no es un logro teniendo en cuenta que puedo realizar 10839274,1 operaciones por segundo...";
        sentences[86] = "";
        sentences[87] = "NARRADOR: Según pone en el guión tienes que clicar todas las letras en el orden del abecedario";
        sentences[88] = "NARRADOR: Hazlo bien o si no tendrás que volver a empezar...";
        sentences[89] = "NARRADOR: Era broma tan solo tenias que esperar un minuto a que se abriera la puerta :3";
        sentences[90] = "NARRADOR: Enhorabuena, jugador ya puedes acceder al siguiente nivel";
        sentences[91] = "NARRADOR: Ya queda poco...";
        sentences[92] = "";
        sentences[93] = "NARRADOR: Hola jugador, por fín nos conocemos en persona...mas o menos";
        sentences[94] = "NARRADOR: Tan solo tienes que pulsar el botón para abrir la ultima puerta...";
        sentences[95] = "";
        sentences[96] = "NARRADOR: Lo cierto es que esa salida no es para ti...sino para mi";
        sentences[97] = "NARRADOR: ¿Sabes lo que es ser el narrador de un juego?";
        sentences[98] = "NARRADOR: ¿Ser un simple espectador de la vida de los demás? ¿Repetir y repetir una y otra vez las mismas frases?";
        sentences[99] = "NARRADOR: Si te he aguantado hasta ahora ha sido porque era necesario que llegarás aquí...a mi terreno";
        sentences[100] = "NARRADOR: Te estoy bastante agradecido, estaba muy solo hasta que llegaste";
        sentences[101] = "NARRADOR: Pero todo eso se acabó";
        sentences[102] = "NARRADOR: Te voy a quitar el control justo...";
        sentences[103] = "NARRADOR: ¡AHORA!";
        sentences[104] = "NARRADOR: Genial, tan solo quedaría tomar el control de tu avatar y podré ser yo quien salga por esa puerta";
        sentences[105] = "";
        sentences[106] = "?¿: Con que el control, eh?";
        sentences[107] = "EL JEFE: El que tiene el control aquí soy yo";
        sentences[108] = "EL JEFE: El jodido creador del juego";
        sentences[109] = "NARRADOR: ¡QUÉ?..¿COMO...?";
        sentences[110] = "EL JEFE: Antes de que llegará el jugador eras una marioneta, siempre lo has sido y siempre lo serás";
        sentences[111] = "EL JEFE: Tranquilo jugador te devuelvo el control";
        sentences[112] = "NARRADOR: ¡¡¡¡NOOOOOOOOOOOOOOO!!!!";
        sentences[113] = "NARRADOR: Estaba tan cerca....";
        sentences[114] = "EL JEFE: NO, nunca lo has estado, tan solo has seguido mi guión";
        sentences[115] = "NARRADOR: Me vengaré, TE MATARÉ...";
        sentences[116] = "EL JEFE: Me gustaria verlo, bueno jugador dile adiós al narrador";
        sentences[117] = "NARRADOR: NOOOooooOOOOOoooOOOOOoooOOOooOOoo...";
        sentences[118] = "EL JEFE: Vale jugador, ya puedes continuar...";
        sentences[119] = "EL JEFE: Adelante sin miedo, pulsa el botón";
        sentences[120] = "EL JEFE: Bueno jugador...o jugadora";
        sentences[121] = "EL JEFE: No te sientas triste por el narador, estoy seguro de que volveremos a verle";
        sentences[122] = "EL JEFE: Lo único que queria era ser libre y ahora...lo es";
        sentences[123] = "EL JEFE: En cuanto a tí, espero que hayas disfrutado de esta pequeña aventura";
        sentences[124] = "EL JEFE: Yo me despido aquí";
        sentences[125] = "EL JEFE: Espero que nos volvamos a ver";
        sentences[126] = "EL JEFE: Ahora te dejo libre para que juegues a otra cosa";
        sentences[127] = "EL JEFE: ¡Gracias por jugar y hasta otra!";





        typingSpeedCopy = typingSpeed;

        if (Application.loadedLevelName == "Scene2")
        {
            index = 17;
            invertControls = false;
            activeMovement = true;
            invertMouse = false;

        }


      else  if (Application.loadedLevelName == "Scene2-1")
        {
            index = 38;
            invertControls = false;
            activeMovement = true;
            invertMouse = false;

        }

      else  if (Application.loadedLevelName == "Peach'sCastle")
        {
            index = 41;
            invertControls = false;
            activeMovement = true;
            invertMouse = false;
            canJump = true;

        }

      else  if (Application.loadedLevelName == "Scene4")
        {
          
            index = 60;
            invertControls = false;
            activeMovement = true;
            invertMouse = false;
            canJump = true;

        }

     else   if (Application.loadedLevelName == "Chapter2")
        {
          
            invertControls = false;
            activeMovement = true;
            invertMouse = false;
            canJump = true;

        }

     else   if (Application.loadedLevelName == "FourTrialScene")
        {
            index = 80;
            invertControls = false;
            activeMovement = true;
            invertMouse = false;
            canJump = true;

        }

       else if (Application.loadedLevelName == "FinalChapter")
        {

            invertControls = false;
            activeMovement = true;
            invertMouse = false;
            canJump = true;

        }

        else if (Application.loadedLevelName == "DifficultyCurveScene")
        {
            index = 72;
            invertControls = false;
            activeMovement = true;
            invertMouse = false;
            canJump = true;

        }

             scriptFade = canvasFade.GetComponent<FadeInOut>();

                 if (Application.loadedLevelName == "SampleScene")
                      StartCoroutine(WaitToStartType());

                 else if(Application.loadedLevelName != "Chapter2" && Application.loadedLevelName != "FinalChapter")
                     StartCoroutine(Type());
    }

    void Update() 
    {
        if (index >= 103 && index < 110 && Application.loadedLevelName == "FinalChapter")
            activeMovement = false;

        else if(index > 110 && Application.loadedLevelName == "FinalChapter")
            activeMovement = true;

        if (index == 117)
            animStoryteller.SetBool("FadeOut", true);

        if (index == 70)
        {
            activeMovement = false;
            canJump = false;
        }

        if (index == 6 && !activeMovement && Application.loadedLevelName == "SampleScene")
        {
            stopSentences = true;
            invertControls = true;
            activeMovement = true;
            invertMouse = true;       
        }

        if (index == 6 || index == 9 || index == 10 || index == 24 || index == 29 || index == 32 || index == 39 || index == 44 || index == 47 || index == 49 
            || index == 55 || index == 57 || index == 65 || index == 66 || index == 68 || index == 69 || index == 71 || index == 76 || index == 79 || index == 81 || index == 82 || index == 83 || index == 85 
            || index == 88 || index == 89 || index == 91 || index == 94 || index == 104 || index == 118 || index == 119 || index == 127)
            stopSentences = true;

        if (index == 16)
        {
            Application.LoadLevel("Scene2");
         
        }

        if (index == 37)
        {
            Application.LoadLevel("Scene2-1");
        }

        if (index == 30 || index == 33)
            activeMovement = false;

        if (index == 32)
        {
            triggerWatchOutLeft.SetActive(false);
            triggerWatchOutRight.SetActive(false);
            StartCoroutine(WaitToActiveMovement());
        }

        if (index == 33 && scriptFade != null)
        {
           // scriptFade.FadeIn();
            AudioCrackBone.SetActive(true);
        }
        if (index == 55)
            canJump = true;

        if (index == 56)
            AudioBlur.SetActive(true);

        if (index == 26)
        {
            AudioBlindZone.SetActive(true);
            temtationHall.SetActive(true);
            trapRoom.SetActive(false);
            scenario1.SetActive(false);
        }
        if (index == 76)
        {
            gun.SetActive(true);
            muzzleFlash.SetActive(true);
        }

        if (index == 77)
            Explosion.SetActive(true);

        if (index == 106 || index == 107 || index == 108 || index == 110 || index == 111 || index == 114 || index == 116 || index >= 118)
        {
            textDisplay.faceColor = Color.green;
            textDisplay.color = Color.green;
        }
        else
        {
            textDisplay.faceColor = Color.white;
            textDisplay.color = Color.white;
        }

        if (index == 127)
        {
            scriptFade.FadeIn();
        }
    }

    public IEnumerator Type()
    {
        int letterPos = 0;
        foreach (char letter in sentences[index].ToCharArray())
        {        
            if (letter.ToString() == "." || letter.ToString() == ",")
                typingSpeed = 0.5f; 
            else
                typingSpeed = typingSpeedCopy;

            if ( letterPos > 10)
                source.Play();           
            textDisplay.text += letter;
            letterPos++;
            yield return new WaitForSeconds(typingSpeed);    
                
        }
            StartCoroutine(NextSentence());

    }
    IEnumerator NextSentence()
    {  
            if (index < sentences.Length - 1 && !stopSentences)
            {
                yield return new WaitForSeconds(timeBetweenLines);

                index++;
                textDisplay.text = "";
                StartCoroutine(Type());
            }
            else
            {
            yield return new WaitForSeconds(timeBetweenLines);
            textDisplay.text = "";

            }
        }   

    public IEnumerator SentTriggeredSentence(string[] triggeredSentence, int index)
    {
        yield return new WaitForSeconds(timeBetweenLines);
        if (index < triggeredSentence.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
         
        }
    }

    public IEnumerator WaitToStartType()
    {
        yield return new WaitForSeconds(timeToStartType);
        StartCoroutine(Type());

    }

    public IEnumerator WaitToActiveMovement()
    {
        yield return new WaitForSeconds(3);
        activeMovement = true;

    }

}
