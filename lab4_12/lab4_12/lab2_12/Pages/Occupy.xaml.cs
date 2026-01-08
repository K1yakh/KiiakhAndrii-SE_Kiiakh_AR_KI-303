using System.Windows;
using System;
using lab2_12.api.Post;
using lab2_12.Entity;

namespace lab2_12.Pages;

public partial class Occupy : Window
{
    public Patient Patient { get; set; }
    public Room Room { get; set; }

    public Occupy(Room room)
    {
        InitializeComponent();
        Patient = new Patient("");
        Room = room;
        DataContext = Patient;
    }

    private async void OccupyClick(object sender, RoutedEventArgs e)
    {
        if (Room.Capacity != 0)
        {
            try
            {
                var success = await AddPatientToRoom.Send(Patient.Name, Room.Id);
                if (success)
                {
                    MessageBox.Show("Patient successfully added to the room!");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        else
        {
            MessageBox.Show("Кімната заповнена");
        }
    }
}