
// Displaying name of the user

let user=prompt("Nice to meet you! Please tell us your name (or even a nickname!).","Friend A");
if(user==null) user="Friend A";
document.getElementById('head').innerHTML=`Welcome ${user} !`;
document.getElementById('text').innerHTML="Remember, you're not alone because we are always with you!";

// Format for displaying the options

let format=`<div class="options" id="op1">
  						<input type="radio" name="options" id="1" class="op">
  						<label for="1" id="op1text"></label>
  					</div>
  					<div class="options" id="op2">
  						<input type="radio" name="options" id="2" class="op">
  						<label for="2" id="op2text"></label>
  					</div>
  					<div class="options" id="op3">
  						<input type="radio" name="options" id="3" class="op">
  						<label for="3" id="op3text"></label>
  					</div>
  					<div class="options" id="op4">
  						<input type="radio" name="options" id="4" class="op">
  						<label for="4" id="op4text"></label>
  					</div>`;
let score=0;
let qno=0;
let quizstarted=false;
let displayquote=false;

// list of the quiz questions

let questions=[{
	question:"How often do you talk with your friends or loved ones?",
	options:["All the time","Regularly","Rarely","Never"],
	reverse: true,
	quote:"Sharing your thoughts with others helps you flush out all the negativity in your mind while not doing so will only cause it to pile up. There are always people who are ready to lend you an ear. It may be a friend , a family member or even a complete stranger!",
	
},{
	question:"Do you feel that you have started losing interest in the things you once enjoyed?",
	options:["Yes, I believe so","I feel like that sometimes","I rarely feel like that","I never feel like that"],
	reverse: false,
	quote:"As your thinking becomes more pessimistic, you start forgetting the meaning of things that you once enjoyed in your life. You need to make sure to look only at the good things and ignoring the bad ones so as to reinforce the meaning these things hold in your life."
},{
	question:"Do you excercise regularly?",
	options:["Yeah, I am a gym freak!","Yes, I do it regularly","Sometimes","I would prefer to stay in my bed"],
	reverse: true,
	quote:"Excercising and meditating not only helps you improve your physical health but also distract you from negative thoughts. After all, you can't have a healthy mind without a healthy body!"
},{
	question:"Do you feel left out when in a group?",
	options:["Yes, I always feel left out","I feel so quite often","I rarely feel so","Never"],
	reverse: false,
	quote:"It's important to be actively involved when in a group conversation to ensure that all the members of the group recognize your worth. But if the members themselves aren't ready to get you involved, then it just means that it's time for you to change your group!"
},{
	question:"Do you have a proper appetite?",
	options:["Yeah, I am hungry all the time","I would say it's good enough","It's lower than it used to be","I rarely feel like eating anything"],
	reverse: true,
	quote:"A loss of appetite could be a sign of increased stress. You need to take it easy and make sure not to allow anything to take too much toll on your mind. Also, make sure to have a healthy and proper diet."
},{
	question:"Do you prefer to stay alone?",
	options:["I would love to stay alone all the time","Sometimes, I prefer to stay alone","I would prefer to be with other people","I can't live without having atleast one person with me"],
	reverse: false,
	quote:"While staying alone can sometimes help you in collecting your thoughts or have some time with yourself, you need to talk with people regularly as only by doing so can you ensure that too much stress or negativity doesnt take over you. Sharing your thoughts and feelings is very important."
},{
	question:"Are you having trouble getting to sleep and staying asleep?",
	options:["I am sleep deprived all the time","Sometimes, I find it difficult to sleep","Most of the times I have no sleep problems","I get sufficient sleep everyday"],
	reverse: false,
	quote:"Your sleep can be badly affected by stress caused due to any daily events or thinking about any of your past failures. Make sure not to overthink anything and make your bed your own personal space where none of your life problems can disturb you. Agood night's sleep is very important to maintain one's mental health!"
},{
	question:"Do you think about your past mistakes or worry about your future goals?",
	options:["Yeah, they can't seem to get out of my head","Sometimes, I think out them","I rarely think about them","Well, I never think about them"],
	reverse: false,
	quote:"You shouldn't consider your past failures as your incapabilities but instead, learn from them. Also, boost yourself to work on your goals instead of worrying about failures. And above all, dont forget to live in the present. Yesterday is history, tomorrow is a mystery, but today is a gift, that's why we call it the Present!"
},{
	question:"Are you satisfied with yourself?",
	options:["Yeah, I am confident in my abilities","Yes, to some extent","I expected much more from myself","I am not satisfied at all"],
	reverse: true,
	quote:"You might find yourself not fulfilling the expectations that you set for yourself. But that doesn't necessarily mean that you're worthless. Humans aren't perfect and if we just count our flaws, it will only demotivate us and not act as any solution to our problems. What is required is a sense of self esteem and confidence in one's own abilities. Above all, don't let someone else define who you should be. You are special in your own way."
},{
	question:"Do you feel that your life is meaningless?",
	options:["Yeah, all the time","Sometimes","Rarely","Never"],
	reverse: false,
	quote:"A sense of worthlessness generated by failures or decreased self esteem can prompt a person to lose meaning in their lives and it's worth. But it's important for all of us to know that we all have a quality that makes us special and we all have something that makes us happy. So spending time with loved ones and focusing on our abilities so as to work towards our goals without any regrets will make us realise how precious human life is."
}];

