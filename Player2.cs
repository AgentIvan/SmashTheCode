//not finished improvement
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Player
{
    static void Main(string[] args)
    {

        // game loop
        while (true)
        {
            int[] cAs = new int[8];
            int[] cBs = new int[8];
            int[] col = new int[6];
            List<int>[]  a = new List<int>[6];
            for (int i = 0; i < a.Length; i++)
                a[i] = new List<int>();
                
            for (int i = 0; i < 8; i++)
            {
                string input =  Console.ReadLine();
                string[] inputs = input.Split(' ');
                cAs[i] = int.Parse(inputs[0]); // color of the first block
                cBs[i] = int.Parse(inputs[1]); // color of the attached block
                col[cAs[i]]++;
                col[cBs[i]]++;
                Console.Error.WriteLine("colorA B:{0} ", input);
            }
            Console.Error.WriteLine("maxCol:{0} ", col.Max());
            string[] rows = new string[12];
            for (int i = 0; i < 12; i++)
            {
                rows[i] = Console.ReadLine();
                if(rows[i]!="......")
                for (int j = 0; j < 6; j++)
                {
                    Console.Error.Write(rows[i][j]);
                    if(rows[i][j]!='.') a[j].Add(Int32.Parse(rows[i][j].ToString()));
                }
                Console.Error.WriteLine();
            }
            for (int i = 0; i < 12; i++)
            {
                string row = Console.ReadLine(); // One line of the map ('.' = empty, '0' = skull block, '1' to '5' = colored block)
                // Console.Error.WriteLine("row2:"+row);
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            int[] ar = new int[6];
            for(int i=0; i<6; i++)
            {
                ar[i]=7;
                if(a[i].Count!=0&&a[i].First()==cAs[0]) ar[i]=cAs[0];
                if(a[i].Count!=0&&a[i].First()==cBs[0]) ar[i]=cBs[0];
            }
            bool b = false;
            // List<Tuple<int, int>> possible = new List<Tuple<int, int>>();
            int[,] pos = new int[6,4];// cAs[0].Cost cBs[0].Cost
            
            for(int i=0; i<6; i++)
            {
                int m = a[i].Count+1;
                if(m<12)
                {
                    if(m>1&&a[i][0]==cAs[0]) pos[i,0]++;
                    if(m>1&&a[i][0]==cBs[0]) pos[i,1]++;
                    
                    if(i>0&&a[i-1].Count>m-1&&a[i-1][a[i-1].Count-m]==cAs[0]) pos[i,0]++;
                    if(i>0&&a[i-1].Count>m-1&&a[i-1][a[i-1].Count-m]==cBs[0]) pos[i,1]++;
                    if(i>0&&a[i-1].Count>m&&a[i-1][a[i-1].Count-m-1]==cAs[0]) pos[i,3]++;
                    if(i>0&&a[i-1].Count>m&&a[i-1][a[i-1].Count-m-1]==cBs[0]) pos[i,4]++;
                    
                    if(i<5&&a[i+1].Count>m-1&&a[i+1][a[i+1].Count-m]==cAs[0]) pos[i,0]++;
                    if(i<5&&a[i+1].Count>m-1&&a[i+1][a[i+1].Count-m]==cBs[0]) pos[i,1]++;
                    if(i<5&&a[i+1].Count>m&&a[i+1][a[i+1].Count-m-1]==cAs[0]) pos[i,3]++;
                    if(i<5&&a[i+1].Count>m&&a[i+1][a[i+1].Count-m-1]==cBs[0]) pos[i,4]++;
                }
                Console.Error.WriteLine("pos[i,(a:{4},b:{5})]: {0} {1} {2} {3}", pos[i,0], pos[i,1], pos[i,2], pos[i,3], cAs[0], cBs[0]);
            }
            int[,] bal = new int[6,4];
            for(int i=0; i<6; i++)
                for(int j=0; j<4; j++)
                {
                    bal[i,j] = pos[i,j];
                }

                // if(max<pos[i,j])
                // {
                //     max=pos[i,j];
                //     mi=i;
                //     mj=j;
                // }                
            int max=0, mi, mj, rot;
            // if(mj==0) Console.WriteLine("{0} {1}", mi, 1);
            // if(mj==2) Console.WriteLine("{0} {1}", mi, 3);
            for(int i=0; i<6; i++)
            {
                if(a[i].Count<10)
                {
                    if(a[i].Count==0||i<5&&a[i].First()==0&&a[i+1].First()==0)
                    {
                        if(i<5&&a[i+1].Count<10)
                        {
                            Console.WriteLine("{0} {1}", i, 0);
                        }
                        else
                            Console.WriteLine("{0} {1}", i, 1);
                        b = true;
                        break;
                    }
                    else
                    {
                        if(a[i].First()==cBs[0])
                        {
                            Console.WriteLine("{0} {1}", i, 3); // "x": the column in which to drop your blocks
                            b = true;
                            break;
                        }
                        if(a[i].First()==cAs[0])
                        {
                            if(i>0&&(a[i-1].Count<10&&a[i-1][0]==cBs[0]))
                            {
                                Console.WriteLine("{0} {1}", i, 2);
                                b = true;
                                break;
                            }
                            else if(i<5&&(a[i+1].Count==0||(a[i+1].Count<10&&a[i+1][0]==cBs[0])))
                            {
                                Console.WriteLine("{0} {1}", i, 0);
                                b = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("{0} {1}", i, 1);
                                b = true;
                                break;
                            }
                        }
                    }
                }
            }//*/
            if(!b)
            {
                for(int i=0; i<6; i++)
                {
                    if(a[i].Count<11)
                    {
                        Console.WriteLine("{0} {1}", i, 1);
                        break;
                    }
                }
            }
        }
    }
}
