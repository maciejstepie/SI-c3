using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
|||||||||||||||||||||| Maciej Stępień       ||||||||||||||||||||||
|||||||||||||||||||||| UWM, ISI 3           ||||||||||||||||||||||
|||||||||||||||||||||| 2018r                ||||||||||||||||||||||
|||||||||||||||||||||| Sztuczna Inteligencja||||||||||||||||||||||
||||||||||||||||||||||    "Klasyfikator     ||||||||||||||||||||||
||||||||||||||||||||||        k − NN"       ||||||||||||||||||||||
||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    Kod jest nieco chaotyczny ze względu na pisanie go z ręki bez projektu.
*/



namespace DaneZPlikuOkienko
{
    public partial class DaneZPliku : Form
    {
        private string[][] systemTestowy;
        private string[][] systemTreningowy;

        List<List<double>> TestowyDouble;
        List<List<double>> TreningowyDouble;

        List<double> Klasy;
        List<List<ObiektTestowy>> ListObj;
        List<Odpowiedz> ListOdp;

        int ileKlasLiczba;
        int globalPoprawnie, globalChwyconych;
        bool afterInitialization = false;

        public struct ObiektTestowy
        {
            public double sqrt;
            public double decyzja;
            public ObiektTestowy(double s,double d)
            {
                this.sqrt = s;
                this.decyzja = d;
            }

        }

        public struct Odpowiedz
        {
            public double klasa;
            public double klasaWLiscieTestowej;
            public int wiersz;
            public Odpowiedz(int w,double k, double kk)
            {
                this.wiersz = w;
                this.klasa = k;
                this.klasaWLiscieTestowej = kk;
            }

        }
        public DaneZPliku()
        {
            InitializeComponent();
            cBox.SelectedIndex = 0;
            
        }

        private void btnWybierzSystemTestowy_Click(object sender, EventArgs e)
        {
            DialogResult wynikWyboruPliku = ofd.ShowDialog(); // wybieramy plik
            if (wynikWyboruPliku != DialogResult.OK)
                return;

            tbSciezkaDoSystemuTestowego.Text = ofd.FileName;
            string trescPliku = System.IO.File.ReadAllText(ofd.FileName); // wczytujemy treść pliku do zmiennej
            string[] wiersze = trescPliku.Trim().Split(new char[] { '\n' }); // treść pliku dzielimy wg znaku końca linii, dzięki czemu otrzymamy każdy wiersz w oddzielnej komórce tablicy
            systemTestowy = new string[wiersze.Length][];   // Tworzymy zmienną, która będzie przechowywała wczytane dane. Tablica będzie miała tyle wierszy ile wierszy było z wczytanego poliku

            for (int i = 0; i < wiersze.Length; i++)
            {
                string wiersz = wiersze[i].Trim();     // przypisuję i-ty element tablicy do zmiennej wiersz
                string[] cyfry = wiersz.Split(new char[] { ' ' });   // dzielimy wiersz po znaku spacji, dzięki czemu otrzymamy tablicę cyfry, w której każda oddzielna komórka to czyfra z wiersza
                systemTestowy[i] = new string[cyfry.Length];    // Do tablicy w której będą dane finalne dokładamy wiersz w postaci tablicy integerów tak długą jak długa jest tablica cyfry, czyli tyle ile było cyfr w jednym wierszu
                for (int j = 0; j < cyfry.Length; j++)
                {
                    string cyfra = cyfry[j].Trim(); // przypisuję j-tą cyfrę do zmiennej cyfra
                    systemTestowy[i][j] = cyfra;  
                }
            }

            tbSystemTestowy.Text = TablicaDoString(systemTestowy);
        }

        private void btnWybierzSystemTreningowy_Click(object sender, EventArgs e)
        {
            DialogResult wynikWyboruPliku = ofd.ShowDialog(); // wybieramy plik
            if (wynikWyboruPliku != DialogResult.OK)
                return;

            tbSciezkaDoSystemuTreningowego.Text = ofd.FileName;
            string trescPliku = System.IO.File.ReadAllText(ofd.FileName); // wczytujemy treść pliku do zmiennej
            string[] wiersze = trescPliku.Trim().Split(new char[] { '\n' }); // treść pliku dzielimy wg znaku końca linii, dzięki czemu otrzymamy każdy wiersz w oddzielnej komórce tablicy
            systemTreningowy = new string[wiersze.Length][];   // Tworzymy zmienną, która będzie przechowywała wczytane dane. Tablica będzie miała tyle wierszy ile wierszy było z wczytanego poliku

            for (int i = 0; i < wiersze.Length; i++)
            {
                string wiersz = wiersze[i].Trim();     // przypisuję i-ty element tablicy do zmiennej wiersz
                string[] cyfry = wiersz.Split(new char[] { ' ' });   // dzielimy wiersz po znaku spacji, dzięki czemu otrzymamy tablicę cyfry, w której każda oddzielna komórka to czyfra z wiersza
                systemTreningowy[i] = new string[cyfry.Length];    // Do tablicy w której będą dane finalne dokładamy wiersz w postaci tablicy integerów tak długą jak długa jest tablica cyfry, czyli tyle ile było cyfr w jednym wierszu
                for (int j = 0; j < cyfry.Length; j++)
                {
                    string cyfra = cyfry[j].Trim(); // przypisuję j-tą cyfrę do zmiennej cyfra
                    systemTreningowy[i][j] = cyfra;
                }
            }

            tbSystemTreningowy.Text = TablicaDoString(systemTreningowy);
        }

