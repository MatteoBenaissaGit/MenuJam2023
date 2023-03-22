using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

namespace Menu
{
    [Serializable]
    public struct MenuAsset
    {
        public List<Image> MenuImagesList;
        public List<TMP_Text> MenuTextList;
    }
}