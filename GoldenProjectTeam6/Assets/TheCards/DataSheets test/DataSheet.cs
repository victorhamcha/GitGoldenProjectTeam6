
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
		public System.DateTime updated = new System.DateTime(2020,5,16,15,57,35);
		public readonly string[] labels = new string[]{"ID","Name","Titre Carte","Sprite","Description","Place","Event","Mort ?","Success If Die","Can Slide Up","Up Card ID","Up Slide Text","Up Object Unlock","Up Succes Unlock","Right Card ID","Right Slide Text","Right Object Unlock","Right Sucess Unlock","Left Card ID","Left Slide Text","Left Object Unlock","Left Sucess Unlock","Finish Event","Played Once","First Of Event ID","Has VFX","Card VFX","UnlockUpNbrObject","FirstObject","SecondObject"};
		private Test[] _rows = new Test[23];
		public void Init() {
			_rows = new Test[]{
					new Test(77,"Card_Sugar_Stand","The Food Courts","Card_Background","You arrive in front of the cotton candy and other sweets stand.","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",78,"Wait a bit","","none",89,"Bash people around to arrive faster","","none",false,false,77,false,"",0,"",""),
					new Test(78,"Card_Sugar_WaitOnce","The Food Courts","Card_Background","There's a lot of people... You've already been waiting for an hour...","_restaurant","SugarDaddy",false,"none",true,79,"Wait a tiny bit more","_none","none",80,"\"Politely\" ask the one in front of you to leave","","none",81,"Sneak to the front of the row","","none",false,false,77,false,"",0,"",""),
					new Test(79,"Card_Sugar_WaitMore","The Food Courts","Card_Background","You wait two more hours...\n\n These cotton candies must be pretty damn good !","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",97,"Wait a tiny tidy bity more","","none",81,"Sneak to the front of the row","","none",false,false,77,false,"",0,"",""),
					new Test(80,"Card_Sugar_BeatUpLeave","The Food Courts","Card_Background","The man in front of you turns around and throws is fist at your face","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",false,false,77,false,"",0,"",""),
					new Test(81,"Card_Sugar_SeeVendor01","The Food Courts","Card_Background","You're finally in front of the salesman !","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",82,"Ask for some cotton candy","","none",87,"Try to slide behind the stand","","none",false,false,77,false,"",0,"",""),
					new Test(82,"Card_Sugar_Vendor_Machine01","The Food Courts","Card_Background","The salesman starts heat his cotton candy machine and put sugar in it.","_restaurant","SugarDaddy",false,"none",true,85,"Discreetly put two broken teeth in the machine","_none","none",83,"Wait for the cotton candy","","none",84,"Look at the waiting line like a jerk","","none",false,false,77,false,"",1,"_dents",""),
					new Test(83,"Card_Sugar_GetGoodSugar01","The Food Courts","Card_Background","\"Here you go ! A good sweetness ! Good luck !\"\nYou get a [cotton candy].","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(84,"Card_Sugar_JerkWait01","The Food Courts","Card_Background","You look at the crowd like an asshole waiting for the famous cotton candy, that they don't have","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(85,"Card_Sugar_GetPoisonnedSugar01","The Food Courts","Card_Background","The teeth melt slightly in the machine and fuse with the sugar for a cotton candy that is certainly bad considering the cavities you had.\n\"Here you go ! A good sweetness ! Good luck !\"\nYou get a [Poisoned cotton candy].","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",98,"Eat the juicy poisonned cotton candy","","none",86,"Leave with your poisonned cotton candy","","none",false,false,77,false,"",0,"",""),
					new Test(86,"Card_Sugar_PoisonnedSugarLeave01","The Food Courts","Card_Background"," You go and keep your [Poisoned Cotton Candy].","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(87,"Card_Sugar_GetBehindVendor01","The Food Courts","Card_Background","\"Yo! Maan what are you doing here? Get back in line!\"","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",88,"Eat someone else's cotton candy","","none",99,"Intimidate the vendor to get yours faster","","none",true,false,77,false,"",0,"",""),
					new Test(88,"Card_Sugar_VendorAssKickLeave01","The Food Courts","Card_Background","The salesman, very unhappy, rolls up his sleeves and throws you away from the stand.","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(89,"Card_Sugar_SeeVendor02","The Food Courts","Card_Background","You arrive, with a few bruises, in front of the salesman.","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",90,"Ask for some cotton candy","","none",95,"Try to slide behind the stand","","none",false,false,77,false,"",0,"",""),
					new Test(90,"Card_Sugar_Vendor_Machine02","The Food Courts","Card_Background","The salesman starts heat his cotton candy machine and put sugar in it.","_restaurant","SugarDaddy",false,"none",true,93,"Discreetly put two broken teeth in the machine","_none","none",91,"Wait for the cotton candy","","none",92,"Look at the waiting line like a jerk","","none",false,false,77,false,"",1,"_dents",""),
					new Test(91,"Card_Sugar_GetGoodSugar02","The Food Courts","Card_Background","\"Here you go ! A good sweetness ! Good luck !\"\nYou get a [cotton candy].","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","_barbeAPapa","none",0,"","_barbeAPapa","none",true,false,77,false,"",0,"",""),
					new Test(92,"Card_Sugar_JerkWait02","The Food Courts","Card_Background","You look at the crowd like an asshole waiting for the famous cotton candy, that they don't have","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(93,"Card_Sugar_GetPoisonnedSugar02","The Food Courts","Card_Background","The teeth melt slightly in the machine and fuse with the sugar for a cotton candy that is certainly bad considering the cavities you had.\n\"Here you go ! A good sweetness ! Good luck !\"\nYou get a [Poisoned cotton candy].","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",98,"Eat the juicy poisonned cotton candy","","none",94,"Leave with your poisonned cotton candy","","none",false,false,77,false,"",0,"",""),
					new Test(94,"Card_Sugar_PoisonnedSugarLeave02","The Food Courts","Card_Background"," You go and keep your [Poisoned Cotton Candy].","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","_barbeAPapaEmpoisonée","none",0,"","_barbeAPapaEmpoisonée","none",true,false,77,false,"",0,"",""),
					new Test(95,"Card_Sugar_GetBehindVendor02","The Food Courts","Card_Background","\"Yo! Maan what are you doing here? Get back in line!\"","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",96,"Eat someone else's cotton candy","","none",99,"Intimidate the vendor to get yours faster","","none",false,false,77,false,"",0,"",""),
					new Test(96,"Card_Sugar_VendorAssKickLeave02","The Food Courts","Card_Background","The salesman, very unhappy, rolls up his sleeves and throws you away from the stand.","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(97,"Card_Sugar_Death_Waiting","The Food Courts","Card_Background","You can't stand waiting for hours and hours... You're hungry and thirsty...\nYou're dead of boredom.","_restaurant","SugarDaddy",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(98,"Card_Sugar_Death_Poisoned","The Food Courts","Card_Background","You fall down coughing and spitting all over the place and on everyone.\n\nAfter some vomiting, you die with your face in the remains of chewed cotton candy.","_restaurant","SugarDaddy",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(99,"Card_Sugar_Death_BeatenUp","The Food Courts","Card_Background","\"I don't think you know who you're dealing with, asshole.\" \n\nWith those words, the salesman grabs your head and shoves it into his cotton candy machine. \n\nYour face melts and mixes with the pink sugar...\n\n... Let's just say that you've eaten your cotton candy... ","_restaurant","SugarDaddy",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"","")
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