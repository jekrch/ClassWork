using System;
using System.Speech.Synthesis;
using System.Threading;

namespace BattleShip.UI.Audio
{
    class Synth
    {
        // read text in on two threads
        public static void Speak(string toSpeak, int msOffset)
        {
            // I have two iterations of the voice speak with a minor offset to create
            // a more synthetic, creepy AI sound. 

            Thread t2 = new Thread(() => Voice(toSpeak));  // play the jingle while title screen animates
            t2.Start();
            Thread.Sleep(msOffset);
            Thread t3 = new Thread(() => Voice(toSpeak));  // play the jingle while title screen animates
            t3.Start();
        }

        // announces the winner and plays jingle
        public static void WinnerAnnouncement(string playerName)
        {
            Synth.Speak($"{playerName} wins. Congratulations.", 150); // synth speaks with music
            Synth.PlayJingle();
        }

        // read text
        private static void Voice(string toSpeak)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();

            synth.SelectVoiceByHints(VoiceGender.Female);
            synth.Rate = 1;
            synth.Speak(toSpeak);
        }

        // Play jingle on new thread so that it's concurrent 
        // with other events
        public static void PlayJingle()
        {
            Thread t1 = new Thread(Jingle);
            t1.Start();
        }

        // A little title screen jingle 
        public static void Jingle()
        {
            // goes a little something like this
            Thread.Sleep(200);
            Console.Beep(300, 100);
            Console.Beep(400, 100);
            Console.Beep(600, 200);
            Console.Beep(500, 100);
            Console.Beep(400, 100);
            Console.Beep(300, 200);
            Console.Beep(300, 100);
            Console.Beep(400, 100);
            Console.Beep(700, 200);
            Console.Beep(500, 100);
            Console.Beep(400, 100);
            Console.Beep(300, 200);
            Console.Beep(300, 100);
            Console.Beep(400, 100);
            Console.Beep(800, 200);
            Console.Beep(700, 100);
            Console.Beep(200, 100);
            Console.Beep(400, 900);

            // Copyright Jacob "SynthKilla" Krch 2015
        }
    }
}
