
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
		public System.DateTime updated = new System.DateTime(2020,5,16,13,32,19);
		public readonly string[] labels = new string[]{"ID","Name","Titre Carte","Sprite","Description","Place","Event","Mort ?","Success If Die","Can Slide Up","Up Card ID","Up Slide Text","Up Object Unlock","Up Succes Unlock","Right Card ID","Right Slide Text","Right Object Unlock","Right Sucess Unlock","Left Card ID","Left Slide Text","Left Object Unlock","Left Sucess Unlock","Finish Event","Played Once","First Of Event ID","Has VFX","Card VFX","UnlockUpNbrObject","FirstObject","SecondObject"};
		private Test[] _rows = new Test[7];
		public void Init() {
			_rows = new Test[]{
					new Test(119,"Card_Elephant_Enclosure","The Zoo","Card_Background","You arrive in front of the elephant's enclosure. \n\nHe's outside, in the open air with beautiful trees to keep him company.","_animalerie","Elephant",false,"none",true,125,"Throw the dead mouse to the elephant","_none","none",120,"Say Hi to the animal","_none","none",122,"Enter the enclosure","","none",false,false,119,false,"",1,"_souris",""),
					new Test(120,"Card_Elephant_AskBanana","The Zoo","Card_TR_Elephant_Talk","\"Hello to you, friend! Would you like a banana? I got plenty.\"","_animalerie","Elephant",false,"none",false,0,"","_none","none",124,"Take the banana","_none","none",121,"Refuse the banana","","none",false,false,119,false,"",0,"",""),
					new Test(121,"Card_Elephant_GoAway","The Zoo","Card_TR_Elephant_ViolentInsult","\"Fuck off then ! \nGet out of here! Get out of here !\"","_animalerie","Elephant",false,"none",false,0,"","_none","none",0,"","_none","none",0,"","","none",true,false,119,false,"",0,"",""),
					new Test(122,"Card_Elephant_AskWhat","The Zoo","Card_TR_Elephant_Eating","\"What are you doing ?\" asked the animal.","_animalerie","Elephant",false,"none",true,125,"Throw the dead mouse to the elephant","_none","none",123,"Piss off, fuck face","_none","none",123,"Your mother is so cheap, ducks throw her bread","","none",false,false,119,false,"",1,"_souris",""),
					new Test(123,"Card_Elephant_LeaveInsult","The Zoo","Card_Background","\"Be nicer, motherfucker.\"\n\nWith these words, the elephant catches you with its trunk and throws you away from its enclosure.","_animalerie","Elephant",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,119,false,"",0,"",""),
					new Test(124,"Card_Elephant_Death_SlideBanana","The Zoo","Card_Background","On your way to the elephant to get it, you slip on a banana peel and fall on your head. \n\nConcussion, looks like you're dead.","_animalerie","Elephant",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,119,false,"",0,"",""),
					new Test(125,"Card_Elephant_Death_Mouse","The Zoo","Card_Background","At the sight of the dead animal, the elephant start to run everywhere. \n\nIn his blind madness he impale you with one of his tusks.\n\nYou will die with a smile on your face, with a hole in your belly on the elephant's tusk while thanking the lion.","_animalerie","Elephant",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,119,false,"",0,"","")
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