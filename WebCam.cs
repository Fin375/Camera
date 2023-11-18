using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;

namespace kamera
{
    class WebCam
    {
        // gotowe odniesienia do operacji biblioteki avicap32.dll
        private const int WM_USER = 0x400;
        private const int WM_CAP = WM_USER;
        private const int WM_CAP_DRIVER_CONNECT = WM_CAP + 10;
        private const int WM_CAP_DRIVER_DISCONNECT = WM_CAP + 11;
        private const int WM_CAP_EDIT_COPY = 0x41e;
        private const int WM_CAP_SET_PREVIEW = WM_CAP + 50;
        private const int WM_CAP_SET_PREVIEWRATE = WM_CAP + 52;
        private const int WM_CAP_SET_SCALE = WM_CAP + 53;
        private const int WM_CAP_FILE_SET_CAPTURE_FILE = WM_CAP + 20;
        private const int WM_CAP_SEQUENCE = WM_CAP + 62;
        private const int WM_CAP_STOP = WM_CAP + 68;
        private const int WM_CAP_FILE_SAVEAS = WM_CAP + 23;
        private const int WM_CAP_FILE_SAVEDIB = WM_CAP + 25;
        private const int WM_CAP_DLG_VIDEOSOURCE = WM_CAP + 42;
        private const int WM_CAP_DLG_VIDEOFORMAT = WM_CAP + 41;
        private const int WM_CAP_GET_VIDEOFORMAT = WM_CAP + 60;

        private const int WS_CHILD = 0x40000000;
        private const int WS_VISIBLE = 0x10000000;
        private const short SWP_NOMOVE = 0x2;
        private short SWP_NOZORDER = 0x4;
        private short HWND_BOTTOM = 1;

        //funkcja pobierajaca informacje na temat urzadzenia rejestrujacego obraz
        [DllImport("avicap32.dll")]
        protected static extern bool capGetDriverDescriptionA(short wDriverIndex,
            [MarshalAs(UnmanagedType.VBByRefStr)]ref String lpszName,
           int cbName, [MarshalAs(UnmanagedType.VBByRefStr)] ref String lpszVer, int cbVer);

