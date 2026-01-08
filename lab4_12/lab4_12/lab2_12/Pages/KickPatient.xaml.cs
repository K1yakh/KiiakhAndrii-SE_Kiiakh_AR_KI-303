using System;
using System.Collections.ObjectModel;
using System.Windows;
using lab2_12.api.Get;
using lab2_12.api.Post;
using lab2_12.Entity;

namespace lab2_12.Pages
{
    public partial class KickPatient : Window
    {
        public ObservableCollection<Patient> Patients { get; set; }
        public Room Room { get; set; }

        public KickPatient(Room room)
        {
            InitializeComponent();
            Room = room;
            Patients = new ObservableCollection<Patient>();
            GetPatientsFromServer();

            DataContext = this;
        }

        private async void KickPatient_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as FrameworkElement;
            var patient = button?.DataContext as Patient;

            if (patient == null) return;
            var success = await KickPatientFromRoom.Send(Room.Id, patient.Id);
            if (success)
            {
                Close();
            }
        }

        private async void GetPatientsFromServer()
        {
            var (success, patients) = await GetPatientsFromRoom.Send(Room.Id);
            if (success)
            {
                Patients.Clear();
                foreach (var patient in patients)
                {
                    Patients.Add(patient);
                }
            }
        }
    }
}