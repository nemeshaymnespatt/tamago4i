using System;
using System.Windows;
using System.Windows.Threading;

namespace TamagotchiGame
{
    public partial class MainWindow : Window
    {
        private Pet selectedPet;
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            selectedPet = new Pet();

            // Установка таймера для обновления состояния питомца каждую секунду
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void BtnFeed_Click(object sender, RoutedEventArgs e)
        {
            selectedPet.Feed();
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            selectedPet.Play();
        }

        private void BtnClean_Click(object sender, RoutedEventArgs e)
        {
            selectedPet.Clean();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdatePetStatus();
        }

        private void UpdatePetStatus()
        {
            // Обновление состояния питомца в соответствии с его потребностями
            selectedPet.UpdateStatus();

            TxtStatus.Text = "Статус: " + selectedPet.Status;
            TxtHunger.Text = "Голод: " + selectedPet.Hunger;
            TxtHappiness.Text = "Счастье: " + selectedPet.Happiness;
            TxtCleanliness.Text = "Очистка: " + selectedPet.Cleanliness;
        }
    }

    public class Pet
    {
        public string Status { get; set; }
        public int Hunger { get; set; }
        public int Happiness { get; set; }
        public int Cleanliness { get; set; }

        public Pet()
        {
            Status = "Голод";
            Hunger = 50;
            Happiness = 50;
            Cleanliness = 50;
        }

        public void Feed()
        {
            Hunger += 10;
            Happiness += 5;
        }

        public void Play()
        {
            Hunger -= 5;
            Happiness += 10;
        }

        public void Clean()
        {
            Cleanliness += 10;
        }

        public void UpdateStatus()
        {
            Hunger -= 1;
            Happiness -= 1;
            Cleanliness -= 1;

            if (Hunger <= 0 || Happiness <= 0 || Cleanliness <= 0)
            {
                Status = "Смерть";
            }
            else if (Hunger <= 25 || Happiness <= 25 || Cleanliness <= 25)
            {
                Status = "Депрессия 1000-7";
            }
        }
    }
}