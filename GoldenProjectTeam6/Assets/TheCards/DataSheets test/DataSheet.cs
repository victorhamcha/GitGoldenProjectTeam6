
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DataSheet{
	//Document URL: https://spreadsheets.google.com/feeds/worksheets/1-TmSsKZyAZpDKps-5ZESSWSriS6dGSivQE9-63VITjU/public/basic?alt=json-in-script

	//Sheet SheetTest
	public static DataSheetTypes.SheetTest test = new DataSheetTypes.SheetTest();
	static DataSheet(){
		test.Init(); 
	}
}


namespace DataSheetTypes{
	public class Test{
		public int iD;
		public string name;
		public string titreCarte;
		public string sprite;
		public string description;
		public string place;
		public string _event;
		public bool mort;
		public string successIfDie;
		public bool canSlideUp;
		public int upCardID;
		public string upSlideText;
		public string upObjectUnlock;
		public string upSuccesUnlock;
		public int rightCardID;
		public string rightSlideText;
		public string rightObjectUnlock;
		public string rightSucessUnlock;
		public int leftCardID;
		public string leftSlideText;
		public string leftObjectUnlock;
		public string leftSucessUnlock;
		public bool finishEvent;
		public bool playedOnce;
		public int firstOfEventID;
		public bool hasVFX;
		public string cardVFX;
		public int unlockUpNbrObject;
		public string firstObject;
		public string secondObject;

		public Test(){}

