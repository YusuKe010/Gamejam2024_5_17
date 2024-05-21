using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StartCountDown : MonoBehaviour
{
	[SerializeField] private Text _text;
	private IEnumerator _enumerator;

	private void Start()
	{
		GameStart();
		foreach (var item in FindObjectsOfType<GameObject>()
			         .Where(_ => _.GetComponent<IPose>() != null)
			         .Select(_ => _.GetComponent<IPose>()).ToList())
		{
			item.InPose();
		}
	}

	void GameStart()
	{
		_text.gameObject.SetActive(true);
		StartCoroutine(CountDown());
	}

	IEnumerator CountDown()
	{
		_text.text = "3";
		yield return new WaitForSeconds(1f);
		_text.text = "2";
		yield return new WaitForSeconds(1f);
		_text.text = "1";
		yield return new WaitForSeconds(1f);
		_text.text = "Start";
		yield return new WaitForSeconds(0.5f);
		_text.gameObject.SetActive(false);
		foreach (var item in FindObjectsOfType<GameObject>()
			         .Where(_ => _.GetComponent<IPose>() != null)
			         .Select(_ => _.GetComponent<IPose>()).ToList())
		{
			item.OutPose();
		}
	}
}