        //funkcja tworzaca okno przechwytywania obrazu wideo; zwraca uchwyt do okna przechwytujacego
        [DllImport("avicap32.dll")]
        protected static extern int capCreateCaptureWindowA([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpszWindowName,
            int dwStyle, int x, int y, int nWidth, int nHeight, int hWndParent, int nID);

        //ustawienie zmian w rozmiarze, położeniu okna podrzędnego
        [DllImport("user32")]
        protected static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        //wysłanie określonej wiadomości do okna lub okien
        [DllImport("user32", EntryPoint = "SendMessageA")]
        protected static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)] object lParam);

        //zniszczenie okna
        [DllImport("user32")]
        protected static extern bool DestroyWindow(int hwnd);

        int DeviceID = 0; // ID kamery
        int hHwnd = 0; // uchwyt do okna podglądu
        ArrayList ListOfDevices = new ArrayList(); // lista urzadzen

        public PictureBox Container { get; set; } //Obraz który ma zostać wyświetlony

        public void Load()
        {
            string Name = String.Empty.PadRight(100);
            string Version = String.Empty.PadRight(100);
            bool EndOfDeviceList = false; // czy lista urzadzen zostala juz przejrzania w calosci
            short index = 0; // indeksowanie urzadzen w liscie
            
            // załadowanie wszystkich dostępnych urzadzen do listy
            do
            {
                // porabnie nazwy i wersji urzadzenia
                EndOfDeviceList = capGetDriverDescriptionA(index, ref Name, 100, ref Version, 100);
                // jesli istnieje urzadzenie to pobierz je do listy
                if (EndOfDeviceList) ListOfDevices.Add(Name.Trim());
                index += 1;
            }
            while (!(EndOfDeviceList == false));
        }

        public struct BITMAPINFOHEADER
        {
            public uint biSize;
            public int biWidth;
            public int biHeight;
            public ushort biPlanes;
            public ushort biBitCount;
            public uint biCompression;
            public uint biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public uint biClrUsed;
            public uint biClrImportant;
        }
        // otwiera połączenie z kamerą USB
        public void OpenConnection()
        {
            string DeviceIndex = Convert.ToString(DeviceID); // Identyfikator kamery
            IntPtr oHandle = Container.Handle; // Pobierz uchwyt do kontrolki PictureBox i przypisz go do zmiennej oHandle

            // Utwórz okno potomne użyte do wyświetlania obrazu z kamery (child window)
            hHwnd = capCreateCaptureWindowA(ref DeviceIndex, WS_VISIBLE | WS_CHILD, 0, 0, Container.Width, Container.Height, oHandle.ToInt32(), 0);

            // Sprawdź, czy udało się połączyć z kamerą
            if (SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, DeviceID, 0) != 0)
            {
                // Ustawienie skali
                SendMessage(hHwnd, WM_CAP_SET_SCALE, 1, 0);

                // Ustawienie prędkości odświeżania (w milisekundach)
                SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0);

                // Rozpocznij podgląd obrazu z kamery
                SendMessage(hHwnd, WM_CAP_SET_PREVIEW, -1, 0);

                // Zmiana rozmiaru okna, żeby pasowało do pictureboxa
                SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, Container.Width, Container.Height, SWP_NOMOVE | SWP_NOZORDER);
            }
            else
            {
                // Nie udało się połączyć z kamerą
                DestroyWindow(hHwnd);
            }
   
            
        }

        public void Dispose()
        {
            CloseConnection(); // zakonczenie polaczenia z kamera
        }

         //zamkniecie okna
        void CloseConnection()
        {
            SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, DeviceID, 0); //komunikat do okna przechwytującego 
            DestroyWindow(hHwnd);
        }

        //zapisanie obrazu
        public void SaveImage()
        {
            IDataObject data;
            Image oImage; // zmienna do przechowywania obrazu
            SaveFileDialog sfdImage = new SaveFileDialog(); // obiekt pozwalający na wybór lokalizacji 
                                                            //i nazwy pliku do zapisania
            sfdImage.Filter = "(*.jpg)|*.jpg";

            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0); // kopiowanie obrazu do schowka

            // pobranie obrazu ze schowka i konwersja na bitmape
            data = Clipboard.GetDataObject(); // kopiowanie ze schowka i przypisanie do zmiennej data 
            if (data.GetDataPresent(typeof(System.Drawing.Bitmap))) // sprawdzenie czy skopiowano bitmape
            {
                oImage = (Image)data.GetData(typeof(System.Drawing.Bitmap));  // przypisanie obrazu z danych 
                                                                              //ze schowka do zmiennej oImage
                Container.Image = oImage; // ustawienie obrazu w pictureboxie


                if (sfdImage.ShowDialog() == DialogResult.OK) // wyświetla okno do zapisywania pliku 
                                                              //i sprawdza, czy użytkownik wybrał plik
                {
                    // zapisanie obrazu do wybranego pliku
                    oImage.Save(sfdImage.FileName, System.Drawing.Imaging.ImageFormat.Bmp); 
                }
                Container.Image = null; // usuwa obraz z pictureboxa
            }
        }

        public void ChangeResolution()
        {
            SendMessage(hHwnd, WM_CAP_DLG_VIDEOFORMAT, 0, 0); // zmiana ustawień formatu wideo (rozdzielczości)
        }
        public void ChangeParameters()
        {
            // zmiana parametrów jasnosc, kontrast, odcien, nasycenie, ostrosc, gamma i przeswietlenie
            SendMessage(hHwnd, WM_CAP_DLG_VIDEOSOURCE, 0, 0); 
        }

        public void StartRecord()
        {
            SendMessage(hHwnd, WM_CAP_FILE_SET_CAPTURE_FILE, 0, "UP.avi"); // ustawia plik do którego będą zapisywane obrazy (0 oznacza domyslny plik nagrania)
            SendMessage(hHwnd, WM_CAP_SEQUENCE, 0, 0); // rozpoczęcie rejestrowania sekwencji klatek
        }

        public void StopRecord()
        {
            SendMessage(hHwnd, WM_CAP_STOP, 0, 0); // zatrzymanie nagrania
            SendMessage(hHwnd, WM_CAP_FILE_SAVEAS, 0, "UP.avi"); // zapisanie nagrania do pliku 
        }



        /// <summary>
        /// czesc przeznaczona na wykrycie detekcji ruchu
        /// </summary>
        private Bitmap previousFrame = null; // Przechowuje poprzednią klatkę obrazu (do wykrycia ruchu)
        private bool motionDetected = false; // Flaga wskazująca, czy wykryto ruch 

        public void ProcessFrame(Bitmap currentFrame)
        {
            if (previousFrame != null)
            {
                motionDetected = CompareFrames(previousFrame, currentFrame);
            }

              previousFrame = currentFrame;
        }
        public Bitmap getPreviousFrame()
        {
            return previousFrame;
        }
        public void setPreviousFrame(Bitmap currentFrame)
        {
            previousFrame = currentFrame;
        }

        public bool CompareFrames(Bitmap previousFrame, Bitmap currentFrame)
        {
            // porównaj piksele i jeśli różnica jest większa niż pewna wartość, uznaj to za ruch

            int threshold = 30; // Próg różnicy pikseli (do ustalenia jaki)
            for (int x = 0; x < currentFrame.Width; x++)
            {
                for (int y = 0; y < currentFrame.Height; y++)
                {
                    Color previousPixel = previousFrame.GetPixel(x, y);
                    Color currentPixel = currentFrame.GetPixel(x, y);

                    int diff = Math.Abs(previousPixel.R - currentPixel.R) +
                               Math.Abs(previousPixel.G - currentPixel.G) +
                               Math.Abs(previousPixel.B - currentPixel.B);

                    if (diff > threshold)
                    {
                        return true; // Jeśli wykryto ruch, zwróć true 
                    }
                }
            }

            return false;
        }

        public bool MotionDetected()
        {
            return motionDetected;
        }
    }


}
