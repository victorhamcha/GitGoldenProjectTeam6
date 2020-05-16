
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
		public System.DateTime updated = new System.DateTime(2020,5,16,14,54,35);
		public readonly string[] labels = new string[]{"ID","Name","Titre Carte","Sprite","Description","Place","Event","Mort ?","Success If Die","Can Slide Up","Up Card ID","Up Slide Text","Up Object Unlock","Up Succes Unlock","Right Card ID","Right Slide Text","Right Object Unlock","Right Sucess Unlock","Left Card ID","Left Slide Text","Left Object Unlock","Left Sucess Unlock","Finish Event","Played Once","First Of Event ID","Has VFX","Card VFX","UnlockUpNbrObject","FirstObject","SecondObject"};
		private Test[] _rows = new Test[29];
		public void Init() {
			_rows = new Test[]{
					new Test(109,"Card_Lion_Cage","The Zoo","Card_Background","You arrive in front of the lion's cage, behind the main tent. He's circling around looking at you.","_animalerie","Lion",false,"none",true,117,"Throw some Cotton Candy to him","_souris","none",110,"Try to enter the cage","","none",114,"Ask the Lion what's up","","none",false,false,109,false,"",1,"_barbeAPapa",""),
					new Test(110,"Card_Lion_Nope","The Zoo","Card_Background","With his big paw, the lion pushes you to keep you out.","_animalerie","Lion",false,"none",false,0,"","_none","none",111,"Ask him to eat you","","none",113,"Try to break the cage with your foot","","none",false,false,109,false,"",0,"",""),
					new Test(111,"Card_Lion_NoEat","The Zoo","Card_Background","\"Why would I do such a thing?\"","_animalerie","Lion",false,"none",false,0,"","_none","none",112,"Because I'm asking you","","none",112,"Oh my god please eat me! I beg you!","","none",false,false,109,false,"",0,"",""),
					new Test(112,"Card_Lion_GetDeadMouse","The Zoo","Card_Background","\"If you wish to die, give this to the elephant.\" \n\nYou get a [dead mouse].","_animalerie","Lion",false,"none",false,0,"","_none","none",0,"","_souris","none",0,"","_souris","none",true,false,109,false,"",0,"",""),
					new Test(113,"Card_Lion_BrokenAnkle","The Zoo","Card_Background","You break your ankle and have to go and sit down for a while.","_animalerie","Lion",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,109,false,"",0,"",""),
					new Test(114,"Card_Lion_LookAtYou","The Zoo","Card_Background","He looks at you sideways as he turns his head, intrigued.","_animalerie","Lion",false,"none",true,118,"Throw some Poisonned Cotton Candy to him","_none","none",115,"I can release you if you want","","none",116,"I hope you stay in this cage forever!","","none",false,false,109,false,"",1,"_barbeAPapaEmpoisonée",""),
					new Test(115,"Card_Lion_TakeOut","The Zoo","Card_Background","\"Of course not, you idiot ! \nI am fed and caressed abundantly every day! \nAll I have to do is roar in front of a few people! \nDo you have such a cool life?\"","_animalerie","Lion",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,109,false,"",0,"",""),
					new Test(116,"Card_Lion_Insult","The Zoo","Card_Background","\"I hope so, too!\n\nI'm taken care of every day if I roar in front of a few people.\n\nYou'd better get out of here now.","_animalerie","Lion",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,109,false,"",0,"",""),
					new Test(117,"Card_Lion_GiveGoodSugar","The Zoo","Card_Background","The lion takes a bite.\n\n\"Humm what a delight! Thank you, my friend.\"\n\nThe lion generously offers you a [dead mouse].","_animalerie","Lion",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,109,false,"",0,"",""),
					new Test(118,"Card_Lion_Death_PoisonnedSugar","The Zoo","Card_Background","The lion takes a bite.\n\nAll of a sudden, he starts vomiting all over the place and goes crazy!\n\nUnintentionally, in an excess of madness, he claws you through the bars in your face.\n\nYou perish with your face slashed.","_animalerie","Lion",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,109,false,"",0,"",""),
					new Test(30,"Card_ConfettiCannon_See","The Circus","Card_Background","You see a beautiful cannon with confetti inside and next to it in a seal. As you get closer, you can choose to add confetti inside, slide inside, or light the fuse of the cannon.","_circus","ConfettisCannon",false,"none",true,37,"Light the fuse","_none","none",31,"Add confettis","","none",32,"Get in the cannon","","none",false,false,30,false,"",1,"_briquet",""),
					new Test(31,"Card_ConfettiCannon_Filled","The Circus","Card_Background","Wow !\nThe cannon is filled to the brim, the confetti are overflowing.","_circus","ConfettisCannon",false,"none",true,35,"Ligh the fuse","_none","none",34,"Leave","","none",32,"Get in the cannon","","none",false,false,30,false,"",1,"_briquet",""),
					new Test(32,"Card_ConfettiCannon_ConfortableLeave","The Circus","Card_Background","Uh huh... It's very comfortable here... It's so much fun! Nothing's happening...\nYou're coming out of the cannon.","_circus","ConfettisCannon",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,30,false,"",0,"",""),
					new Test(33,"Card_ConfettiCannon_ExplosionLeave","The Circus","Card_Background","You light the fuse, but before you can do anything, the gun fires.\nBOOM ! Confetti fireworks! That was cool! But you're still in perfect condition... too bad.","_circus","ConfettisCannon",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,30,false,"",0,"",""),
					new Test(34,"Card_ConfettiCannon_DisappointingLeave","The Circus","Card_Background","Hmmm... disappointing","_circus","ConfettisCannon",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,30,false,"",0,"",""),
					new Test(35,"Card_ConfettiCannon_FuseOn01","The Circus","Card_Background","The fuse begins to burn slowly.","_circus","ConfettisCannon",false,"none",true,36,"Add even more confettis !","_none","none",33,"Add even more confettis","","none",38,"Get inside that cannon","","none",false,false,30,false,"",0,"",""),
					new Test(36,"Card_ConfettisCannon_FullFilled","The Circus","Card_Background","Impressive how many confetti you could put in that cannon, what a nice explosion...","_circus","ConfettisCannon",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",false,false,30,false,"",0,"",""),
					new Test(37,"Card_ConfettiCannon_FuseOn02","The Circus","Card_Background","The fuse begins to burn slowly.","_circus","ConfettisCannon",false,"none",false,0,"","_none","none",33,"Add even more confettis","","none",39,"Get inside that cannon","","none",false,false,30,false,"",0,"",""),
					new Test(38,"Card_ConfettiCannon_BestDeath","The Circus","Card_Background","BAANG !\nYour limbs and the rest of your body join the confetti in the explosion, what a beautiful death !","_circus","ConfettisCannon",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,30,false,"",0,"",""),
					new Test(39,"Card_ConfettiCannon_DisapointingDeath","The Circus","Card_Background","BAANNG ! Members all over the tent ! You died with panache ! But you can do better than that, for sure !","_circus","ConfettisCannon",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,30,false,"",0,"",""),
					new Test(68,"Card_Chicken_EnterRestaurant","The Food Courts","Card_Background","You walk into a restaurant. A waiter puts you at a table and hands you a menu. Make your order.","_restaurant","Chickens",false,"none",false,0,"","_none","none",71,"Poched Egg","","none",69,"Hard Egg","","none",false,false,68,false,"",0,"",""),
					new Test(69,"Card_Chicken_HardEgg","The Food Courts","Card_Background","And the seasoning ?","_restaurant","Chickens",false,"none",false,0,"","_none","none",70,"Salt","","none",75,"Pepper","","none",false,false,68,false,"",0,"",""),
					new Test(70,"Card_Chicken_HardEgg_Salt","The Food Courts","Card_Background","Ow... it's actually well cooked.\n\nYou lose two teeth on this egg...\n\n[You gain two teeth]\n\nYou're going to the dish.\n\nRoast chicken.\n\nThat's just disgusting! \n\nYou are leaving this disgusting restaurant, all you've earned are two of your broken teeth!","_restaurant","Chickens",false,"none",false,0,"","_none","none",0,"","_dents","none",0,"","_dents","none",true,false,68,false,"",0,"",""),
					new Test(71,"Card_Chicken_SoftEgg","The Food Courts","Card_Background","And the seasoning ?","_restaurant","Chickens",false,"none",false,0,"","_none","none",72,"Salt","","none",73,"Pepper","","none",false,false,68,false,"",0,"",""),
					new Test(72,"Card_Chicken_SoftEgg_Salt","The Food Courts","Card_Background","Mmmmh well melting in the mouth this egg!\n\nCome on, the dish : an omelet.\n\nIt's simply disgusting ! \n\nYou're leaving this disgusting restaurant !","_restaurant","Chickens",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,68,false,"",0,"",""),
					new Test(73,"Card_Chicken_SoftEgg_Pepper","The Food Courts","Card_Background","You have a serious stomach ache.\n\nAnyway... it's time for the dish. \n\nYou're going to have the omelette.\n\nYou feel that your stomach ache is becoming unbearable... \n\nAs if your belly is going to explode!","_restaurant","Chickens",false,"none",false,0,"","_none","none",74,"Go to the toilets","","none",76,"Stay, like a real man!","","none",false,false,68,false,"",0,"",""),
					new Test(74,"Card_Chicken_SoftEgg_Toilets","The Food Courts","Card_Background","You're going into the toilet.\n\nYou drink copiously from the tap while hearing drowning cries from your belly.\n\nOnce seated in one of the cubicles, you concentrate and feathers fall into the toilet bowl... \n\nYou leave the restaurant relieved.","_restaurant","Chickens",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,68,false,"",0,"",""),
					new Test(75,"Card_Chicken_Death_HardEgg_Pepper","The Food Courts","Card_Background","What a delight! Perfectly seasoned.\nDish now. \nThe waiter brings you two chickens to choose which one you'll eat.\nOne of them he doesn't like pepper seasonning! \nIt escapes the waiter's hand and pecks at your eye! \nYou will die with your head on the plate...","_restaurant","Chickens",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,68,false,"",0,"",""),
					new Test(76,"Card_Chicken_Death_Alien","The Food Courts","Card_Background","Your shirt is starting to come up. Your belly opens in two and damn it... a chicken comes out !\nYou bleed out badly while the hen tries to escape the cook's knife.","_restaurant","Chickens",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,68,false,"",0,"","")
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