
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
		public System.DateTime updated = new System.DateTime(2020,5,16,15,33,36);
		public readonly string[] labels = new string[]{"ID","Name","Titre Carte","Sprite","Description","Place","Event","Mort ?","Success If Die","Can Slide Up","Up Card ID","Up Slide Text","Up Object Unlock","Up Succes Unlock","Right Card ID","Right Slide Text","Right Object Unlock","Right Sucess Unlock","Left Card ID","Left Slide Text","Left Object Unlock","Left Sucess Unlock","Finish Event","Played Once","First Of Event ID","Has VFX","Card VFX","UnlockUpNbrObject","FirstObject","SecondObject"};
		private Test[] _rows = new Test[9];
		public void Init() {
			_rows = new Test[]{
					new Test(59,"Card_Fire_Bin","The Food Courts","Card_TR_Fire_Bin","You are strolling between restaurants, not really knowing why, you're searching through a garbage...","_restaurant","Combustion",false,"none",true,60,"Take the cig","_none","none",61,"Take the tissue","","none",64,"Take the Spicy Sauce","","none",false,false,59,false,"",0,"",""),
					new Test(60,"Card_Fire_FindCig","The Food Courts","Card_TR_Fire_Smoke","It's full of slime and well chewed.","_restaurant","Combustion",false,"none",false,0,"","_none","none",62,"Put it back","","none",63,"Take a smoke","","none",false,false,59,false,"",0,"",""),
					new Test(61,"Card_Fire_FindTissue","The Food Courts","Card_TR_Fire_Tissue","There's not only snot in this tissue...","_restaurant","Combustion",false,"none",false,0,"","_none","none",62,"Put it back","","none",63,"Take a bite","","none",false,false,59,false,"",0,"",""),
					new Test(62,"Card_Fire_PutItBack","The Food Courts","Card_TR_Fire_DropGood","Good","_restaurant","Combustion",false,"none",false,0,"","_none","none",59,"Look back inside","","none",63,"Realize it's disgusting","","none",false,false,59,false,"",0,"",""),
					new Test(63,"Card_Fire_Gross","The Food Courts","Card_TR_Fire_Use","You still have a modicum of dignity, that's good...","_restaurant","Combustion",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,59,false,"",0,"",""),
					new Test(64,"Card_Fire_ClosedSauce","The Food Courts","Card_TR_Fire_FindSpicy","It's still closed.","_restaurant","Combustion",false,"none",false,0,"","_none","none",65,"Open it","","none",66,"Drop it back in","","none",false,false,59,false,"",0,"",""),
					new Test(65,"Card_Fire_SpicySauce","The Food Courts","Card_Background","\"If you want to smell chilli, it smells chilli!\"","_restaurant","Combustion",false,"none",false,0,"","_none","none",67,"Swallow the sauce","","none",66,"Drop it back in","","none",false,false,59,false,"",0,"",""),
					new Test(66,"Card_Fire_LilDick","The Food Courts","Card_Background","Seems you don't have whart it takes...","_restaurant","Combustion",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,59,false,"",0,"",""),
					new Test(67,"Card_Fire_Death","The Food Courts","Card_Background","You throw away the empty package and resume your walk.\n\nAll of a sudden your belly and mouth burn incredibly hard.\n\nInstantly, you catch fire and die burned alive.","_restaurant","Combustion",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,59,false,"",0,"","")
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