// List of background gifs

let gifs=["g1","g2","g3","g4","g5","g6","g8"];
let qgifs=[];

// Function for conducting quiz

function quiz()
{
	if(!quizstarted)
	{
		document.getElementById("options").innerHTML=format;
		// document.getElementById("q").style.height="50px";
		document.getElementById("q").innerHTML=questions[qno].question;
		document.getElementById("op1text").innerHTML=questions[qno].options[0];
		document.getElementById("op2text").innerHTML=questions[qno].options[1];
		document.getElementById("op3text").innerHTML=questions[qno].options[2];
		document.getElementById("op4text").innerHTML=questions[qno].options[3];
		document.getElementById("next").innerHTML="Next";
		let g=gifs[Math.floor(Math.random()*(gifs.length-1))]
		document.getElementById("buttons").style.backgroundImage=`url("images/${g}.gif")`;
		// console.log(g);
		quizstarted=true;
		displayquote=true;
	}

	else if(displayquote)
	{
		if( ! (document.getElementById("1").checked || document.getElementById("2").checked || document.getElementById("3").checked || document.getElementById("4").checked ) )
		{
			alert("Please select an option");
			return;
		}

		let  res=1;

		if(document.getElementById("1").checked) res=1;
		else if(document.getElementById("2").checked) res=2;
		else if(document.getElementById("3").checked) res=3;
		else res=4;

		if(questions[qno].reverse) res=5-res;

		score+=res;

		document.getElementById("options").innerHTML=``;
		document.getElementById("q").innerHTML=questions[qno].quote;
		qno++;
		displayquote=false;
	}

	else
	{
		
		if(qno>=questions.length)
		{
			document.getElementById("next").innerHTML="Start";
			// document.getElementById("q").innerHTML=`Great work ${user}, Your score was ${score}. Click on Start to play again`;
			let displaytext="";
			console.log(score);
			if(score>=10 && score<=20)
			{
				displaytext=`We highly appreciate the effort put in by you,${user}! Make sure to never overlook your efforts and learn to control your negative thoughts by filling your mind with positive ones. There will always exist things that will bring you joy. Never let yourself forget about them by focusing just on the ones which bring you pain.`;
			}
			else if(score>=21 && score<=30)
			{
				displaytext=`You did well, ${user}. Just never let yourself focus on the things you can't change but instead work on changing those that you can. Never get attached to your burdens more than the burdens are attached to you and you will be good to go!`;
			}
			else
			{
				displaytext=`Great job, ${user}! Make sure not to let stress or negativity ever take over you and you will surely enjoy each and every day of your life!`;
			}
			displaytext+="\nClick on start to play again!";
			document.getElementById("q").innerHTML=displaytext;
			document.getElementById("options").innerHTML="";
			qno=0;
			quizstarted=false;
			score=0;
			document.getElementById("buttons").style.backgroundImage=`url("images/q.gif")`;
		}
		else
		{
			document.getElementById("options").innerHTML=format;
			// document.getElementById("q").style.height="50px";
			document.getElementById("q").innerHTML=questions[qno].question;
			document.getElementById("op1text").innerHTML=questions[qno].options[0];
			document.getElementById("op2text").innerHTML=questions[qno].options[1];
			document.getElementById("op3text").innerHTML=questions[qno].options[2];
			document.getElementById("op4text").innerHTML=questions[qno].options[3];
			displayquote=true;
			let g=gifs[Math.floor(Math.random()*(gifs.length-1))]
			document.getElementById("buttons").style.backgroundImage=`url("images/${g}.gif")`;
			console.log(g);
		}

	}
}

