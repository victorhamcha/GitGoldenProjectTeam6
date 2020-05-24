
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
		public System.DateTime updated = new System.DateTime(2020,5,24,12,12,46);
		public readonly string[] labels = new string[]{"ID","Name","Titre Carte","Sprite","Description","Place","Event","Mort ?","Success If Die","Can Slide Up","Up Card ID","Up Slide Text","Up Object Unlock","Up Succes Unlock","Right Card ID","Right Slide Text","Right Object Unlock","Right Sucess Unlock","Left Card ID","Left Slide Text","Left Object Unlock","Left Sucess Unlock","Finish Event","Played Once","First Of Event ID","Has VFX","Card VFX","UnlockUpNbrObject","FirstObject","SecondObject"};
		private Test[] _rows = new Test[49];
		public void Init() {
			_rows = new Test[]{
					new Test(77,"Card_Sugar_Stand","The Food Courts","Card_Sugar_Stand","You arrive in front of the cotton candy and other sweets stand.","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",78,"Wait a bit","","none",89,"Bash people around to arrive faster","","none",false,false,77,false,"",0,"",""),
					new Test(78,"Card_Sugar_WaitOnce","The Food Courts","Card_Sugar_Wait","There's a lot of people... You've already been waiting for an hour...","_restaurant","SugarDaddy",false,"none",true,79,"Wait a tiny bit more","_none","none",80,"\"Politely\" ask the one in front of you to leave","","none",81,"Sneak to the front of the row","","none",false,false,77,false,"",0,"",""),
					new Test(79,"Card_Sugar_WaitMore","The Food Courts","Card_Sugar_Wait","You wait two more hours...\n These cotton candies better be pretty damn good !","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",97,"Wait a tiny tidy bity more","","none",81,"Sneak to the front of the row","","none",false,false,77,false,"",0,"",""),
					new Test(80,"Card_Sugar_BeatUpLeave","The Food Courts","Card_Trapezist_Sleep","The man in front of you turns around and throws is fist at your face","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(81,"Card_Sugar_SeeVendor01","The Food Courts","Card_Sugar_SeeVendor","You're finally in front of the salesman !","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",82,"Ask for some cotton candy","","none",87,"Try to slide behind the stand","","none",false,false,77,false,"",0,"",""),
					new Test(82,"Card_Sugar_Vendor_Machine01","The Food Courts","Card_Sugar_VendorMachine","He turns his machine on and pours the sugar.","_restaurant","SugarDaddy",false,"none",true,85,"Discreetly put two broken teeth in the machine","_none","none",83,"Wait for the cotton candy","","none",84,"Look at the waiting line like a jerk","","none",false,false,77,false,"",1,"_dents",""),
					new Test(83,"Card_Sugar_GetGoodSugar01","The Food Courts","Card_Sugar_VendorGiveSugar","\"Here you go! A good treat for you! Good luck!\"\nYou get a [cotton candy].","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(84,"Card_Sugar_JerkWait01","The Food Courts","Card_Sugar_VendorGiveSugar","You look at the crowd like an asshole waiting for the famous cotton candy, that they don't have","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(85,"Card_Sugar_GetPoisonnedSugar01","The Food Courts","Card_Sugar_TeethInMachine","The teeth melt slightly in the machine and fuse with the sugar for a cotton candy that is certainly bad considering the cavities you had.\n\"Here you go! A good treat for you! Good luck!\"","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",98,"Eat the juicy poisonned cotton candy","","none",86,"Leave with your poisonned cotton candy","","Poisonofpatience",false,false,77,false,"",0,"",""),
					new Test(86,"Card_Sugar_PoisonnedSugarLeave01","The Food Courts","Card_Sugar_GivePoisonnedSugar"," You go and keep your [Poisoned Cotton Candy].","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(87,"Card_Sugar_GetBehindVendor01","The Food Courts","Card_Sugar_SeeVendor","\"Hey! What are you doing here? Get back in line!\"","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",88,"Eat someone else's cotton candy","","none",99,"Intimidate the vendor to get yours faster","","none",true,false,77,false,"",0,"",""),
					new Test(88,"Card_Sugar_VendorAssKickLeave01","The Food Courts","Card_Sugar_VendorPushYou","The salesman, very unhappy, rolls up his sleeves and throws you away from the stand.","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(89,"Card_Sugar_SeeVendor02","The Food Courts","Card_Sugar_SeeVendor","You arrive, with a few bruises, in front of the salesman.","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",90,"Ask for some cotton candy","","none",95,"Try to slide behind the stand","","none",false,false,77,false,"",0,"",""),
					new Test(90,"Card_Sugar_Vendor_Machine02","The Food Courts","Card_Sugar_VendorMachine","He turns his machine on and pours the sugar.","_restaurant","SugarDaddy",false,"none",true,93,"Discreetly put two broken teeth in the machine","_none","none",91,"Wait for the cotton candy","","none",92,"Look at the waiting line like a jerk","","none",false,false,77,false,"",1,"_dents",""),
					new Test(91,"Card_Sugar_GetGoodSugar02","The Food Courts","Card_Sugar_VendorGiveSugar","\"Here you go! A good treat for you! Good luck!\"\nYou get a [cotton candy].","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","_barbeAPapa","none",0,"","_barbeAPapa","none",true,false,77,false,"",0,"",""),
					new Test(92,"Card_Sugar_JerkWait02","The Food Courts","Card_Sugar_VendorGiveSugar","You look at the crowd like an asshole waiting for the famous cotton candy, that they don't have","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(93,"Card_Sugar_GetPoisonnedSugar02","The Food Courts","Card_Sugar_TeethInMachine","The teeth melt slightly in the machine and fuse with the sugar for a cotton candy that is certainly bad considering the cavities you had.\n\"Here you go! A good treat for you! Good luck!\"","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",98,"Eat the juicy poisonned cotton candy","","none",94,"Leave with your poisonned cotton candy","","none",false,false,77,false,"",0,"",""),
					new Test(94,"Card_Sugar_PoisonnedSugarLeave02","The Food Courts","Card_Sugar_GivePoisonnedSugar"," You go and keep your [Poisoned Cotton Candy].","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","_barbeAPapaEmpoisonée","none",0,"","_barbeAPapaEmpoisonée","none",true,false,77,false,"",0,"",""),
					new Test(95,"Card_Sugar_GetBehindVendor02","The Food Courts","Card_Trapezist_Lol","\"Hey! What are you doing here? Get back in line!\"","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",96,"Eat someone else's cotton candy","","none",99,"Intimidate the vendor to get yours faster","","none",false,false,77,false,"",0,"",""),
					new Test(96,"Card_Sugar_VendorAssKickLeave02","The Food Courts","Card_Sugar_VendorPushYou","The salesman, very unhappy, rolls up his sleeves and throws you away from the stand.","_restaurant","SugarDaddy",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(97,"Card_Sugar_Death_Waiting","The Food Courts","Card_Death_Sugar_Bored","You've been waiting for hours and hours... You're hungry and thirsty...\nAnd suddenly someone starts talking to you, you're not listening and suddenly you realize you can't move or breath...You're dead of boredom.","_restaurant","SugarDaddy",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(98,"Card_Sugar_Death_Poisoned","The Food Courts","Card_Death_Sugar_Poisonned","You fall down coughing and spitting all over the place and on everyone.\n\nAfter some vomiting, you die with your face in the remains of chewed cotton candy.","_restaurant","SugarDaddy",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(99,"Card_Sugar_Death_BeatenUp","The Food Courts","Card_Death_Sugar_Burned","\"I don't think you know who you're dealing with, asshole.\" \n\nWith those words, the salesman grabs your head and shoves it into his cotton candy machine. \n\nYour face melts and mixes with the pink sugar...\n\n... Let's just say that you've eaten your cotton candy... ","_restaurant","SugarDaddy",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,77,false,"",0,"",""),
					new Test(100,"Card_Piranhas_Aquarium","The Zoo","Card_Piranha_Aquarium","You arrive in front of a pool filled with piranhas, right next to the circus tent.\nA man from the circus feeds them little wounded fish to eat.","_animalerie","Piranhas",false,"none",false,0,"","_none","none",101,"Enter, legs deep, in the fish tank","","none",103,"Go and talk to him","","none",false,false,100,false,"",0,"",""),
					new Test(101,"Card_Piranhas_Feet","The Zoo","Card_Piranha_WetFoot","Piranhas graze your legs but don't attack you. \nThe man looks at you strangely while asking you to come out.","_animalerie","Piranhas",false,"none",false,0,"","_none","none",107,"Grab and bite a piranha","","none",102,"Thorw a piranha to the cleaner's head","","Hitman",false,false,100,false,"",0,"",""),
					new Test(102,"Card_Piranhas_CleanderDead","The Zoo","Card_Piranha_ManDead","Smelling the bloody smell of fish, the piranha severely bit the nose of the man who fell into the pond. \n\nHe is devoured within seconds while you are still unharmed, in the midst of the carnage.","_animalerie","Piranhas",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,100,false,"",0,"",""),
					new Test(103,"Card_Piranhas_CleanerQuestion","The Zoo","Card_Piranha_Aquarium","\"What do you want, sir ?\"","_animalerie","Piranhas",false,"none",false,0,"","_none","none",108,"Shove him and try to take a fish","","none",104,"Give me one of those fish","","none",false,false,100,false,"",0,"",""),
					new Test(104,"Card_Piranhas_OldFish","The Zoo","Card_Piranha_FishDisgusting","\"I warn you, they taste very bad, they're supposed to be for piranhas... Here you go.\"\nYou get a wounded fish.","_animalerie","Piranhas",false,"none",false,0,"","_none","none",105,"Rub the fish on your face","","none",106,"Eat the fish","","none",false,false,100,false,"",0,"",""),
					new Test(105,"Card_Piranhas_FishOnFace","The Zoo","Card_Piranha_FishOnFace","You're wondering what made you to do such a stupid thing...\nYou go away thinking about the meaning of your life.","_animalerie","Piranhas",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,100,false,"",0,"",""),
					new Test(106,"Card_Piranhas_EatFish","The Zoo","Card_Piranha_FishOnFace","You're wondering what made you to do such a stupid thing...\n\"Another one of those nutcases...\" said the man in a low voice as you walked away...","_animalerie","Piranhas",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,100,false,"",0,"",""),
					new Test(107,"Card_Piranhas_Death_PirhanaRevenge","The Zoo","Card_Death_Piranha_Bite","You seriously hurt the piranha who, wishing for revenge, bites you back.\nYou fall backwards in the pool and all the piranhas throw themselves at you.\nYou feel your limbs tear and die in unimaginable pain.","_animalerie","Piranhas",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,100,false,"",0,"",""),
					new Test(108,"Card_Piranhas_Death_ManAttacked","The Zoo","Card_Death_Piranha_Head","With an incredible speed and strength, the man pushes you back and pushes a fish in your mouth he then plunges your head into the pond.\nYou struggle a bit while the man holds you and the piranhas tear your face.\nYou die in indescribable suffering.","_animalerie","Piranhas",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,100,false,"",0,"",""),
					new Test(109,"Card_Lion_Cage","The Zoo","Card_Lion_Cage","You arrive in front of the lion's cage, behind the main tent. He's circling around looking at you.","_animalerie","Lion",false,"none",true,117,"Throw some Cotton Candy to him","_souris","none",110,"Try to enter the cage","","none",114,"Ask the Lion what's up","","none",false,false,109,false,"",1,"_barbeAPapa",""),
					new Test(110,"Card_Lion_Nope","The Zoo","Card_Lion_Nope","The huge cat meows something, something you understood \"Don't come in\"","_animalerie","Lion",false,"none",false,0,"","_none","none",111,"Ask him to eat you","","none",113,"Try to break the cage with your foot","","none",false,false,109,false,"",0,"",""),
					new Test(111,"Card_Lion_NoEat","The Zoo","Card_Lion_WtfMan","\"Why would I do such a thing?\"","_animalerie","Lion",false,"none",false,0,"","_none","none",112,"Because I'm asking you","","none",112,"Oh my god please eat me! I beg you!","","none",false,false,109,false,"",0,"",""),
					new Test(112,"Card_Lion_GetDeadMouse","The Zoo","Card_Lion_GiveMouse","\"If you wish to die, give this to the elephant.\" \n\nYou get a [dead mouse].","_animalerie","Lion",false,"none",false,0,"","_none","none",0,"","_souris","none",0,"","_souris","none",true,false,109,false,"",0,"",""),
					new Test(113,"Card_Lion_BrokenAnkle","The Zoo","Card_Lion_BrokenAnkle","You break your ankle and have to go and sit down for a while.","_animalerie","Lion",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,109,false,"",0,"",""),
					new Test(114,"Card_Lion_LookAtYou","The Zoo","Card_Lion_WtfMan","He looks sideways as he turns his head, intrigued.","_animalerie","Lion",false,"none",true,118,"Throw some Poisonned Cotton Candy to him","_none","none",115,"I can release you if you want","","none",116,"I hope you stay in this cage forever!","","none",false,false,109,false,"",1,"_barbeAPapaEmpoisonée",""),
					new Test(115,"Card_Lion_TakeOut","The Zoo","Card_Lion_FeelsGoodInCage","\"Of course not, you idiot ! \nI am fed and caressed abundantly every day! \nAll I have to do is roar in front of a few people! \nDo you have such a cool life?\"","_animalerie","Lion",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,109,false,"",0,"",""),
					new Test(116,"Card_Lion_Insult","The Zoo","Card_Lion_FeelsGoodInCage","\"I hope so, too!\n\nI'm taken care of every day if I roar in front of a few people.\n\nYou'd better get out of here now.","_animalerie","Lion",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,109,false,"",0,"",""),
					new Test(117,"Card_Lion_GiveGoodSugar","The Zoo","Card_Lion_GiveMouse","The lion takes a bite.\n\n\"Humm what a delight! Thank you, my friend.\"\n\nThe lion generously offers you a [dead mouse].","_animalerie","Lion",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,109,false,"",0,"",""),
					new Test(118,"Card_Lion_Death_PoisonnedSugar","The Zoo","Card_Death_Lion","The lion takes a bite.\n\nAll of a sudden, he starts vomiting all over the place and goes crazy!\n\nUnintentionally, in an excess of madness, he claws you through the bars in your face.\n\nYou perish with your face slashed.","_animalerie","Lion",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,109,false,"",0,"",""),
					new Test(119,"Card_Elephant_Enclosure","The Zoo","Card_Elephant_enclosure","You arrive in front of the elephant's enclosure. \n\nHe's outside, in the open air with beautiful trees to keep him company.","_animalerie","Elephant",false,"none",true,125,"Throw the dead mouse to the elephant","_none","none",120,"Say Hi to the animal","_none","none",122,"Enter the enclosure","","none",false,false,119,false,"",1,"_souris",""),
					new Test(120,"Card_Elephant_AskBanana","The Zoo","Card_Elephant_Talk","\"Hello to you, friend! Would you like a banana? I got plenty.\"","_animalerie","Elephant",false,"none",false,0,"","_none","none",124,"Take the banana","_none","none",121,"Refuse the banana","","none",false,false,119,false,"",0,"",""),
					new Test(121,"Card_Elephant_GoAway","The Zoo","Card_Elephant_ViolentInsult","\"Fuck off then ! \nGet out of here! Get out of here !\"","_animalerie","Elephant",false,"none",false,0,"","_none","none",0,"","_none","none",0,"","","none",true,false,119,false,"",0,"",""),
					new Test(122,"Card_Elephant_AskWhat","The Zoo","Card_Elephant_Eating","\"What are you doing ?\" asked the animal.","_animalerie","Elephant",false,"none",true,125,"Throw the dead mouse to the elephant","_none","none",123,"Piss off, fuck face","_none","none",123,"Your mother is so cheap, ducks throw her bread","","Wedontinsultmothers",false,false,119,false,"",1,"_souris",""),
					new Test(123,"Card_Elephant_Insult","The Zoo","Card_Elephant_ThrowAway","\"Be nicer, motherfucker.\"\n\nWith these words, the elephant catches you with its trunk and throws you away from its enclosure.","_animalerie","Elephant",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,119,false,"",0,"",""),
					new Test(124,"Card_Elephant_Death_SlideBanana","The Zoo","Card_Death_Elephant_Slipped","On your way to the elephant to get it, you slip on a banana peel and fall on your head. \n\nConcussion, looks like you're dead.","_animalerie","Elephant",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,119,false,"",0,"",""),
					new Test(125,"Card_Elephant_Death_Mouse","The Zoo","Card_Death_Elephant_Stomped","At the sight of the dead animal, the elephant start to run everywhere. \n\nIn his blind madness he impale you with one of his tusks.\n\nYou will die with a smile on your face, with a hole in your belly on the elephant's tusk while thanking the lion.","_animalerie","Elephant",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,119,false,"",0,"","")
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