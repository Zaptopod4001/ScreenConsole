using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Eses.ScreenConsole
{

    // Copyright Sami S.

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.

    public class ScreenConsole : MonoBehaviour
    {
        public static ScreenConsole instance;

        [Header("Console Settings")]
        public float minY = 0f;
        public float maxY = 0.3f;
        public float maxX = 0.3f;
        public int rows = 32;
        public int fontSize = 24;
        public Color textColor = Color.green;

        // local
        RectTransform prt;
        Canvas canvas;

        // lists
        List<Text> textList;
        Queue<string> textRows;


        void OnDisable()
        {
            Application.logMessageReceived -= HandleLog;
        }

        void Awake()
        {
            instance = this;
            textList = new List<Text>();
            Application.logMessageReceived += HandleLog;
            CreateCanvas();
        }

        void Start()
        {
        }


        void CreateCanvas()
        {
            GameObject consoleGo = new GameObject();

            // Canvas
            consoleGo.AddComponent<Canvas>();
            canvas = consoleGo.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.name = "canvas";

            consoleGo.transform.SetParent(this.transform);

            // Scaler
            consoleGo.AddComponent<CanvasScaler>();
            var sc = canvas.GetComponent<CanvasScaler>();
            sc.referenceResolution = new Vector2(1920, 1080);
            sc.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;


            // Panel
            var panel = new GameObject();
            panel.AddComponent<RectTransform>();
            panel.transform.SetParent(consoleGo.transform);
            panel.name = "panel";
            panel.AddComponent<Image>().color = new Vector4(0, 0, 0, 0.6f);


            // Vertical layout
            prt = panel.GetComponent<RectTransform>();
            panel.AddComponent<VerticalLayoutGroup>();

            // Anchor item
            prt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 4f);
            prt.anchoredPosition = Vector2.zero;
            prt.offsetMin = new Vector2(0, minY);
            prt.offsetMax = new Vector2(maxX, maxY);
            prt.anchorMin = new Vector2(0, minY);
            prt.anchorMax = new Vector2(maxX, maxY);


            // rows
            for (int i = 0; i < rows; i++)
            {
                GameObject textGo = new GameObject();
                textGo.name = "row";
                textGo.transform.SetParent(panel.transform);

                // Set text
                textGo.AddComponent<Text>();
                var text = textGo.GetComponent<Text>();
                text.text = ">";
                text.fontSize = fontSize;
                text.resizeTextForBestFit = true;
                text.color = textColor;

                // Layout element
                textGo.AddComponent<LayoutElement>();
                var le = textGo.GetComponent<LayoutElement>();
                le.preferredHeight = fontSize;

                // Font
                Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
                text.font = ArialFont;

                // store to list
                textList.Add(text);
            }

            // Output queue
            textRows = new Queue<string>(textList.Count);
        }


        void HandleLog(string logString, string stackTrace, LogType type)
        {
            PrintText("> " + logString);
        }


        void PrintText(string text)
        {
            textRows.Enqueue(text);

            if (textRows.Count > textList.Count)
            {
                textRows.Dequeue();
            }

            UpdateTexts();
        }


        void UpdateTexts()
        {
            int i = 0;

            foreach (string item in textRows)
            {
                textList[i].text = item;
                textList[i].color = textColor;
                i++;
            }
        }

    }

}

