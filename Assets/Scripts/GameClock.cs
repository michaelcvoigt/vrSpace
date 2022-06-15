using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameClock : MonoBehaviour
{
	[SerializeField]
	public TextMeshPro timeText;
	[SerializeField]
	public TextMeshPro dateText;

	private float gameRunTime;

	private string ampm;
	private float minutes;
	private float hours;
	private int day;
	private int month;
	private int year;
	
	private float currentHours;
	private int currentDay;
	private int currentMonth;
	private int currentYear;	

	void Start()
	{
		ampm = "PM";		
		currentDay = 16;
		currentMonth = 12;
		currentYear = 2021;
		dateText.text = "August 27, 2019"; //currentMonth.ToString("00") + "/" + currentDay.ToString("00") + "/" + currentYear.ToString("00");

	}

	void Update()
	{
		gameRunTime = Time.time;
		ConvertTime();

	}

	private void ConvertTime()
	{
		minutes = Mathf.Floor(gameRunTime % 60);
		hours = Mathf.Floor(gameRunTime / 60 % 12);
		//day = Mathf.FloorToInt(gameRunTime) / 1440 % 31;
		//month = Mathf.FloorToInt(gameRunTime) / 44640 % 12;
		//year = Mathf.FloorToInt(gameRunTime) / 535680;

		Display();
	}

	private void Display()
	{
		timeText.text = hours.ToString("00") + ":" + minutes.ToString("00") + " " + ampm;
		//dateText.text = currentMonth.ToString("00") + "/" + currentDay.ToString("00") + "/" + currentYear.ToString("00");
	}


}
