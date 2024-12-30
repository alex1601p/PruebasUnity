using UnityEngine;
using System.Collections;
using TMPro;

public class Dialogo : MonoBehaviour

{
    private bool PlayerTrigger; //Detecta cuando el BoxCollider del NPC detecta el del jugador
    private bool DialogueStart; //Boleando para saber si se esta ejecutando un dialogo o no
    private int LineIndex; //Indica cual linea de dialogo se esta ejecutando
    [SerializeField,TextArea(4,6)] private string[] dialogueLines;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TMP_Text DialogueText; 
    [SerializeField] private float Seconds;
    
    void Update()
    {
        if(PlayerTrigger && Input.GetButtonDown("Fire1")) //Se activa el dialogo con el click izquierdo o ctrl
	{
		if(!DialogueStart) 
		{
			StartDialogue();
		}
		else if (DialogueText.text == dialogueLines[LineIndex]) //Cuando acaba una linea de dialogo se carga la siguiente
		{
			ShowNextLine();
		}
		else //En caso de que no queramos que se escriban las letras una por una volvemos a presionar el boton de accion y mostrara el dialogo completo
		{
			StopAllCoroutines();
			DialogueText.text = dialogueLines[LineIndex];
		}
	}    
    }


    private void StartDialogue()
    {
	DialogueStart = true;
	DialoguePanel.SetActive(true); 
	LineIndex = 0; //Esto debido a que se esta comenzando el dialogo
	StartCoroutine(ShowLine());
    }	

    private void ShowNextLine()
    {
	LineIndex++;
	if (LineIndex < dialogueLines.Length)
	{
		StartCoroutine(ShowLine());
	}
	else
	{
		DialogueStart = false;
		DialoguePanel.SetActive(false);
	}
    }

    private IEnumerator ShowLine()
    {
	DialogueText.text = string.Empty;
	foreach(char ch in dialogueLines[LineIndex])
	{
		DialogueText.text += ch;
		yield return new WaitForSeconds(Seconds);
	}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
	if (collision.gameObject.CompareTag("Player"))
	{
		PlayerTrigger = true;
		Debug.Log("Hola");
	}
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
	if (collision.gameObject.CompareTag("Player"))
         {
        	PlayerTrigger = false;
		Debug.Log("Adios");
         }
    }

}