        public string TablicaDoString<T>(T[][] tab)
        {
            string wynik = "";
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 0; j < tab[i].Length; j++)
                {
                    wynik += tab[i][j].ToString() + " ";
                }
                wynik = wynik.Trim() + Environment.NewLine;
            }

            return wynik;
        }


        public double StringToDouble(string liczba)
        {
            double wynik; liczba = liczba.Trim();
            if (!double.TryParse(liczba.Replace(',', '.'), out wynik) && !double.TryParse(liczba.Replace('.', ','), out wynik))
                throw new Exception("Nie udało się skonwertować liczby do double");

            return wynik;
        }


        public int StringToInt(string liczba)
        {
            int wynik;
            if (!int.TryParse(liczba.Trim(), out wynik))
                throw new Exception("Nie udało się skonwertować liczby do int");

            return wynik;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Tablica z wczytanymi danymi dostępna poniżej
            // this.systemTestowy;

            // Tablica z typami atrybutów
            // this.systemTreningowy;


            //Czyszczenie
            TestowyDouble = new List<List<double>>();
            TreningowyDouble = new List<List<double>>();
            Klasy = new List<double>();
            ListObj = new List<List<ObiektTestowy>>();
            ListOdp = new List<Odpowiedz>();
            ileKlasLiczba = 0;
         
            tbWyniki.Text = "";
            globalPoprawnie = 0; globalChwyconych = 0;
            //To ponizej jest 100% dobrze napisane

            //Zamiana odrazu na double bo latwiej
            TableToList();
            ileKlasLiczba = IleKlas();


            //????
            XY();
           
            //Wyswietla wszystko
           Wyswietl();
            Tabelkowo();
        }

        void Tabelkowo()
        {
            tbWyniki.Text += Environment.NewLine;


            tbWyniki.Text += "\t";
            for (int i = 0; i < ileKlasLiczba; i++)
                tbWyniki.Text += Klasy[i] + "\t";


           
            tbWyniki.Text += "No. of obj.\tAccuracy \tCoverage" + Environment.NewLine;

                for (int i =0; i < ileKlasLiczba; i++)
            {
                double klasa = Klasy[i];
                int iloscWystepowaniaKlasy = 0;
                
               
               
                
              
               // double TPRc;

                foreach(var j in TestowyDouble)
                {
                    if(j[j.Count -1] == klasa) iloscWystepowaniaKlasy += 1;
                }
                double acc = 0;
                double cov = 0;
                double costam = 0;
                tbWyniki.Text += Klasy[i] + "\t";
                for(int k = 0;k < ileKlasLiczba; k++)
                {

                    int poprawnie = 0;
                    double poprawnieKlasa = 0;
                    
                    for (int j = 0; j < ListOdp.Count; j++)
                    {
                        int tmp = (int)xd(ListOdp[j].klasa, ListOdp[j].klasaWLiscieTestowej, Klasy[i], Klasy[k]);
                        poprawnie += tmp;
                        costam += tmp;
                        

                        if (Klasy[i] == ListOdp[j].klasa)
                        {
                            poprawnieKlasa++;
                            globalPoprawnie += tmp;
                        }
                            
                        
                    }
                    tbWyniki.Text += poprawnie + "\t";
                    acc = poprawnieKlasa / iloscWystepowaniaKlasy;
                    cov = costam / iloscWystepowaniaKlasy;
                }



                tbWyniki.Text += iloscWystepowaniaKlasy + "\t\t" + acc + "\t\t" + cov +  Environment.NewLine;
                
            }
            tbWyniki.Text += "TPR: \t";

            for (int j = 0; j < ileKlasLiczba; j++)
                tbWyniki.Text += Math.Round(ostatnia_funkcja(j),2) + "\t";

            tbWyniki.Text += Environment.NewLine + "Global acc: " + Math.Round(((double)globalPoprawnie / (double)globalChwyconych), 2) + ", Globall cov: " + ((double)globalChwyconych / (double)ListOdp.Count);
        }


        double ostatnia_funkcja(int j)
            {
                double y = 0, x = 0;
                
                    
                    double klasaPrzeszukiwana = Klasy[j];
                    for (int i = 0; i < ListOdp.Count; i++)
                    {
                        //jeszeli jest w ogole chwytany
                        if(ListOdp[i].klasaWLiscieTestowej != 99 || ListOdp[i].klasa != 99)
                {
                    //x = liczba obiektów poprawnie sklasyfikowanych w klasie decyzyjnym c
                    if (ListOdp[i].klasaWLiscieTestowej == ListOdp[i].klasa && ListOdp[i].klasa == Klasy[j] )
                        x++;


                            // y liczba obiektów z pozostałych klas błednie trafiajacych do klasy c oraz nie chwytane
                    if (ListOdp[i].klasaWLiscieTestowej != Klasy[j] && ListOdp[i].klasa == Klasy[j])
                        y++;

                }

                
                        
                        



                        
                }




                //tprc = x / ( x + y) 
                return x / (x + y);
            }
        double xd(double x1, double x2, double i, double k)
        {
            
            if (x1 == k && x2 == i) return 1;
            else return 0;
        }
        void TableToList()
        {

            foreach(var i in systemTestowy)
            {
                List<double> tmp = new List<double>();

                foreach (var j in i)
                    tmp.Add(StringToDouble(j));
                
                
                TestowyDouble.Add(tmp);
            }

            foreach (var i in systemTreningowy)
            {
                List<double> tmp = new List<double>();

                foreach (var j in i)
                    tmp.Add(StringToDouble(j));


                TreningowyDouble.Add(tmp);
            }


        }
        int IleKlas()
        {
            foreach(var i in TreningowyDouble)
            {
                double tmp = i[i.Count - 1];                
                if(!Klasy.Exists(x => x == tmp))
                {
                    Klasy.Add(tmp);
                    //tbWyniki.Text += tmp;
                }
            }
            return Klasy.Count;
        }

        void XY()
        {
            int WierszX;
            int WierszY;
            double dTmp;
            //Dla kazdego x w testowym
            

            for(WierszX = 0; WierszX < TestowyDouble.Count; WierszX++)
            {
                List<ObiektTestowy> tmp = new List<ObiektTestowy>();

                for (WierszY = 0; WierszY < TreningowyDouble.Count; WierszY++)
                {

                    dTmp = CalculateSqrt(TestowyDouble[WierszX], TreningowyDouble[WierszY],cBox.SelectedIndex);
                    if(WierszY < TreningowyDouble.Count)
                    tmp.Add(new ObiektTestowy(dTmp, TreningowyDouble[WierszY][TreningowyDouble[WierszY].Count - 1]));
                    //tbWyniki.Text += "d(" + WierszX + ", " + WierszyY + ") = " + dTmp + Environment.NewLine;
                }


                


                ListObj.Add(tmp);
                
                
            }

            //Kolejne funkcje
            A_XY1();
            
        }

        void A_XY1()
        {
            
            for (int i =0; i < ListObj.Count;i++)
            {
                if(i > 0 ) tbWyniki.Text += Environment.NewLine + Environment.NewLine;
                tbWyniki.Text +=  "Obiekt X" + i + Environment.NewLine;
                foreach (var j in ListObj[i])
                {
                    tbWyniki.Text += "decyzja: " + j.decyzja + ", sqrt(" + j.sqrt + ")" + Environment.NewLine;
                }

                //To sie wykonuje dla kazdego wiersza x, czyli fukcje ktore z tej wychodza rowniez
                if (ileKlasLiczba == 2)
                    A_XY3(A_XY2(ListObj[i]), i);
                else
                    MessageBox.Show("Narazie nie zaimplementowano dla wiecej niz 2 klas!");
            }
                
        }

        List<double> A_XY2(List<ObiektTestowy> list)

        {
            //dynamiczna ilosc klas nie tylko 2 ale tez 3 4 itd.
            List<double> lDouble = new List<double>();
            double klasa;

           
            for (int i = 0; i < ileKlasLiczba; i++)
            {
                //Dodajemy 0 na poczatek dla kazdej klasy
                lDouble.Add(0);
                tbWyniki.Text += Environment.NewLine +"W klasie ";
                klasa = Klasy[i];

                

                for(int k =0; k < XY2_1(klasa, list).Count;k++)
                
                {
                    if (k == 0) tbWyniki.Text += XY2_1(klasa, list)[k].decyzja + " glosuje";
                    lDouble[i] += XY2_1(klasa, list)[k].sqrt;
                    tbWyniki.Text += ": sqrt(" + XY2_1(klasa, list)[k].sqrt + ")";
                }
                
            }

            return lDouble;//XY3(lDouble[0], lDouble[1], X);
            

        }
        
        //Tu sie wszystko odgrywa XD
        void A_XY3(List<double> lista, int wiersz)
        {
            
            if(lista[0] == lista[1])
            {
                ListOdp.Add(new Odpowiedz(wiersz, 99, 99));
            }
            if (lista[0] > lista[1])
            {
                ListOdp.Add(new Odpowiedz(wiersz, Klasy[1] , Qua(Klasy[1], wiersz)));
            }
            if (lista[0] < lista[1])
            {
                ListOdp.Add(new Odpowiedz(wiersz, Klasy[0], Qua(Klasy[0],wiersz)));
            }

        }

        double Qua(double klasa, int wiersz)
        {
            klasa = TestowyDouble[wiersz][TestowyDouble[wiersz].Count - 1];


                return klasa;

                
        }
        List<ObiektTestowy> XY2_1(double d, List<ObiektTestowy> l1)
        {
            List<ObiektTestowy> tmp = new List<ObiektTestowy>();
            foreach(var i in l1)
            {
                if (i.decyzja == d) tmp.Add(i);
            }

            //List<Order> SortedList = objListOrder.OrderBy(o=>o.OrderDate).ToList();
            tmp = tmp.OrderBy(x => x.sqrt).ToList();
                if (tmp.Count >= 2)
                return tmp.GetRange(0, 2);
            else return tmp;

        }


        double CalculateSqrt(List<double> test,List<double> tren, int metoda)
        {
            double XY = 0;
            // 0 = eukidelsowa, 1 = Canberra , 2 = Manhattan,  3= Czebyszewa, 4 = Pearsona
            switch (metoda)
            {
                case 0:
                    for (int i = 0; i < test.Count - 1; i++)
                    {

                        double tmpPrzedPow = test[i] - tren[i];

                        XY += Math.Pow(tmpPrzedPow, 2);
                    }
                    break;
                case 1:
                    for (int i = 0; i < test.Count - 1; i++)
                    {

                        double tmpPrzedPow = (test[i] - tren[i]) / (test[i] + tren[i]);

                        XY += Math.Abs(tmpPrzedPow);
                    }
                    break;
                case 2:// do zrobienia
                    for (int i = 0; i < test.Count - 1; i++)
                    {

                        double tmpPrzedPow = test[i] - tren[i];

                        XY += Math.Pow(tmpPrzedPow, 2);
                    }
                    break;
                case 3:// do zrobienia
                    for (int i = 0; i < test.Count - 1; i++)
                    {

                        double tmpPrzedPow = test[i] - tren[i];

                        XY += Math.Pow(tmpPrzedPow, 2);
                    }
                    break;
                case 4:// do zrobienia
                    for (int i = 0; i < test.Count - 1; i++)
                    {

                        double tmpPrzedPow = test[i] - tren[i];

                        XY += Math.Pow(tmpPrzedPow, 2);
                    }
                    break;


            }

            
            //return Math.Sqrt(XY);
            return XY;
        }

        private void cBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sprawdza czy jest juz zaladowane 
            if (!afterInitialization)
            {
                afterInitialization = true;
                return;
            }
            if(cBox.SelectedIndex > 1)
            {
                cBox.SelectedIndex = 0;
                MessageBox.Show("Tej metody jeszcze nie zaimplementowano!");
            }
        }

        void Wyswietl()
        {
            tbWyniki.Text += Environment.NewLine + Environment.NewLine + Environment.NewLine;

            foreach (var i in ListOdp)
            {
                
                if (i.klasa == 99)
                {
                    tbWyniki.Text += "Obiekt X" + i.wiersz + " nie jest chwytany" + Environment.NewLine;

                }

                else {
                    tbWyniki.Text += "Obiekt X" + i.wiersz + " otrzymuje decyzje " + i.klasa;
                    globalChwyconych++;

                    if (i.klasaWLiscieTestowej == i.klasa)                    
                        tbWyniki.Text += ", skfalifikowany poprawnie. " + Environment.NewLine;                      

                    else tbWyniki.Text += ", skfalifikowany niepoprawnie jako: " + i.klasaWLiscieTestowej + Environment.NewLine;
                } 
                

            }
        }

        
    }
}
