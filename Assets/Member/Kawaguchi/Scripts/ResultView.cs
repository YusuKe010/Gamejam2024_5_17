using UnityEngine;
using UnityEngine.UI;

public class ResultView : MonoBehaviour
{
	[SerializeField, Header("感染者人数を表示するテキスト")] private Text _text;
	[SerializeField] private Font _font;
	[SerializeField, Header("フォントの大きさ")] private int _fontSize = 50;
	private void Start()
	{
		Result();
	}

	void Result()
	{
		SaveManage.Instance.Save(SaveManage.Instance.Data);
		
		_text.text = $"本日の感染者{SaveManage.Instance.Data.InfectionCount.ToString()}人";
		for (int i = 0; i < 5; i++)
		{
			var obj = new GameObject($"Cell{i}").AddComponent<Text>();
			obj.transform.parent = this.transform;
			obj.text = $"{i + 1}位:{SaveManage.Instance.Data.Score[i].ToString()}ポイント";
			
			TextSetting(obj);
		}
	}

	void TextSetting(Text obj)
	{
		obj.font = _font;
		obj.fontSize = _fontSize;
		obj.alignment = TextAnchor.MiddleCenter;
		obj.horizontalOverflow = HorizontalWrapMode.Overflow;
		obj.verticalOverflow = VerticalWrapMode.Overflow;
	}
}
