using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI _textOnScreen; //текст в канвосе

    [SerializeField] 
    private TextAsset _textFile; // текст в файле

    [SerializeField] 
    private float _symbolDelay = 0.05f; //скорость печатания текста

    private string[] _textInLines; //массив текста
    private int _numberLine = 0; //номер строки
    private bool _clickCheker = false; //проверка на то пишется ли сейчас текст

    public void Start()
    {
        _textInLines = _textFile.text.Split('\n'); //получаем из файла текст
    }

    public void Update()
    {
        WriteTextLetterByLetter(_textInLines, _textOnScreen, _symbolDelay); //вызываем метод печатания
    }

    public void WriteTextLetterByLetter(string[] text, TextMeshProUGUI textOnScreen, float textSpeed)
    {
        if ((Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)) && _clickCheker == false) //проверяем на нажатие
        {
            _clickCheker = true; //ставим что текст печаетается
            if (_numberLine == text.Length) //проверка на конец текста закончился ли весь текст
            {
                textOnScreen.text = ""; //стираем текст
                _numberLine = 0; //обнуляем строчку
                _clickCheker = false; //ставим флаг что текст не печатается
                return; //выходим из метода 
            }

            if (_numberLine <= text.Length) //проверяем не вышли ли за пределы количества строчек
            {
                string newText = text[_numberLine]; // получаем текст строчки 
                StartCoroutine(WriteLBL(newText, textOnScreen, textSpeed)); //вызываем метод для печатания текста
                _numberLine++; //переходим на след стрчоку
            }
        }
    }

    private IEnumerator WriteLBL(string text, TextMeshProUGUI resultText, float speed)
    {
        for (int i = 0; i <= text.Length; i++) //проверкан а то вышли ли за рамки
        {
            resultText.text = text.Substring(0, i); //прибавляем один символ
            yield return new WaitForSeconds(speed); //ждем заданное время
        }

        _clickCheker = false; //ставим что текст напечатался и можно дальше нажимать
    }

    public void ButtonEvent()
    {
        Debug.Log("Нажатие");
    }

}
