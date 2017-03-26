﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private string name; //Имя игрока
    private Suprime[] suprimes; //ВС, которыми владеет игрок
    private List<Crystall> crystalls; //Кристалы, которыми владеет игрок
    private GameManager manager;
	// Use this for initialization
    void Start () {
		manager = new GameManager();
        this.PlayerName = name;
        suprimes = new Suprime[manager.MaxSuprimeAmount];
        crystalls = new List<Crystall>();
	}
	//возвращает имя игрока
    public string GetName { get {return name; } }
	//Возвращает массив кристаллов принадлежавших игроку
	public Suprime[] GetSuprimes { get { return suprimes; } }
    //Возвращает массив юнитов принадлежавших игроку
    public List<Crystall> GetCrystalls{ get {return crystalls;} }
    public string PlayerName { get{return name;}  set { name = value; } }

    //Возвращает кол-во ВС под контролем игрока
    public int getNumOfSuprime() { return suprimes.Length; }
	//Добавляет ВС в массив suprimes
	public void addSuprime(Suprime suprime) {
		if(getNumOfSuprime() <= manager.MaxSuprimeAmount) {
            suprimes[getNumOfSuprime() - 1] = suprime;
        }
	}
	public void addCrystall(Crystall crystall) {
        crystalls.Add(crystall);
    }

    public GameManager getManager { get { return manager; } }

    // Update is called once per frame
    void Update () {
		
	}
}