		public Test(int iD, string name, string titreCarte, string sprite, string description, string place, string _event, bool mort, string successIfDie, bool canSlideUp, int upCardID, string upSlideText, string upObjectUnlock, string upSuccesUnlock, int rightCardID, string rightSlideText, string rightObjectUnlock, string rightSucessUnlock, int leftCardID, string leftSlideText, string leftObjectUnlock, string leftSucessUnlock, bool finishEvent, bool playedOnce, int firstOfEventID, bool hasVFX, string cardVFX, int unlockUpNbrObject, string firstObject, string secondObject){
			this.iD = iD;
			this.name = name;
			this.titreCarte = titreCarte;
			this.sprite = sprite;
			this.description = description;
			this.place = place;
			this._event = _event;
			this.mort = mort;
			this.successIfDie = successIfDie;
			this.canSlideUp = canSlideUp;
			this.upCardID = upCardID;
			this.upSlideText = upSlideText;
			this.upObjectUnlock = upObjectUnlock;
			this.upSuccesUnlock = upSuccesUnlock;
			this.rightCardID = rightCardID;
			this.rightSlideText = rightSlideText;
			this.rightObjectUnlock = rightObjectUnlock;
			this.rightSucessUnlock = rightSucessUnlock;
			this.leftCardID = leftCardID;
			this.leftSlideText = leftSlideText;
			this.leftObjectUnlock = leftObjectUnlock;
			this.leftSucessUnlock = leftSucessUnlock;
			this.finishEvent = finishEvent;
			this.playedOnce = playedOnce;
			this.firstOfEventID = firstOfEventID;
			this.hasVFX = hasVFX;
			this.cardVFX = cardVFX;
			this.unlockUpNbrObject = unlockUpNbrObject;
			this.firstObject = firstObject;
			this.secondObject = secondObject;
		}
	}
	public class SheetTest: IEnumerable{
		public System.DateTime updated = new System.DateTime(2020,5,25,8,35,24);
		public readonly string[] labels = new string[]{"ID","Name","Titre Carte","Sprite","Description","Place","Event","Mort ?","Success If Die","Can Slide Up","Up Card ID","Up Slide Text","Up Object Unlock","Up Succes Unlock","Right Card ID","Right Slide Text","Right Object Unlock","Right Sucess Unlock","Left Card ID","Left Slide Text","Left Object Unlock","Left Sucess Unlock","Finish Event","Played Once","First Of Event ID","Has VFX","Card VFX","UnlockUpNbrObject","FirstObject","SecondObject"};
		private Test[] _rows = new Test[13];
		public void Init() {
			_rows = new Test[]{
					new Test(14,"Card_Clown_See","The Broadwalk","Card_Clown_See","You approach a clown who is blowing balloons to the shape of lions and elephants for children.","_balade","Clown",false,"none",true,25,"Pinch his big, appealing red nose","_none","none",18,"Hey Clown, tell me a joke!","","none",15,"Hey clown! I want a balloon","","none",false,false,14,false,"",0,"",""),
					new Test(15,"Card_Clown_AskBalloon","The Broadwalk","Card_Clown_Ballon","\"What shape do you want for your ballon, man?\"","_balade","Clown",false,"none",false,0,"","_none","none",16,"A lion","","none",16,"An elephant","","none",false,false,14,false,"",0,"",""),
					new Test(16,"Card_Clown_TakeBalloon","The Broadwalk","Card_Clown_GiveBallon","\"There you have it ! It's a shark, I don't care what you ask\"","_balade","Clown",false,"none",false,0,"","_none","none",17,"Explode the balloon","","none",17,"\"This balloon looks like shit\"","","none",false,false,14,false,"",0,"",""),
					new Test(17,"Card_Clown_CryLeave","The Broadwalk","Card_Clown_Cry","\"............\"\nThe clown quickly inflates a big balloon and puts it in your mouth before releasing it.\nThe air is released from the balloon and you fly away.\n\"So we're having a ball, huh?!\"","_balade","Clown",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,14,false,"",0,"",""),
					new Test(18,"Card_Clown_Joke01","The Broadwalk","Card_Clown_Joke","\"How do you recognize a letter sent by a leper ?\"","_balade","Clown",false,"none",false,0,"","_none","none",19,"Ok! What is it?","","none",19,"...","","none",false,false,14,false,"",0,"",""),
					new Test(19,"Card_Clown_Answer01","The Broadwalk","Card_Clown_Answer","\"The tongue is stuck to the stamp!\"","_balade","Clown",false,"none",false,0,"","_none","none",24,"Not funny...","","none",20,"Another one!","","none",false,false,14,false,"",0,"",""),
					new Test(20,"Card_Clown_Joke02","The Broadwalk","Card_Clown_Joke"," \"How many men does it take to paint a car red?\"","_balade","Clown",false,"none",false,0,"","_none","none",21,"Ahaha! What's the answer?","","none",21,"...","","none",false,false,14,false,"",0,"",""),
					new Test(21,"Card_Clown_Answer02","The Broadwalk","Card_Clown_Answer","\"Only one, but you have to throw it very hard !\"","_balade","Clown",false,"none",false,0,"","_none","none",24,"Shut up! Please!","","Insulting",22,"Again! Bis!","","none",false,false,14,false,"",0,"",""),
					new Test(22,"Card_Clown_Joke03","The Broadwalk","Card_Clown_Joke","\"A little girl's on a swing.\nSuddenly she falls. Why ?\"","_balade","Clown",false,"none",false,0,"","_none","none",23,"AHAHAHAHAHAHAHAHAHAHAHA","","none",23,"...","","none",false,false,14,false,"",0,"",""),
					new Test(23,"Card_Clown_AnswerLaughDeath","The Broadwalk","Card_Death_Clown_Laugh","\"Because she doesn't have arms!\nAHHAAAHAHAAHHHAAHA!\"\nYou can't take it anymore, you're bent in half by laughter before you drop dead.\n\"That's what we call being dead laughing AHAHAHAHAHAHAHAH!\"","_balade","Clown",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,14,false,"",0,"",""),
					new Test(24,"Card_Clown_ShutUp","The Broadwalk","Card_Clown_ShutUp","\"........\" \n\nYou take a hammer thump to the head and pass out.","_balade","Clown",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,14,false,"",0,"",""),
					new Test(25,"Card_Clown_AcidDeath","The Broadwalk","Card_Death_Clown_Acid","His nose spits acid right on your eye! You're now one-eyed...\n\"Shit, oh my poor thing! You're a real pirate now ahahahahaa!\"  He presses his nose again and spits more acid on your melting face, you're dead...","_balade","Clown",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,14,false,"",0,"",""),
					new Test(26,"Card_Clown_LaughDeath","The Broadwalk","Card_Death_Clown_Laugh","\"Oh... so sorry my friend, I was laughing... hey hey hey hey.\"\n\nThe clown shakes your hand to apologize.\n\nYou get a shock and die electrocuted.","_balade","Clown",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,14,false,"",0,"","")
				};
		}
			
		public IEnumerator GetEnumerator(){
			return new SheetEnumerator(this);
		}
		private class SheetEnumerator : IEnumerator{
			private int idx = -1;
			private SheetTest t;
			public SheetEnumerator(SheetTest t){
				this.t = t;
			}
			public bool MoveNext(){
				if (idx < t._rows.Length - 1){
					idx++;
					return true;
				}else{
					return false;
				}
			}
			public void Reset(){
				idx = -1;
			}
			public object Current{
				get{
					return t._rows[idx];
				}
			}
		}
		public int Length{ get{ return _rows.Length; } }
		public Test this[int index]{
			get{
				return _rows[index];
			}
		}
		public Test[] ToArray(){
			return _rows;
		}
		public Test Random() {
			return _rows[ UnityEngine.Random.Range(0, _rows.Length) ];
		}


	}
}