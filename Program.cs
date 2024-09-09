namespace ikt1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1.
            int[] szamok = args.Select(Int32.Parse).ToArray();

            if (szamok.Length < 3 || szamok.Length % 2 == 0)
            {
                Console.Error.WriteLine("Nem megfelelő argumentumszám!");
                Environment.Exit(1);
            }

            int kozepsoIndex = szamok.Length / 2;
            int y = Math.Max(szamok[kozepsoIndex - 1], szamok[kozepsoIndex + 1]) / Math.Min(szamok[kozepsoIndex - 1], szamok[kozepsoIndex + 1]);
            Console.WriteLine($"Eredmény: {Math.Pow(szamok[kozepsoIndex], y)}");

            //2.
            char[] MAGANHANGZOK = ['a', 'e', 'i', 'o', 'u'];

            string[] szavak = File.ReadAllLines("szavak.txt");
            int[] szotagok = szavak.Select(word => word.ToLower().Count(character => MAGANHANGZOK.Contains(character))).ToArray();
            Console.WriteLine($"\nA több, mint négy szótagból álló szavak száma: {szotagok.Count(x => x > 4)}");
            Console.WriteLine($"A legnagyobb szótagszám: {szotagok.Max()}\n");

            //3.
            const int MATRIX_MERET = 6;
            Random r = new(33);

            int[,] matrix = new int[MATRIX_MERET, MATRIX_MERET];
            double osszeg = 0;
            for (int i = 0; i < MATRIX_MERET; i++)
            {
                for (int j = 0; j < MATRIX_MERET; j++)
                {
                    matrix[i, j] = r.Next(55, 156);
                    Console.Write(matrix[i, j].ToString().PadLeft(3) + " ");

                    if (i == 0 || i == MATRIX_MERET - 1 || j == 0 || j == MATRIX_MERET - 1)
                    {
                        osszeg += matrix[i, j];
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"A szélső elemek átlaga: {osszeg / ((MATRIX_MERET + MATRIX_MERET - 2) * 2)}");

            //4.
            Pixel[] pixelek = File.ReadAllLines("kep.txt").Select(x => new Pixel(x)).ToArray();
            pixelek.Where(x => x.szinek[2] < 100).ToList().ForEach(x => x.szinek[2] = Math.Min(x.szinek[2] + 20, 255));
            File.WriteAllLines("kekitett.txt", pixelek.Select(x => x.ToString()));
            Console.WriteLine("\n#Kész!");

        }

        class Pixel(string sor)
        {
            public int[] szinek = sor.Split(';').Select(Int32.Parse).ToArray();

            public override string ToString() => string.Join(";", szinek);
        }
    }
}
