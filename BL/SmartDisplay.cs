using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaspberryPiNetCore.LCD;
using System.Threading;

namespace BL
{
   public class SmartDisplay
   {
        private SerLCD LCD;

        public SmartDisplay()
        {
            LCD = new SerLCD();
        }


        public void PrintOpstartMenu()
        {
            LCD.lcdSetBackLight(200, 30, 20);
            LCD.lcdPrint("___BLODTRYKMAALER___");
            Thread.Sleep(3000);
            LCD.lcdSetBackLight(200, 30, 20);
            LCD.lcdGotoXY(0, 1);
            LCD.lcdPrint("______Gruppe 4______");
            Thread.Sleep(3000);
            LCD.lcdSetBackLight(200, 30, 20);
            LCD.lcdGotoXY(0, 2);
            LCD.lcdPrint("--Best of the best--");
            Thread.Sleep(3000);
        }


        public void PrintStartMenu()
        {
            LCD.lcdClear();
            LCD.lcdSetBackLight(50, 200, 50);
            LCD.lcdPrint("Blodtryksmaaler");
            LCD.lcdGotoXY(0, 1);
            LCD.lcdPrint("1:Nulpunktsjustering");
            LCD.lcdGotoXY(0, 2);
            LCD.lcdPrint("2:Start BT maaling");

        }


        public void Print()
        {

        }












    }
}
