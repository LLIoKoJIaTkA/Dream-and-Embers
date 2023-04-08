using System.Collections;
using TMPro;
using UnityEngine;

namespace Scenes._0_Scene___Village.Scripts
{
    public class Dialogue : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] string[] lines;
        [SerializeField] float TextSpeed;

        private int index;
        // Start is called before the first frame update
        void Start()
        {
            text.text = string.Empty;
            StartDialogue();

        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(text.text == lines[index])
                {
                    IsNextLine();
                }
                else
                {
                    StopAllCoroutines();
                    text.text = lines[index];
                }
            }
        }

        void StartDialogue(){
            index = 0;
            StartCoroutine(TypeLine());
        }

        IEnumerator TypeLine(){
            foreach(char c in lines[index].ToCharArray())
            {
                text.text += c;
                yield return new WaitForSeconds(TextSpeed);
            }
        }

        void IsNextLine(){
            if(index < lines.Length - 1)
            {
                index++;
                text.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
