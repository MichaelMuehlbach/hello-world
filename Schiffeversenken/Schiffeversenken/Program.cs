using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiffeversenken
{
    class Program
    {
        public class Spiel
        {
            public string[,] Spielfeld1 = new string[6, 6];
            public string[,] Spielfeld2 = new string[6, 6];

            public void Felderstellen()
            {
                for (int i = 0; i < Spielfeld1.GetLength(0); i++)
                {
                    for (int s = 0; s < Spielfeld1.GetLength(1); s++)
                    {
                        Spielfeld1[i, s] = "#";
                    }
                }

                for (int i = 0; i < Spielfeld2.GetLength(0); i++)
                {
                    for (int s = 0; s < Spielfeld2.GetLength(1); s++)
                    {
                        Spielfeld2[i, s] = "#";
                    }
                }
            }

            public void Feldanzeigen()
            {
                for (int i = 0; i < Spielfeld1.GetLength(0); i++)
                {
                    for (int s = 0; s < Spielfeld1.GetLength(1); s++)
                    {
                        Console.Write(Spielfeld1[i, s]);
                    }
                    Console.WriteLine();
                }
            }

            public void Feldanzeige2() 
            {
                for (int i = 0; i < Spielfeld2.GetLength(0); i++)
                {
                    for (int s = 0; s < Spielfeld2.GetLength(1); s++)
                    {
                        Console.Write(Spielfeld2[i, s]);
                    }
                    Console.WriteLine();
                }
            }

            public void Schiffeplatzieren(int x1, int y1, int x2, int y2)
            {
           

             

                    for (int b = x1 - 1; b <= x2 - 1; b++)
                    {
                        for (int j = y1 - 1; j <= y2 - 1; j++)
                        {
                         
                                Spielfeld2[b, j] = "S";

                              
                             
                            


                        }
                    
                
                    }



               



            }

            public void Schuss(int sx, int sy)
            {

                if (Spielfeld1[sx - 1, sy - 1] == "T" | Spielfeld1[sx - 1, sy - 1] == "D")
                {
                    Console.WriteLine("Bitte Erneut eingeben");
                    Console.WriteLine("sx");
                    int sx1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("sy");
                    int sy1 = Convert.ToInt32(Console.ReadLine());
                    Schuss(sx1, sy1);


                }
                else
                {
                    if (Spielfeld2[sx - 1, sy - 1] == "S")
                    {
                        Spielfeld1[sx - 1, sy - 1] = "T";
                        Feldanzeigen();
                    }
                    else
                    {
                        Spielfeld1[sx - 1, sy - 1] = "D";
                        Feldanzeigen();
                    }


                }
                



            }

       

            public int AnzahlSchiffe()
            {
                int Anzahl = 0;
              

                for (int i = 0; i < Spielfeld2.GetLength(0); i++)
                {
                    for (int s = 0; s < Spielfeld2.GetLength(1); s++)
                    {
                       if (Spielfeld2[i,s] == "S") 
                        {
                            Anzahl = Anzahl + 1;

                          
                        }
                    }
                }
                return Anzahl;

            }

            public int AnzahlTreffer()
            {
                int Anzahltreffer = 0;



                for (int i = 0; i < Spielfeld1.GetLength(0); i++)
                {
                    for (int s = 0; s < Spielfeld1.GetLength(1); s++)
                    {
                        if (Spielfeld1[i, s] == "T")
                        {

                            Anzahltreffer = Anzahltreffer + 1;

                            
                            
                        }
                    }
                }

               return Anzahltreffer;
            }  
        }
  
      
        static void Main(string[] args)
        {
            Spiel s = new Spiel();

            s.Felderstellen();

            Random rnd = new Random();

            int Zufall = rnd.Next(1, 5);

            if (Zufall == 1)
            {
                s.Schiffeplatzieren(1, 1, 1, 4);
                s.Schiffeplatzieren(2, 3, 5, 3);
                s.Schiffeplatzieren(1, 6, 4, 6);
            }
            else if (Zufall == 2)
            {
                s.Schiffeplatzieren(1, 1, 4, 1);
                s.Schiffeplatzieren(2, 3, 6, 3);
                s.Schiffeplatzieren(1, 4, 1, 6);
            }

            else if (Zufall == 3)
            {
                s.Schiffeplatzieren(2, 1, 2, 4);
                s.Schiffeplatzieren(1, 5, 5, 5);
                s.Schiffeplatzieren(6, 1, 6, 3);
            }
            else
            {
                s.Schiffeplatzieren(1, 3, 1, 5);
                s.Schiffeplatzieren(3, 2, 6, 2);
                s.Schiffeplatzieren(2, 2, 2, 6);
            }



            s.Feldanzeige2();

            while (true)  
            {
                Console.WriteLine("sx");
                int sx = Convert.ToInt32(Console.ReadLine());
               Console.WriteLine("sy");
              int sy = Convert.ToInt32(Console.ReadLine());
             s.Schuss(sx,sy);
               
               
             if (s.AnzahlSchiffe() == s.AnzahlTreffer()) 
               {
                   Console.WriteLine("Spiel vorbei");
                  break;
              }
              
            
            }
             
         }
        
      static void main() 
        {
        
        }
        

    }
}
