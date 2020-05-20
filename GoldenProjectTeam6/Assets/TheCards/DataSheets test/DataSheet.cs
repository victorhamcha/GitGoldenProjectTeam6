
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
		public System.DateTime updated = new System.DateTime(2020,5,20,9,40,55);
		public readonly string[] labels = new string[]{"ID","Name","Titre Carte","Sprite","Description","Place","Event","Mort ?","Success If Die","Can Slide Up","Up Card ID","Up Slide Text","Up Object Unlock","Up Succes Unlock","Right Card ID","Right Slide Text","Right Object Unlock","Right Sucess Unlock","Left Card ID","Left Slide Text","Left Object Unlock","Left Sucess Unlock","Finish Event","Played Once","First Of Event ID","Has VFX","Card VFX","UnlockUpNbrObject","FirstObject","SecondObject"};
		private Test[] _rows = new Test[8];
		public void Init() {
			_rows = new Test[]{
					new Test(55,"Card_Trapezist_GetPopcorn","The Circus","Card_Background","You knock him out and get a bag of popcorn. \n\n[You win \"Pack of Popcorn.\"]","_circus","Trapezist",false,"none",false,0,"","_none","none",57,"Throw some popcorn on the acrobats","","none",56,"Be a jerk to the acrobats","","Bastard",false,false,48,false,"",0,"",""),
					new Test(43,"Card_Magician_Volunteer","The Circus","Card_Background","\"Ohhh ! Come on ! Come on, volunteer ! You won't be disappointed! hehehehehe...\"","_circus","Magician",false,"none",false,0,"","_none","none",44,"Spit on his face","","Nonerespect",47,"Join him for the trick","","none",false,false,40,false,"",0,"",""),
					new Test(21,"Card_Clown_Answer02","The Broadwalk","Card_Background","\"Only one, but you have to throw it very hard !\"","_balade","Clown",false,"none",false,0,"","_none","none",24,"Shut up! Please!","","Insulting",22,"Again! Bis!","","none",false,false,14,false,"",0,"",""),
					new Test(73,"Card_Chicken_SoftEgg_Pepper","The Food Courts","Card_Background","You have a serious stomach ache.\n\nAnyway... it's time for the dish. \n\nYou're going to have the omelette.\n\nYou feel that your stomach ache is becoming unbearable... \n\nAs if your belly is going to explode!","_restaurant","Chickens",false,"none",false,0,"","_none","none",74,"Go to the toilets","","Routineoftherestaurant",76,"Stay, like a real man!","","none",false,false,68,false,"",0,"",""),
					new Test(11,"Card_KnifeThrower_Show","The Broadwalk","Card_Background","\"Ooooh, all right, come here. \nLie down on that wheel... let me tie you up...\" \nYou're strapped vertically on a wheel that slowly spins. \nThe pitcher sharpens his knives before throwing them while drinking.","_balade","KnifeThrower",false,"none",false,0,"","_none","none",13,"Let him, he's a pro!","","none",12,"Ask him to stop drinking","","Alcoholisdangeroustohealth",false,false,7,false,"",0,"",""),
					new Test(101,"Card_Piranhas_Feet","The Zoo","Card_Background","Piranhas graze your legs but do not attack you. \n\nThe man looks at you strangely while asking you to come out.","_animalerie","Piranhas",false,"none",false,0,"","_none","none",107,"Grab and bite a piranha","","none",102,"Thorw a piranha to the cleaner's head","","Hitman",false,false,100,false,"",0,"",""),
					new Test(122,"Card_Elephant_AskWhat","The Zoo","Card_Elephant_Eating","\"What are you doing ?\" asked the animal.","_animalerie","Elephant",false,"none",true,125,"Throw the dead mouse to the elephant","_none","none",123,"Piss off, fuck face","_none","none",123,"Your mother is so cheap, ducks throw her bread","","Wedontinsultmothers",false,false,119,false,"",1,"_souris",""),
					new Test(85,"Card_Sugar_GetPoisonnedSugar01","The Food Courts","Card_Sugar_TeethInMachine","The teeth melt slightly in the machine and fuse with the sugar for a cotton candy that is certainly bad considering the cavities you had.\n\"Here you go ! A good sweetness ! Good luck !\"\nYou get a [Poisoned cotton candy].","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",98,"Eat the juicy poisonned cotton candy","","none",86,"Leave with your poisonned cotton candy","","Poisonofpatience",false,false,77,false,"",0,"","")
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