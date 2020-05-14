
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
		public System.DateTime updated = new System.DateTime(2020,5,14,13,4,42);
		public readonly string[] labels = new string[]{"ID","Name","Titre Carte","Sprite","Description","Place","Event","Mort ?","Success If Die","Can Slide Up","Up Card ID","Up Slide Text","Up Object Unlock","Up Succes Unlock","Right Card ID","Right Slide Text","Right Object Unlock","Right Sucess Unlock","Left Card ID","Left Slide Text","Left Object Unlock","Left Sucess Unlock","Finish Event","Played Once","First Of Event ID","Has VFX","Card VFX","UnlockUpNbrObject","FirstObject","SecondObject"};
		private Test[] _rows = new Test[77];
		public void Init() {
			_rows = new Test[]{
					new Test(0,"Card_FortuneTeller_Tent","The Broadwalk","Card_TR_FortuneTeller_Tent","As you walk through the funfair, you come across a fortune-teller and she invites you to follow her in her tent for a prediction.","_balade","FortuneTeller",false,"none",false,0,"","_none","none",4,"Follow her inside","","none",1,"Get on your way","","none",false,false,0,false,"",0,"",""),
					new Test(1,"Card_FortuneTeller_FindLighter","The Broadwalk","Card_TR_FortuneTeller_Lighter","You continue on your way and notice that there is a lighter on the ground.","_balade","FortuneTeller",false,"none",false,0,"","_none","none",2,"Pick up the lighter","_briquet","none",3,"Don't pick up the lighter","","none",false,false,0,false,"",0,"",""),
					new Test(2,"Card_FortuneTeller_TakeLighter","The Broadwalk","Card_Background","You take the lighter and you walk away","_balade","FortuneTeller",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,0,false,"",0,"",""),
					new Test(3,"Card_FortuneTeller_LeaveNoLighter","The Broadwalk","Card_Background","You leave and continue your walk","_balade","FortuneTeller",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,0,false,"",0,"",""),
					new Test(4,"Card_FortuneTeller_Follow","The Broadwalk","Card_TR_FortuneTeller_Prophecy","You walk into her tent and sit at a table. \nThe woman look at her crystal ball and shouted: \"By all the gods, something horrible is about to happen to you! You must leave at once!\".","_balade","FortuneTeller",false,"none",false,0,"","_none","none",6,"Stay anyway","","none",5,"Leave, that's some freaky shit","","none",false,false,0,false,"",0,"",""),
					new Test(5,"Card_FortuneTeller_LeaveSucess","The Broadwalk","Card_Background","You continue on your way, unfortunately all is well for the moment.","_balade","FortuneTeller",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,0,false,"",0,"",""),
					new Test(6,"Card_FortuneTeller_Death","The Broadwalk","Card_Background","You hear the ceiling crack and get a petanque ball on your head. \nYou're stunned and you collapse on a chair. Unfortunately the chair in question gives way and you fall on the nail board of the fortune teller. \nEven when you are standing, the plank literally remains nailed to your ass. \nYou step on the petanque ball and fall back on your buttocks again. \nAt the same time, a plank from the perforated ceiling falls on you....\nYou die with your head squashed and your asshole punctured.","_balade","FortuneTeller",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,0,false,"",0,"",""),
					new Test(7,"Card_KnifeThrower_Meeting","The Broadwalk","Card_TR_Char_KnifeThrower","As you walk through the funfair, you come across the knife-thrower's stall. He's drinking whiskey.","_balade","KnifeThrower",false,"none",false,0,"","_none","none",11,"Volunteer for his show","","none",8,"Tell him to stop drinking","","none",false,false,7,false,"",0,"",""),
					new Test(8,"Card_KnifeThrower_Sleep","The Broadwalk","Card_Background","\"Hummm...oooh...okkk hehehe...\" \nThe knife-thrower falls asleep. \nYou notice a pair of scissors stuck in a target...","_balade","KnifeThrower",false,"none",false,0,"","_none","none",9,"Take the scissors","_ciseaux","none",10,"Don't take the rusty scissors","","none",false,false,7,false,"",0,"",""),
					new Test(9,"Card_KnifeThrower_Scissors","The Broadwalk","Card_Background","You get pair of scissors and continue on your way.","_balade","KnifeThrower",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,7,false,"",0,"",""),
					new Test(10,"Card_KnifeThrower_Leave","The Broadwalk","Card_Background","You go on your way.","_balade","KnifeThrower",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,7,false,"",0,"",""),
					new Test(11,"Card_KnifeThrower_Show","The Broadwalk","Card_Background","\"Ooooh, all right, come here. \nLie down on that wheel... let me tie you up...\" \nYou're strapped vertically on a wheel that slowly spins. \nThe pitcher sharpens his knives before throwing them while drinking.","_balade","KnifeThrower",false,"none",false,0,"","_none","none",13,"Let him, he's a pro!","","none",12,"Ask him to stop drinking","","none",false,false,7,false,"",0,"",""),
					new Test(12,"Card_KnifeThrower_Unharmed","The Broadwalk","Card_Background","He's putting the bottle down.\nHe throws his knives right at the edge of your limbs on the wheel. \nYou leave, unharmed.","_balade","KnifeThrower",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,7,false,"",0,"",""),
					new Test(13,"Card_KnifeThrower_Death","The Broadwalk","Card_Background","Totally drunk, he sends his four knives. \nYour hands and feet are pierced. The knife-thrower falls asleep on a chair next to you. \nYou bleed to death... and die.","_balade","KnifeThrower",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,7,false,"",0,"",""),
					new Test(14,"Card_Clown_See","The Broadwalk","Card_Background","You go ahead of a clown who blows up balloons in the shape of lions and elephants for children.","_balade","Clown",false,"none",true,25,"Pinch his big, appealing red nose","_none","none",18,"Hey Clown, tell me a joke!","","none",15,"Hey clown! I want a balloon","","none",false,false,14,false,"",0,"",""),
					new Test(15,"Card_Clown_AskBalloon","The Broadwalk","Card_Background","\"What shape do you want for your ballon, man?\"","_balade","Clown",false,"none",false,0,"","_none","none",16,"A lion","","none",16,"An elephant","","none",false,false,14,false,"",0,"",""),
					new Test(16,"Card_Clown_TakeBalloon","The Broadwalk","Card_Background","\"There you have it ! It's a shark, I don't care what you ask\"","_balade","Clown",false,"none",false,0,"","_none","none",17,"Explode the balloon","","none",17,"\"This balloon looks like shit\"","","none",false,false,14,false,"",0,"",""),
					new Test(17,"Card_Clown_CryLeave","The Broadwalk","Card_Background","\"............\"\n\nThe clown quickly inflates a big balloon and puts it in your mouth before dropping it.\n\nThe air is released from the balloon and you fly away.\n\n\"So we're having a ball, huh?!\"","_balade","Clown",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,14,false,"",0,"",""),
					new Test(18,"Card_Clown_Joke01","The Broadwalk","Card_Background","\"How do you recognize a letter from a leper ?\"","_balade","Clown",false,"none",false,0,"","_none","none",19,"Ok! What is it?","","none",19,"...","","none",false,false,14,false,"",0,"",""),
					new Test(19,"Card_Clown_Answer01","The Broadwalk","Card_Background","\"The tongue stay stuck to the stamp.\"","_balade","Clown",false,"none",false,0,"","_none","none",24,"Not funny...","","none",20,"Another one!","","none",false,false,14,false,"",0,"",""),
					new Test(20,"Card_Clown_Joke02","The Broadwalk","Card_Background"," \"How many men does it take to paint a car red?\"","_balade","Clown",false,"none",false,0,"","_none","none",21,"Ahaha! What's the answer?","","none",21,"...","","none",false,false,14,false,"",0,"",""),
					new Test(21,"Card_Clown_Answer02","The Broadwalk","Card_Background","\"Only one, but you have to throw it very hard !\"","_balade","Clown",false,"none",false,0,"","_none","none",24,"Shut up! Please!","","none",22,"Again! Bis!","","none",false,false,14,false,"",0,"",""),
					new Test(22,"Card_Clown_Joke03","The Broadwalk","Card_Background","\"A little girl's on a swing.\nSuddenly she falls. Why does she fall ?\"","_balade","Clown",false,"none",false,0,"","_none","none",23,"AHAHAHAHAHAHAHAHAHAHAHA","","none",23,"...","","none",false,false,14,false,"",0,"",""),
					new Test(23,"Card_Clown_Answer03","The Broadwalk","Card_Background","\"Because she doesn't have any arms!\n\nAHHAAAHAHAAHHHAAHA!\"\n\nYou can't take it anymore, you're bent in half by laughter before you drop dead.\n\n\"That's what we call being dead laughing hehehahahahahahahaha!\"","_balade","Clown",false,"none",false,0,"","_none","none",24,"Those jokes oppress me!","","none",26,"AHAHAHAHHAHAHAHHAHAHAHHAHAHH","","none",false,false,14,false,"",0,"",""),
					new Test(24,"Card_Clown_ShutUp","The Broadwalk","Card_Background","\"........\" \n\nYou take a hammer thump to the head and pass out.","_balade","Clown",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,14,false,"",0,"",""),
					new Test(25,"Card_Clown_AcidDeath","The Broadwalk","Card_Background","Acid comes out of his nostrils and lands in your eye! You're now one-eyed...\n\n\"Shit, oh my poor thing! You're a real pirate now ahahahahaa!\" ","_balade","Clown",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,14,false,"",0,"",""),
					new Test(26,"Card_Clown_LaughDeath","The Broadwalk","Card_Background","\"Oh... so sorry my friend, I was laughing... hey hey hey hey.\"\n\nThe clown shakes your hand to apologize.\n\nYou get a shock and die electrocuted.","_balade","Clown",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,14,false,"",0,"",""),
					new Test(27,"Card_Vald_See","The Broadwalk","Card_Background","You are walking and at a moment, you bump into a man.","_balade","VALD",false,"none",false,0,"","_none","none",28,"Bonjour","","none",29,"Wassup ?","","none",false,false,27,false,"",0,"",""),
					new Test(28,"Card_Vald_Bonjour","The Broadwalk","Card_Background","The man gives you a tomato and leaves.","_balade","VALD",false,"none",false,0,"","_none","none",0,"","_tomate","none",0,"","_tomate","none",true,false,27,false,"",0,"",""),
					new Test(29,"Card_Vald_Death","The Broadwalk","Card_Background","He's screwing your mother.\n\nYou're fucking DEAD !","_balade","VALD",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,27,false,"",0,"",""),
					new Test(30,"Card_ConfettiCannon_See","The Circus","Card_Background","You see a beautiful cannon with confetti inside and next to it in a seal. As you get closer, you can choose to add confetti inside, slide inside, or light the fuse of the cannon.","_circus","ConfettisCannon",false,"none",true,37,"Light the fuse","_none","none",31,"Add confettis","","none",32,"Get in the cannon","","none",false,false,30,false,"",1,"_briquet",""),
					new Test(31,"Card_ConfettiCannon_Filled","The Circus","Card_Background","Wow !\nThe cannon is filled to the brim, the confetti are overflowing.","_circus","ConfettisCannon",false,"none",true,35,"Ligh the fuse","_none","none",34,"Leave","","none",32,"Get in the cannon","","none",false,false,30,false,"",1,"_briquet",""),
					new Test(32,"Card_ConfettiCannon_ConfortableLeave","The Circus","Card_Background","Uh huh... It's very comfortable here... It's so much fun! Nothing's happening...\nYou're coming out of the cannon.","_circus","ConfettisCannon",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,30,false,"",0,"",""),
					new Test(33,"Card_ConfettiCannon_ExplosionLeave","The Circus","Card_Background","You light the fuse, but before you can do anything, the gun fires.\nBOOM ! Confetti fireworks! That was cool! But you're still in perfect condition... too bad.","_circus","ConfettisCannon",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,30,false,"",0,"",""),
					new Test(34,"Card_ConfettiCannon_DisappointingLeave","The Circus","Card_Background","Hmmm... disappointing","_circus","ConfettisCannon",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,30,false,"",0,"",""),
					new Test(35,"Card_ConfettiCannon_FuseOn01","The Circus","Card_Background","The fuse begins to burn slowly.","_circus","ConfettisCannon",false,"none",false,0,"","_none","none",33,"Add even more confettis","","none",38,"Get inside that cannon","","none",false,false,30,false,"",0,"",""),
					new Test(36,"Card_ConfettisCannon_FullFilled","The Circus","Card_Background","Impressive how many confetti you could put in that cannon, what a nice explosion...","_circus","ConfettisCannon",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",false,false,30,false,"",0,"",""),
					new Test(37,"Card_ConfettiCannon_FuseOn02","The Circus","Card_Background","The fuse begins to burn slowly.","_circus","ConfettisCannon",false,"none",false,0,"","_none","none",33,"Add even more confettis","","none",39,"Get inside that cannon","","none",false,false,30,false,"",0,"",""),
					new Test(38,"Card_ConfettiCannon_BestDeath","The Circus","Card_Background","BAANG !\nYour limbs and the rest of your body join the confetti in the explosion, what a beautiful death !","_circus","ConfettisCannon",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,30,false,"",0,"",""),
					new Test(39,"Card_ConfettiCannon_DisapointingDeath","The Circus","Card_Background","BAANNG ! Members all over the tent ! You died with panache ! But you can do better than that, for sure !","_circus","ConfettisCannon",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,30,false,"",0,"",""),
					new Test(40,"Card_Magician_Show","The Circus","Card_Background","On the stage is a strange magician doing his show.\n\n\"Are you ready for the next number!? I will need a volunteer!\"","_circus","Magician",false,"none",false,0,"","_none","none",41,"He's so bad, boo him","","none",43,"I volunteer as tribute!","","none",false,false,40,false,"",0,"",""),
					new Test(41,"Card_Magician_Boo","The Circus","Card_TR_Magician_Boo","\"What's the matter with you people? Let's calm down!\"","_circus","Magician",false,"none",true,46,"Throw a tomato","_none","none",45,"Try to insult someone mothers","","none",42,"Leave, it's shit anyways","","none",false,false,40,false,"",1,"_tomate",""),
					new Test(42,"Card_Magician_Leave","The Circus","Card_Background","You're leaving the magic show.","_circus","Magician",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,40,false,"",0,"",""),
					new Test(43,"Card_Magician_Volunteer","The Circus","Card_Background","\"Ohhh ! Come on ! Come on, volunteer ! You won't be disappointed! hehehehehe...\"","_circus","Magician",false,"none",false,0,"","_none","none",44,"Spit on his face","","none",47,"Join him for the trick","","none",false,false,40,false,"",0,"",""),
					new Test(44,"Card_Magician_SpitLeave","The Circus","Card_TR_Magician_Spit","\"Damn it! You animal! Get him out of here, will you?\"\nThe guards grab you by the arms and throw you off the stage and off the show.  ","_circus","Magician",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,40,false,"",0,"",""),
					new Test(45,"Card_Magician_FailLeave","The Circus","Card_Background","Finding, no one's mother in the crowd you leave, a bit sad.","_circus","Magician",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,40,false,"",0,"",""),
					new Test(46,"Card_Magician_CrowdDeath","The Circus","Card_Background","Right in the face ! \nYou have heated the public ! \nHe throws chairs at the magician and starts to climb on the stage ! \nYou're trampled to death by the madding crowd...","_circus","Magician",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,40,false,"",0,"",""),
					new Test(47,"Card_Magician_MagicalDeath","The Circus","Card_Background","\"All right ! Come on, get on that cross on the ground. \nLadies and gentlemen ! Behold ! \nWith this wand I will make our friend disappear! A\nla wak vadaaa baa davraa !\" \nPOOOF ! \n\"And now he's going to reappear: Davraaa baa vadaaa vadaaa wak ala !\n............ Uhh.......... It's all part of the show, hey.... \nGet the hell out of here now ! Show's over.\nPooof! You disappeared without reappearing !\nYou're dead... for sure... Let's say you're dead, well done !\n","_circus","Magician",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,40,false,"",0,"",""),
					new Test(48,"Card_Trapezist_Enter","The Circus","Card_Background","You enter in the part of the acrobats of the circus. From the public benches, several possibilities are open to you.","_circus","Trapezist",false,"none",false,0,"","_none","none",55,"Try to get some damn popcorn","","none",49,"Get on the sand","","none",false,false,48,false,"",0,"",""),
					new Test(49,"Card_Trapezist_UnderNet","The Circus","Card_Background","You are under their safety net on the stage.","_circus","Trapezist",false,"none",true,50,"Cut the safety net","_none","none",53,"Wave your middle finger at the acrobats","","none",54,"Rest under the net","","none",false,false,48,false,"",1,"_ciseaux",""),
					new Test(50,"Card_Trapezist_NetCut","The Circus","Card_Background","A good thing done !","_circus","Trapezist",false,"none",true,51,"Cut the cables holding the poles","_none","none",52,"Get the crowd to attack the acrobats","","none",58,"Stress the acrobats insulting their mothers","","none",false,false,48,false,"",1,"_ciseaux",""),
					new Test(51,"Card_Trapezist_SteelCables","The Circus","Card_Background","The main trapeze artist falls into his net.\nHe yells at you for what you've done and shoves your popcorn down your throat.\nYou'll choke to death... ","_circus","Trapezist",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,48,false,"",0,"",""),
					new Test(52,"Card_Trapezist_CrowdNoCare","The Circus","Card_Background","The crowd isn't listening to you. They don't give a shit about you.","_circus","Trapezist",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,48,false,"",0,"",""),
					new Test(53,"Card_Trapezist_TooLow","The Circus","Card_Background","You're waving down on the sand but they can't see you, they're too high up...","_circus","Trapezist",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,48,false,"",0,"",""),
					new Test(54,"Card_Trapezist_SleepOnNet","The Circus","Card_Background","You end up falling asleep on the net... The show's over... you just have to leave.","_circus","Trapezist",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,48,false,"",0,"",""),
					new Test(55,"Card_Trapezist_GetPopcorn","The Circus","Card_Background","You knock him out and get a bag of popcorn. \n\n[You win \"Pack of Popcorn.\"]","_circus","Trapezist",false,"none",false,0,"","_none","none",57,"Throw some popcorn on the acrobats","","none",56,"Be a jerk to the acrobats","","none",false,false,48,false,"",0,"",""),
					new Test(56,"Card_Trapezist_FunLeave","The Circus","Card_Background","You're laughing all through the show. Show's over. You're leaving.","_circus","Trapezist",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,48,false,"",0,"",""),
					new Test(57,"Card_Trapezist_ChokeDeath","The Circus","Card_Background","The main trapeze artist falls into his net.\nHe yells at you for what you've done and shoves your popcorn down your throat.\nYou'll choke to death... ","_circus","Trapezist",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,48,false,"",0,"",""),
					new Test(58,"Card_Trapezist_FallOnYouDeath","The Circus","Card_Background","An acrobat lets go of her partner's hand to give you an obscene gesture and drops him... on you!\n\nDid she do it on purpose? It doesn't matter, you're dead.","_circus","Trapezist",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,48,false,"",0,"",""),
					new Test(59,"Card_Fire_Bin","The Food Courts","Card_TR_Fire_Bin","You are strolling between restaurants, not really knowing why, you're searching through a garbage...","_restaurant","Combustion",false,"none",true,60,"Take the cig","_none","none",61,"Take the tissue","","none",64,"Take the Spicy Sauce","","none",false,false,59,false,"",0,"",""),
					new Test(60,"Card_Fire_FindCig","The Food Courts","Card_TR_Fire_Smoke","It's full of slime and well chewed.","_restaurant","Combustion",false,"none",false,0,"","_none","none",62,"Put it back","","none",63,"Take a smoke","","none",false,false,59,false,"",0,"",""),
					new Test(61,"Card_Fire_FindTissue","The Food Courts","Card_TR_Fire_Tissue","There's not only snot in this tissue...","_restaurant","Combustion",false,"none",false,0,"","_none","none",62,"Put it back","","none",63,"Take a bite","","none",false,false,59,false,"",0,"",""),
					new Test(62,"Card_Fire_PutItBack","The Food Courts","Card_TR_Fire_DropGood","Good","_restaurant","Combustion",false,"none",false,0,"","_none","none",59,"Look back inside","","none",66,"Leave","","none",false,false,59,false,"",0,"",""),
					new Test(63,"Card_Fire_Gross","The Food Courts","Card_TR_Fire_Use","You still have a modicum of dignity, that's good...","_restaurant","Combustion",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,59,false,"",0,"",""),
					new Test(64,"Card_Fire_ClosedSauce","The Food Courts","Card_TR_Fire_FindSpicy","It's still closed.","_restaurant","Combustion",false,"none",false,0,"","_none","none",64,"Open it","","none",66,"Drop it back in","","none",false,false,59,false,"",0,"",""),
					new Test(65,"Card_Fire_SpicySauce","The Food Courts","Card_Background","\"If you want to smell chilli, it smells chilli!\"","_restaurant","Combustion",false,"none",false,0,"","_none","none",67,"Swallow the sauce","","none",66,"Drop it back in","","none",false,false,59,false,"",0,"",""),
					new Test(66,"Card_Fire_LilDick","The Food Courts","Card_Background","Seems you don't have whart it takes...","_restaurant","Combustion",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,59,false,"",0,"",""),
					new Test(67,"Card_Fire_Death","The Food Courts","Card_Background","You throw away the empty package and resume your walk.\n\nAll of a sudden your belly and mouth burn incredibly hard.\n\nInstantly, you catch fire and die burned alive.","_restaurant","Combustion",true,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,59,false,"",0,"",""),
					new Test(68,"Card_Chicken_EnterRestaurant","The Food Courts","Card_Background","You walk into a restaurant. A waiter puts you at a table and hands you a menu. Make your order.","_restaurant","Chickens",false,"none",false,0,"","_none","none",71,"Poched Egg","","none",69,"Hard Egg","","none",false,false,68,false,"",0,"",""),
					new Test(69,"Card_Chicken_HardEgg","The Food Courts","Card_Background","And the seasoning ?","_restaurant","Chickens",false,"none",false,0,"","_none","none",70,"Salt","","none",75,"Pepper","","none",false,false,68,false,"",0,"",""),
					new Test(70,"Card_Chicken_HardEgg_Salt","The Food Courts","Card_Background","Ow... it's actually well cooked.\n\nYou lose two teeth on this egg...\n\n[You gain two teeth]\n\nYou're going to the dish.\n\nRoast chicken.\n\nThat's just disgusting! \n\nYou are leaving this disgusting restaurant, all you've earned are two of your broken teeth!","_restaurant","Chickens",false,"none",false,0,"","_none","none",0,"","_dents","none",0,"","_dents","none",true,false,68,false,"",0,"",""),
					new Test(71,"Card_Chicken_SoftEgg","The Food Courts","Card_Background","And the seasoning ?","_restaurant","Chickens",false,"none",false,0,"","_none","none",71,"Salt","","none",72,"Pepper","","none",false,false,68,false,"",0,"",""),
					new Test(72,"Card_Chicken_SoftEgg_Salt","The Food Courts","Card_Background","Mmmmh well melting in the mouth this egg!\n\nCome on, the dish : an omelet.\n\nIt's simply disgusting ! \n\nYou're leaving this disgusting restaurant !","_restaurant","Chickens",false,"none",false,0,"","_none","none",0,"","","none",0,"","","none",true,false,68,false,"",0,"",""),
					new Test(73,"Card_Chicken_SoftEgg_Pepper","The Food Courts","Card_Background","You have a serious stomach ache.\n\nAnyway... it's time for the dish. \n\nYou're going to have the omelette.\n\nYou feel that your stomach ache is becoming unbearable... \n\nAs if your belly is going to explode!","_restaurant","Chickens",false,"none",false,0,"","_none","none",73,"Go to the toilets","","none",75,"Stay, like a real man!","","none",false,false,68,false,"",0,"",""),
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