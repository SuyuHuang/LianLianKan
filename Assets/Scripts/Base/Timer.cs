using System.Collections;
using System.Collections.Generic;
using Scripts;
using Scripts.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : SingleTemplate<Timer>
{
	public TMP_Text remainingHP;

	private Slider _slider;


	public float SliderValue
	{
		get
		{
			if (!_slider)
			{
				_slider = GetComponent<Slider>();
			}
			return _slider.value;
		}
		set { _slider.value = value; }
	}



	// Use this for initialization
	void Start()
	{
		_slider = GetComponent<Slider>();
	}
	public void UpdateHP()
    {
		remainingHP.text = (int)(_slider.value * 100)+"";
    }

	private void Update()
	{
		if (BattleManager.level != 0)
		{
			if ((GameManager.IsPause == false) && (GameManager.IsOver == false))
			{
				_slider.value -= 0.0001f;

			}

			if (_slider.value <= 0) GameManager.IsOver = true;
		}
        else
        {
			if ((GameManager.IsPause == false) && (GameManager.IsOver == false))
			{
				_slider.value -= 0.0001f;

			}
		}
		UpdateHP();
	}
}
