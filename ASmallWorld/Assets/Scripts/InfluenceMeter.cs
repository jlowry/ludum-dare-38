using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ASmallWorld {
    public class InfluenceMeter : MonoBehaviour
    {
        public RectTransform red;
        public RectTransform blue;
        public RectTransform green;
        public RectTransform yellow;

        private RectTransform rectTransform;

        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void SetPercentages(float r, float g, float b, float y)
        {
            float width = rectTransform.rect.width;
            float redWidth = width * r;
            float greenWidth = width * g;
            float blueWidth = width * b;
            float yellowWidth = width * y;
            float offset = 0.0F;
            red.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, offset, redWidth);
            offset += redWidth;
            green.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, offset, greenWidth);
            offset += greenWidth;
            blue.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, offset, blueWidth);
            offset += blueWidth;
            yellow.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, offset, yellowWidth);
        }

    }
}

