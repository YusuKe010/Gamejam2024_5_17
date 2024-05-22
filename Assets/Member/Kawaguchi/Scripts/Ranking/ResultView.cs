using UnityEngine;
using UnityEngine.UI;

public class ResultView : MonoBehaviour
{
    [SerializeField, Header("感染者人数を表示するテキスト")] private Text _infectionText;
    [SerializeField] private Font _font;
    [SerializeField, Header("フォントの大きさ")] private int _fontSize = 50;
    [SerializeField, Header("表示人数")] int numberOfPersons = 3;
    [SerializeField, Header("今回のスコアを表示するテキスト")] Text _currentScoreText;

    private void Start()
    {
        Result();
    }

    //ランキング
    void Result()
    {
        _infectionText.text = $"本日の感染者{SaveManage.Instance.Data.InfectionCount.ToString()}人";
        _currentScoreText.text = $"今回のスコア:{SaveManage.Instance.Data.CurrentScore}ステージ";

        for (int i = 0; i < numberOfPersons; i++)
        {
            if (SaveManage.Instance.Data.Score[i] != 0)
            {
                var obj = new GameObject($"Cell{i}").AddComponent<Text>();
                obj.transform.parent = this.transform;
                obj.text = $"{i + 1}位:{SaveManage.Instance.Data.Score[i].ToString()}ステージ";

                TextSetting(obj);
            }
        }
    }

    //テキストの設定
    void TextSetting(Text obj)
    {
        obj.font = _font;
        obj.fontSize = _fontSize;
        obj.alignment = TextAnchor.MiddleCenter;
        obj.horizontalOverflow = HorizontalWrapMode.Overflow;
        obj.verticalOverflow = VerticalWrapMode.Overflow;
    }
}