//function for help section

function help(id)
{
	document.getElementById("t1").style="background-color:none; color:white";
	document.getElementById("t2").style="background-color:none; color:white";
	document.getElementById("t3").style="background-color:none; color:white";
	document.getElementById("t4").style="background-color:none; color:white";
	document.getElementById("t5").style="background-color:none; color:white";
	document.getElementById("t6").style="background-color:none; color:white";
	document.getElementById("t7").style="background-color:none; color:white";
	document.getElementById(id).style="background-color:white; color:black";
	let link="";
	if(id=="t1")
	{
		link="https://snacknation.com/blog/how-to-reduce-stress-at-work/";
	}
	else if(id=="t2")
	{
		link="https://www.headspace.com/sleep/stress";
	}
	else if(id=="t3")
	{
		link="https://www.mindtools.com/pages/article/dealing-with-anxiety.htm";
	}
	else if(id=="t4")
	{
		link="https://blog.zencare.co/boost-self-esteem/";
	}
	else if(id=="t5")
	{
		link="https://www.healthline.com/health/how-to-stop-being-insecure";
	}
	else if(id=="t6")
	{
		link="https://www.medicalnewstoday.com/articles/320502";
	}
	else
	{
		link="https://www.healthline.com/health/how-to-be-happy";
	}
	document.getElementById("blog").innerHTML=`<iframe src="${link}" name="helpblog1" id="b1"></iframe>
				<p><a href="${link}" class="blink" id="b1link" target="blank">Read complete blog</a></p>`;
}

// Function for changing color when someone stops hovering on a help topic

function colorchange(id)
{
	// console.log(document.getElementById(id).style.backgroundColor);
	if(document.getElementById(id).style.backgroundColor=="white") document.getElementById(id).style.color="black";
	else document.getElementById(id).style.color="white";
}

// Function for submitting confession

let submitted=false;

function confessionsubmit()
{
	if(!submitted)
	{
		if(document.getElementById("cbox").value=="")
		{
			alert("Please write something before submitting");
			return;
		}
		// document.getElementById("cbox").value="";
		// document.getElementById("cbox").style.visibility="hidden";
		// document.getElementById("cshead").innerHTML="See, that wasn't so hard. Whenever you feel like sharing anything, just write it here and we won't mind it at all!";
		document.getElementById("box").innerHTML="See, that wasn't so hard. Whenever you feel like sharing anything, just write it here and we won't mind it at all!";
		document.getElementById("csubmit").innerHTML="Write again";
		submitted=true;
	}
	else
	{
		// document.getElementById("cbox").style.visibility="visible";
		document.getElementById("box").innerHTML='<textarea id="cbox"></textarea>';
		document.getElementById("csubmit").innerHTML="Submit";
		submitted=false;
	}
}